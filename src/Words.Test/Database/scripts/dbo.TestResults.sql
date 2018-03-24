CREATE TABLE [dbo].[TestResults] (
    [Id]                 INT             NOT NULL IDENTITY,
    [FinishedAt]         DATETIME        NOT NULL,
    [DurationAsTicks]    BIGINT          NOT NULL,
    [WordsType]          NVARCHAR (100)     NOT NULL,
    [SelectedLanguage]   NVARCHAR (100)     NOT NULL,
    [TestType]           NVARCHAR (100)     NOT NULL,
    [NumberOfTotalWords] INT             NOT NULL,
    [LearnedWordsAsJson] NVARCHAR (MAX) COLLATE Lithuanian_CI_AS NOT NULL,
    [UnknownWordsAsJson] NVARCHAR (MAX) COLLATE Lithuanian_CI_AS NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO