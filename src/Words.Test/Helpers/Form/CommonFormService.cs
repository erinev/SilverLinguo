using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Words.Test.Helpers.Form
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

        private static void timer_Tick(object sender, EventArgs args, Label testTimerLabel, Stopwatch stopwatch)
        {
            testTimerLabel.Text = stopwatch.Elapsed.Hours.ToString("00") + @":" +
                                  stopwatch.Elapsed.Minutes.ToString("00") + @":" +
                                  stopwatch.Elapsed.Seconds.ToString("00");
        }
    }
}
