using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Constants;
using SilverLinguo.Enums;
using SilverLinguo.Forms.Helper;
using SilverLinguo.Forms.TestResults;
using SilverLinguo.Repositories.Models;
using SilverLinguo.Services;
using SilverLinguo.Services.Form;

namespace SilverLinguo.Forms
{
    public partial class UnknownWordsGrammarTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private readonly SelectedLanguage _selectedLanguage;
        private InputLanguage _originalInputLanguage = InputLanguage.DefaultInputLanguage;

        private int _currentUnknownWordPairId;

        private WordPair[] _unknownWords;
        private readonly List<WordPair> _learnedWords = new List<WordPair>();
        private readonly int _startingCountOfUnknownWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public UnknownWordsGrammarTestForm(SelectedLanguage selectedLanguage, WordPair[] uknownWords)
        {
            _wordsService = new WordsService();

            _unknownWords = uknownWords;
            _startingCountOfUnknownWords = _unknownWords.Length;

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void UnknownWordsGrammarTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);

            GrammarFormService.ConfigureSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox, ValidateWordButton, NextWordButton);

            GrammarFormService.HanldeVerbalFormLoadedEvent(_unknownWords, out _currentUnknownWordPairId, ProgressLabel,
                FirstLanguageWordTextBox, SecondLanguageWordTextBox);

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
                    HandleNextWordEvent();
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
                bool isEqual = _wordsService.CheckIfWordsMatches(SecondLanguageWordTextBox.Text, currentWordPair.SecondLanguageWord);
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
                bool isEqual = _wordsService.CheckIfWordsMatches(FirstLanguageWordTextBox.Text, currentWordPair.FirstLanguageWord);
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
            HandleNextWordEvent();
        }

        private void HandleNextWordEvent()
        {
            GrammarFormService.HandleNextWordButtonEvent(ValidateWordButton, NextWordButton,
                CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                _unknownWords);
        }

        private void LearnedWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _learnedWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            CommonFormService.HandelEndTestButtonPressedEvent(_unknownWords, HandleFinishedTest);
        }

        private void HandleFinishedTest()
        {
            InputLanguage.CurrentInputLanguage = _originalInputLanguage;

            _stopWatch.Stop();

            this.Hide();
            
            var testResultsForm = new TestResultsForUnknownWordsForm(_selectedLanguage, TestType.Grammar, _stopWatch, _startingCountOfUnknownWords, _learnedWords);
            testResultsForm.Closed += (s, args) => this.Close();

            testResultsForm.Show();
        }
    }
}
