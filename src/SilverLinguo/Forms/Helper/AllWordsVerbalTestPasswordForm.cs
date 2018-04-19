using System;
using System.Windows.Forms;
using SilverLinguo.Constants;
using SilverLinguo.Enums;

namespace SilverLinguo.Forms.Helper
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

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ValidatePasswordButton.Visible && !String.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                ValidatePasswordButton.Visible = true;
            }
            else if (ValidatePasswordButton.Visible && String.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                ValidatePasswordButton.Visible = false;
            }

            if (IncorrectPasswordLabel.Visible)
            {
                IncorrectPasswordLabel.Visible = false;
            }
        }

        private void PasswordTextBox_KeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyValue == KeyCodes.Enter)
            {
                if (ValidatePasswordButton.Visible)
                {
                    ValidateAndHandlePassword();
                }

                keyEventArgs.Handled = true;
            }
        }

        private void ValidatePasswordButton_Click(object sender, EventArgs e)
        {
            ValidateAndHandlePassword();
        }

        private void ValidateAndHandlePassword()
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
            GetBackToStartupForm();
        }

        private void GetBackToStartupForm()
        {
            this.Hide();

            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }
    }
}
