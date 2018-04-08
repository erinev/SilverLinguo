using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Words.Test.Constants;
using Words.Test.Enums;
using Words.Test.Repositories.Models;
using Words.Test.Services;
using Words.Test.Services.Form;

namespace Words.Test.Forms
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

        private Point _firstWordLocationForButton = new Point(29, 120);
        private Point _secondWordLocationForButton = new Point(663, 120);

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
            FirstWordTextBox.Text = FirstWordTextBox.ReadOnly ? firstUnknownWord.FirstLanguageWord : String.Empty;
            SecondWordTextBox.Text = SecondWordTextBox.ReadOnly ? firstUnknownWord.SecondLanguageWord : String.Empty;
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

        private void UnknownWordsGrammarTestForm_KeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyValue == KeyCodes.Enter)
            {
                if (NextWordButton.Visible)
                {
                    HandleNextWordEvent();
                }
                else
                {
                    AssertAndHandleEnteredWord();
                }

                keyEventArgs.Handled = true;
            }
        }

        private void ConfirmWordButton_MouseClick(object sender, EventArgs e)
        {
            AssertAndHandleEnteredWord();
        }

        private void AssertAndHandleEnteredWord()
        {
            WordPair currentWordPair = _unknownWords.First(unknownWord => unknownWord.Id == _currentUnknownWordPairId);

            if (!SecondWordTextBox.ReadOnly)
            {
                bool isEqual = IsEnteredValueIsEqualToExpectedValue(SecondWordTextBox.Text, currentWordPair.SecondLanguageWord);
                if (isEqual)
                {
                    HandleCorrectlyEnteredWord();
                }
                else
                {
                    HandleIncorrectlyEnteredWord(SecondWordTextBox, currentWordPair.SecondLanguageWord);
                }
            }
            else if (!FirstWordTextBox.ReadOnly)
            {
                bool isEqual = IsEnteredValueIsEqualToExpectedValue(FirstWordTextBox.Text, currentWordPair.FirstLanguageWord);
                if (isEqual)
                {
                    HandleCorrectlyEnteredWord();
                }
                else
                {
                    HandleIncorrectlyEnteredWord(FirstWordTextBox, currentWordPair.FirstLanguageWord);
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
            ValidateWordButton.Visible = false;
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

        private void NextWordButton_MouseClick(object sender, MouseEventArgs e)
        {
            HandleNextWordEvent();
        }

        private void HandleNextWordEvent()
        {
            ValidateWordButton.Visible = true;
            NextWordButton.Visible = false;
            CorrectWordTextBox.Visible = false;

            if (_selectedLanguage == SelectedLanguage.Mixed)
            {
                bool currentEnWordTextBoxReadOnlyState = SecondWordTextBox.ReadOnly;
                bool currentLtWordTextBoxReadOnlyState = FirstWordTextBox.ReadOnly;
                SecondWordTextBox.ReadOnly = !currentEnWordTextBoxReadOnlyState;
                FirstWordTextBox.ReadOnly = !currentLtWordTextBoxReadOnlyState;

                RepositionConfirmAndNextWordButtons();
            }

            SetInputColorsOnNextWordEvent();

            WordPair currentUnknownWord = _unknownWords.First();
            FirstWordTextBox.Text = FirstWordTextBox.ReadOnly ? currentUnknownWord.FirstLanguageWord : String.Empty;
            SecondWordTextBox.Text = SecondWordTextBox.ReadOnly ? currentUnknownWord.SecondLanguageWord : String.Empty;

            if (!FirstWordTextBox.ReadOnly)
            {
                FirstWordTextBox.Focus();
            }
            else
            {
                SecondWordTextBox.Focus();
            }
        }

        private void SetInputColorsOnNextWordEvent()
        {
            if (FirstWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && !FirstWordTextBox.ReadOnly)
            {
                FirstWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (FirstWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && FirstWordTextBox.ReadOnly)
            {
                FirstWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (FirstWordTextBox.BackColor == Color.FromKnownColor(KnownColor.Control) && !FirstWordTextBox.ReadOnly)
            {
                FirstWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                SecondWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }

            if (SecondWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && !SecondWordTextBox.ReadOnly)
            {
                SecondWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (SecondWordTextBox.BackColor == _textBoxBackColorForIncorrectWord && SecondWordTextBox.ReadOnly)
            {
                SecondWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (SecondWordTextBox.BackColor == Color.FromKnownColor(KnownColor.Control) && !SecondWordTextBox.ReadOnly)
            {
                SecondWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                FirstWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void LearnedWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.FirstLanguageWord + " - " + learnedWord.SecondLanguageWord).ToList();

            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, learnedWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            CommonFormService.HandelEndTestButtonPressedEvent(HandleFinishedTest);
        }

        private void ConfigureSelectedLanguage(SelectedLanguage selectedLanguage)
        {
            switch (selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    FirstWordTextBox.ReadOnly = false;
                    SecondWordTextBox.ReadOnly = true;
                    FirstWordTextBox.Select();
                    break;
                case SelectedLanguage.English:
                    FirstWordTextBox.ReadOnly = true;
                    SecondWordTextBox.ReadOnly = false;
                    SecondWordTextBox.Select();
                    break;
                default:
                    FirstWordTextBox.ReadOnly = false;
                    SecondWordTextBox.ReadOnly = true;
                    FirstWordTextBox.Select();
                    break;
            }

            RepositionConfirmAndNextWordButtons();
        }

        private void RepositionConfirmAndNextWordButtons()
        {
            ValidateWordButton.Location =
                FirstWordTextBox.ReadOnly ? _secondWordLocationForButton : _firstWordLocationForButton;
            NextWordButton.Location =
                FirstWordTextBox.ReadOnly ? _firstWordLocationForButton : _secondWordLocationForButton;
        }

        private void HandleFinishedTest()
        {
            InputLanguage.CurrentInputLanguage = _originalInputLanguage;

            _stopWatch.Stop();

            this.Hide();
            
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.FirstLanguageWord + " - " + learnedWord.SecondLanguageWord).ToList();

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
