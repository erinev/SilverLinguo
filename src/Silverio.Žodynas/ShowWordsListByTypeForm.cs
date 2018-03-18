using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Silverio.Žodynas
{
    public partial class ShowWordsListByTypeForm : Form
    {
        private readonly List<string> _words;
        public ShowWordsListByTypeForm(List<string> words)
        {
            _words = words ?? Enumerable.Empty<string>().ToList();

            InitializeComponent();
        }

        private void ShowWordsListByTypeForm_Load(object sender, EventArgs e)
        {
            WordsListBox.DataSource = _words;
        }
    }
}
