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

            NewUnknownWordsCountLabel.Enabled = false;
            UnknownWordsCountLinkLabel.Enabled = false;
            LearnedWordsCountLinkLabel.Enabled = false;
        }

        private void AllWordsVerbalTestForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KeyCodes.Enter)
            {
                if (NextWordButton.Visible)
                {
                    HandleNextWordButtonClickedEvent();
                }

                e.Handled = true;
            }
            else if (e.KeyChar == KeyCodes.Backspace)
            {
                if (IDontKnowTheWordButton.Visible)
                {
                    //HandleIDontKnowWordButtonClickedEvent();
                }
            }
        }

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            HandleNextWordButtonClickedEvent();
        }

        private void HandleNextWordButtonClickedEvent()
        {
            if (IDontKnowTheWordButton.Visible)
            {
                _allWords = VerbalFormService.HandleLearnedWordOnNextWordClick(_learnedWords, _allWords, _currentWordPairId, LearnedWordsCountLinkLabel);
            }
            else
            {
                VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox);
            }

            VerbalFormService.HandleNextWordButtonClickedEvent(LearnedWordsCountLinkLabel, _learnedWords, IDontKnowTheWordButton,
                _allWords, ProgressLabel, FirstLanguageWordTextBox, SecondLanguageWordTextBox, out _currentWordPairId,
                HandleFinishedTest, _selectedLanguage);
        }

        private void IDontKnowTheWordButton_Click(object sender, EventArgs e)
        {
            HandleIDontKnowWordButtonClickedEvent();
        }

        private void HandleIDontKnowWordButtonClickedEvent()
        {
            VerbalFormService.HandleVisibilityOnIDontKnowButtonClickedEvent(IDontKnowTheWordButton, NextWordButton,
                FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            _unknownWords.Add(_allWords.First(aw => aw.Id == _currentWordPairId));

            WordPair currentUnknownWord = _unknownWords[0];
            bool added = _wordsService.InsertNewUnknownWordIfDoesntExist(currentUnknownWord);
            // AddToUnknownWords table IfDoesntExist
            // depending on query result add to newUnkownWords array or unknownWordsArray
        }

        private void HandleFinishedTest()
        {
            _stopWatch.Stop();
        }
    }
}
