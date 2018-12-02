using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using SilverLinguo.Configuration;
using SilverLinguo.Repositories.Functions;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Repositories
{
    public interface IWordsRepository
    {
        WordPair[] GetAllWords(QueryCriteria criteria = null);
        WordPair[] GetUnknownWords(QueryCriteria criteria = null);
        bool CheckIfUnknownWordAlreadyExist(int wordId);
        bool AddNewUnknownWord(int wordId);
        bool RemoveLearnedUnknownWord(int wordId);
        int RemoveAllWordsByIds(IEnumerable<int> wordPairIdsToRemove);
        int UpdateMultipleWordPairs(IEnumerable<WordPair> updatedWordPairs);
        int InsertMultipleWordPairs(IEnumerable<WordPair> addedWordPairs);
    }

    public class WordsRepository : IWordsRepository
    {
        public WordsRepository()
        {
            SQLiteFunction.RegisterFunction(typeof(CustomToLowerFunction));
        }

        public WordPair[] GetAllWords(QueryCriteria criteria = null)
        {
            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
            {
                dbConnection.Open();

                object queryParameters = new {};

                string getAllWordsQuery =
                    @"SELECT  
                        AW.Id, AW.FirstLanguageWord, AW.SecondLanguageWord, 
                        AW.LanguagePair, AW.CreatedAt, AW.ModifiedAt
                      FROM AllWords AW";

                if (criteria != null)
                {
                    queryParameters = PrepareQueryCriteria(criteria, ref getAllWordsQuery);
                }
                
                WordPair[] allWords = dbConnection.Query<WordPair>(getAllWordsQuery, queryParameters).ToArray();

                return allWords;
            }
        }

        private static object PrepareQueryCriteria(QueryCriteria criteria, ref string getAllWordsQuery)
        {
            if (criteria.SearchText != null)
            {
                string searchCriteria =
                    " WHERE AW.LowercasedFirstLanguageWord LIKE @SearchCriteria OR AW.LowercasedSecondLanguageWord LIKE @SearchCriteria";

                getAllWordsQuery += searchCriteria;
            }

            if (criteria.OrderByCriteria != null)
            {
                string orderByCriteria = string.Empty;

                if (criteria.OrderByCriteria.OrderBy == OrderBy.CreatedAt)
                {
                    orderByCriteria = $" ORDER BY datetime(AW.CreatedAt) {criteria.OrderByCriteria.SortOrder.ToString()}";
                }

                getAllWordsQuery += orderByCriteria;
            }

            if (criteria.Limit.HasValue)
            {
                string limitCriteria = " LIMIT @Limit";

                getAllWordsQuery += limitCriteria;
            }

            object queryParameters = new
            {
                SearchCriteria = $"%{criteria.SearchText?.ToLowerInvariant()}%",
                Limit = criteria.Limit ?? int.MaxValue
            };

            return queryParameters;
        }

        public WordPair[] GetUnknownWords(QueryCriteria criteria = null)
        {
            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
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
            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
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
            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
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
            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
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

            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
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

            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
            {
                dbConnection.Open();

                using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
                {
                    foreach (WordPair updatedWordPair in updatedWordPairs)
                    {
                        const string updateWordPairCommand =
                            @"UPDATE AllWords
                              SET 
                                FirstLanguageWord = @FirstLanguageWord, 
                                SecondLanguageWord = @SecondLanguageWord, 
                                ModifiedAt = @ModifiedAt,
                                LowercasedFirstLanguageWord = @LowercasedFirstLanguageWord,
                                LowercasedSecondLanguageWord = @LowercasedSecondLanguageWord
                              WHERE Id = @Id";
                        var queryParameters = new
                        {
                            FirstLanguageWord = updatedWordPair.FirstLanguageWord,
                            SecondLanguageWord = updatedWordPair.SecondLanguageWord,
                            ModifiedAt = updatedWordPair.ModifiedAt,
                            Id = updatedWordPair.Id,
                            LowercasedFirstLanguageWord = updatedWordPair.FirstLanguageWord.ToLowerInvariant(),
                            LowercasedSecondLanguageWord = updatedWordPair.SecondLanguageWord.ToLowerInvariant()
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
                
            using (var dbConnection = new SQLiteConnection(AppConfig.DatabaseConnectionString))
            {
                dbConnection.Open();

                using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
                {
                    foreach (WordPair addedWordPair in addedWordPairs)
                    {
                        const string insertNewWordPairCommand =
                            @"INSERT INTO AllWords
                              VALUES(
                                NULL, @FirstLanguageWord, @SecondLanguageWord, @LanguagePair, @CreatedAt, 
                                @ModifiedAt, @LowercasedFirstLanguageWord, @LowercasedSecondLanguageWord
                              )";
                        var queryParameters = new
                        {
                            FirstLanguageWord = addedWordPair.FirstLanguageWord,
                            SecondLanguageWord = addedWordPair.SecondLanguageWord,
                            LanguagePair = addedWordPair.LanguagePair,
                            CreatedAt = addedWordPair.CreatedAt,
                            ModifiedAt = addedWordPair.ModifiedAt,
                            LowercasedFirstLanguageWord = addedWordPair.FirstLanguageWord.ToLowerInvariant(),
                            LowercasedSecondLanguageWord = addedWordPair.SecondLanguageWord.ToLowerInvariant()
                        };

                        int affectedRows = dbConnection.Execute(insertNewWordPairCommand, queryParameters);

                        insertedWordPairsCount += affectedRows;
                    }

                    transaction.Commit();
                }
            }

            return insertedWordPairsCount;
        }
    }
}
