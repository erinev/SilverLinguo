using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Words.Test.Enums;
using Words.Test.Helpers.Form;
using Words.Test.Repositories.Models;
using Words.Test.Services;

namespace Words.Test.Forms
{
    public partial class AllWordsVerbalTestForm : Form
    {
        private readonly IWordsService _wordsService;
        private readonly SelectedLanguage _selectedLanguage;

        private int _currentUnknownWordPairId;

        private WordPair[] _unknownWords;
        private readonly IList<WordPair> _learnedWords = new List<WordPair>();
        private int _startingCountOfUnknownWords;

        private readonly Stopwatch _stopWatch = new Stopwatch();

        public AllWordsVerbalTestForm(SelectedLanguage selectedLanguage)
        {
            _wordsService = new WordsService();

            _selectedLanguage = selectedLanguage;

            InitializeComponent();
        }

        private void AllWordsVerbalTestForm_Load(object sender, EventArgs e)
        {
            CommonFormService.InitializeTestTimer(TestTimerLabel, _stopWatch);
            VerbalFormService.SetWordTextBoxVisibilityForSelectedLanguage(_selectedLanguage, FirstLanguageWordTextBox,
                SecondLanguageWordTextBox);

        }
    }
}
