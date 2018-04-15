using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private int _startingCountOfUnknownWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public UnknownWordsGrammarTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void UnknownWordsGrammarTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);

            GrammarFormService.ConfigureSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox, ValidateWordButton, NextWordButton);

            GrammarFormService.HanldeVerbalFormLoadedEvent(out _unknownWords, _wordsService.GetRandomlySortedUnknownWords, out _startingCountOfUnknownWords, out _currentUnknownWordPairId, ProgressLabel, FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            LearnedWordsCountLinkLabel.Enabled = false;
        }

        private void UnknownWordsGrammarTestForm_Shown(object sender, EventArgs e)
        {
            GrammarFormService.ConfigureInputLanguageForTest(out _originalInputLanguage, _selectedLanguage);
        }

        private void UnknownWordsGrammarTestForm_KeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyValue == KeyCodes.Enter)
            {
                if (NextWordButton.Visible)
                {
                    GrammarFormService.HandleNextWordButtonEvent(ValidateWordButton, NextWordButton,
                        CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                        _unknownWords);
                }
                else
                {
                    ValidateAndHandleEnteredWord();
                }

                keyEventArgs.Handled = true;
            }
        }

        private void ValidateWordButton_MouseClick(object sender, EventArgs e)
        {
            ValidateAndHandleEnteredWord();
        }

        private void ValidateAndHandleEnteredWord()
        {
            WordPair currentWordPair = _unknownWords.First(unknownWord => unknownWord.Id == _currentUnknownWordPairId);

            if (!SecondLanguageWordTextBox.ReadOnly)
            {
                bool isEqual = _wordsService.IsEnteredWordIsEqualToExpectedWord(SecondLanguageWordTextBox.Text, currentWordPair.SecondLanguageWord);
                if (isEqual)
                {
                    HandleCorrectlyEnteredWord();
                }
                else
                {
                    HandleIncorrectlyEnteredWord(SecondLanguageWordTextBox, currentWordPair.SecondLanguageWord);
                }
            }
            else if (!FirstLanguageWordTextBox.ReadOnly)
            {
                bool isEqual = _wordsService.IsEnteredWordIsEqualToExpectedWord(FirstLanguageWordTextBox.Text, currentWordPair.FirstLanguageWord);
                if (isEqual)
                {
                    HandleCorrectlyEnteredWord();
                }
                else
                {
                    HandleIncorrectlyEnteredWord(FirstLanguageWordTextBox, currentWordPair.FirstLanguageWord);
                }
            }
        }

        private void HandleIncorrectlyEnteredWord(TextBox textBox, string correctValueForTextBox)
        {
            GrammarFormService.HandleVisibilityOnIncorrectlyEnteredWordEvent(ValidateWordButton, NextWordButton,
                CorrectWordTextBox, textBox, correctValueForTextBox);

            WordPair unknownWordToMove = _unknownWords[0];

            List<WordPair> wordsWithoutUnknownWord = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToList();

            wordsWithoutUnknownWord.Add(unknownWordToMove);

            _unknownWords = wordsWithoutUnknownWord.ToArray();
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
                CommonFormService.SetProgressLabelText(ProgressLabel, _unknownWords);
                _currentUnknownWordPairId = _unknownWords.First().Id;

                GrammarFormService.HandleNextWordButtonEvent(ValidateWordButton, NextWordButton,
                    CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                    _unknownWords);
            }
            else
            {
                HandleFinishedTest();
            }
        }

        private void NextWordButton_MouseClick(object sender, MouseEventArgs e)
        {
            GrammarFormService.HandleNextWordButtonEvent(ValidateWordButton, NextWordButton,
                CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                _unknownWords);
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
    }
}
