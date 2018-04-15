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
    public partial class AllWordsVerbalTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private readonly SelectedLanguage _selectedLanguage;

        private int _currentWordPairId;

        private WordPair[] _allWords;
        private readonly List<WordPair> _knownWords = new List<WordPair>();
        private readonly List<WordPair> _learnedWords = new List<WordPair>();
        private readonly List<WordPair> _unknownWords = new List<WordPair>();
        private readonly List<WordPair> _newUnknownWords = new List<WordPair>();
        private int _startingCountOfAllWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public AllWordsVerbalTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void AllWordsVerbalTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);
            
            VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox,
                SecondLanguageWordTextBox);

            VerbalFormService.HanldeVerbalFormLoadedEvent(NextWordButton, out _allWords, _wordsService.GetRandomlySortedAllWords, out _startingCountOfAllWords, out _currentWordPairId,
                ProgressLabel, FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            NewUnknownWordsCountLinkLabel.Enabled = false;
            UnknownWordsCountLinkLabel.Enabled = false;
            NewLearnedWordsCountLinkLabel.Enabled = false;
            KnownWordsCountLinkLabel.Enabled = false;
        }

        private void AllWordsVerbalTestForm_KeyUp(object sender, KeyEventArgs keyEventArgs)
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
                WordPair currentLearnedWord = _allWords.First(uw => uw.Id == _currentWordPairId);
                bool learnedUnknownWord = _wordsService.RemoveLearnedUnknownWordIfExist(currentLearnedWord);
                if (learnedUnknownWord)
                {
                    _learnedWords.Add(currentLearnedWord);
                    NewLearnedWordsCountLinkLabel.Text = _learnedWords.Count.ToString();
                }
                else
                {
                    _knownWords.Add(currentLearnedWord);
                    KnownWordsCountLinkLabel.Text = _knownWords.Count.ToString();
                }

                _allWords = _allWords.Where(aw => aw.Id != _currentWordPairId).ToArray();

                NewLearnedWordsCountLinkLabel.Enabled = _learnedWords.Count > 0;
                KnownWordsCountLinkLabel.Enabled = _knownWords.Count > 0;
            }
            else
            {
                VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox);
            }

            VerbalFormService.HandleNextWordButtonClickedEvent(IDontKnowTheWordButton, FirstLanguageWordTextBox, SecondLanguageWordTextBox, _selectedLanguage);

            if (_allWords.Length > 0)
            {
                CommonFormService.SetProgressLabelText(ProgressLabel, _allWords);

                WordPair nextWord = _allWords.First();

                FirstLanguageWordTextBox.Text = nextWord.FirstLanguageWord;
                SecondLanguageWordTextBox.Text = nextWord.SecondLanguageWord;

                _currentWordPairId = nextWord.Id;
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

            WordPair currentUnknownWord = _allWords.First(aw => aw.Id == _currentWordPairId);
            bool unknownWordAdded = _wordsService.InsertNewUnknownWordIfDoesntExist(currentUnknownWord);
            if (unknownWordAdded)
            {
                _newUnknownWords.Add(currentUnknownWord);
                NewUnknownWordsCountLinkLabel.Text = _newUnknownWords.Count.ToString();
            }
            else
            {
                _unknownWords.Add(currentUnknownWord);
                UnknownWordsCountLinkLabel.Text = _unknownWords.Count.ToString();
            }

            NewUnknownWordsCountLinkLabel.Enabled = _newUnknownWords.Count > 0;
            UnknownWordsCountLinkLabel.Enabled = _unknownWords.Count > 0;

            _allWords = _allWords.Where(aw => aw.Id != _currentWordPairId).ToArray();
        }

        private void NewUnknownWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> newUnknownWordsToDisplay =
                _newUnknownWords.Select(w => w.FirstLanguageWord + " - " + w.SecondLanguageWord).ToList();

            string showWordsFormName = "Nauji nežinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, newUnknownWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void UnknownWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> unknownWordsToDisplay =
                _unknownWords.Select(w => w.FirstLanguageWord + " - " + w.SecondLanguageWord).ToList();

            string showWordsFormName = "Vis dar nežinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, unknownWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void NewLearnedWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(w => w.FirstLanguageWord + " - " + w.SecondLanguageWord).ToList();

            string showWordsFormName = "Nauji išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, learnedWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void KnownWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> knownWordsToDisplay =
                _knownWords.Select(w => w.FirstLanguageWord + " - " + w.SecondLanguageWord).ToList();

            string showWordsFormName = "Žinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, knownWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            CommonFormService.HandelEndTestButtonPressedEvent(_allWords, HandleFinishedTest);
        }

        private void HandleFinishedTest()
        {
            _stopWatch.Stop();

            this.Hide();

            List<WordPair> learnedAndKnownWords = _learnedWords.Concat(_knownWords).ToList();
            List<string> learnedAndKnownWordsToDisplay =
                learnedAndKnownWords.Select(w => w.FirstLanguageWord + " - " + w.SecondLanguageWord).ToList();
            List<WordPair> unknownWords = _newUnknownWords.Concat(_unknownWords).ToList();
            List<string> unknownWordsToDisplay =
                unknownWords.Select(w => w.FirstLanguageWord + " - " + w.SecondLanguageWord).ToList();

            var testResultsForm = new UnknownWordsTestResultsForm(_selectedLanguage, TestType.Verbal, WordsType.AllWords, _stopWatch, _startingCountOfAllWords, learnedAndKnownWordsToDisplay, unknownWordsToDisplay);
            testResultsForm.Closed += (s, args) => this.Close();

            testResultsForm.Show();
        }
    }
}
