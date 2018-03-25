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
    public partial class UnknownWordsVerbalTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private readonly SelectedLanguage _selectedLanguage;

        private int _currentUnknownWordPairId;

        private WordPair[] _unknownWords;
        private readonly IList<WordPair> _learnedWords = new List<WordPair>();
        private int _startingCountOfUnknownWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public UnknownWordsVerbalTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void UnknownWordsTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);
            VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox);

            NextWordButton.Select();

            _unknownWords = _wordsService.GetRandomlySortedUnknownWords();
            _startingCountOfUnknownWords = _unknownWords.Length;

            _currentUnknownWordPairId = _unknownWords[0].Id;

            ProgressLabel.Text = _unknownWords.Length.ToString();
            LearnedWordsCountLinkLabel.Enabled = false;

            WordPair firstUnknownWord = _unknownWords.First();
            FirstLanguageWordTextBox.Text = firstUnknownWord.FirstLanguageWord;
            SecondLanguageWordTextBox.Text = firstUnknownWord.SecondLanguageWord;
        }

        private void UnknownWordsVerbalTestForm_KeyPress(object sender, KeyPressEventArgs e)
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
                    HandleIDontKnowWordButtonClickedEvent();
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
                _learnedWords.Add(_unknownWords.First(uw => uw.Id == _currentUnknownWordPairId));
                LearnedWordsCountLinkLabel.Text = _learnedWords.Count.ToString();

                _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();
            }
            else
            {
                VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox, SecondLanguageWordTextBox);
            }

            LearnedWordsCountLinkLabel.Enabled = _learnedWords.Count > 0;
            IDontKnowTheWordButton.Visible = true;

            if (_unknownWords.Length > 0)
            {
                ProgressLabel.Text = _unknownWords.Length.ToString();

                WordPair nextUnknownWord = _unknownWords.First();

                FirstLanguageWordTextBox.Text = nextUnknownWord.FirstLanguageWord;
                SecondLanguageWordTextBox.Text = nextUnknownWord.SecondLanguageWord;
                _currentUnknownWordPairId = nextUnknownWord.Id;
            }
            else
            {
                HandleFinishedTest();
            }

            switch (_selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    FirstLanguageWordTextBox.Visible = false;
                    break;
                case SelectedLanguage.English:
                    SecondLanguageWordTextBox.Visible = false;
                    break;
                case SelectedLanguage.Mixed:
                    bool currentEnLabelVisibleState = SecondLanguageWordTextBox.Visible;
                    bool currentLtLabelVisibleState = FirstLanguageWordTextBox.Visible;
                    SecondLanguageWordTextBox.Visible = !currentEnLabelVisibleState;
                    FirstLanguageWordTextBox.Visible = !currentLtLabelVisibleState;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void IDontKnowTheWordButton_Click(object sender, EventArgs e)
        {
            HandleIDontKnowWordButtonClickedEvent();
        }

        private void HandleIDontKnowWordButtonClickedEvent()
        {
            IDontKnowTheWordButton.Visible = false;
            NextWordButton.Focus();

            SecondLanguageWordTextBox.Visible = true;
            FirstLanguageWordTextBox.Visible = true;

            var unknownWordToMove = _unknownWords[0];

            _unknownWords = _unknownWords.Where(unknownWord => unknownWord.Id != _currentUnknownWordPairId).ToArray();

            var unknownWordsWithoutUnknownWord = _unknownWords.ToList();
            unknownWordsWithoutUnknownWord.Add(unknownWordToMove);

            _unknownWords = unknownWordsWithoutUnknownWord.ToArray();
        }

        private void EndTestButton_Click(object sender, EventArgs e)
        {
            HandleFinishedTest();
        }

        private void LearnedWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.FirstLanguageWord + " - " + learnedWord.SecondLanguageWord).ToList();

            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, learnedWordsToDisplay);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void HandleFinishedTest()
        {
            _stopWatch.Stop();

            this.Hide();
            
            List<string> learnedWordsToDisplay =
                _learnedWords.Select(learnedWord => learnedWord.FirstLanguageWord + " - " + learnedWord.SecondLanguageWord).ToList();
            var testResultsForm = new TestResultsForm(_selectedLanguage, TestType.Verbal, WordsType.UnknownWords, _stopWatch, _startingCountOfUnknownWords, learnedWordsToDisplay);
            testResultsForm.Closed += (s, args) => this.Close();

            testResultsForm.Show();
        }
    }
}
