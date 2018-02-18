using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Models;
using Silverio.Žodynas.Repositories;

namespace Silverio.Žodynas
{
    public partial class UnknownWordsTestForm : Form
    {
        private static CurrentLanguage _currentLanguage;
        private static int _currentUnknownWordPairIndex;
        private static int _currentUnknownWordPairIndexForProgress = 1;

        private readonly Bitmap _englishFlagBitmap = Properties.Resources.EnglishFlag;
        private readonly Bitmap _lithuanianFlagBitmap = Properties.Resources.LithuanianFlag;
        private static WordPair[] _unknownWords;
        private static IList<WordPair> _learnedWords = new List<WordPair>();
        private readonly string _progressLabelText = "{0} / {1}";

        public UnknownWordsTestForm()
        {
            _unknownWords = WordsRepository.GetUnknownWordsForTest();

            InitializeComponent();

            _currentLanguage = CurrentLanguage.Lithuanian;

            LtWordLabel.Visible = true;
            EnWordLabel.Visible = false;

            NextWordButton.Visible = true;
            PreviousWordButton.Visible = false;

            ChangeLanguageButton.Image = _englishFlagBitmap;
        }

        private void UnknownWordsTestForm_Load(object sender, EventArgs e)
        {
            ProgressLabel.Text = string.Format(_progressLabelText, _currentUnknownWordPairIndexForProgress, _unknownWords.Length);

            LtWordLabel.Text = _unknownWords[_currentUnknownWordPairIndex].LithuanianWord;
            EnWordLabel.Text = _unknownWords[_currentUnknownWordPairIndex].EnglishWord;
        }

        private void ChangeLanguageButton_Click(object sender, EventArgs e)
        {
            Bitmap languageIcon;

            if (_currentLanguage == CurrentLanguage.Lithuanian)
            {
                languageIcon = _lithuanianFlagBitmap;
                _currentLanguage = CurrentLanguage.English;
                EnWordLabel.Visible = true;
            }
            else if (_currentLanguage == CurrentLanguage.English)
            {
                languageIcon = _englishFlagBitmap;
                _currentLanguage = CurrentLanguage.Lithuanian;
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
            if (_currentUnknownWordPairIndex - 1 == 0)
            {
                PreviousWordButton.Visible = false;
            }
            else if (_currentUnknownWordPairIndex < _unknownWords.Length)
            {
                NextWordButton.Visible = true;
            }

            if (_currentUnknownWordPairIndex > 0)
            {
                --_currentUnknownWordPairIndexForProgress;
                ProgressLabel.Text = string.Format(_progressLabelText, _currentUnknownWordPairIndexForProgress, _unknownWords.Length);

                int previousWordIndex = --_currentUnknownWordPairIndex;

                LtWordLabel.Text = _unknownWords[previousWordIndex].LithuanianWord;
                EnWordLabel.Text = _unknownWords[previousWordIndex].EnglishWord;
            }

            if (_currentLanguage == CurrentLanguage.Lithuanian)
            {
                EnWordLabel.Visible = false;
            }
            else if (_currentLanguage == CurrentLanguage.English)
            {
                LtWordLabel.Visible = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            if (_currentUnknownWordPairIndex + 2 == _unknownWords.Length)
            {
                NextWordButton.Visible = false;
            }
            else if (_currentUnknownWordPairIndex >= 0)
            {
                PreviousWordButton.Visible = true;
            }

            if (_currentUnknownWordPairIndex + 1 < _unknownWords.Length)
            {
                ++_currentUnknownWordPairIndexForProgress;
                ProgressLabel.Text = string.Format(_progressLabelText, _currentUnknownWordPairIndexForProgress, _unknownWords.Length);

                int nextWordIndex = ++_currentUnknownWordPairIndex;

                LtWordLabel.Text = _unknownWords[nextWordIndex].LithuanianWord;
                EnWordLabel.Text = _unknownWords[nextWordIndex].EnglishWord;
            }

            if (_currentLanguage == CurrentLanguage.Lithuanian)
            {
                EnWordLabel.Visible = false;
            }
            else if (_currentLanguage == CurrentLanguage.English)
            {
                LtWordLabel.Visible = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void LearnedWordButton_Click(object sender, EventArgs e)
        {
            WordPair learnedWordCandidate = _unknownWords[_currentUnknownWordPairIndex];

            WordPair existingLearnedWord =
                _learnedWords.FirstOrDefault(learnedWord =>
                    learnedWord.LithuanianWord == learnedWordCandidate.LithuanianWord &&
                    learnedWord.EnglishWord == learnedWordCandidate.EnglishWord);

            if (existingLearnedWord == null)
            {
                _learnedWords.Add(
                    new WordPair
                    {
                        Id = _learnedWords.Count + 1,
                        LithuanianWord = learnedWordCandidate.LithuanianWord,
                        EnglishWord = learnedWordCandidate.EnglishWord
                    }
                );
            }

            UnknownWordsCountLabel.Text = _learnedWords.Count.ToString();
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
