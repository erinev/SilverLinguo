using System;
using System.Windows.Forms;
using SilverLinguo.Enums;
using SilverLinguo.Forms;
using SilverLinguo.Forms.AdminPanel;
using SilverLinguo.Forms.Helper;
using SilverLinguo.Repositories.Models;
using SilverLinguo.Services;
using SilverLinguo.Services.Form;
using SortOrder = SilverLinguo.Repositories.Models.SortOrder;

namespace SilverLinguo
{
    public partial class StartupForm : Form
    {
        private readonly IWordsService _wordsService;

        private WordPair[] _allWords;
        private WordPair[] _unknownWords;

        public StartupForm()
        {
            _wordsService = new WordsService();

            InitializeComponent();
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            SetWordsCountForTestSelection();
        }

        private void SetWordsCountForTestSelection()
        {
            _allWords = _wordsService.GetAllWords(shouldShuffle: false);
            _unknownWords = _wordsService.GetUnknownWords(shouldShuffle: false);

            int allWordsCount = _allWords.Length;
            int unknownWordsCount = _unknownWords.Length;

            CreatedAtLimitNumericUpDown.Maximum = allWordsCount;

            AllWordsPanel.Visible = allWordsCount > 0;
            UnknownWordsPanel.Visible = unknownWordsCount > 0;

            LithuanianLanguageRadioButton.Select();
            ShouldCheckGrammarCheckBox.Checked = false;

            WordsCountLabel.Text = $@"({allWordsCount})";
            UnknownWordsCountLabel.Text = $@"({unknownWordsCount})";
        }

        private void AllWordListSelectionButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (CreatedAtLimitEnablingCheckBox.Checked)
            {
                var limitCriteria = new QueryCriteria
                {
                    OrderByCriteria = new OrderByCriteria { OrderBy = OrderBy.CreatedAt, SortOrder = SortOrder.DESC },
                    Limit = (int?) CreatedAtLimitNumericUpDown.Value
                };

                _allWords = _wordsService.GetAllWords(shouldShuffle: false, queryCriteria: limitCriteria);
            }

            SelectedLanguage selectedLanguage = GetSelectedLanguage();

            if (ShouldCheckGrammarCheckBox.Checked)
            {
                var allWordsGrammarTestForm = new AllWordsGrammarTestForm(selectedLanguage, _allWords);
                allWordsGrammarTestForm.Closed += (s, args) => this.Close();

                allWordsGrammarTestForm.Show();
            }
            else
            {
                string passwordFormName = "Visų žodžių testo (žodžiu) apsauga:";
                string expectedPassword = "memo";
                var allWordsVerbalTestForm = new AllWordsVerbalTestForm(selectedLanguage, _allWords);

                var passwordConfirmationForm = 
                    new PasswordConfirmationForm(passwordFormName, expectedPassword, allWordsVerbalTestForm);
                passwordConfirmationForm.Closed += (s, args) => this.Close();

                passwordConfirmationForm.Show();
            }
        }

        private void UnknownWordsListSelectionButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectedLanguage selectedLanguage = GetSelectedLanguage();

            if (ShouldCheckGrammarCheckBox.Checked)
            {
                var unknownWordsGrammarTestForm = new UnknownWordsGrammarTestForm(selectedLanguage, _unknownWords);
                unknownWordsGrammarTestForm.Closed += (s, args) => this.Close();

                unknownWordsGrammarTestForm.Show();
            }
            else
            {
                var unknownWordsVerbalTestForm = new UnknownWordsVerbalTestForm(selectedLanguage, _unknownWords);
                unknownWordsVerbalTestForm.Closed += (s, args) => this.Close();

                unknownWordsVerbalTestForm.Show();
            }
        }

        private void AdminPanelButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            string passwordFormName = "Redaktoriaus apsauga:";
            string expectedPassword = "linguo";
            var adminPanelForm = new AdminPanelForm();

            var passwordConfirmationForm = new PasswordConfirmationForm(passwordFormName, expectedPassword, adminPanelForm);

            passwordConfirmationForm.Closed += (s, args) => this.Close();

            passwordConfirmationForm.Show();
        }

        private void CreatedAtLimitEnablingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CreatedAtLimitNumericUpDown.Enabled = CreatedAtLimitEnablingCheckBox.Checked;
        }

        private void CreatedAtLimitNumericUpDown_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CreatedAtLimitNumericUpDown.Text))
            {
                CreatedAtLimitNumericUpDown.Text = @"1";
                CreatedAtLimitNumericUpDown.Value = 1;
            }
        }

        private void EndProgramButton_MouseClick(object sender, EventArgs e)
        {
            CommonFormService.CloseProgram();
        }

        private SelectedLanguage GetSelectedLanguage()
        {
            SelectedLanguage selectedLanguage;

            if (LithuanianLanguageRadioButton.Checked)
            {
                selectedLanguage = SelectedLanguage.Lithuanian;
            } 
            else if (EnglishRadioButton.Checked)
            {
                selectedLanguage = SelectedLanguage.English;
            }
            else if (RandomRadioButton.Checked)
            {
                selectedLanguage = SelectedLanguage.Mixed;
            }
            else
            {
                throw new InvalidOperationException("Unknown language selected");
            }

            return selectedLanguage;
        }
    }
}
