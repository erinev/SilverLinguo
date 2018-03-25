using System;
using Words.Test.Enums;

namespace Words.Test.Repositories.Models
{
    public class WordPair
    {
        public int Id { get; set; }
        public string FirstLanguageWord { get; set; }
        public string SecondLanguageWord { get; set; }
        public LanguagePair LanguagePair { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public class WordPairQueries
    {
        public const string GetAllWordsQuery = 
            @"select 
                AW.Id, AW.FirstLanguageWord, AW.SecondLanguageWord, AW.LanguagePair, AW.CreatedAt, AW.ModifiedAt  
              from AllWords AW";

        public const string GetUnknownWordsQuery = 
            @"select 
                AW.Id, AW.FirstLanguageWord, AW.SecondLanguageWord, AW.LanguagePair, AW.CreatedAt, AW.ModifiedAt  
              from UnknownWords UW
              join AllWords AW ON UW.ID_AllWords = AW.Id";

        public const string CheckIfUnknownWordExist = 
            @"select top 1 
                1
              from UnknownWords
              where ID_AllWords = @WordId";
    }
}
