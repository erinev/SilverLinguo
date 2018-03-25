-- Script Date: 2018-03-24 17:58  - ErikEJ.SqlCeScripting version 3.5.2.75
CREATE TABLE [TestResults] (
  [Id] INTEGER NOT NULL
, [FinishedAt] TEXT NOT NULL
, [DurationAsTicks] TEXT NOT NULL
, [WordsType] INTEGER NOT NULL
, [LanguagePair] INTEGER NOT NULL
, [SelectedLanguage] INTEGER NOT NULL
, [TestType] INTEGER NOT NULL
, [NumberOfTotalWords] INTEGER NOT NULL
, [LearnedWordsAsJson] TEXT NOT NULL
, [UnknownWordsAsJson] TEXT NOT NULL
, CONSTRAINT [PK_TestResults] PRIMARY KEY ([Id])
);
