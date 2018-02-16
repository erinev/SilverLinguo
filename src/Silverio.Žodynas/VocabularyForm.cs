using System;
using System.Drawing;
using System.Windows.Forms;
using Silverio.Žodynas.Enums;

namespace Silverio.Žodynas
{
    public partial class VocabularyForm : Form
    {
        private static CurrentLanguage _currentLanguage;

        private readonly Bitmap _englishFlagBitmap = Properties.Resources.EnglishFlag;
        private readonly Bitmap _lithuanianFlagBitmap = Properties.Resources.LithuanianFlag;

        public VocabularyForm()
        {
            InitializeComponent();

            _currentLanguage = CurrentLanguage.Lithuanian;

            LtWordLabel.Visible = true;
            EnWordLabel.Visible = false;

            ChangeLanguageButton.Image = _englishFlagBitmap;
        }

        private void ChangeLanguageButton_Click(object sender, EventArgs e)
        {
            Bitmap languageIcon;

            switch (_currentLanguage)
            {
                case CurrentLanguage.Lithuanian:
                    languageIcon = _lithuanianFlagBitmap;
                    _currentLanguage = CurrentLanguage.English;
                    LtWordLabel.Visible = false;
                    EnWordLabel.Visible = true;
                    break;
                case CurrentLanguage.English:
                    languageIcon = _englishFlagBitmap;
                    _currentLanguage = CurrentLanguage.Lithuanian;
                    LtWordLabel.Visible = true;
                    EnWordLabel.Visible = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ChangeLanguageButton.Image = languageIcon;
        }
    }
}
