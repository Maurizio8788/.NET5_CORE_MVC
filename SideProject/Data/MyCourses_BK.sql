-- Script Date: 24/10/2021 23:38  - ErikEJ.SqlCeScripting version 3.5.2.90
CREATE TABLE [Courses] (
  [Id] INTEGER NOT NULL
, [Title] TEXT NOT NULL
, [Description] TEXT NULL
, [ImagePath] TEXT NULL
, [Author] TEXT NOT NULL
, [Email] TEXT NULL
, [Rating] REAL DEFAULT (0) NOT NULL
, [FullPrice_Amount] NUMERIC DEFAULT (0) NOT NULL
, [FullPrice_Currency] TEXT DEFAULT ('EUR') NOT NULL
, [CurrentPrice_Amount] NUMERIC DEFAULT (0) NOT NULL
, [CurrentPrice_Currency] TEXT DEFAULT ('EUR') NOT NULL
, CONSTRAINT [PK_Courses] PRIMARY KEY ([Id])
);
