using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Forms.Helper
{
    public partial class ShowWordsListByTypeForm : Form
    {
        private readonly string _wordsListFormName;
        private readonly List<string> _wordsToDisplay;
        //private readonly Action<Form> _initializeTestAction;

        public ShowWordsListByTypeForm(string wordsListFormName, IEnumerable<WordPair> words/*, Action<Form> initializeTestAction = null*/)
        {
            _wordsListFormName = wordsListFormName;
            _wordsToDisplay = words.Select(w => w.FirstLanguageWord + " - " + w.SecondLanguageWord).ToList();
            //_initializeTestAction = initializeTestAction;

            InitializeComponent();
        }

        private void ShowWordsListByTypeForm_Load(object sender, EventArgs e)
        {
            this.Text = _wordsListFormName;

            WordsListBox.DataSource = _wordsToDisplay;
            
            /*if (_initializeTestAction != null)
            {
                TestShownWordsButton.MouseClick += TestShownWordsButton_MouseClick;
                TestShownWordsButton.Visible = true;
            }*/
        }

        /*private void TestShownWordsButton_MouseClick(object sender, EventArgs e)
        {
            _initializeTestAction(this.Owner);

            this.Close();
        }*/
    }
}
