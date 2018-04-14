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
    public partial class UnknownWordsVerbalTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private readonly SelectedLanguage _selectedLanguage;

        private int _currentUnknownWordPairId;

        private WordPair[] _unknownWords;
        private readonly List<WordPair> _learnedWords = new List<WordPair>();
        private int _startingCountOfUnknownWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public UnknownWordsVerbalTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void UnknownWordsTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);
            
            VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            VerbalFormService.HanldeVerbalFormLoadedEvent(NextWordButton, out _unknownWords, _wordsService.GetRandomlySortedUnknownWords, out _startingCountOfUnknownWords, out _currentUnknownWordPairId,
                ProgressLabel, FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            LearnedWordsCountLinkLabel.Enabled = false;
        }

        private void UnknownWordsVerbalTestForm_KeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyValue == KeyCodes.Enter)
            {
                if (NextWordButton.Visible)
                {
                    HandleNextWordButtonClickedEvent();
                }

                keyEventArgs.Handled = true;
            }
            else if (keyEventArgs.KeyValue == KeyCodes.Backspace)
            {
                if (IDontKnowTheWordButton.Visible)
                {
                    HandleIDontKnowWordButtonClickedEvent();
                }

                keyEventArgs.Handled = true;
            }
        }

        private void NextWordButton_MouseClick(object sender, EventArgs e)
        {
            HandleNextWordButtonClickedEvent();
        }

        private void HandleNextWordButtonClickedEvent()
        {
            if (IDontKnowTheWordButton.Visible)
            {
                _learnedWords.Add(_unknownWords.First(uw => uw.Id == _currentUnknownWordPairId));
                LearnedWordsCountLinkLabel.Text = _learnedWords.Count.ToString();
                LearnedWordsCountLinkLabel.Enabled = _learnedWords.Count > 0;

                _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();
            }
            else
            {
                VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox);
            }

            VerbalFormService.HandleNextWordButtonClickedEvent(IDontKnowTheWordButton, FirstLanguageWordTextBox, SecondLanguageWordTextBox, _selectedLanguage);

            if (_unknownWords.Length > 0)
            {
                ProgressLabel.Text = _unknownWords.Length.ToString();

                WordPair nextWord = _unknownWords.First();

                FirstLanguageWordTextBox.Text = nextWord.FirstLanguageWord;
                SecondLanguageWordTextBox.Text = nextWord.SecondLanguageWord;

                _currentUnknownWordPairId = nextWord.Id;
            }
            else
            {
                HandleFinishedTest();
            }
        }

        private void IDontKnowTheWordButton_MouseClick(object sender, EventArgs e)
        {
            HandleIDontKnowWordButtonClickedEvent();
        }

        private void HandleIDontKnowWordButtonClickedEvent()
        {
            VerbalFormService.HandleVisibilityOnIDontKnowButtonClickedEvent(IDontKnowTheWordButton, NextWordButton,
                FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            WordPair unknownWordToMove = _unknownWords[0];

            List<WordPair> wordsWithoutUnknownWord = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToList();

            wordsWithoutUnknownWord.Add(unknownWordToMove);

            _unknownWords = wordsWithoutUnknownWord.ToArray();
            _currentUnknownWordPairId = _unknownWords.First().Id;
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
            _stopWatch.Stop();

            this.Hide();
            
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.FirstLanguageWord + " - " + learnedWord.SecondLanguageWord).ToList();
            
            var testResultsForm = new TestResultsForm(_selectedLanguage, TestType.Verbal, WordsType.UnknownWords, _stopWatch, _startingCountOfUnknownWords, learnedWordsToDisplay);
            testResultsForm.Closed += (s, args) => this.Close();

            testResultsForm.Show();
        }
    }
}
