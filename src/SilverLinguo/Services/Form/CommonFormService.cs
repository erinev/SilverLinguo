using System;
using System.Diagnostics;
using System.Windows.Forms;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Services.Form
{
    public class CommonFormService
    {
        public static void InitializeTestTimer(Label testTimerLabel, Stopwatch stopwatch)
        {
            var timer = new Timer();
            timer.Tick += (o, args) => timer_Tick(o, args, testTimerLabel, stopwatch);
            timer.Interval = 1000;
            timer.Enabled = true;
            stopwatch.Start();
            timer.Start();
        }

        public static void HandelEndTestButtonPressedEvent(WordPair[] testWords, Action endTestConfirmedAction)
        {
            if (testWords.Length <= 0)
            {
                endTestConfirmedAction();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Ne visi žodžiai išspręsti ar tikrai norite baigti testą ?", "Testo pabaiga",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    endTestConfirmedAction();
                }
            }
        }

        public static void ShowConfirmAction(string dialogCaption, string dialogText, Action userConfirmedAction)
        {
            DialogResult dialogResult = MessageBox.Show(dialogText, dialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                userConfirmedAction();
            }
        }

        public static void SetProgressLabelText(Label progressLabel, WordPair[] wordsForProgress)
        {
            int leftWordsCount = wordsForProgress.Length - 1;
            progressLabel.Text = leftWordsCount.ToString();
        }

        private static void timer_Tick(object sender, EventArgs args, Label testTimerLabel, Stopwatch stopwatch)
        {
            testTimerLabel.Text = stopwatch.Elapsed.Hours.ToString("00") + @":" +
                                  stopwatch.Elapsed.Minutes.ToString("00") + @":" +
                                  stopwatch.Elapsed.Seconds.ToString("00");
        }
    }
}
