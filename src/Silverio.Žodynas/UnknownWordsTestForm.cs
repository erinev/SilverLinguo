using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Models;
using Silverio.Žodynas.Services;

namespace Silverio.Žodynas
{
    public partial class UnknownWordsTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private static SelectedLanguage _selectedLanguage;
        private static bool _shouldCheckGrammar;

        private static int _currentUnknownWordPairId;

        private static WordPair[] _unknownWords;
        private static IList<WordPair> _learnedWords = new List<WordPair>();

        public UnknownWordsTestForm(SelectedLanguage selectedLanguage, bool shouldCheckGrammar)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;
            _shouldCheckGrammar = shouldCheckGrammar;

            InitializeComponent();

            SetSelectedLanguage(_selectedLanguage);
            ConfigureGrammarChecking(_shouldCheckGrammar);
        }

        private void UnknownWordsTestForm_Load(object sender, EventArgs e)
        {
            _unknownWords = _wordsService.GetRandomlySortedUnknownWords();

            _currentUnknownWordPairId = _unknownWords[0].Id;

            ProgressLabel.Text = _unknownWords.Length.ToString();

            WordPair firstUnknownWord = _unknownWords.First();
            LtWordTextBox.Text = LtWordTextBox.ReadOnly ? firstUnknownWord.LithuanianWord : String.Empty;
            EnWordTextBox.Text = EnWordTextBox.ReadOnly ? firstUnknownWord.EnglishWord : String.Empty;
        }

        private void NextWordButton_Click(object sender, EventArgs e)
        {
            if (IDontKnowTheWordButton.Visible)
            {
                _learnedWords.Add(_unknownWords.First(uw => uw.Id == _currentUnknownWordPairId));
                LearnedWordsCountLabel.Text = _learnedWords.Count.ToString();
                
                _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();
            }
            else
            {
                SetSelectedLanguage(_selectedLanguage);
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
                case SelectedLanguage.Random:
                    bool currentEnLabelVisibleState = EnWordLabel.Visible;
                    bool currentLtLabelVisibleState = LtWordLabel.Visible;
                    EnWordLabel.Visible = !currentEnLabelVisibleState;
                    LtWordLabel.Visible = !currentLtLabelVisibleState;
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
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetSelectedLanguage(SelectedLanguage selectedLanguage)
        {
            if (selectedLanguage == SelectedLanguage.Lithuanian)
            {
                LtWordTextBox.ReadOnly = true;
                EnWordTextBox.ReadOnly = false;
            }
            else if (selectedLanguage == SelectedLanguage.English)
            {
                LtWordTextBox.ReadOnly = false;
                EnWordTextBox.ReadOnly = true;
            }
            else
            {
                LtWordTextBox.ReadOnly = true;
                EnWordTextBox.ReadOnly = false;
            }
        }

        private void ConfigureGrammarChecking(bool shouldCheckGrammar)
        {
            if (shouldCheckGrammar)
            {
                NextWordButton.Visible = false;
                IDontKnowTheWordButton.Visible = false;
            }
            else
            {
                NextWordButton.Visible = true;
                IDontKnowTheWordButton.Visible = true;
            }
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
