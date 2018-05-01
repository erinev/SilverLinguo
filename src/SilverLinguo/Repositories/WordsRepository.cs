using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Dapper;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Repositories
{
    public interface IWordsRepository
    {
        WordPair[] GetAllWords();
        WordPair[] GetUnknownWords();
        bool CheckIfUnknownWordAlreadyExist(int wordId);
        bool AddNewUnknownWord(int wordId);
        bool RemoveLearnedUnknownWord(int wordId);
        int RemoveAllWordsByIds(IEnumerable<int> wordPairIdsToRemove);
        int UpdateMultipleWordPairs(IEnumerable<WordPair> updatedWordPairs);
        int InsertMultipleWordPairs(IEnumerable<WordPair> addedWordPairs);
    }

    public class WordsRepository : IWordsRepository
    {
        private readonly string _dbFolder;
        private readonly string _dbFile;
        private readonly string _connectionString;

        public WordsRepository()
        {
            string databaseName = "SilverLinguo";
            _dbFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SilverLinguo-75d4fcd7-4e68-47ba-9d46-8aad90575c09";
            _dbFile = $"{_dbFolder}\\{databaseName}.db";
            _connectionString = $"Data Source={_dbFile};Version=3;UseUTF16Encoding=True;Password=FJtkLXz2aBeBARdW;";
        }

        public WordPair[] GetAllWords()
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                const string getAllWordsQuery =
                    @"SELECT 
                        AW.Id, AW.FirstLanguageWord, AW.SecondLanguageWord, 
                        AW.LanguagePair, AW.CreatedAt, AW.ModifiedAt
                      FROM AllWords AW";

                WordPair[] allWords = dbConnection.Query<WordPair>(getAllWordsQuery).ToArray();

                return allWords;
            }
        }

        public WordPair[] GetUnknownWords()
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                const string getUnknownWordsQuery =
                    @"SELECT 
                        AW.Id, AW.FirstLanguageWord, AW.SecondLanguageWord, 
                        AW.LanguagePair, AW.CreatedAt, AW.ModifiedAt  
                      FROM UnknownWords UW
                      JOIN AllWords AW ON UW.ID_AllWords = AW.Id";

                WordPair[] unknownWords = dbConnection.Query<WordPair>(getUnknownWordsQuery).ToArray();

                return unknownWords;
            }
        }

        public bool CheckIfUnknownWordAlreadyExist(int wordId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                const string checkIfUnknownWordAlreadyExistsQuery =
                    @"SELECT EXISTS(
                        SELECT 1 
                        FROM UnknownWords
                        WHERE ID_AllWords = @WordId
                        LIMIT 1
                      )";
                var queryParameters = new {WordId = wordId};

                bool exist = dbConnection.QuerySingle<bool>(checkIfUnknownWordAlreadyExistsQuery, queryParameters);

                return exist;
            }
        }

        public bool AddNewUnknownWord(int wordId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                const string insertNewUnknownWordCommand =
                    @"INSERT INTO UnknownWords
                      VALUES(NULL, @WordId)";
                var queryParameters = new {WordId = wordId};

                int affectedRows = dbConnection.Execute(insertNewUnknownWordCommand, queryParameters);

                return affectedRows == 1;
            }
        }

        public bool RemoveLearnedUnknownWord(int wordId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                const string deleteLearnedUnknownWordCommand =
                    @"DELETE FROM UnknownWords
                      WHERE ID_AllWords = @WordId";
                var queryParameters = new {WordId = wordId};

                int affectedRows = dbConnection.Execute(deleteLearnedUnknownWordCommand, queryParameters);

                return affectedRows == 1;
            }
        }

        public int RemoveAllWordsByIds(IEnumerable<int> wordPairIdsToRemove)
        {
            int removedWordPairsCount = 0;

            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
                {
                    foreach (int id in wordPairIdsToRemove)
                    {
                        const string deleteWordPairCommand =
                            @"DELETE FROM AllWords
                              WHERE Id = @Id";
                        var queryParameters = new {Id = id};

                        int affectedRows = dbConnection.Execute(deleteWordPairCommand, queryParameters);

                        removedWordPairsCount += affectedRows;
                    }

                    transaction.Commit();
                }
            }

            return removedWordPairsCount;
        }

        public int UpdateMultipleWordPairs(IEnumerable<WordPair> updatedWordPairs)
        {
            int updatedWordPairsCount = 0;

            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
                {
                    foreach (WordPair updatedWordPair in updatedWordPairs)
                    {
                        const string updateWordPairCommand =
                            @"UPDATE AllWords
                              SET FirstLanguageWord = @FirstLanguageWord, SecondLanguageWord = @SecondLanguageWord, ModifiedAt = @ModifiedAt
                              WHERE Id = @Id";
                        var queryParameters = new
                        {
                            FirstLanguageWord = updatedWordPair.FirstLanguageWord,
                            SecondLanguageWord = updatedWordPair.SecondLanguageWord,
                            ModifiedAt = updatedWordPair.ModifiedAt,
                            Id = updatedWordPair.Id
                        };

                        int affectedRows = dbConnection.Execute(updateWordPairCommand, queryParameters);

                        updatedWordPairsCount += affectedRows;
                    }

                    transaction.Commit();
                }
            }

            return updatedWordPairsCount;
        }

        public int InsertMultipleWordPairs(IEnumerable<WordPair> addedWordPairs)
        {
            int insertedWordPairsCount = 0;

            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
                {
                    foreach (WordPair addedWordPair in addedWordPairs)
                    {
                        const string insertNewWordPairCommand =
                            @"INSERT INTO AllWords
                              VALUES(NULL, @FirstLanguageWord, @SecondLanguageWord, @LanguagePair, @CreatedAt, @ModifiedAt)";
                        var queryParameters = new
                        {
                            FirstLanguageWord = addedWordPair.FirstLanguageWord,
                            SecondLanguageWord = addedWordPair.SecondLanguageWord,
                            LanguagePair = addedWordPair.LanguagePair,
                            CreatedAt = addedWordPair.CreatedAt,
                            ModifiedAt = addedWordPair.ModifiedAt
                        };

                        int affectedRows = dbConnection.Execute(insertNewWordPairCommand, queryParameters);

                        insertedWordPairsCount += affectedRows;
                    }

                    transaction.Commit();
                }
            }

            return insertedWordPairsCount;
        }

        public void InitializeDatabaseIfNotExist()
        {
            if (File.Exists(_dbFile)) return;

            if (!Directory.Exists(_dbFolder))
            {
                Directory.CreateDirectory(_dbFolder);
            }
            else
            {
                DeleteLeftoverFilesAndFoldersBeforeDbCreate();
            }
            
            SQLiteConnection.CreateFile(_dbFile);

            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                CreateAllTables(dbConnection);

                FillAllWordsTable(dbConnection);
            }
        }

        private void DeleteLeftoverFilesAndFoldersBeforeDbCreate()
        {
            var directory = new DirectoryInfo(_dbFolder);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
            {
                subdirectory.Delete(true);
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

            const string createAllWordsTableSql =
                @"                  
                  CREATE TABLE [AllWords] (
                    [Id] INTEGER NOT NULL
                    , [FirstLanguageWord] TEXT NOT NULL
                    , [SecondLanguageWord] TEXT NOT NULL
                    , [LanguagePair] INTEGER NOT NULL
                    , [CreatedAt] TEXT NOT NULL
                    , [ModifiedAt] TEXT NOT NULL
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
            INSERT INTO 'AllWords' VALUES (NULL, 'Sapnas, Svajonė', 'Dream', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
            INSERT INTO 'AllWords' VALUES (NULL, 'Lėktuvas', 'Airplane, Plane, Aircraft', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Ranka', 'Arm', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Pirmyn', 'Forward, Ahead', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Atgal', 'Backward', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Nugara', 'Back', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Peilis', 'Knife', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Aštrus', 'Sharp, Spicy', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Mes', 'We', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Jų', 'Theirs', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Gegutė', 'Cuckoo', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Tamsus, Tamsa', 'Dark', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Vienišas', 'Lonely', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Megztinis', 'Sweater', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Suknelė', 'Dress', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Praeitis', 'Past', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Grindys', 'Floor', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Apie ką tu kalbi?', 'What are you talking about?', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
	        INSERT INTO 'AllWords' VALUES (NULL, 'Man patinka mėlynas dangus', 'I like blue sky', 1, '2018-03-24 10:09:03', '2018-03-24 10:09:03');
                COMMIT;";
            SQLiteCommand createTestResultsTableCommand = new SQLiteCommand(fillAllWordsTableCommand, dbConnection);
            createTestResultsTableCommand.ExecuteNonQuery();
        }
    }
}
