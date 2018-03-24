using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Words.Test.Models;

namespace Words.Test.Repositories
{
    public interface IWordsRepository
    {
        WordPair[] GetWordsForTest();
        WordPair[] GetUnknownWordsForTest();
    }

    public class WordsRepository : IWordsRepository
    {
        private static string _connectionString;

        private const string GetUnknownWordsQuery = @"select * from UnknownWords";
        private const string GetAllWordsQuery = @"select * from AllWords";

        public WordsRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["VocabularyConnectionString"].ConnectionString;
        }

        public WordPair[] GetWordsForTest()
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                WordPair[] allWords = dbConnection.Query<WordPair>(GetAllWordsQuery).ToArray();

                return allWords;
            }
        }

        public WordPair[] GetUnknownWordsForTest()
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                WordPair[] unknownWords = dbConnection.Query<WordPair>(GetUnknownWordsQuery).ToArray();

                return unknownWords;
            }
        }
    }
}
