using System;
using System.Windows.Forms;

namespace SilverLinguo.Forms.Helper
{
    public partial class CustomizableDialog : Form
    {
        private readonly string _title;
        private readonly string _body;

        public CustomizableDialog(string title, string body)
        {
            InitializeComponent();

            _title = title;
            _body = body;
        }

        private void BetterMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = _title;
            DialogBodyReadonlyTextBox.Text = _body;
        }

        private void YesButton_MouseClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void NoButton_MouseClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
