using System;
using System.Linq;
using SilverLinguo.Extensions;
using SilverLinguo.Repositories;
using SilverLinguo.Repositories.Models;

namespace SilverLinguo.Services
{
    public interface IWordsService
    {
        bool CheckIfWordsMatches(string suppliedWord, string expectedWord);
        int GetAllWordsCount();
        int GetUnknownWordsCount();
        WordPair[] GetAllWords(bool shouldShuffle);
        WordPair[] GetUnknownWords(bool shouldShuffle);
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

        public bool CheckIfWordsMatches(string suppliedWord, string expectedWord)
        {
            string[] expectedWords = expectedWord.Split(',')
                .Select(ev => ev.Trim().ToLowerInvariant())
                .OrderBy(ev => ev)
                .ToArray();
            expectedWords = expectedWords.OrderBy(x => x).ToArray();

            string[] enteredWords = suppliedWord.Split(',')
                .Select(ev => ev.Trim().ToLowerInvariant())
                .OrderBy(ev => ev)
                .ToArray();

            bool isEnteredValueIsEqualToExpectedValue = expectedWords.SequenceEqual(enteredWords);

            return isEnteredValueIsEqualToExpectedValue;
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

        public WordPair[] GetAllWords(bool shouldShuffle)
        {
            WordPair[] words = _wordsRepository.GetAllWords();

            if (shouldShuffle)
            {
                new Random().Shuffle(words);
            }

            return words;
        }

        public WordPair[] GetUnknownWords(bool shouldShuffle)
        {
            WordPair[] unknownWords = _wordsRepository.GetUnknownWords();

            if (shouldShuffle)
            {
                new Random().Shuffle(unknownWords);
            }

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
