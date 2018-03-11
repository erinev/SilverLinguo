using System;
using Silverio.Žodynas.Helpers;
using Silverio.Žodynas.Models;
using Silverio.Žodynas.Repositories;

namespace Silverio.Žodynas.Services
{
    public interface IWordsService
    {
        int GetWordsCount();
        int GetUnknownWordsCount();
        WordPair[] GetRandomlySortedWords();
        WordPair[] GetRandomlySortedUnknownWords();
    }

    public class WordsService : IWordsService
    {
        private readonly IWordsRepository _wordsRepository;

        public WordsService()
        {
            _wordsRepository = new WordsRepository();
        }

        public int GetWordsCount()
        {
            WordPair[] words = _wordsRepository.GetWordsForTest();

            return words.Length;
        }

        public int GetUnknownWordsCount()
        {
            WordPair[] unknownWords = _wordsRepository.GetUnknownWordsForTest();

            return unknownWords.Length;
        }

        public WordPair[] GetRandomlySortedWords()
        {
            WordPair[] words = _wordsRepository.GetWordsForTest();

            new Random().Shuffle(words);

            return words;
        }

        public WordPair[] GetRandomlySortedUnknownWords()
        {
            WordPair[] unknownWords = _wordsRepository.GetUnknownWordsForTest();

            new Random().Shuffle(unknownWords);

            return unknownWords;
        }
    }
}
