USE [master]
GO

DROP DATABASE if exists [DVDLibrary]
CREATE DATABASE [DVDLibrary]

GO
USE [DVDLibrary]

CREATE TABLE [DVDsADO]
([DVD ID] INT Primary Key Identity(1,1),
[Title] nvarchar(50) NOT NULL,
[Release Year] INT NOT NULL,
[Director] nvarchar(50) NOT NULL,
[Rating] nvarchar(50) NOT NULL,
[Notes] nvarchar(50) NULL)
GO