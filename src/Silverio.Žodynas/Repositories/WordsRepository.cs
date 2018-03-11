using Silverio.Žodynas.Models;

namespace Silverio.Žodynas.Repositories
{
    public interface IWordsRepository
    {
        WordPair[] GetWordsForTest();
        WordPair[] GetUnknownWordsForTest();
    }

    public class WordsRepository : IWordsRepository
    {
        public WordPair[] GetWordsForTest()
        {
            return new[]
            {
                new WordPair {Id = 1, LithuanianWord = "Pirmadienis", EnglishWord = "Monday"},
                new WordPair {Id = 2, LithuanianWord = "Šiandien", EnglishWord = "Today"},
                new WordPair {Id = 3, LithuanianWord = "Metai", EnglishWord = "Year"},
                new WordPair {Id = 4, LithuanianWord = "Laikrodis", EnglishWord = "Clock"},
                new WordPair {Id = 5, LithuanianWord = "Valanda", EnglishWord = "Hour"},
                new WordPair {Id = 6, LithuanianWord = "Pavasaris", EnglishWord = "Spring"},
                new WordPair {Id = 7, LithuanianWord = "Viso gero", EnglishWord = "Good bye"},
                new WordPair {Id = 8, LithuanianWord = "Senelis", EnglishWord = "Grandfather, Grandpa, Grandad"},
                new WordPair {Id = 9, LithuanianWord = "Grybas", EnglishWord = "Mushroom"},
                new WordPair {Id = 10, LithuanianWord = "Book bag", EnglishWord = "Kuprinė"},
                new WordPair {Id = 11, LithuanianWord = "Man patinka mėlynas dangus", EnglishWord = "I like blue sky"},
            };
        }

        public WordPair[] GetUnknownWordsForTest()
        {
            return new[]
            {
                new WordPair {Id = 1, LithuanianWord = "Stogas", EnglishWord = "Roof"},
                new WordPair {Id = 2, LithuanianWord = "Šiukšlės", EnglishWord = "Recycle"},
                new WordPair {Id = 3, LithuanianWord = "Parduotuvė", EnglishWord = "Shop, Store"},
                new WordPair {Id = 4, LithuanianWord = "Aitvaras", EnglishWord = "Kite"},
            };
        }
    }
}
