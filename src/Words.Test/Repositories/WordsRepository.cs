using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Words.Test.Repositories.Models;

namespace Words.Test.Repositories
{
    public interface IWordsRepository
    {
        WordPair[] GetAllWords();
        WordPair[] GetUnknownWords();
        bool CheckIfUnknownWordAlreadyExist(int wordId);
    }

    public class WordsRepository : IWordsRepository
    {
        private readonly string _connectionString;

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

                WordPair[] allWords = dbConnection.Query<WordPair>(WordPairQueries.GetAllWordsQuery).ToArray();

                return allWords;
            }
        }

        public WordPair[] GetUnknownWords()
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                WordPair[] unknownWords = dbConnection.Query<WordPair>(WordPairQueries.GetUnknownWordsQuery).ToArray();

                return unknownWords;
            }
        }

        public bool CheckIfUnknownWordAlreadyExist(int wordId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                string queryWithInserterId = string.Format(WordPairQueries.CheckIfUnknownWordExistQuery, wordId);

                bool exist = dbConnection.QuerySingle<bool>(queryWithInserterId);

                return exist;
            } 
        }

        /*public void AddNewUnknownWord(WordPair newUnknownWord)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                DynamicParameters parameter = new DynamicParameters();
                //parameter.Add("@Kind", InvoiceKind.WebInvoice, DbType.Int64, ParameterDirection.Input);

                dbConnection.Execute(WordPairQueries.CheckIfUnknownWordExistQuery);
            } 
        }*/
    }
}
