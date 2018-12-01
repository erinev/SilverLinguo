using System;
using System.Threading;
using System.Windows.Forms;
using SilverLinguo.Configuration;
using SilverLinguo.Repositories;

namespace SilverLinguo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using(Mutex mutex = new Mutex(false, "Global\\" + AppConfig.AppUuid))
            {
                if(!mutex.WaitOne(0, false))
                {
                    MessageBox.Show(@"Vienu metu galima paleisti tik vieną SilverLinguo aplikaciją!");
                    return;
                }

                var setupRepository = new ApplicationSetupRepository();

                setupRepository.InitializeDatabaseIfNotExist();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new StartupForm());
            }
        }
    }
}
