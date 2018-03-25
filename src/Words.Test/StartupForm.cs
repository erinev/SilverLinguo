using System;
using System.Windows.Forms;
using Words.Test.Enums;
using Words.Test.Forms;
using Words.Test.Services;

namespace Words.Test
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
                var allWordsVerbalTestForm = new AllWordsVerbalTestForm(selectedLanguage);
                allWordsVerbalTestForm.Closed += (s, args) => this.Close();

                allWordsVerbalTestForm.Show();
            }
            else
            {
                var allWordsVerbalTestForm = new AllWordsVerbalTestForm(selectedLanguage);
                allWordsVerbalTestForm.Closed += (s, args) => this.Close();

                allWordsVerbalTestForm.Show();
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
    }
}
