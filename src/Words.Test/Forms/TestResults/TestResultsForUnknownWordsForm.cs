using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Words.Test.Enums;
using Words.Test.Forms.Helper;

namespace Words.Test.Forms.TestResults
{
    public partial class TestResultsForUnknownWordsForm : BaseTestResultsForm
    {
        private readonly int _totalWordsCountInTest;
        private readonly List<string> _lernedWordsForStats;

        public TestResultsForUnknownWordsForm(
            SelectedLanguage selectedLanguage, TestType testType, Stopwatch elapsedTimeStopWatch, 
            int totalWordsCountInTest, List<string> lernedWordsForStats) 
            : base(selectedLanguage, testType, elapsedTimeStopWatch)
        {
            _totalWordsCountInTest = totalWordsCountInTest;
            _lernedWordsForStats = lernedWordsForStats;

            InitializeComponent();
        }

        private void TestResultsForUnknownWordsForm_Load(object sender, EventArgs e)
        {
            WordsTypeLabel.Text = @"Nežinomi";

            if (_lernedWordsForStats != null)
            {
                LearnedWordsStatsLinkLabel.Enabled = _lernedWordsForStats.Count > 0;
                LearnedWordsStatsLinkLabel.Text = $@"{_lernedWordsForStats.Count} / {_totalWordsCountInTest}";
            }
        }

        private void LearnedWordsStatsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string showWordsFormName = "Išmokti žodžiai:";
            var showWordsListByTypeForm = new ShowWordsListByTypeForm(showWordsFormName, _lernedWordsForStats);

            showWordsListByTypeForm.Activate();
            showWordsListByTypeForm.ShowDialog(this);
        }
    }
}
