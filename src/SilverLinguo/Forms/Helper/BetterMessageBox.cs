using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SilverLinguo.Forms.Helper
{
    public partial class BetterMessageBox : Form
    {
        private readonly string _title;
        private readonly string _body;

        public BetterMessageBox(string title, string body)
        {
            InitializeComponent();

            _title = title;
            _body = body;
        }

        private void BetterMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = _title;
            WarningQuestionLabel.Text = _body;
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
