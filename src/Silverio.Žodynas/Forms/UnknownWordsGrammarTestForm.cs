using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Silverio.Žodynas.Constants;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Models;
using Silverio.Žodynas.Services;

namespace Silverio.Žodynas.Forms
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
            if (e.KeyChar == KeyCodes.Space)
            {
                if (NextWordButton.Visible)
                {
                    HandleNextWordEvent();
                }

                e.Handled = true;
            }
            else if (e.KeyChar == KeyCodes.Enter)
            {
                AssertAndHandleEnteredWord();

                e.Handled = true;
            }
            /*else if (e.KeyChar == KeyCodes.Backspace)
            {
                e.Handled = true;
            }*/
        }

        private void AssertAndHandleEnteredWord()
        {
            bool isLtWordReadOnly = LtWordTextBox.ReadOnly;
            bool isEnWordReadOnly = EnWordTextBox.ReadOnly;

            var currentWordPair = _unknownWords.First(unknownWord => unknownWord.Id == _currentUnknownWordPairId);

            if (!isEnWordReadOnly)
            {
                bool isEqual = EnWordTextBox.Text == currentWordPair.EnglishWord;
                EnWordTextBox.BackColor = isEqual ? Color.LightGreen : Color.LightCoral;

            }
            else if (!isLtWordReadOnly)
            {
                bool isEqual = LtWordTextBox.Text == currentWordPair.LithuanianWord;
                if (isEqual)
                {
                    LtWordTextBox.BackColor = Color.LightGreen;
                    _learnedWords.Add(_unknownWords.First(uw => uw.Id == _currentUnknownWordPairId));
                    LearnedWordsCountLabel.Text = _learnedWords.Count.ToString();
                
                    _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();
                }
                else
                {
                    LtWordTextBox.BackColor = Color.LightCoral;
                }
                
            }

            NextWordButton.Visible = true;
        }

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            HandleNextWordEvent();
        }

        private void HandleNextWordEvent()
        {
            LtWordTextBox.BackColor = Color.White;
            EnWordTextBox.BackColor = Color.White;

            NextWordButton.Visible = false;

            WordPair currentUnknownWord = _unknownWords.First();
            LtWordTextBox.Text = LtWordTextBox.ReadOnly ? currentUnknownWord.LithuanianWord : String.Empty;
            EnWordTextBox.Text = EnWordTextBox.ReadOnly ? currentUnknownWord.EnglishWord : String.Empty;
        }

        private void ShowLearnedWordsButton_Click(object sender, EventArgs e)
        {
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.LithuanianWord + " - " + learnedWord.EnglishWord).ToList();

            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, learnedWordsToDisplay);

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
