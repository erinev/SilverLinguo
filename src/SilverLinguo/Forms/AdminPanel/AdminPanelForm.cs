using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Constants;
using SilverLinguo.Dto;
using SilverLinguo.Repositories.Models;
using SilverLinguo.Services;
using SilverLinguo.Services.Form;

namespace SilverLinguo.Forms.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        private readonly IWordsService _wordsService;

        private readonly BindingSource _allWordsBindingSource;

        private int _wordPairIdCellIndex = 0;
        private int _firstLanguageWordCellIndex = 1;
        private int _dirtyRowUuidCellIndex = 2;
        private int _secondLanguageWordCellIndex = 3;

        private readonly List<WordPairForDataGridView> _wordsToDeleteOnSave = new List<WordPairForDataGridView>();

        private InputLanguage _originalInputLanguage = InputLanguage.DefaultInputLanguage;
        private readonly string _allWordsTabTagValue = "1";

        public AdminPanelForm()
        {
            _wordsService = new WordsService();

            _allWordsBindingSource = new BindingSource();

            InitializeComponent();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            List<WordPair> allWords = _wordsService.GetAllWords(shouldShuffle: false).ToList();

            List<WordPairForDataGridView> allWordsForDataGridView = MapToDataGridViewStructure(allWords);

            _allWordsBindingSource.DataSource = allWordsForDataGridView;

            AllWordsDataGridView.DataSource = _allWordsBindingSource;
        }

        private void AdminPanelForm_Shown(object sender, EventArgs e)
        {
            ConfigureInputLanguageForTest();
        }

        private void AdminPanelTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Tag.ToString() == _allWordsTabTagValue)
            {
                ConfigureInputLanguageForTest();
            }
            else
            {
                InputLanguage.CurrentInputLanguage = _originalInputLanguage;
            }
        }

        private void AdminPanelForm_KeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            bool allWordsTabSelected = AdminPanelTabControl.SelectedTab.Tag.ToString() == _allWordsTabTagValue;

            if (keyEventArgs.KeyValue == KeyCodes.Enter)
            {
                if (allWordsTabSelected)
                {
                    HandleSearchAllWordsButtonClickedEvent();

                    keyEventArgs.Handled = true;
                }
            } 
            /*else if (keyEventArgs.KeyValue == KeyCodes.SomeOtherKey) //TODO: Backspace is used for deleting while typing
            {
                if (allWordsTabSelected)
                {
                    if (ClearAllWordsSearchButton.Enabled)
                    {
                        HandleClearAllWordsSearchButtonClickedEvent();
                    }
                    
                    keyEventArgs.Handled = true;
                }
            }*/
        }

        private void GoBackToStartupFormButton_Click(object sender, EventArgs e)
        {
            CommonFormService.ShowConfirmAction(
                "Grįžti atgal",
                "Ar tikrai norite grįžti į pradžios formą ? (neišaugoti pakeitimai bus atšaukti)",
                () =>
                {
                    this.Hide();

                    var startupForm = new StartupForm();

                    startupForm.Closed += (s, args) => this.Close();

                    startupForm.Show();
                });
        }

        private void AllWordsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (AllWordsDataGridView.IsCurrentRowDirty)
            {
                DataGridViewRow editingRow = AllWordsDataGridView.Rows[e.RowIndex];

                DataGridViewCell firstLanguageWordCell = editingRow.Cells[_firstLanguageWordCellIndex];
                DataGridViewCell secondLanguageWordCell = editingRow.Cells[_secondLanguageWordCellIndex];

                string initialFirstLanguageWord = firstLanguageWordCell.EditedFormattedValue.ToString();
                string initialSecondLanguageWord = secondLanguageWordCell.EditedFormattedValue.ToString();

                var dirtyRowUuidValue = editingRow.Cells[_dirtyRowUuidCellIndex].EditedFormattedValue;

                if (string.IsNullOrWhiteSpace(dirtyRowUuidValue.ToString()) ||
                    Guid.Empty.ToString() == dirtyRowUuidValue.ToString())
                {
                    editingRow.Cells[_dirtyRowUuidCellIndex].Value = Guid.NewGuid();
                }

                int wordPairId = Int32.Parse(editingRow.Cells[_wordPairIdCellIndex].EditedFormattedValue.ToString());

                Guid dirtyRowIdentifier = Guid.Parse(editingRow.Cells[_dirtyRowUuidCellIndex].EditedFormattedValue.ToString());

                var currentWords = (IEnumerable<WordPairForDataGridView>) _allWordsBindingSource.DataSource;

                if (string.IsNullOrEmpty(firstLanguageWordCell.EditedFormattedValue.ToString()) &&
                    !string.IsNullOrEmpty(initialFirstLanguageWord))
                {
                    // somehow cell value is wiped after i set _dirtyRowUuidCell value in few lines above
                    // so restoring to initial entered value
                    firstLanguageWordCell.Value = initialFirstLanguageWord;
                }
                if (string.IsNullOrEmpty(secondLanguageWordCell.EditedFormattedValue.ToString()) && 
                         !string.IsNullOrEmpty(initialSecondLanguageWord))
                {
                    // somehow cell value is wiped after i set _dirtyRowUuidCell value in few lines above
                    // so restoring to initial entered value
                    secondLanguageWordCell.Value = initialSecondLanguageWord;
                }

                string firstLanguageWord = firstLanguageWordCell.EditedFormattedValue.ToString();
                string secondLanguageWord = secondLanguageWordCell.EditedFormattedValue.ToString();

                DuplicateWord duplicateWord =
                    CheckIfWordAlreadyExists(wordPairId, currentWords, firstLanguageWord, secondLanguageWord, dirtyRowIdentifier);

                if (duplicateWord.WordAlreadyExist)
                {
                    AllWordsDataGridView.Rows[e.RowIndex].ErrorText = $"Žodis '{duplicateWord.DuplicateWordValue}' jau egzistuoja!";
                    e.Cancel = true;
                }
            }
        }

        private void AllWordsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AllWordsDataGridView.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void AllWordsDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (AllWordsDataGridView.IsCurrentRowDirty)
            {
                DataGridViewRow editingRow = AllWordsDataGridView.Rows[e.RowIndex];

                string firstLanguageWord = editingRow.Cells[_firstLanguageWordCellIndex].EditedFormattedValue.ToString();
                string secondLanguageWord = editingRow.Cells[_secondLanguageWordCellIndex].EditedFormattedValue.ToString();

                bool atLeastOneCellIsEmpty = CheckIfRowContainsEmptyCells(firstLanguageWord, secondLanguageWord);
                if (atLeastOneCellIsEmpty)
                {
                    AllWordsDataGridView.Rows[e.RowIndex].ErrorText = "Žodis negali būti tusčia reikšmė!";
                    e.Cancel = true;
                }
            }
        }

        private void AllWordsDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int deletedWordPairId = Int32.Parse(e.Row.Cells[_wordPairIdCellIndex].EditedFormattedValue.ToString());

            if (deletedWordPairId > 0)
            {
                var currentWords = (IEnumerable<WordPairForDataGridView>) _allWordsBindingSource.DataSource;

                _wordsToDeleteOnSave.Add(currentWords.First(w => w.Id == deletedWordPairId));
            }
        }

        private void SearchAllWordsButton_Click(object sender, EventArgs e)
        {
            HandleSearchAllWordsButtonClickedEvent();
        }

        private void ClearAllWordsSearchButton_Click(object sender, EventArgs e)
        {
            HandleClearAllWordsSearchButtonClickedEvent();
        }

        private void ReloadAllWordsGridViewButton_Click(object sender, EventArgs e)
        {
            CommonFormService.ShowConfirmAction(
                "Atstatyti žodžius",
                "Ar tikrai norite atstatyti žodžius iš duomenų bazės ? (neišaugoti pakeitimai bus atšaukti)",
                () =>
                {
                    ReloadAllWordsToDataGridView();

                    _wordsToDeleteOnSave.Clear();
                });
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            CommonFormService.ShowConfirmAction(
                "Išsaugoti pakeitimus",
                "Ar tikrai norite išsaugoti pakeitimus ? (ištrinti žodžiai nus pašalinti iš duomenų bazės)",
                () =>
                {
                    bool anyChangesPerssisted = false;

                    DateTime currentDateTime = DateTime.Now;

                    var currentWords = (IEnumerable<WordPairForDataGridView>) _allWordsBindingSource.DataSource;
                    List<WordPairForDataGridView> currentWordsList = currentWords.ToList();

                    List<WordPairForDataGridView> wordsToDelete = _wordsToDeleteOnSave;
                    if (wordsToDelete.Any())
                    {
                        _wordsService.RemoveWordsDeletedInAdminPanel(wordsToDelete);
                        anyChangesPerssisted = true;
                        _wordsToDeleteOnSave.Clear();
                    }
                    
                    List<WordPairForDataGridView> modifiedWordPairs = 
                        currentWordsList.Where(w => w.DirtyRowUuid != Guid.Empty && w.Id > 0).ToList();
                    if (modifiedWordPairs.Any())
                    {
                        _wordsService.UpdatedWordsChangedInAdminPanel(modifiedWordPairs, currentDateTime);
                        anyChangesPerssisted = true;

                    }
                    
                    List<WordPairForDataGridView> newWords = 
                        currentWordsList.Where(w => w.DirtyRowUuid != Guid.Empty && w.Id <= 0).ToList();
                    if (newWords.Any())
                    {
                        _wordsService.SaveWordsNewlyAddedInAdminPanel(newWords, currentDateTime);
                        anyChangesPerssisted = true;
                    }

                    if (anyChangesPerssisted)
                    {
                        ReloadAllWordsToDataGridView();
                    }
                });
        }

        private void HandleSearchAllWordsButtonClickedEvent()
        {
            string searchText = AllWordsSearchTextBox.Text;

            if (string.IsNullOrWhiteSpace(searchText)) return;

            CommonFormService.ShowConfirmAction(
                "Žodžio paieška",
                "Ar tikrai norite ieškoti žodžio ? (neišaugoti pakeitimai bus atšaukti)",
                () =>
                {
                    ClearAllWordsSearchButton.Visible = true;

                    var searchCriteria = new QueryCriteria
                    {
                        SearchText = searchText
                    };

                    var allWordsThatMatchedSearchCriteria =
                        _wordsService.GetAllWords(shouldShuffle: false, queryCriteria: searchCriteria).ToList();

                    List<WordPairForDataGridView> allWordsForDataGridView =
                        MapToDataGridViewStructure(allWordsThatMatchedSearchCriteria);

                    _allWordsBindingSource.DataSource = allWordsForDataGridView;
                });
        }

        private void HandleClearAllWordsSearchButtonClickedEvent()
        {
            CommonFormService.ShowConfirmAction(
                "Atšaukti paieška",
                "Ar tikrai norite atšaukti paieška ir užkrauti visus žodžius ? (neišaugoti pakeitimai bus atšaukti)",
                () =>
                {
                    var allWords = _wordsService.GetAllWords(shouldShuffle: false).ToList();

                    List<WordPairForDataGridView> allWordsForDataGridView = MapToDataGridViewStructure(allWords);

                    _allWordsBindingSource.DataSource = allWordsForDataGridView;

                    AllWordsSearchTextBox.Text = string.Empty;

                    ClearAllWordsSearchButton.Visible = false;
                });
        }

        private void ReloadAllWordsToDataGridView()
        {
            List<WordPair> allWords = _wordsService.GetAllWords(shouldShuffle: false).ToList();

            List<WordPairForDataGridView> allWordsForDataGridView = MapToDataGridViewStructure(allWords);

            _allWordsBindingSource.DataSource = allWordsForDataGridView;
        }

        private void ConfigureInputLanguageForTest()
        {
            _originalInputLanguage = InputLanguage.CurrentInputLanguage;

            try
            {
                CultureInfo lithuanianCultureInfo = CultureInfo.GetCultureInfo("lt-LT");
                InputLanguage lithuanianLanguage = InputLanguage.FromCulture(lithuanianCultureInfo);

                InputLanguage.CurrentInputLanguage =
                    // ReSharper disable once AssignNullToNotNullAttribute
                    InputLanguage.InstalledInputLanguages.IndexOf(lithuanianLanguage) >= 0
                        ? lithuanianLanguage
                        : _originalInputLanguage;

            }
            catch (Exception)
            {
                InputLanguage.CurrentInputLanguage = _originalInputLanguage;
            }
        }

        private DuplicateWord CheckIfWordAlreadyExists(int wordPairId, IEnumerable<WordPairForDataGridView> currentWords, 
            string firstLanguageWord, string secondLanguageWord, Guid dirtyRowIdentifier)
        {
            DuplicateWord duplicateWord;

            if (wordPairId > 0)
            {
                IEnumerable<WordPairForDataGridView> wordsListExcludingCurrentlyEditingWord =
                    currentWords.Where(w => w.Id != wordPairId);

                duplicateWord =
                    WordPairAlreadyExits(wordsListExcludingCurrentlyEditingWord, firstLanguageWord, secondLanguageWord);
            }
            else
            {
                IEnumerable<WordPairForDataGridView> currentWordsExcludingNewlyAddedWord =
                    currentWords.Where(w => w.DirtyRowUuid != dirtyRowIdentifier);

                duplicateWord =
                    WordPairAlreadyExits(currentWordsExcludingNewlyAddedWord, firstLanguageWord, secondLanguageWord);
            }

            return duplicateWord;
        }

        private bool CheckIfRowContainsEmptyCells(string firstLanguageWord, string secondLanguageWord)
        {
            return String.IsNullOrWhiteSpace(firstLanguageWord) || String.IsNullOrWhiteSpace(secondLanguageWord);
        }

        private List<WordPairForDataGridView> MapToDataGridViewStructure(List<WordPair> allWords)
        {
            return allWords.Select(aw => new WordPairForDataGridView()
            {
                Id = aw.Id,
                FirstLanguageWord = aw.FirstLanguageWord,
                SecondLanguageWord = aw.SecondLanguageWord,
                LanguagePair = aw.LanguagePair,
                CreatedAt = aw.CreatedAt,
                ModifiedAt = aw.ModifiedAt
            }).ToList();
        }

        private DuplicateWord WordPairAlreadyExits(IEnumerable<WordPairForDataGridView> wordsListExcludingCurrentlyEditingWord,
            string firstLanguageWord, string secondLanguageWord)
        {
            var duplicateWord = new DuplicateWord
            {
                WordAlreadyExist = false
            };

            foreach (var word in wordsListExcludingCurrentlyEditingWord)
            {
                bool firstLanguageWordAlreadyExist = _wordsService.CheckIfWordsMatches(word.FirstLanguageWord, firstLanguageWord);
                bool secondLanguageWordAlreadyExist = _wordsService.CheckIfWordsMatches(word.SecondLanguageWord, secondLanguageWord);

                if (firstLanguageWordAlreadyExist || secondLanguageWordAlreadyExist)
                {
                    duplicateWord.WordAlreadyExist = true;

                    duplicateWord.DuplicateWordValue = firstLanguageWordAlreadyExist ? firstLanguageWord : secondLanguageWord;
                    
                    break;
                }
            }

            return duplicateWord;
        }
    }
}
