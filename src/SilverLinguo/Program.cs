using System;
using System.Windows.Forms;
using SilverLinguo.Repositories;

namespace SilverLinguo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var wordsRepository = new WordsRepository();
            wordsRepository.InitializeDatabaseIfNotExist();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new StartupForm());
        }
    }
}
