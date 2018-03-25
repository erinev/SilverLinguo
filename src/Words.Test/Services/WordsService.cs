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
        bool InsertNewUnknownWordIfDoesntExist(WordPair newUnknownWordCandidate);
        bool RemoveLearnedUnknownWordIfExist(WordPair learnedWord);
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

        public bool InsertNewUnknownWordIfDoesntExist(WordPair newUnknownWordCandidate)
        {
            bool unknownWordAdded = false;

            bool unknownWordAlreadyExist = _wordsRepository.CheckIfUnknownWordAlreadyExist(newUnknownWordCandidate.Id);
            if (!unknownWordAlreadyExist)
            {
                unknownWordAdded = _wordsRepository.AddNewUnknownWord(newUnknownWordCandidate.Id);
            }

            return unknownWordAdded;
        }

        public bool RemoveLearnedUnknownWordIfExist(WordPair learnedWord)
        {
            bool unknownWordRemoved = false;

            bool unknownWordExists = _wordsRepository.CheckIfUnknownWordAlreadyExist(learnedWord.Id);
            if (unknownWordExists)
            {
                unknownWordRemoved = _wordsRepository.RemoveLearnedUnknownWord(learnedWord.Id);
            }

            return unknownWordRemoved;
        }
    }
}
