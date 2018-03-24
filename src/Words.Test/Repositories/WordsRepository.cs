using System;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Words.Test.Models;

namespace Words.Test.Repositories
{
    public interface IWordsRepository
    {
        WordPair[] GetAllWords();
        WordPair[] GetUnknownWords();
    }

    public class WordsRepository : IWordsRepository
    {
        private readonly string _connectionString;
        private const string GetAllWordsQuery = @"select * from AllWords";
        private const string GetUnknownWordsQuery = @"select * from UnknownWords";

        public WordsRepository()
        {
            string dbFile = Environment.CurrentDirectory + "\\Database\\Vocabulary.db";
            _connectionString = $"Data Source={dbFile}";
        }

        public WordPair[] GetAllWords()
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                WordPair[] allWords = dbConnection.Query<WordPair>(GetAllWordsQuery).ToArray();

                return allWords;
            }
        }

        public WordPair[] GetUnknownWords()
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                WordPair[] unknownWords = dbConnection.Query<WordPair>(GetUnknownWordsQuery).ToArray();

                return unknownWords;
            }
        }
    }
}
