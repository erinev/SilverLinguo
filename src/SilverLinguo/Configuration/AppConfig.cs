using System;

namespace SilverLinguo.Configuration
{
    public class AppConfig
    {
        public const string AppUuid = "e7b565a1-8d49-40ea-a2d4-ab0bcbbc2131";
        public static string DatabaseFolder => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SilverLinguo-75d4fcd7-4e68-47ba-9d46-8aad90575c09";
        public static string DatabaseFile => $"{DatabaseFolder}\\{DatabaseName}.db";
        public static string DatabaseConnectionString => $"Data Source={DatabaseFile};Version=3;UseUTF16Encoding=True;Password=FJtkLXz2aBeBARdW;";

        private const string DatabaseName = "SilverLinguo";
    }
}
