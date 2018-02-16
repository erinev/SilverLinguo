using System;
using System.Drawing;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Models;

namespace Silverio.Žodynas
{
    public partial class VocabularyForm : Form
    {
        private static CurrentLanguage _currentLanguage;
        private static int _currentWordPairIndex;
        private static int _currentWordPairIndexForProgress = 1;

        private readonly Bitmap _englishFlagBitmap = Properties.Resources.EnglishFlag;
        private readonly Bitmap _lithuanianFlagBitmap = Properties.Resources.LithuanianFlag;
        private static WordPair[] _words;
        private readonly string _progressLabelText = "{0} / {1}";

        public VocabularyForm()
        {
            InitializeComponent();

            _currentLanguage = CurrentLanguage.Lithuanian;

            LtWordLabel.Visible = true;
            EnWordLabel.Visible = false;

            ChangeLanguageButton.Image = _englishFlagBitmap;
        }

        private void VocabularyForm_Load(object sender, EventArgs e)
        {
            InitializeMockWords();

            ProgressLabel.Text = string.Format(_progressLabelText, _currentWordPairIndexForProgress, _words.Length);

            LtWordLabel.Text = _words[_currentWordPairIndex].LithuanianWord;
            EnWordLabel.Text = _words[_currentWordPairIndex].EnglishWord;
        }

        private void InitializeMockWords()
        {
            _words = new[]
            {
                new WordPair {Id = 1, LithuanianWord = "Šuo", EnglishWord = "Dog"},
                new WordPair {Id = 2, LithuanianWord = "Katė", EnglishWord = "Cat"},
                new WordPair {Id = 3, LithuanianWord = "Namas", EnglishWord = "House"},
                new WordPair {Id = 4, LithuanianWord = "Kalnas", EnglishWord = "Mountain"},
                new WordPair {Id = 5, LithuanianWord = "Spalva", EnglishWord = "Color"},
            };
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

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const int CpNocloseButton = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CpNocloseButton;
                return myCp;
            }
        }
    }
}
