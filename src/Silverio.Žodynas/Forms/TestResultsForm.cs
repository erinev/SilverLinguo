using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;

namespace Silverio.Žodynas.Forms
{
    public partial class TestResultsForm : Form
    {
        public TestResultsForm(SelectedLanguage selectedLanguage, TestType testType, WordsType wordsType, Stopwatch elapsedTime, List<string> wordsForStats)
        {
            InitializeComponent();
        }

        private void WordsStatsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void StartDifferentTestButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            
            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }

        private void EndProgramButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
