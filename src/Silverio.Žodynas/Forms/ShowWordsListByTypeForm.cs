using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Silverio.Žodynas.Forms
{
    public partial class ShowWordsListByTypeForm : Form
    {
        private readonly List<string> _words;
        private readonly string _wordsListFormName;

        public ShowWordsListByTypeForm(string wordsListFormName, List<string> words)
        {
            _words = words ?? Enumerable.Empty<string>().ToList();
            _wordsListFormName = wordsListFormName;

            InitializeComponent();
        }

        private void ShowWordsListByTypeForm_Load(object sender, EventArgs e)
        {
            this.Text = _wordsListFormName;

            WordsListBox.DataSource = _words;
        }
    }
}
