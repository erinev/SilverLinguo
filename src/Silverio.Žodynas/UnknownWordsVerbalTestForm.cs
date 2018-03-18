using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Models;
using Silverio.Žodynas.Services;

namespace Silverio.Žodynas
{
    public partial class UnknownWordsVerbalTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private static SelectedLanguage _selectedLanguage;

        private static int _currentUnknownWordPairId;

        private static WordPair[] _unknownWords;
        private static IList<WordPair> _learnedWords = new List<WordPair>();

        public UnknownWordsVerbalTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();

            SetSelectedLanguage(_selectedLanguage);
        }

        private void UnknownWordsTestForm_Load(object sender, EventArgs e)
        {
            ShowLearnedWordsButton.Visible = false;

            _unknownWords = _wordsService.GetRandomlySortedUnknownWords();

            _currentUnknownWordPairId = _unknownWords[0].Id;

            ProgressLabel.Text = _unknownWords.Length.ToString();

            WordPair firstUnknownWord = _unknownWords.First();
            LtWordTextBox.Text = firstUnknownWord.LithuanianWord;
            EnWordTextBox.Text = firstUnknownWord.EnglishWord;
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

            ShowLearnedWordsButton.Visible = _learnedWords.Count > 0;
            IDontKnowTheWordButton.Visible = true;

            if (_unknownWords.Length > 0)
            {
                ProgressLabel.Text = _unknownWords.Length.ToString();

                WordPair nextUnknownWord = _unknownWords.First();

                LtWordTextBox.Text = nextUnknownWord.LithuanianWord;
                EnWordTextBox.Text = nextUnknownWord.EnglishWord;
                _currentUnknownWordPairId = nextUnknownWord.Id;
            }
            else
            {
                OpenStartupForm();
            }

            switch (_selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    LtWordTextBox.Visible = false;
                    break;
                case SelectedLanguage.English:
                    EnWordTextBox.Visible = false;
                    break;
                case SelectedLanguage.Random:
                    bool currentEnLabelVisibleState = EnWordTextBox.Visible;
                    bool currentLtLabelVisibleState = LtWordTextBox.Visible;
                    EnWordTextBox.Visible = !currentEnLabelVisibleState;
                    LtWordTextBox.Visible = !currentLtLabelVisibleState;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void IDontKnowTheWordButton_Click(object sender, EventArgs e)
        {
            IDontKnowTheWordButton.Visible = false;

            EnWordTextBox.Visible = true;
            LtWordTextBox.Visible = true;

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
                LtWordTextBox.Visible = false;
                EnWordTextBox.Visible = true;
            }
            else if (selectedLanguage == SelectedLanguage.English)
            {
                LtWordTextBox.Visible = true;
                EnWordTextBox.Visible = false;
            }
            else
            {
                LtWordTextBox.Visible = false;
                EnWordTextBox.Visible = true;
            }
        }

        private void OpenStartupForm()
        {
            this.Hide();
            
            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }

        private void ShowLearnedWordsButton_Click(object sender, EventArgs e)
        {
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.LithuanianWord + " - " + learnedWord.EnglishWord).ToList();

            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, learnedWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }
    }
}
