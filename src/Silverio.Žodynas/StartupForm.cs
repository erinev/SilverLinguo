using System;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;
using Silverio.Žodynas.Forms;
using Silverio.Žodynas.Services;

namespace Silverio.Žodynas
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
            int wordsCount = _wordsService.GetWordsCount();
            int unknownWordsCount = _wordsService.GetUnknownWordsCount();

            LithuanianLanguageRadioButton.Select();
            ShouldCheckGrammarCheckBox.Checked = false;

            WordsCountLabel.Text = $@"({wordsCount})";
            UnknownWordsCountLabel.Text = $@"({unknownWordsCount})";
        }

        private void WordListSelectionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            var wordsVocabularyForm = new WordsTestForm();
            wordsVocabularyForm.Closed += (s, args) => this.Close();

            wordsVocabularyForm.Show();
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
