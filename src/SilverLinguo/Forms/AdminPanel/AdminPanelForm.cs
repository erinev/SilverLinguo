using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Extensions;
using SilverLinguo.Repositories;
using SilverLinguo.Repositories.Models;
using SilverLinguo.Services;

namespace SilverLinguo.Forms.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        private readonly IWordsService _wordsService;

        private readonly BindingSource _allWordsBindingSource;

        public AdminPanelForm()
        {
            _wordsService = new WordsService();

            _allWordsBindingSource = new BindingSource();

            InitializeComponent();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            List<WordPair> allWords = _wordsService.GetAllWords(shouldShuffle: false).ToList();

            _allWordsBindingSource.DataSource = allWords;

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

                string firstLanguageWord = editingRow.Cells[0].EditedFormattedValue.ToString();
                string secondLanguageWord = editingRow.Cells[1].EditedFormattedValue.ToString();

                var currentWords = (IEnumerable<WordPair>) _allWordsBindingSource.DataSource;
                var currentWordsExcludingNewlyAddedWord = currentWords.WithoutLast();

                bool wordAlreadyExits = currentWordsExcludingNewlyAddedWord.Any(w => 
                    _wordsService.CheckIfWordsMatches(w.FirstLanguageWord, firstLanguageWord) &&
                    _wordsService.CheckIfWordsMatches(w.SecondLanguageWord, secondLanguageWord));

                if (wordAlreadyExits)
                {
                    AllWordsDataGridView.Rows[e.RowIndex].ErrorText =
                        "Tokia žodžių pora jau egzistuoja!";
                    e.Cancel = true;
                }
            }
        }

        private void AllWordsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AllWordsDataGridView.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}
