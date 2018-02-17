using System.Windows.Forms;
using Silverio.Žodynas.Enums;

namespace Silverio.Žodynas
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void WordListSelectionButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            
            var wordsVocabularyForm = new WordsVocabularyForm();
            wordsVocabularyForm.Closed += (s, args) => this.Close();

            wordsVocabularyForm.Show();
        }

        private void UnknownWordsListSelectionButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
