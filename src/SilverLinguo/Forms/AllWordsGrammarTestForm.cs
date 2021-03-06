﻿using System;
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
        private readonly int _startingCountOfAllWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public AllWordsGrammarTestForm(SelectedLanguage selectedLanguage, WordPair[] allWords)
        {
            _wordsService = new WordsService();

            _allWords = allWords;
            _startingCountOfAllWords = _allWords.Length;

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void AllWordsGrammarTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);

            GrammarFormService.ConfigureSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox, ValidateWordButton, NextWordButton);

            GrammarFormService.HanldeVerbalFormLoadedEvent(_allWords, out _currentWordPairId, ProgressLabel, 
                FirstLanguageWordTextBox, SecondLanguageWordTextBox);

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
                    HandleNextWordButtonEvent();
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

            if (_allWords.Length > 0)
            {
                _currentWordPairId = _allWords.First().Id;
            }
        }

        private void HandleCorrectlyEnteredWord()
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

            if (_allWords.Length > 0)
            {
                CommonFormService.SetProgressLabelText(ProgressLabel, _allWords);
                _currentWordPairId = _allWords.First().Id;

                GrammarFormService.HandleNextWordButtonEvent(ValidateWordButton, NextWordButton,
                    CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                    _allWords);
            }
            else
            {
                HandleFinishedTest();
            }
        }

        private void NextWordButton_MouseClick(object sender, MouseEventArgs e)
        {
            HandleNextWordButtonEvent();
        }

        private void HandleNextWordButtonEvent()
        {
            if (_allWords.Length > 0)
            {
                CommonFormService.SetProgressLabelText(ProgressLabel, _allWords);

                GrammarFormService.HandleNextWordButtonEvent(ValidateWordButton, NextWordButton,
                    CorrectWordTextBox, _selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox,
                    _allWords);
            }
            else
            {
                HandleFinishedTest();
            }
        }

        private void NewUnknownWordsCountLinkLabel_LinkMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            string showWordsFormName = "Nauji nežinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _newUnknownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void UnknownWordsCountLinkLabel_LinkMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            string showWordsFormName = "Vis dar nežinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _unknownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void NewLearnedWordsCountLinkLabel_LinkMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            string showWordsFormName = "Nauji išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _learnedWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void KnownWordsCountLinkLabel_LinkMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            string showWordsFormName = "Žinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _knownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void EndTestButton_MouseClick(object sender, EventArgs e)
        {
            CommonFormService.HandelEndTestButtonPressedEvent(_allWords, HandleFinishedTest);
        }

        private void HandleFinishedTest()
        {
            InputLanguage.CurrentInputLanguage = _originalInputLanguage;

            _stopWatch.Stop();

            this.Hide();

            var testResultsForm = new TestResultsForAllWordsForm(_selectedLanguage, TestType.Grammar, _stopWatch, 
                _startingCountOfAllWords, _learnedWords, _knownWords, _newUnknownWords, _unknownWords);
            testResultsForm.Closed += (s, args) => this.Close();

            testResultsForm.Show();
        }
    }
}
