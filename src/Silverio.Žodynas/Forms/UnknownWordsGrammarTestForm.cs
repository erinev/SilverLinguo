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
        private readonly Color _textBoxBackColorForIncorrectWord = Color.LightCoral;

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
            if (e.KeyChar == KeyCodes.Plus)
            {
                if (NextWordButton.Visible)
                {
                    HandleNextWordEvent();
                }

                e.Handled = true;
            }
            else if (e.KeyChar == KeyCodes.Enter)
            {
                if (!NextWordButton.Visible)
                {
                    AssertAndHandleEnteredWord();
                }

                e.Handled = true;
            }
            /*else if (e.KeyChar == KeyCodes.Backspace)
            {
                e.Handled = true;
            }*/
        }

        private void AssertAndHandleEnteredWord()
        {
            WordPair currentWordPair = _unknownWords.First(unknownWord => unknownWord.Id == _currentUnknownWordPairId);

            if (!EnWordTextBox.ReadOnly)
            {
                bool isEqual = String.Equals(EnWordTextBox.Text.Trim(), currentWordPair.EnglishWord.Trim(),
                    StringComparison.InvariantCultureIgnoreCase);
                if (isEqual)
                {
                    HandleCorrectlyEnteredWord();
                }
                else
                {
                    HandleIncorrectlyEnteredWord(EnWordTextBox, currentWordPair.EnglishWord);
                }
            }
            else if (!LtWordTextBox.ReadOnly)
            {
                bool isEqual = String.Equals(LtWordTextBox.Text.Trim(), currentWordPair.LithuanianWord.Trim(), StringComparison.InvariantCultureIgnoreCase);
                if (isEqual)
                {
                    HandleCorrectlyEnteredWord();
                }
                else
                {
                    HandleIncorrectlyEnteredWord(LtWordTextBox, currentWordPair.LithuanianWord);
                }
            }
        }

        private void HandleIncorrectlyEnteredWord(TextBox textBox, string correctValueForTextBox)
        {
            NextWordButton.Visible = true;

            textBox.BackColor = _textBoxBackColorForIncorrectWord;
            textBox.Text = correctValueForTextBox;

            WordPair unknownWordToMove = _unknownWords.First();

            _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();

            List<WordPair> unknownWordsWithoutUnknownWord = _unknownWords.ToList();
            unknownWordsWithoutUnknownWord.Add(unknownWordToMove);

            _unknownWords = unknownWordsWithoutUnknownWord.ToArray();
            _currentUnknownWordPairId = _unknownWords.First().Id;
        }

        private void HandleCorrectlyEnteredWord()
        {
            _learnedWords.Add(_unknownWords.First(uw => uw.Id == _currentUnknownWordPairId));
            LearnedWordsCountLabel.Text = _learnedWords.Count.ToString();

            _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();

            if (_unknownWords.Length > 0)
            {
                _currentUnknownWordPairId = _unknownWords.First().Id;

                HandleNextWordEvent();
            }
            else
            {
                OpenStartupForm();
            }
        }

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            HandleNextWordEvent();
        }

        private void HandleNextWordEvent()
        {
            if (LtWordTextBox.BackColor == _textBoxBackColorForIncorrectWord)
            {
                LtWordTextBox.BackColor = Color.White;
            }

            if (EnWordTextBox.BackColor == _textBoxBackColorForIncorrectWord)
            {
                EnWordTextBox.BackColor = Color.White;
            }

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

        private void OpenStartupForm()
        {
            this.Hide();
            
            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }
    }
}
