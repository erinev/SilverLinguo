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
    public partial class WordsTestForm : Form
    {
        private static CurrentLanguage _currentLanguage;
        private static int _currentWordPairIndex;
        private static int _currentWordPairIndexForProgress = 1;

        private readonly Bitmap _englishFlagBitmap = Properties.Resources.EnglishFlag;
        private readonly Bitmap _lithuanianFlagBitmap = Properties.Resources.LithuanianFlag;
        private static WordPair[] _words;
        private static IList<WordPair> _unknownWords = new List<WordPair>();
        private readonly string _progressLabelText = "{0} / {1}";

        public WordsTestForm()
        {
            _words = WordsRepository.GetWordsForTest();

            InitializeComponent();

            _currentLanguage = CurrentLanguage.Lithuanian;

            LtWordLabel.Visible = true;
            EnWordLabel.Visible = false;

            ChangeLanguageButton.Image = _englishFlagBitmap;
        }

        private void VocabularyForm_Load(object sender, EventArgs e)
        {
            ProgressLabel.Text = string.Format(_progressLabelText, _currentWordPairIndexForProgress, _words.Length);

            LtWordLabel.Text = _words[_currentWordPairIndex].LithuanianWord;
            EnWordLabel.Text = _words[_currentWordPairIndex].EnglishWord;
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

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            if (_currentWordPairIndex + 1 < _words.Length)
            {
                ++_currentWordPairIndexForProgress;
                ProgressLabel.Text = string.Format(_progressLabelText, _currentWordPairIndexForProgress, _words.Length);

                int nextWordIndex = ++_currentWordPairIndex;

                LtWordLabel.Text = _words[nextWordIndex].LithuanianWord;
                EnWordLabel.Text = _words[nextWordIndex].EnglishWord;
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

        private void UnknownWordButton_Click(object sender, EventArgs e)
        {
            WordPair unknownWordCandidate = _words[_currentWordPairIndex];

            WordPair existingUnknownWord =
                _unknownWords.FirstOrDefault(unknownWord =>
                    unknownWord.LithuanianWord == unknownWordCandidate.LithuanianWord &&
                    unknownWord.EnglishWord == unknownWordCandidate.EnglishWord);

            if (existingUnknownWord == null)
            {
                _unknownWords.Add(
                    new WordPair
                    {
                        Id = _unknownWords.Count + 1,
                        LithuanianWord = unknownWordCandidate.LithuanianWord,
                        EnglishWord = unknownWordCandidate.EnglishWord
                    }
                );
            }

            UnknownWordsCountLabel.Text = _unknownWords.Count.ToString();
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
