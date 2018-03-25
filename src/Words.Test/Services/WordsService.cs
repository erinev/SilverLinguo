using System;
using Words.Test.Extensions;
using Words.Test.Repositories;
using Words.Test.Repositories.Models;

namespace Words.Test.Services
{
    public interface IWordsService
    {
        int GetAllWordsCount();
        int GetUnknownWordsCount();
        WordPair[] GetRandomlySortedAllWords();
        WordPair[] GetRandomlySortedUnknownWords();
    }

    public class WordsService : IWordsService
    {
        private readonly IWordsRepository _wordsRepository;

        public WordsService()
        {
            _wordsRepository = new WordsRepository();
        }

        public int GetAllWordsCount()
        {
            WordPair[] words = _wordsRepository.GetAllWords();

            return words.Length;
        }

        public int GetUnknownWordsCount()
        {
            WordPair[] unknownWords = _wordsRepository.GetUnknownWords();

            return unknownWords.Length;
        }

        public WordPair[] GetRandomlySortedAllWords()
        {
            WordPair[] words = _wordsRepository.GetAllWords();

            new Random().Shuffle(words);

            return words;
        }

        public WordPair[] GetRandomlySortedUnknownWords()
        {
            WordPair[] unknownWords = _wordsRepository.GetUnknownWords();

            new Random().Shuffle(unknownWords);

            return unknownWords;
        }
    }
}
