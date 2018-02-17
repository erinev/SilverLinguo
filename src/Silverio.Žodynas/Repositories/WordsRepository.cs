using System;
using System.Collections.Generic;
using Silverio.Žodynas.Models;

namespace Silverio.Žodynas.Repositories
{
    public class WordsRepository
    {
        public static WordPair[] GetWordsForTest()
        {
            return new[]
            {
                new WordPair {Id = 1, LithuanianWord = "Šuo", EnglishWord = "Dog"},
                new WordPair {Id = 2, LithuanianWord = "Katė", EnglishWord = "Cat"},
                new WordPair {Id = 3, LithuanianWord = "Namas", EnglishWord = "House"},
                new WordPair {Id = 4, LithuanianWord = "Kalnas", EnglishWord = "Mountain"},
                new WordPair {Id = 5, LithuanianWord = "Spalva", EnglishWord = "Color"},
                new WordPair {Id = 6, LithuanianWord = "Apelsinas", EnglishWord = "Orange"},
                new WordPair {Id = 7, LithuanianWord = "Beždžionė", EnglishWord = "Monkey"},
                new WordPair {Id = 8, LithuanianWord = "Jūra", EnglishWord = "Sea"},
                new WordPair {Id = 9, LithuanianWord = "Upė", EnglishWord = "River"},
                new WordPair {Id = 10, LithuanianWord = "Lėktuvas", EnglishWord = "Airplane"},
            };
        }

        public static WordPair[] GetUnknownWordsForTest()
        {
            return new[]
            {
                new WordPair {Id = 1, LithuanianWord = "Medis", EnglishWord = "Tree"},
                new WordPair {Id = 2, LithuanianWord = "Žiema", EnglishWord = "Winter"},
                new WordPair {Id = 3, LithuanianWord = "Bulvė", EnglishWord = "Potato"},
            };
        }

        public static void AddNewUnknownWords(IList<WordPair> newUnknownWords)
        {
            throw new NotImplementedException();
        }

        public static void RemoveLearnedUnknownWords(IList<WordPair> newUnknownWords)
        {
            throw new NotImplementedException();
        }
    }
}
