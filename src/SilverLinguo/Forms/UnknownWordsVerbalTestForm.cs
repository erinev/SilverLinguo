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
using SilverLinguo.Services.Form;

namespace SilverLinguo.Forms
{
    public partial class UnknownWordsVerbalTestForm : Form
    {
        private readonly SelectedLanguage _selectedLanguage;

        private int _currentUnknownWordPairId;

        private WordPair[] _unknownWords;
        private readonly List<WordPair> _learnedWords = new List<WordPair>();
        private readonly int _startingCountOfUnknownWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public UnknownWordsVerbalTestForm(SelectedLanguage selectedLanguage, WordPair[] unknownWords)
        {
            _unknownWords = unknownWords;
            _startingCountOfUnknownWords = _unknownWords.Length;

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void UnknownWordsTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);
            
            VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            VerbalFormService.HanldeVerbalFormLoadedEvent(NextWordButton, _unknownWords, out _currentUnknownWordPairId, 
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
                CommonFormService.SetProgressLabelText(ProgressLabel, _unknownWords);

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
            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _learnedWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void EndTestButton_MouseClick(object sender, EventArgs e)
        {
            CommonFormService.HandelEndTestButtonPressedEvent(_unknownWords, HandleFinishedTest);
        }

        private void HandleFinishedTest()
        {
            _stopWatch.Stop();

            this.Hide();
            
            var testResultsForm = new TestResultsForUnknownWordsForm(_selectedLanguage, TestType.Verbal, _stopWatch,
                _startingCountOfUnknownWords, _learnedWords);

            testResultsForm.Show();
        }
    }
}
