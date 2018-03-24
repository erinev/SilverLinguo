CREATE TABLE [dbo].[AllWords] (
    [Id]             INT         NOT NULL IDENTITY,
    [LithuanianWord] NVARCHAR (500) COLLATE Lithuanian_CI_AS NOT NULL,
    [EnglishWord]    NVARCHAR (500) NOT NULL,
    [CreatedAt]      DATETIME    NOT NULL,
    [ModifiedAt]     DATETIME    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO