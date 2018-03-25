using System.Windows.Forms;
using Words.Test.Enums;

namespace Words.Test.Services.Form
{
    public class VerbalFormService
    {
        public static void SetWordTextBoxVisibilityForSelectedLanguage(SelectedLanguage selectedLanguage, TextBox firstLanguageWordTextBox, TextBox secondLanguageWordTextBox)
        {
            switch (selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    firstLanguageWordTextBox.Visible = false;
                    secondLanguageWordTextBox.Visible = true;
                    break;
                case SelectedLanguage.English:
                    firstLanguageWordTextBox.Visible = true;
                    secondLanguageWordTextBox.Visible = false;
                    break;
                default:
                    firstLanguageWordTextBox.Visible = false;
                    secondLanguageWordTextBox.Visible = true;
                    break;
            }
        }

    }
}