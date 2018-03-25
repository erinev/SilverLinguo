using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Words.Test.Enums;
using Words.Test.Models;
using Words.Test.Repositories;

namespace Words.Test.Forms
{
    public partial class WordsTestForm : Form
    {
        private readonly IWordsRepository _wordsRepository;

        private SelectedLanguage _selectedLanguage;
        private int _currentWordPairIndex;
        private int _currentWordPairIndexForProgress = 1;

        private readonly Bitmap _englishFlagBitmap = Properties.Resources.EnglishFlag;
        private readonly Bitmap _lithuanianFlagBitmap = Properties.Resources.LithuanianFlag;
        private WordPair[] _allWords;
        private readonly IList<WordPair> _unknownWords = new List<WordPair>();
        private readonly string _progressLabelText = "{0} / {1}";

        public WordsTestForm()
        {
            _wordsRepository = new WordsRepository();

            InitializeComponent();
        }

        private void VocabularyForm_Load(object sender, EventArgs e)
        {
            _allWords = _wordsRepository.GetAllWords();

            _selectedLanguage = SelectedLanguage.Lithuanian;

            LtWordLabel.Visible = true;
            EnWordLabel.Visible = false;

            NextWordButton.Visible = true;
            PreviousWordButton.Visible = false;

            ChangeLanguageButton.Image = _englishFlagBitmap;

            ProgressLabel.Text = string.Format(_progressLabelText, _currentWordPairIndexForProgress, _allWords.Length);

            LtWordLabel.Text = _allWords[_currentWordPairIndex].FirstLanguageWord;
            EnWordLabel.Text = _allWords[_currentWordPairIndex].SecondLanguageWord;
        }

        private void ChangeLanguageButton_Click(object sender, EventArgs e)
        {
            Bitmap languageIcon;

            if (_selectedLanguage == SelectedLanguage.Lithuanian)
            {
                languageIcon = _lithuanianFlagBitmap;
                _selectedLanguage = SelectedLanguage.English;
                EnWordLabel.Visible = true;
            }
            else if (_selectedLanguage == SelectedLanguage.English)
            {
                languageIcon = _englishFlagBitmap;
                _selectedLanguage = SelectedLanguage.Lithuanian;
                LtWordLabel.Visible = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            ChangeLanguageButton.Image = languageIcon;
        }

        private void PreviousWordButton_Click(object sender, EventArgs e)
        {
            if (_currentWordPairIndex - 1 == 0)
            {
                PreviousWordButton.Visible = false;
            }
            else if (_currentWordPairIndex < _allWords.Length)
            {
                NextWordButton.Visible = true;
            }

            if (_currentWordPairIndex > 0)
            {
                --_currentWordPairIndexForProgress;
                ProgressLabel.Text = string.Format(_progressLabelText, _currentWordPairIndexForProgress, _allWords.Length);

                int previousWordIndex = --_currentWordPairIndex;

                LtWordLabel.Text = _allWords[previousWordIndex].FirstLanguageWord;
                EnWordLabel.Text = _allWords[previousWordIndex].SecondLanguageWord;
            }

            if (_selectedLanguage == SelectedLanguage.Lithuanian)
            {
                EnWordLabel.Visible = false;
            }
            else if (_selectedLanguage == SelectedLanguage.English)
            {
                LtWordLabel.Visible = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            HandleUnknownButtonVisibility();
        }

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            if (_currentWordPairIndex + 2 == _allWords.Length)
            {
                NextWordButton.Visible = false;
            } else if (_currentWordPairIndex >= 0)
            {
                PreviousWordButton.Visible = true;
            }

            if (_currentWordPairIndex + 1 < _allWords.Length)
            {
                ++_currentWordPairIndexForProgress;
                ProgressLabel.Text = string.Format(_progressLabelText, _currentWordPairIndexForProgress, _allWords.Length);

                int nextWordIndex = ++_currentWordPairIndex;

                LtWordLabel.Text = _allWords[nextWordIndex].FirstLanguageWord;
                EnWordLabel.Text = _allWords[nextWordIndex].SecondLanguageWord;
            }
            
            if (_selectedLanguage == SelectedLanguage.Lithuanian)
            {
                EnWordLabel.Visible = false;
            }
            else if (_selectedLanguage == SelectedLanguage.English)
            {
                LtWordLabel.Visible = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            HandleUnknownButtonVisibility();
        }

        private void UnknownWordButton_Click(object sender, EventArgs e)
        {
            WordPair unknownWordCandidate = _allWords[_currentWordPairIndex];

            WordPair existingUnknownWord =
                _unknownWords.FirstOrDefault(unknownWord =>
                    unknownWord.FirstLanguageWord == unknownWordCandidate.FirstLanguageWord &&
                    unknownWord.SecondLanguageWord == unknownWordCandidate.SecondLanguageWord);

            if (existingUnknownWord == null)
            {
                _unknownWords.Add(
                    new WordPair
                    {
                        Id = _unknownWords.Count + 1,
                        FirstLanguageWord = unknownWordCandidate.FirstLanguageWord,
                        SecondLanguageWord = unknownWordCandidate.SecondLanguageWord
                    }
                );
            }

            UnknownWordsCountLabel.Text = _unknownWords.Count.ToString();

            UnknownWordButton.Visible = false;
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HandleUnknownButtonVisibility()
        {
            WordPair currentWord = _allWords[_currentWordPairIndex];

            WordPair alreadyExistingUnknownWord = _unknownWords.FirstOrDefault(unknownWord =>
                unknownWord.FirstLanguageWord == currentWord.FirstLanguageWord &&
                unknownWord.SecondLanguageWord == currentWord.SecondLanguageWord);

            UnknownWordButton.Visible = alreadyExistingUnknownWord == null;
        }
    }
}
