using System;
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
        void AddNewUnknownWord(int wordId);
        void RemoveLearnedUnknownWord(int wordId);
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
                var queryParameters = new { WordId = wordId };

                bool exist = dbConnection.QuerySingle<bool>(checkIfUnknownWordAlreadyExistsQuery, queryParameters);

                return exist;
            } 
        }

        public void AddNewUnknownWord(int wordId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                const string insertNewUnknownWord = 
                    @"INSERT INTO UnknownWords
                      VALUES(NULL, @WordId)";
                var queryParameters = new { WordId = wordId };

                dbConnection.Execute(insertNewUnknownWord, queryParameters);
            } 
        }

        public void RemoveLearnedUnknownWord(int wordId)
        {
            using (var dbConnection = new SQLiteConnection(_connectionString))
            {
                dbConnection.Open();

                const string insertNewUnknownWord = 
                    @"DELETE FROM UnknownWords
                      WHERE ID_AllWords = @WordId";
                var queryParameters = new { WordId = wordId };

                dbConnection.Execute(insertNewUnknownWord, queryParameters);
            } 
        }
    }
}
