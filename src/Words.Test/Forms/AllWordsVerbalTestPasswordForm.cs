using System;
using System.Windows.Forms;
using Words.Test.Enums;

namespace Words.Test.Forms
{
    public partial class AllWordsVerbalTestPasswordForm : Form
    {
        private readonly SelectedLanguage _selectedLanguage;

        private readonly string password = "memo";

        public AllWordsVerbalTestPasswordForm(SelectedLanguage selectedLanguage)
        {
            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void AllWordsVerbalTestPasswordForm_Load(object sender, EventArgs e)
        {
            IncorrectPasswordLabel.Visible = false;
            ValidatePasswordButton.Visible = false;
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidatePasswordButton.Visible)
            {
                ValidatePasswordButton.Visible = true;
            }

            if (IncorrectPasswordLabel.Visible)
            {
                IncorrectPasswordLabel.Visible = false;
            }
        }

        private void ValidatePasswordButton_Click(object sender, EventArgs e)
        {
            bool passwordMatches = PasswordTextBox.Text.Equals(password);

            if (passwordMatches)
            {
                this.Hide();

                var allWordsVerbalTestForm = new AllWordsVerbalTestForm(_selectedLanguage);
                allWordsVerbalTestForm.Closed += (s, args) => this.Close();

                allWordsVerbalTestForm.Show();
            }
            else
            {
                IncorrectPasswordLabel.Visible = true;
            }
        }

        private void BackToTestSelectionButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }
    }
}
