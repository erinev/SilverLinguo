-- Script Date: 2018-03-24 17:58  - ErikEJ.SqlCeScripting version 3.5.2.75
CREATE TABLE [UnknownWords] (
  [Id] INTEGER NOT NULL
, [Id_AllWords] INTEGER NOT NULL
, CONSTRAINT [PK_UnknownWords] PRIMARY KEY ([Id])
, FOREIGN KEY([Id_AllWords]) REFERENCES AllWords([Id])
);
