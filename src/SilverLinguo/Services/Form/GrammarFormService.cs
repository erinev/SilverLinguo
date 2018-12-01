using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SilverLinguo.Enums;
using SilverLinguo.Extensions;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Services.Form
{
    public class GrammarFormService
    {
        private static readonly Point FirstWordLocationForButton = new Point(29, 120);
        private static readonly Point SecondWordLocationForButton = new Point(663, 120);

        private static readonly Color TextBoxBackColorForIncorrectWord = Color.LightCoral;

        public static void ConfigureSelectedLanguage(SelectedLanguage selectedLanguage, TextBox firstLanguageWordTextBox, TextBox secondLanguageWordTextBox, Button validateWordButton, Button nextWordButton)
        {
            switch (selectedLanguage)
            {
                case SelectedLanguage.Lithuanian:
                    firstLanguageWordTextBox.ReadOnly = false;
                    secondLanguageWordTextBox.ReadOnly = true;
                    firstLanguageWordTextBox.Select();
                    break;
                case SelectedLanguage.English:
                    firstLanguageWordTextBox.ReadOnly = true;
                    secondLanguageWordTextBox.ReadOnly = false;
                    secondLanguageWordTextBox.Select();
                    break;
                default:
                    firstLanguageWordTextBox.ReadOnly = false;
                    secondLanguageWordTextBox.ReadOnly = true;
                    firstLanguageWordTextBox.Select();
                    break;
            }

            RepositionConfirmAndNextWordButtons(validateWordButton, nextWordButton, firstLanguageWordTextBox, secondLanguageWordTextBox);
        }

        public static void HanldeVerbalFormLoadedEvent(
            WordPair[] wordsArray, out int currentWordPairId, Label progressLabel,
            TextBox firstLanguageWordTextBox, TextBox secondLanguageWordTextBox)
        {
            new Random().Shuffle(wordsArray);

            currentWordPairId = wordsArray[0].Id;

            CommonFormService.SetProgressLabelText(progressLabel, wordsArray);

            WordPair firstWord = wordsArray.First();
            firstLanguageWordTextBox.Text = firstLanguageWordTextBox.ReadOnly ? firstWord.FirstLanguageWord : String.Empty;
            secondLanguageWordTextBox.Text = secondLanguageWordTextBox.ReadOnly ? firstWord.SecondLanguageWord : String.Empty;
        }

        public static void ConfigureInputLanguageForTest(out InputLanguage originalInputLanguage, SelectedLanguage selectedLanguage)
        {
            originalInputLanguage = InputLanguage.CurrentInputLanguage;

            try
            {
                if (selectedLanguage == SelectedLanguage.Lithuanian || selectedLanguage == SelectedLanguage.Mixed)
                {
                    CultureInfo lithuanianCultureInfo = CultureInfo.GetCultureInfo("lt-LT");
                    InputLanguage lithuanianLanguage = InputLanguage.FromCulture(lithuanianCultureInfo);

                    InputLanguage.CurrentInputLanguage =
                        // ReSharper disable once AssignNullToNotNullAttribute
                        InputLanguage.InstalledInputLanguages.IndexOf(lithuanianLanguage) >= 0
                            ? lithuanianLanguage
                            : originalInputLanguage;
                }
            }
            catch (Exception)
            {
                InputLanguage.CurrentInputLanguage = originalInputLanguage;
            }
        }

        public static void HandleVisibilityOnIncorrectlyEnteredWordEvent(
            Button validateWordButton, Button nextWordButton, TextBox correctWordTextBox,
            TextBox textBoxWithIncorrectWord, string correctValueForTextBox)
        {
            validateWordButton.Visible = false;
            nextWordButton.Visible = true;
            nextWordButton.Focus();

            textBoxWithIncorrectWord.Enabled = false;
            textBoxWithIncorrectWord.BackColor = TextBoxBackColorForIncorrectWord;

            correctWordTextBox.Visible = true;
            correctWordTextBox.Text = correctValueForTextBox;
        }

        public static void HandleNextWordButtonEvent(Button validateWordButton, Button nextWordButton, TextBox correctWordTextBox, SelectedLanguage selectedLanguage, TextBox firstLanguageWordTextBox, TextBox secondLanguageWordTextBox, WordPair[] words)
        {
            if (!firstLanguageWordTextBox.Enabled)
            {
                firstLanguageWordTextBox.Enabled = true;
            }

            if (!secondLanguageWordTextBox.Enabled)
            {
                secondLanguageWordTextBox.Enabled = true;
            }

            validateWordButton.Visible = true;
            nextWordButton.Visible = false;
            correctWordTextBox.Visible = false;

            if (selectedLanguage == SelectedLanguage.Mixed)
            {
                bool currentEnWordTextBoxReadOnlyState = secondLanguageWordTextBox.ReadOnly;
                bool currentLtWordTextBoxReadOnlyState = firstLanguageWordTextBox.ReadOnly;
                secondLanguageWordTextBox.ReadOnly = !currentEnWordTextBoxReadOnlyState;
                firstLanguageWordTextBox.ReadOnly = !currentLtWordTextBoxReadOnlyState;

                RepositionConfirmAndNextWordButtons(validateWordButton, nextWordButton, firstLanguageWordTextBox,
                    secondLanguageWordTextBox);
            }

            SetInputColorsOnNextWordEvent(firstLanguageWordTextBox, secondLanguageWordTextBox);

            WordPair currentUnknownWord = words.First();
            firstLanguageWordTextBox.Text = firstLanguageWordTextBox.ReadOnly ? currentUnknownWord.FirstLanguageWord : String.Empty;
            secondLanguageWordTextBox.Text = secondLanguageWordTextBox.ReadOnly ? currentUnknownWord.SecondLanguageWord : String.Empty;

            if (!firstLanguageWordTextBox.ReadOnly)
            {
                firstLanguageWordTextBox.Focus();
            }
            else
            {
                secondLanguageWordTextBox.Focus();
            }
        }

        private static void SetInputColorsOnNextWordEvent(TextBox firstLanguageWordTextBox, TextBox secondLanguageWordTextBox)
        {
            if (firstLanguageWordTextBox.BackColor == TextBoxBackColorForIncorrectWord && !firstLanguageWordTextBox.ReadOnly)
            {
                firstLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (firstLanguageWordTextBox.BackColor == TextBoxBackColorForIncorrectWord && firstLanguageWordTextBox.ReadOnly)
            {
                firstLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (firstLanguageWordTextBox.BackColor == Color.FromKnownColor(KnownColor.Control) && !firstLanguageWordTextBox.ReadOnly)
            {
                firstLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                secondLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }

            if (secondLanguageWordTextBox.BackColor == TextBoxBackColorForIncorrectWord && !secondLanguageWordTextBox.ReadOnly)
            {
                secondLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (secondLanguageWordTextBox.BackColor == TextBoxBackColorForIncorrectWord && secondLanguageWordTextBox.ReadOnly)
            {
                secondLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else if (secondLanguageWordTextBox.BackColor == Color.FromKnownColor(KnownColor.Control) && !secondLanguageWordTextBox.ReadOnly)
            {
                secondLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                firstLanguageWordTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private static void RepositionConfirmAndNextWordButtons(Button validateWordButton, Button nextWordButton, TextBox firstLanguageWordTextBox, TextBox secondLanguageWordTextBox)
        {
            validateWordButton.Location =
                firstLanguageWordTextBox.ReadOnly ? SecondWordLocationForButton : FirstWordLocationForButton;
            nextWordButton.Location =
                secondLanguageWordTextBox.ReadOnly ? FirstWordLocationForButton : SecondWordLocationForButton;
        }
    }
}
