using System.Windows.Forms;

namespace Silverio.Žodynas
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void StartupForm_Load(object sender, System.EventArgs e)
        {

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

            var unknownWordsVocabularyForm = new UnknownWordsTestForm();
            unknownWordsVocabularyForm.Closed += (s, args) => this.Close();

            unknownWordsVocabularyForm.Show();
        }

        private void EndProgramButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
