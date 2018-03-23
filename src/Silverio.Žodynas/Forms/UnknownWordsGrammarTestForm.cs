using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        private readonly SelectedLanguage _selectedLanguage;
        private InputLanguage _originalInputLanguage = InputLanguage.DefaultInputLanguage;

        private int _currentUnknownWordPairId;

        private WordPair[] _unknownWords;
        private readonly IList<WordPair> _learnedWords = new List<WordPair>();
        private readonly Color _textBoxBackColorForIncorrectWord = Color.LightCoral;
        private int _startingCountOfUnknownWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public UnknownWordsGrammarTestForm(SelectedLanguage selectedLanguage)
        {
            SetTestTimer();

            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();

            ConfigureSelectedLanguage(selectedLanguage);
        }

        private void SetTestTimer()
        {
            var timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = true;
            _stopWatch.Start();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TestTimerLabel.Text = GetElapsedTestTimeText();
        }

        private void UnknownWordsGrammarTestForm_Load(object sender, EventArgs e)
        {
            _unknownWords = _wordsService.GetRandomlySortedUnknownWords();
            _startingCountOfUnknownWords = _unknownWords.Length;

            _currentUnknownWordPairId = _unknownWords[0].Id;

            ProgressLabel.Text = _unknownWords.Length.ToString();
            LearnedWordsCountLinkLabel.Enabled = false;

            WordPair firstUnknownWord = _unknownWords.First();
            LtWordTextBox.Text = LtWordTextBox.ReadOnly ? firstUnknownWord.LithuanianWord : String.Empty;
            EnWordTextBox.Text = EnWordTextBox.ReadOnly ? firstUnknownWord.EnglishWord : String.Empty;
        }

        private void UnknownWordsGrammarTestForm_Shown(object sender, EventArgs e)
        {
            try
            {
                _originalInputLanguage = InputLanguage.CurrentInputLanguage;

                if (_selectedLanguage == SelectedLanguage.Lithuanian || _selectedLanguage == SelectedLanguage.Mixed)
                {
                    CultureInfo lithuanianCultureInfo = CultureInfo.GetCultureInfo("lt-LT");
                    InputLanguage lithuanianLanguage = InputLanguage.FromCulture(lithuanianCultureInfo);

                    InputLanguage.CurrentInputLanguage = 
                        // ReSharper disable once AssignNullToNotNullAttribute
                        InputLanguage.InstalledInputLanguages.IndexOf(lithuanianLanguage) >= 0 ?
                            lithuanianLanguage :
                            InputLanguage.DefaultInputLanguage;
                }
            }
            catch (Exception)
            {
                InputLanguage.CurrentInputLanguage = _originalInputLanguage;
            }
        }

        private void UnknownWordsGrammarTestForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KeyCodes.Enter)
            {
                if (NextWordButton.Visible)
                {
                    HandleNextWordEvent();
                }
                else
                {
                    AssertAndHandleEnteredWord();
                }

                e.Handled = true;
            }
        }

        private void AssertAndHandleEnteredWord()
        {
            WordPair currentWordPair = _unknownWords.First(unknownWord => unknownWord.Id == _currentUnknownWordPairId);

            if (!EnWordTextBox.ReadOnly)
            {
                bool isEqual = IsEnteredValueIsEqualToExpectedValue(EnWordTextBox.Text, currentWordPair.EnglishWord);
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
                bool isEqual = IsEnteredValueIsEqualToExpectedValue(LtWordTextBox.Text, currentWordPair.LithuanianWord);
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

        private bool IsEnteredValueIsEqualToExpectedValue(string enteredValue, string expectedValue)
        {
            string[] expectedWords = expectedValue.Split(',')
                .Select(ev => ev.Trim().ToLowerInvariant())
                .OrderBy(ev => ev)
                .ToArray();
            expectedWords = expectedWords.OrderBy(x => x).ToArray();

            string[] enteredWords = enteredValue.Split(',')
                .Select(ev => ev.Trim().ToLowerInvariant())
                .OrderBy(ev => ev)
                .ToArray();

            bool isEnteredValueIsEqualToExpectedValue = expectedWords.SequenceEqual(enteredWords);

            return isEnteredValueIsEqualToExpectedValue;
        }

        private void HandleIncorrectlyEnteredWord(TextBox textBox, string correctValueForTextBox)
        {
            NextWordButton.Visible = true;
            NextWordButton.Focus();
            CorrectWordTextBox.Visible = true;

            textBox.BackColor = _textBoxBackColorForIncorrectWord;
            CorrectWordTextBox.Text = correctValueForTextBox;

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
            LearnedWordsCountLinkLabel.Text = _learnedWords.Count.ToString();

            LearnedWordsCountLinkLabel.Enabled = _learnedWords.Count > 0;

            _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();

            if (_unknownWords.Length > 0)
            {
                ProgressLabel.Text = _unknownWords.Length.ToString();
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
            NextWordButton.Visible = false;
            CorrectWordTextBox.Visible = false;

            if (_selectedLanguage == SelectedLanguage.Mixed)
            {
                bool currentEnWordTextBoxReadOnlyState = EnWordTextBox.ReadOnly;
                bool currentLtWordTextBoxReadOnlyState = LtWordTextBox.ReadOnly;
                EnWordTextBox.ReadOnly = !currentEnWordTextBoxReadOnlyState;
                LtWordTextBox.ReadOnly = !currentLtWordTextBoxReadOnlyState;
            }

            SetInputColorsOnNextWordEvent();

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

        private void SetInputColorsOnNextWordEvent()
        {
            if (LtWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && !LtWordTextBox.ReadOnly)
            {
                LtWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (LtWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && LtWordTextBox.ReadOnly)
            {
                LtWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (LtWordTextBox.BackColor == Color.FromKnownColor(KnownColor.Control) && !LtWordTextBox.ReadOnly)
            {
                LtWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                EnWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }

            if (EnWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && !EnWordTextBox.ReadOnly)
            {
                EnWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (EnWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && EnWordTextBox.ReadOnly)
            {
                EnWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (EnWordTextBox.BackColor == Color.FromKnownColor(KnownColor.Control) && !EnWordTextBox.ReadOnly)
            {
                EnWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                LtWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void LearnedWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.LithuanianWord + " - " + learnedWord.EnglishWord).ToList();

            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, learnedWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            HandleFinishedTest();
        }

        private void ConfigureSelectedLanguage(SelectedLanguage selectedLanguage)
        {
            switch (selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    LtWordTextBox.ReadOnly = false;
                    EnWordTextBox.ReadOnly = true;
                    LtWordTextBox.Select();
                    break;
                case SelectedLanguage.English:
                    LtWordTextBox.ReadOnly = true;
                    EnWordTextBox.ReadOnly = false;
                    EnWordTextBox.Select();
                    break;
                default:
                    LtWordTextBox.ReadOnly = false;
                    EnWordTextBox.ReadOnly = true;
                    LtWordTextBox.Select();
                    break;
            }
        }

        private void HandleFinishedTest()
        {
            InputLanguage.CurrentInputLanguage = _originalInputLanguage;

            _stopWatch.Stop();

            this.Hide();
            
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.LithuanianWord + " - " + learnedWord.EnglishWord).ToList();
            var testResultsForm = new TestResultsForm(_selectedLanguage, TestType.Grammar, WordsType.UnknownWords, _stopWatch, _startingCountOfUnknownWords, learnedWordsToDisplay);
            testResultsForm.Closed += (s, args) => this.Close();

            testResultsForm.Show();
        }

        private string GetElapsedTestTimeText()
        {
            return _stopWatch.Elapsed.Hours.ToString("00") + @":" +
                   _stopWatch.Elapsed.Minutes.ToString("00") + @":" +
                   _stopWatch.Elapsed.Seconds.ToString("00");
        }
    }
}
