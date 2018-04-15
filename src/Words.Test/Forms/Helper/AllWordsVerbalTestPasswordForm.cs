using System;
using System.Windows.Forms;
using Words.Test.Constants;
using Words.Test.Enums;

namespace Words.Test.Forms.Helper
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

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs keyEventArgs)
        {
            //TODO: cleanup or proper handle Enter key (now it causes one word as entered in opened form)
            /*if (keyEventArgs.KeyChar == KeyCodes.Enter)
            {
                if (ValidatePasswordButton.Visible)
                {
                    ValidateAndHandlePassword();
                }
                
                keyEventArgs.Handled = true;
            }*/
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
            this.Hide();

            var startupForm = new StartupForm();
            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }
    }
}
