using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Repositories;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Forms.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        private readonly BindingSource _allWordsBindingSource;

        public AdminPanelForm()
        {
            _allWordsBindingSource = new BindingSource();

            InitializeComponent();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            var wordsRepository = new WordsRepository();

            List<WordPair> allWords = wordsRepository.GetAllWords().ToList();

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

        private void AllWordsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
