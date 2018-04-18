using System;
using System.Windows.Forms;
using SilverLinguo.Repositories;

namespace SilverLinguo.Forms.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void ReintializeDatabaseButton_Click(object sender, EventArgs e)
        {
            var wordsRepository = new WordsRepository();

            wordsRepository.ReinitializeAllTables();
        }

        private void GoBackToStartupFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            var startupForm = new StartupForm();

            startupForm.Closed += (s, args) => this.Close();

            startupForm.Show();
        }
    }
}
