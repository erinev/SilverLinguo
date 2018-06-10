using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Enums;
using SilverLinguo.Forms.Helper;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Forms.TestResults
{
    public partial class TestResultsForAllWordsForm : BaseTestResultsForm
    {
        private readonly SelectedLanguage _selectedLanguage;
        private readonly TestType _testType;
        private readonly int _totalWordsCountInTest;
        private readonly List<WordPair> _learnedWordsForStats;
        private readonly List<WordPair> _knownWords;
        private readonly List<WordPair> _newUnknownWords;
        private readonly List<WordPair> _unknownWords;

        public TestResultsForAllWordsForm(
            SelectedLanguage selectedLanguage, TestType testType, Stopwatch elapsedTimeStopwatch,
            int totalWordsCountInTest, List<WordPair> learnedWordsForStats, List<WordPair> knownWords, 
            List<WordPair> newUnknownWords, List<WordPair> unknownWords) 
            : base(selectedLanguage, testType, elapsedTimeStopwatch)
        {
            _selectedLanguage = selectedLanguage;
            _testType = testType;
            _totalWordsCountInTest = totalWordsCountInTest;
            _learnedWordsForStats = learnedWordsForStats;
            _knownWords = knownWords;
            _newUnknownWords = newUnknownWords;
            _unknownWords = unknownWords;

            InitializeComponent();
        }

        private void TestResultsForAllWordsForm_Load(object sender, EventArgs e)
        {
            WordsTypeLabel.Text = @"Visi";

            int wordsProgressCount = 0;

            if (_learnedWordsForStats != null)
            {
                wordsProgressCount += _learnedWordsForStats.Count;
                LearnedWordsCountLinkLabel.Enabled = _learnedWordsForStats.Count > 0;
                LearnedWordsCountLinkLabel.Text = $@"{_learnedWordsForStats.Count} / {_totalWordsCountInTest}";
            }
            
            if (_knownWords != null)
            {
                wordsProgressCount += _knownWords.Count;
                KnownWordsCountLinkLabel.Enabled = _knownWords.Count > 0;
                KnownWordsCountLinkLabel.Text = $@"{_knownWords.Count} / {_totalWordsCountInTest}";
            }

            if (_newUnknownWords != null)
            {
                wordsProgressCount += _newUnknownWords.Count;
                NewUnknownWordsCountLinkLabel.Enabled = _newUnknownWords.Count > 0;
                NewUnknownWordsCountLinkLabel.Text = $@"{_newUnknownWords.Count} / {_totalWordsCountInTest}";
                TestNewUnknownWordsButton.Enabled = _newUnknownWords.Count > 0;
            }
            
            if (_unknownWords != null)
            {
                wordsProgressCount += _unknownWords.Count;
                UnknownWordsCountLinkLabel.Enabled = _unknownWords.Count > 0;
                UnknownWordsCountLinkLabel.Text = $@"{_unknownWords.Count} / {_totalWordsCountInTest}";
                TestUnknownWordsButton.Enabled = _unknownWords.Count > 0;
            }

            TestProgressLabel.Text = $@"{wordsProgressCount} / {_totalWordsCountInTest}";
        }
        
        private void LearnedWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Nauji išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _learnedWordsForStats);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void KnownWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Žinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _knownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void NewUnknownWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Nauji nežinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _newUnknownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void UnknownWordsCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Vis dar nežinomi žodžiai:";
            var showWordsListByTypeForm =
                new ShowWordsListByTypeForm(showWordsFormName, _unknownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void TestNewUnknownWordsButton_MouseClick(object sender, EventArgs e)
        {
            StartTemporaryTestForSelectedResultWords(_newUnknownWords);
        }

        private void TestUnknownWordsButton_MouseClick(object sender, EventArgs e)
        {
            StartTemporaryTestForSelectedResultWords(_unknownWords);
        }

        private void StartTemporaryTestForSelectedResultWords(IEnumerable<WordPair> wordsToTest)
        {
            var wordsToTestArray = wordsToTest.ToArray();

            this.Hide();

            switch (_testType)
            {
                case TestType.Grammar:
                    var unknownWordsGrammarTestForm =
                        new UnknownWordsGrammarTestForm(_selectedLanguage, wordsToTestArray);
                    unknownWordsGrammarTestForm.Closed += (s, args) => this.Close();

                    unknownWordsGrammarTestForm.Show();
                    break;
                case TestType.Verbal:
                    var unknownWordsVerbalTestForm = new UnknownWordsVerbalTestForm(_selectedLanguage, wordsToTestArray);
                    unknownWordsVerbalTestForm.Closed += (s, args) => this.Close();

                    unknownWordsVerbalTestForm.Show();
                    break;
                default:
                    throw new Exception($"Unknown TestType: '{_testType}' detected");
            }
        }
    }
}
