using System;
using System.Diagnostics;
using System.Windows.Forms;
using SilverLinguo.Enums;

namespace SilverLinguo.Forms.TestResults
{
    public partial class BaseTestResultsForm : Form
    {
        private readonly SelectedLanguage _selectedLanguage;
        private readonly TestType _testType;
        private readonly Stopwatch _elapsedTimeStopWatch;

        protected BaseTestResultsForm(SelectedLanguage selectedLanguage, TestType testType, Stopwatch elapsedTimeStopWatch)
        {
            _selectedLanguage = selectedLanguage;
            _testType = testType;
            _elapsedTimeStopWatch = elapsedTimeStopWatch;

            InitializeComponent();
        }

        [Obsolete("Designer initializes parameterless contructor in design view", true)]
        protected BaseTestResultsForm()
        {
        }

        private void BaseTestResultsForm_Load(object sender, EventArgs e)
        {
            switch (_selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    SelectedLanguageLabel.Text = @"Lietuvių";
                    break;
                case SelectedLanguage.English:
                    SelectedLanguageLabel.Text = @"Anglų";
                    break;
                case SelectedLanguage.Mixed:
                    SelectedLanguageLabel.Text = @"Maišyta";
                    break;
                default:
                    SelectedLanguageLabel.Text = @"Nenustatyta";
                    break;
            }

            switch (_testType)
            {
                case TestType.Grammar:
                    SelectedTestTypeLabel.Text = @"Raštu";
                    break;
                case TestType.Verbal:
                    SelectedTestTypeLabel.Text = @"Žodžiu";
                    break;
                default:
                    SelectedTestTypeLabel.Text = @"Nenustatyta";
                    break;
            }

            TimeSpan timeSpan = _elapsedTimeStopWatch.Elapsed;
            ElapsedTimeLabel.Text = $@"{timeSpan.Hours}h {timeSpan.Minutes}m {timeSpan.Seconds}s";
        }
            

        private void StartDifferentTestButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }

        private void EndProgramButton_MouseClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
