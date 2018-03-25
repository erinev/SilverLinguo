CREATE TABLE [AllWords] (
  [Id] INTEGER NOT NULL
, [FirstLanguageWord] TEXT NOT NULL
, [SecondLanguageWord] TEXT NOT NULL
, [LanguagePair] INTEGER NOT NULL
, [CreatedAt] TEXT NOT NULL
, [ModifiedAt] TEXT NOT NULL
, CONSTRAINT [PK_AllWords] PRIMARY KEY ([Id])
, UNIQUE(FirstLanguageWord, SecondLanguageWord, LanguagePair)
);
