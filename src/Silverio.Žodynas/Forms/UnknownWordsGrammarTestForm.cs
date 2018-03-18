using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static readonly Stopwatch StopWatch = new Stopwatch();

        public UnknownWordsGrammarTestForm(SelectedLanguage selectedLanguage)
        {
            SetTestTimer();

            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();

            SetSelectedLanguage(selectedLanguage);
        }

        private void SetTestTimer()
        {
            var timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = true;
            StopWatch.Start();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TestTimerLabel.Text = GetElapsedTestTimeText();
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
                HandleFinishedTest();
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

            if (_selectedLanguage == SelectedLanguage.Mixed)
            {
                bool currentEnWordTextBoxReadOnlyState = EnWordTextBox.ReadOnly;
                bool currentLtWordTextBoxReadOnlyState = LtWordTextBox.ReadOnly;
                EnWordTextBox.ReadOnly = !currentEnWordTextBoxReadOnlyState;
                LtWordTextBox.ReadOnly = !currentLtWordTextBoxReadOnlyState;
            }

            WordPair currentUnknownWord = _unknownWords.First();
            LtWordTextBox.Text = LtWordTextBox.ReadOnly ? currentUnknownWord.LithuanianWord : String.Empty;
            EnWordTextBox.Text = EnWordTextBox.ReadOnly ? currentUnknownWord.EnglishWord : String.Empty;

            if (!LtWordTextBox.ReadOnly)
            {
                LtWordTextBox.Focus();
            }
            else
            {
                EnWordTextBox.Focus();
            }
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
            HandleFinishedTest();
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

        private void HandleFinishedTest()
        {
            StopWatch.Stop();

            this.Hide();
            
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.LithuanianWord + " - " + learnedWord.EnglishWord).ToList();
            var testResultsForm = new TestResultsForm(_selectedLanguage, TestType.Grammar, WordsType.UnknownWords, StopWatch, learnedWordsToDisplay);
            testResultsForm.Closed += (s, args) => this.Close();

            testResultsForm.Show();
        }

        private static string GetElapsedTestTimeText()
        {
            return StopWatch.Elapsed.Hours.ToString("00") + @":" +
                   StopWatch.Elapsed.Minutes.ToString("00") + @":" +
                   StopWatch.Elapsed.Seconds.ToString("00");
        }
    }
}
