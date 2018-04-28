using System;
using System.Windows.Forms;
using SilverLinguo.Constants;

namespace SilverLinguo.Forms.Helper
{
    public partial class PasswordConfirmationForm : Form
    {
        private readonly string _passwordFormName;
        private readonly string _expectedPassword;
        private readonly Form _formToOpenAfterCorrectPassword;

        public PasswordConfirmationForm(string passwordFormName, string expectedPassword, Form formToOpenAfterCorrectPassword)
        {
            _passwordFormName = passwordFormName;
            _expectedPassword = expectedPassword;
            _formToOpenAfterCorrectPassword = formToOpenAfterCorrectPassword;

            InitializeComponent();
        }

        private void AllWordsVerbalTestPasswordForm_Load(object sender, EventArgs e)
        {
            this.Text = $@"SilverLinguo™ - {_passwordFormName}";

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
            bool passwordMatches = PasswordTextBox.Text.Equals(_expectedPassword);

            if (passwordMatches)
            {
                this.Hide();

                Form allWordsVerbalTestForm = _formToOpenAfterCorrectPassword;
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
