using System.Data.SQLite;
using System.IO;
using SilverLinguo.Configuration;

namespace SilverLinguo.Repositories
{
    public class ApplicationSetupRepository
    {
        public void InitializeDatabaseIfNotExist()
        {
            if (File.Exists(AppConfig.DatabaseFile))
            {
                CreateColumnsForAllWordsSearchIfNotExists();

                return;
            }

            if (!Directory.Exists(AppConfig.DatabaseFolder))
            {
                Directory.CreateDirectory(AppConfig.DatabaseFolder);
            }
            
            SQLiteConnection.CreateFile(AppConfig.DatabaseFile);

            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
            {
                dbConnection.Open();

                CreateAllTables(dbConnection);

                FillAllWordsTable(dbConnection);
            }
        }

        private void CreateColumnsForAllWordsSearchIfNotExists()
        {
            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
            {
                dbConnection.Open();

                string allWordsTableName = "AllWords";
                string newColumnType = "TEXT";

                CreateFirstLanguageWordSearchColumnIfNotExists(allWordsTableName, newColumnType, dbConnection);
                CreateSecondLanguageWordSearchColumnIfNotExists(allWordsTableName, newColumnType, dbConnection);
            }
        }

        private void CreateFirstLanguageWordSearchColumnIfNotExists(string allWordsTableName, string newColumnType, SQLiteConnection dbConnection)
        {
            string firstLanguageWordColumnName = "FirstLanguageWord";
            string lowercasedFirstLanguageWordColumnName = "LowercasedFirstLanguageWord";

            bool lowercasedFirstLanguageWordColumnExists = CheckIfColumnExists(allWordsTableName, lowercasedFirstLanguageWordColumnName, dbConnection);
            if (!lowercasedFirstLanguageWordColumnExists)
            {
                AddNullableColumnForTable(allWordsTableName, lowercasedFirstLanguageWordColumnName, newColumnType, dbConnection);
                CopyLowercasedColumnValueToDestinationColumn(allWordsTableName, firstLanguageWordColumnName, lowercasedFirstLanguageWordColumnName, dbConnection);
            }
        }

        private void CreateSecondLanguageWordSearchColumnIfNotExists(string allWordsTableName, string newColumnType, SQLiteConnection dbConnection)
        {
            string firstLanguageWordColumnName = "SecondLanguageWord";
            string lowercasedFirstLanguageWordColumnName = "LowercasedSecondLanguageWord";

            bool lowercasedFirstLanguageWordColumnExists = CheckIfColumnExists(allWordsTableName, lowercasedFirstLanguageWordColumnName, dbConnection);
            if (!lowercasedFirstLanguageWordColumnExists)
            {
                AddNullableColumnForTable(allWordsTableName, lowercasedFirstLanguageWordColumnName, newColumnType, dbConnection);
                CopyLowercasedColumnValueToDestinationColumn(allWordsTableName, firstLanguageWordColumnName, lowercasedFirstLanguageWordColumnName, dbConnection);
            }
        }

        private void CreateAllTables(SQLiteConnection dbConnection)
        {
            CreateAllWordsTable(dbConnection);

            CreateUnknownWordsTable(dbConnection);

            CreateTestResultsTable(dbConnection);
        }

        private void CreateAllWordsTable(SQLiteConnection dbConnection)
        {
            string dropAllWordsTableQuery = GetDropTableQuery("AllWords");
            SQLiteCommand dropAllWordsTableCommand = new SQLiteCommand(dropAllWordsTableQuery, dbConnection);
            dropAllWordsTableCommand.ExecuteNonQuery();
            //                    
            const string createAllWordsTableSql =
                @"                  
                  CREATE TABLE [AllWords] (
                      [Id] INTEGER NOT NULL
                    , [FirstLanguageWord] TEXT NOT NULL
                    , [SecondLanguageWord] TEXT NOT NULL
                    , [LanguagePair] INTEGER NOT NULL
                    , [CreatedAt] TEXT NOT NULL
                    , [ModifiedAt] TEXT NOT NULL
                    , [LowercasedFirstLanguageWord] TEXT
                    , [LowercasedSecondLanguageWord] TEXT
                    , CONSTRAINT [PK_AllWords] PRIMARY KEY ([Id])
                    , UNIQUE(FirstLanguageWord, SecondLanguageWord, LanguagePair)
                  );
                ";
            SQLiteCommand createAllWordsTableCommand = new SQLiteCommand(createAllWordsTableSql, dbConnection);
            createAllWordsTableCommand.ExecuteNonQuery();
        }

        private void CreateUnknownWordsTable(SQLiteConnection dbConnection)
        {
            string dropUnknownWordsTableQuery = GetDropTableQuery("UnknownWords");
            SQLiteCommand dropUnknownWordsTableCommand = new SQLiteCommand(dropUnknownWordsTableQuery, dbConnection);
            dropUnknownWordsTableCommand.ExecuteNonQuery();

            const string createUnknownWordsTableSql =
                @"                  
                  CREATE TABLE [UnknownWords] (
                      [Id] INTEGER NOT NULL
                    , [Id_AllWords] INTEGER NOT NULL
                    , CONSTRAINT [PK_UnknownWords] PRIMARY KEY ([Id])
                    , FOREIGN KEY([Id_AllWords]) REFERENCES AllWords([Id])
                  );
                ";
            SQLiteCommand createUnknownWordsTableCommand = new SQLiteCommand(createUnknownWordsTableSql, dbConnection);
            createUnknownWordsTableCommand.ExecuteNonQuery();
        }

        private void CreateTestResultsTable(SQLiteConnection dbConnection)
        {
            string dropTestResultsTableQuery = GetDropTableQuery("TestResults");
            SQLiteCommand dropTestResultsTableCommand = new SQLiteCommand(dropTestResultsTableQuery, dbConnection);
            dropTestResultsTableCommand.ExecuteNonQuery();

            const string createTestResultsTableSql =
                @"                  
                  CREATE TABLE [TestResults] (
                      [Id] INTEGER NOT NULL
                    , [FinishedAt] TEXT NOT NULL
                    , [DurationAsTicks] TEXT NOT NULL
                    , [WordsType] INTEGER NOT NULL
                    , [LanguagePair] INTEGER NOT NULL
                    , [SelectedLanguage] INTEGER NOT NULL
                    , [TestType] INTEGER NOT NULL
                    , [NumberOfTotalWords] INTEGER NOT NULL
                    , [LearnedWordsAsJson] TEXT NOT NULL
                    , [KnownWordsAsJson] TEXT NOT NULL
                    , [NewUnknownWordsAsJson] TEXT NOT NULL
                    , [UnknownWordsAsJson] TEXT NOT NULL
                    , CONSTRAINT [PK_TestResults] PRIMARY KEY ([Id])
                );";
            SQLiteCommand createTestResultsTableCommand = new SQLiteCommand(createTestResultsTableSql, dbConnection);
            createTestResultsTableCommand.ExecuteNonQuery();
        }

        private string GetDropTableQuery(string tableName)
        {
            return $"DROP TABLE IF EXISTS [{tableName}]";
        }

        private void FillAllWordsTable(SQLiteConnection dbConnection)
        {
            const string fillAllWordsTableCommand =
                @"BEGIN TRANSACTION;
            INSERT INTO 'AllWords' VALUES (NULL, 'Sapnas, Svajonė', 'Dream', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'sapnas, svajonė', 'dream');
            INSERT INTO 'AllWords' VALUES (NULL, 'Lėktuvas', 'Airplane, Plane, Aircraft', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'lėktuvas', 'airplane, plane, aircraft');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Ranka', 'Arm', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'ranka', 'arm');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Pirmyn', 'Forward, Ahead', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'pirmyn', 'forward, ahead');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Atgal', 'Backward', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'atgal', 'backward');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Nugara', 'Back', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'nugara', 'back');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Aštrus', 'Sharp, Spicy', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'aštrus', 'sharp, spicy');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Jų', 'Theirs', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'jų', 'theirs');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Tamsus, Tamsa', 'Dark', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'tamsus, tamsa', 'dark');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Megztinis', 'Sweater', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'megztinis', 'sweater');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Apie ką tu kalbi?', 'What are you talking about?', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'apie ką tu kalbi?', 'what are you talking about?');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Man patinka mėlynas dangus', 'I like blue sky', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03', 'man patinka mėlynas dangus', 'i like blue sky');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Žemė', 'Ground', 1, '2018-12-01 11:38:03', '2018-12-01 11:38:03', 'žemė', 'ground');
                COMMIT;";
            SQLiteCommand createTestResultsTableCommand = new SQLiteCommand(fillAllWordsTableCommand, dbConnection);
            createTestResultsTableCommand.ExecuteNonQuery();
        }

        private bool CheckIfColumnExists(string tableName, string columnName, SQLiteConnection dbConnection)
        {
            string getTableColumnsCommand = $"PRAGMA table_info({tableName});";
            SQLiteCommand createTestResultsTableCommand = new SQLiteCommand(getTableColumnsCommand, dbConnection);
            SQLiteDataReader tableColumnsReader = createTestResultsTableCommand.ExecuteReader();

            int nameIndex = tableColumnsReader.GetOrdinal("Name");
            while (tableColumnsReader.Read())
            {
                if (tableColumnsReader.GetString(nameIndex).Equals(columnName))
                {
                    return true;
                }
            }

            return false;
        }

        private void AddNullableColumnForTable(string tableName, string columnName, string columnType, SQLiteConnection dbConnection)
        {
            string addColumnCommand = 
                $@"
                    ALTER TABLE {tableName} 
                    ADD COLUMN {columnName} {columnType};
                 ";

            SQLiteCommand createTestResultsTableCommand = new SQLiteCommand(addColumnCommand, dbConnection);

            createTestResultsTableCommand.ExecuteNonQuery();
        }

        private void CopyLowercasedColumnValueToDestinationColumn(string tableName, string targetColumnName, string destinationColumnName, SQLiteConnection dbConnection)
        {
            string copyColumnCommand = 
                $@" 
                    UPDATE {tableName} 
                    SET {destinationColumnName} = CUSTOM_TO_LOWER({targetColumnName})
                ";

            SQLiteCommand createTestResultsTableCommand = new SQLiteCommand(copyColumnCommand, dbConnection);

            createTestResultsTableCommand.ExecuteNonQuery();
        }
    }
}