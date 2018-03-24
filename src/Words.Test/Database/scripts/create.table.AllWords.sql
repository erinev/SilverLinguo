-- Script Date: 2018-03-24 17:58  - ErikEJ.SqlCeScripting version 3.5.2.75
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
