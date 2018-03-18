using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Models;
using Silverio.Žodynas.Services;

namespace Silverio.Žodynas
{
    public partial class UnknownWordsGrammarTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private static SelectedLanguage _selectedLanguage;

        private static int _currentUnknownWordPairId;

        private static WordPair[] _unknownWords;
        private static IList<WordPair> _learnedWords = new List<WordPair>();

        public UnknownWordsGrammarTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();

            SetSelectedLanguage(selectedLanguage);
        }

        private void UnknownWordsGrammarTestForm_Load(object sender, System.EventArgs e)
        {
            _unknownWords = _wordsService.GetRandomlySortedUnknownWords();

            _currentUnknownWordPairId = _unknownWords[0].Id;

            ProgressLabel.Text = _unknownWords.Length.ToString();

            WordPair firstUnknownWord = _unknownWords.First();
            LtWordTextBox.Text = LtWordTextBox.ReadOnly ? firstUnknownWord.LithuanianWord : String.Empty;
            EnWordTextBox.Text = EnWordTextBox.ReadOnly ? firstUnknownWord.EnglishWord : String.Empty;
        }

        private void UnknownWordsGrammarTestForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Form.KeyPress: '" +
                                e.KeyChar.ToString() + "' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show("Form.KeyPress: '" +
                                        e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }

        private void ShowLearnedWordsButton_Click(object sender, EventArgs e)
        {
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.LithuanianWord + " - " + learnedWord.EnglishWord).ToList();

            var showWordsListByTypeForm = new ShowWordsListByTypeForm(learnedWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void EndTestButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void SetSelectedLanguage(SelectedLanguage selectedLanguage)
        {
            switch (selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    LtWordTextBox.ReadOnly = false;
                    EnWordTextBox.ReadOnly = true;
                    break;
                case SelectedLanguage.English:
                    LtWordTextBox.ReadOnly = true;
                    EnWordTextBox.ReadOnly = false;
                    break;
                default:
                    LtWordTextBox.ReadOnly = false;
                    EnWordTextBox.ReadOnly = true;
                    break;
            }
        }
    }
}
