CREATE TABLE [UnknownWords] (
  [Id] INTEGER NOT NULL
, [Id_AllWords] INTEGER NOT NULL
, CONSTRAINT [PK_UnknownWords] PRIMARY KEY ([Id])
, FOREIGN KEY([Id_AllWords]) REFERENCES AllWords([Id])
);
