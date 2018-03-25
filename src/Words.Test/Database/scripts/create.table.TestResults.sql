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
, [KnownWordsAsJson] TEXT NOT NULL
, [NewUnknownWordsAsJson] TEXT NOT NULL
, [UnknownWordsAsJson] TEXT NOT NULL
, CONSTRAINT [PK_TestResults] PRIMARY KEY ([Id])
);
