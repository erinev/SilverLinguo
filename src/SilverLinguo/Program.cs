using System;
using System.Threading;
using System.Windows.Forms;
using SilverLinguo.Repositories;

namespace SilverLinguo
{
    static class Program
    {
        private const string AppUuid = "e7b565a1-8d49-40ea-a2d4-ab0bcbbc2131";

        [STAThread]
        static void Main()
        {
            using(Mutex mutex = new Mutex(false, "Global\\" + AppUuid))
            {
                if(!mutex.WaitOne(0, false))
                {
                    MessageBox.Show(@"Vienu metu galima paleisti tik vieną SilverLinguo aplikaciją!");
                    return;
                }

                var wordsRepository = new WordsRepository();
                wordsRepository.InitializeDatabaseIfNotExist();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new StartupForm());
            }
        }
    }
}
