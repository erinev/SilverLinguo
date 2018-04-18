using System;
using System.Windows.Forms;
using SilverLinguo.Enums;
using SilverLinguo.Forms;
using SilverLinguo.Forms.AdminPanel;
using SilverLinguo.Forms.Helper;
using SilverLinguo.Repositories;
using SilverLinguo.Services;

namespace SilverLinguo
{
    public partial class StartupForm : Form
    {
        private readonly IWordsService _wordsService;

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
            int allWordsCount = _wordsService.GetAllWordsCount();
            int unknownWordsCount = _wordsService.GetUnknownWordsCount();

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

            SelectedLanguage selectedLanguage = GetSelectedLanguage();

            if (ShouldCheckGrammarCheckBox.Checked)
            {
                var allWordsGrammarTestForm = new AllWordsGrammarTestForm(selectedLanguage);
                allWordsGrammarTestForm.Closed += (s, args) => this.Close();

                allWordsGrammarTestForm.Show();
            }
            else
            {
                var allWordsVerbalTestPasswordForm = new AllWordsVerbalTestPasswordForm(selectedLanguage);
                allWordsVerbalTestPasswordForm.Closed += (s, args) => this.Close();

                allWordsVerbalTestPasswordForm.Show();
            }
        }

        private void UnknownWordsListSelectionButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectedLanguage selectedLanguage = GetSelectedLanguage();

            if (ShouldCheckGrammarCheckBox.Checked)
            {
                var unknownWordsGrammarTestForm = new UnknownWordsGrammarTestForm(selectedLanguage);
                unknownWordsGrammarTestForm.Closed += (s, args) => this.Close();

                unknownWordsGrammarTestForm.Show();
            }
            else
            {
                var unknownWordsVerbalTestForm = new UnknownWordsVerbalTestForm(selectedLanguage);
                unknownWordsVerbalTestForm.Closed += (s, args) => this.Close();

                unknownWordsVerbalTestForm.Show();
            }
        }

        private void EndProgramButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AdminPanelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            var adminPanelForm = new AdminPanelForm();

            adminPanelForm.Closed += (s, args) => this.Close();

            adminPanelForm.Show();
        }
    }
}
