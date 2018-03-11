using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Models;
using Silverio.Žodynas.Repositories;
using Silverio.Žodynas.Services;

namespace Silverio.Žodynas
{
    public partial class UnknownWordsTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private static SelectedLanguage _selectedLanguage;

        private static int _currentUnknownWordPairIndex;
        private static int _currentUnknownWordPairId;

        private readonly Bitmap _englishFlagBitmap = Properties.Resources.EnglishFlag;
        private readonly Bitmap _lithuanianFlagBitmap = Properties.Resources.LithuanianFlag;

        private static WordPair[] _unknownWords;
        private static IList<WordPair> _learnedWords = new List<WordPair>();

        public UnknownWordsTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void UnknownWordsTestForm_Load(object sender, EventArgs e)
        {
            _unknownWords = _wordsService.GetRandomlySortedUnknownWords();

            LtWordLabel.Visible = true;
            EnWordLabel.Visible = false;

            NextWordButton.Visible = true;

            _currentUnknownWordPairId = _unknownWords[0].Id;

            ProgressLabel.Text = _unknownWords.Length.ToString();

            LtWordLabel.Text = _unknownWords[_currentUnknownWordPairIndex].LithuanianWord;
            EnWordLabel.Text = _unknownWords[_currentUnknownWordPairIndex].EnglishWord;
        }

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            if (IDontKnowTheWordButton.Visible)
            {
                _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();
            }
            
            IDontKnowTheWordButton.Visible = true;

            if (_unknownWords.Length > 0)
            {
                ProgressLabel.Text = _unknownWords.Length.ToString();

                WordPair nextUnknownWord = _unknownWords.First();

                LtWordLabel.Text = nextUnknownWord.LithuanianWord;
                EnWordLabel.Text = nextUnknownWord.EnglishWord;
                _currentUnknownWordPairId = nextUnknownWord.Id;
            }
            else
            {
                OpenStartupForm();
            }

            switch (_selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    EnWordLabel.Visible = false;
                    break;
                case SelectedLanguage.English:
                    LtWordLabel.Visible = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void IDontKnowTheWordButton_Click(object sender, EventArgs e)
        {
            IDontKnowTheWordButton.Visible = false;

            EnWordLabel.Visible = true;
            LtWordLabel.Visible = true;

            var unknownWordToMove = _unknownWords[0];

            _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();
            var unknownWordsWithoutUnknownWord = _unknownWords.ToList();
            unknownWordsWithoutUnknownWord.Add(unknownWordToMove);
            _unknownWords = unknownWordsWithoutUnknownWord.ToArray();

            /*WordPair learnedWordCandidate = _unknownWords[_currentUnknownWordPairIndex];

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

            LearnedWordsCountLabel.Text = _learnedWords.Count.ToString();

            IDontKnowTheWordButton.Visible = false;*/
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenStartupForm()
        {
            this.Hide();
            
            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }
    }
}
