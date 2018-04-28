using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        private void GoBackToStartupFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            var startupForm = new StartupForm();

            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
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

                var dirtyRowUuidValue = editingRow.Cells[_dirtyRowUuidCellIndex].EditedFormattedValue;

                if (string.IsNullOrWhiteSpace(dirtyRowUuidValue.ToString()) || Guid.Empty.ToString() == dirtyRowUuidValue.ToString())
                {
                    editingRow.Cells[_dirtyRowUuidCellIndex].Value = Guid.NewGuid();
                }

                int wordPairId = Int32.Parse(editingRow.Cells[_wordPairIdCellIndex].EditedFormattedValue.ToString());

                Guid dirtyRowIdentifier = Guid.Parse(editingRow.Cells[_dirtyRowUuidCellIndex].EditedFormattedValue.ToString());

                string firstLanguageWord = editingRow.Cells[_firstLanguageWordCellIndex].EditedFormattedValue.ToString();
                string secondLanguageWord = editingRow.Cells[_secondLanguageWordCellIndex].EditedFormattedValue.ToString();

                var currentWords = (IEnumerable<WordPairForDataGridView>) _allWordsBindingSource.DataSource;

                bool atLeastOneCellIsEmpty = CheckIfRowContainsEmptyCells(firstLanguageWord, secondLanguageWord);
                if (atLeastOneCellIsEmpty)
                {
                    AllWordsDataGridView.Rows[e.RowIndex].ErrorText = "Žodis negali būti tusčia reikšmė!";
                    e.Cancel = true;
                    return;
                }

                bool wordPairAlreadyExits = 
                    CheckIfWordAlreadyExists(wordPairId, currentWords, firstLanguageWord, secondLanguageWord, dirtyRowIdentifier);

                if (wordPairAlreadyExits)
                {
                    AllWordsDataGridView.Rows[e.RowIndex].ErrorText = "Tokia žodžių pora jau egzistuoja!";
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

        private void ReloadAllWordsToDataGridView()
        {
            List<WordPair> allWords = _wordsService.GetAllWords(shouldShuffle: false).ToList();

            List<WordPairForDataGridView> allWordsForDataGridView = MapToDataGridViewStructure(allWords);

            _allWordsBindingSource.DataSource = allWordsForDataGridView;
        }

        private bool CheckIfWordAlreadyExists(int wordPairId, IEnumerable<WordPairForDataGridView> currentWords, string firstLanguageWord,
            string secondLanguageWord, Guid dirtyRowIdentifier)
        {
            bool wordPairAlreadyExits;

            if (wordPairId > 0)
            {
                IEnumerable<WordPairForDataGridView> wordsListExcludingCurrentlyEditingWord =
                    currentWords.Where(w => w.Id != wordPairId);

                wordPairAlreadyExits =
                    WordPairAlreadyExits(wordsListExcludingCurrentlyEditingWord, firstLanguageWord, secondLanguageWord);
            }
            else
            {
                IEnumerable<WordPairForDataGridView> currentWordsExcludingNewlyAddedWord =
                    currentWords.Where(w => w.DirtyRowUuid != dirtyRowIdentifier);

                wordPairAlreadyExits =
                    WordPairAlreadyExits(currentWordsExcludingNewlyAddedWord, firstLanguageWord, secondLanguageWord);
            }

            return wordPairAlreadyExits;
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

        private bool WordPairAlreadyExits(IEnumerable<WordPairForDataGridView> wordsListExcludingCurrentlyEditingWord,
            string firstLanguageWord, string secondLanguageWord)
        {
            bool wordPairAlreadyExits = wordsListExcludingCurrentlyEditingWord.Any(w =>
                _wordsService.CheckIfWordsMatches(w.FirstLanguageWord, firstLanguageWord) &&
                _wordsService.CheckIfWordsMatches(w.SecondLanguageWord, secondLanguageWord));

            return wordPairAlreadyExits;
        }
    }
}
