using System.Windows.Forms;
using Silverio.Žodynas.Enums;
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

        private void StartupForm_Load(object sender, System.EventArgs e)
        {
            int _wordsCount = _wordsService.GetWordsCount();
            int _unknownWordsCount = _wordsService.GetUnknownWordsCount();

            LithuanianLanguageRadioButton.Select();

            WordsCountLabel.Text = $"({_wordsCount})";
            UnknownWordsCountLabel.Text = $"({_unknownWordsCount})";
        }

        private void WordListSelectionButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            
            var wordsVocabularyForm = new WordsTestForm();
            wordsVocabularyForm.Closed += (s, args) => this.Close();

            wordsVocabularyForm.Show();
        }

        private void UnknownWordsListSelectionButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();

            var unknownWordsVocabularyForm = new UnknownWordsTestForm(SelectedLanguage.Lithuanian);
            unknownWordsVocabularyForm.Closed += (s, args) => this.Close();

            unknownWordsVocabularyForm.Show();
        }

        private void EndProgramButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
