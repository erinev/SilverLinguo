using System;
using System.Collections.Generic;
using System.Diagnostics;
using Words.Test.Enums;

namespace Words.Test.Forms
{
    public partial class TestResultsForAllWordsForm : BaseTestResultsForm
    {
        private readonly int _totalWordsCountInTest;
        private readonly List<string> _learnedWordsForStats;
        private readonly List<string> _knownWords;
        private readonly List<string> _newUnknownWords;
        private readonly List<string> _unknownWords;

        public TestResultsForAllWordsForm(
            SelectedLanguage selectedLanguage, TestType testType, Stopwatch elapsedTimeStopwatch,
            int totalWordsCountInTest, List<string> learnedWordsForStats, List<string> knownWords, 
            List<string> newUnknownWords, List<string> unknownWords) 
            : base(selectedLanguage, testType, elapsedTimeStopwatch)
        {
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
            }
            
            if (_unknownWords != null)
            {
                wordsProgressCount += _unknownWords.Count;
                UnknownWordsCountLinkLabel.Enabled = _unknownWords.Count > 0;
                UnknownWordsCountLinkLabel.Text = $@"{_unknownWords.Count} / {_totalWordsCountInTest}";
            }

            TestProgressLabel.Text = $@"{wordsProgressCount} / {_totalWordsCountInTest}";
        }
        
        private void LearnedWordsCountLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Nauji išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _learnedWordsForStats);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void KnownWordsCountLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Žinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _knownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void NewUnknownWordsCountLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Nauji nežinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _newUnknownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }

        private void UnknownWordsCountLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Vis dar nežinomi žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _unknownWords);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }
    }
}
