using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SilverLinguo.Dto;
using SilverLinguo.Enums;
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

        bool RemoveWordsDeletedInAdminPanel(List<WordPairForDataGridView> deletedWordPairsForDataGridView);
        bool UpdatedWordsChangedInAdminPanel(List<WordPairForDataGridView> updatedWordPairsForDataGridView,
            DateTime modificationTime);
        bool SaveWordsNewlyAddedInAdminPanel(List<WordPairForDataGridView> addedWordPairsForDataGridView,
            DateTime modificationTime);
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

        public bool RemoveWordsDeletedInAdminPanel(List<WordPairForDataGridView> deletedWordPairsForDataGridView)
        {
            IEnumerable<int> wordPairIdsToRemove = deletedWordPairsForDataGridView.Select(dw => dw.Id);

            int removedWordPairsCount = _wordsRepository.RemoveAllWordsByIds(wordPairIdsToRemove);

            return removedWordPairsCount == deletedWordPairsForDataGridView.Count;
        }

        public bool UpdatedWordsChangedInAdminPanel(List<WordPairForDataGridView> updatedWordPairsForDataGridView, DateTime modificationTime)
        {
            IEnumerable<WordPair> updatedWordPairs = updatedWordPairsForDataGridView.Select(MapToDataGridViewStructure);

            updatedWordPairs = updatedWordPairs.Select(w => UpdateModifiedAtDateForChangedWords(w, modificationTime));

            int updatedWordPairsCount = _wordsRepository.UpdateMultipleWordPairs(updatedWordPairs);

            return updatedWordPairsCount == updatedWordPairsForDataGridView.Count;
        }

        public bool SaveWordsNewlyAddedInAdminPanel(List<WordPairForDataGridView> addedWordPairsForDataGridView,
            DateTime modificationTime)
        {
            IEnumerable<WordPair> addedWordPairs = addedWordPairsForDataGridView.Select(MapToDataGridViewStructure);

            addedWordPairs = addedWordPairs.Select(w => PrepareAddedWords(w, modificationTime));

            int addedWordPairsCount = _wordsRepository.InsertMultipleWordPairs(addedWordPairs);

            return addedWordPairsCount == addedWordPairsForDataGridView.Count;
        }

        private WordPair MapToDataGridViewStructure(WordPairForDataGridView wordPairForDataGridView)
        {
            return new WordPair
            {
                Id = wordPairForDataGridView.Id,
                FirstLanguageWord = wordPairForDataGridView.FirstLanguageWord,
                SecondLanguageWord = wordPairForDataGridView.SecondLanguageWord,
                LanguagePair = wordPairForDataGridView.LanguagePair,
                CreatedAt = wordPairForDataGridView.CreatedAt,
                ModifiedAt = wordPairForDataGridView.ModifiedAt
            };
        }

        private WordPair UpdateModifiedAtDateForChangedWords(WordPair wordPair, DateTime modificationTime)
        {
            wordPair.ModifiedAt = modificationTime;

            return wordPair;
        }

        private WordPair PrepareAddedWords(WordPair wordPair, DateTime modificationTime)
        {
            wordPair.LanguagePair = LanguagePair.LithuanianEnglish;

            wordPair.CreatedAt = modificationTime;
            wordPair.ModifiedAt = modificationTime;

            return wordPair;
        }
    }
}
