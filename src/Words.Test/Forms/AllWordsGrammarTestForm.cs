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
    public partial class AllWordsGrammarTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private readonly SelectedLanguage _selectedLanguage;
        private InputLanguage _originalInputLanguage = InputLanguage.DefaultInputLanguage;

        private int _currentWordPairId;

        private WordPair[] _allWords;
        private readonly List<WordPair> _knownWords = new List<WordPair>();
        private readonly List<WordPair> _learnedWords = new List<WordPair>();
        private readonly List<WordPair> _unknownWords = new List<WordPair>();
        private readonly List<WordPair> _newUnknownWords = new List<WordPair>();
        private int _startingCountOfAllWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public AllWordsGrammarTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void AllWordsGrammarTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);

            GrammarFormService.ConfigureSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox, ValidateWordButton, NextWordButton);

            GrammarFormService.HanldeVerbalFormLoadedEvent(out _allWords, _wordsService.GetRandomlySortedAllWords, out _startingCountOfAllWords, out _currentWordPairId, ProgressLabel, FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            NewUnknownWordsCountLinkLabel.Enabled = false;
            UnknownWordsCountLinkLabel.Enabled = false;
            NewLearnedWordsCountLinkLabel.Enabled = false;
            KnownWordsCountLinkLabel.Enabled = false;
        }

        private void AllWordsGrammarTestForm_Shown(object sender, EventArgs e)
        {
            GrammarFormService.ConfigureInputLanguageForTest(out _originalInputLanguage, _selectedLanguage);
        }

        private void AllWordsGrammarTestForm_KeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyValue == KeyCodes.Enter)
            {
                if (NextWordButton.Visible)
                {
                    GrammarFormService.HandleNextWordButtonClickedEvent(ValidateWordButton, NextWordButton,
                        CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                        _allWords);
                }
                else
                {
                    ValidateAndHandleEnteredWord();
                }

                keyEventArgs.Handled = true;
            }
        }

        private void ValidateWordButton_MouseClick(object sender, MouseEventArgs e)
        {
            ValidateAndHandleEnteredWord();
        }

        private void ValidateAndHandleEnteredWord()
        {
            WordPair currentWordPair = _allWords.First(unknownWord => unknownWord.Id == _currentWordPairId);

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

            /*WordPair unknownWordToMove = _unknownWords[0];

            List<WordPair> wordsWithoutUnknownWord = _unknownWords.Where(unknownWord => unknownWord.Id != _currentWordPairId).ToList();

            wordsWithoutUnknownWord.Add(unknownWordToMove);

            _allWords = wordsWithoutUnknownWord.ToArray();
            _currentWordPairId = _unknownWords.First().Id;*/
        }

        private void HandleCorrectlyEnteredWord()
        {
            /*_learnedWords.Add(_unknownWords.First(uw => uw.Id == _currentUnknownWordPairId));
            LearnedWordsCountLinkLabel.Text = _learnedWords.Count.ToString();

            LearnedWordsCountLinkLabel.Enabled = _learnedWords.Count > 0;

            _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();

            if (_unknownWords.Length > 0)
            {
                ProgressLabel.Text = _unknownWords.Length.ToString();
                _currentUnknownWordPairId = _unknownWords.First().Id;

                GrammarFormService.HandleNextWordButtonClickedEvent(ValidateWordButton, NextWordButton,
                    CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                    _unknownWords);
            }
            else
            {
                HandleFinishedTest();
            }*/
        }
    }
}
