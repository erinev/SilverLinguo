using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Dto;
using SilverLinguo.Repositories;
using SilverLinguo.Repositories.Models;
using SilverLinguo.Services;

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

        private void ReintializeDatabaseButton_Click(object sender, EventArgs e)
        {
            var wordsRepository = new WordsRepository();

            wordsRepository.ReinitializeAllTables();
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

        private void AllWordsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AllWordsDataGridView.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}
