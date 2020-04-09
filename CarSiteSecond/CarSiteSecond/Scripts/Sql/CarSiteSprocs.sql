USE CarSite
GO
IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateDB'
)
BEGIN
DROP PROCEDURE [CreateDB]
END
GO

CREATE PROCEDURE [CreateDB]
AS

IF DB_ID('CarSite') IS NOT NULL
DROP DATABASE [CarSite]
CREATE DATABASE [CarSite]

CREATE TABLE [Contacts]
([id] INT Primary Key Identity(1,1),
[Name] nvarchar(50) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[Phone] nvarchar(50) NOT NULL,
[Message] nvarchar(500) NOT NULL)

CREATE TABLE [Sales]
([id] INT Primary Key Identity(1,1),
[PurchaseType] INT NOT NULL,
[Name] nvarchar(50) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[Street1] nvarchar(50) NOT NULL,
[Street2] nvarchar(50) NULL,
[City] nvarchar(50) NOT NULL,
[State] nvarchar(50) NOT NULL,
[Zip] varchar(10) NOT NULL,
[Phone] nvarchar(50) NOT NULL,
[CarID] int NOT NULL,
[UserID] nvarchar(128) NOT NULL,
[PurchasePrice] decimal(15,2) NOT NULL)

CREATE TABLE [Interior]
([id] INT Primary Key Identity (1,1),
[Interior] nvarchar(50) NOT NULL)

CREATE TABLE [Color]
([id] INT Primary Key Identity (1,1),
[Color] nvarchar(50) NOT NULL)

CREATE TABLE [PurchaseType]
([id] INT Primary Key Identity (1,1),
[Type] nvarchar(50) NOT NULL)

CREATE TABLE [Cars]
([id] INT PRIMARY KEY IDENTITY (1,1),
[ModelID] INT NOT NULL,
[Year] INT NOT NULL,
[BodyStyle] nvarchar(50) NOT NULL,
[Transmission] nvarchar(50) NOT NULL,
[PictureSrc] nvarchar(100) NOT NULL,
[InteriorID] INT NOT NULL,
[Mileage] INT NOT NULL,
[VIN] nvarchar(50) NOT NULL,
[SalePrice] decimal(15,2) NOT NULL,
[MSRP] decimal(15,2) NOT NULL,
[Featured] bit NOT NULL,
[ColorID] INT NOT NULL)

CREATE TABLE [Make]
([id] INT PRIMARY KEY IDENTITY(1,1),
[MakeName] nvarchar(50) NOT NULL,
[DateAdded] DATE NOT NULL,
[UserID] nvarchar(128) NOT NULL)

CREATE TABLE [Model]
([id] INT PRIMARY KEY IDENTITY(1,1),
[ModelName] nvarchar(50) NOT NULL,
[MakeID] INT NOT NULL,
[DateAdded] DATE NOT NULL,
[UserID] nvarchar(128) NOT NULL)

ALTER TABLE Sales
ADD CONSTRAINT FK_SalesPurchaseType
FOREIGN KEY (PurchaseType) REFERENCES PurchaseType(id);

ALTER TABLE Sales
ADD CONSTRAINT FK_SalesCarID
FOREIGN KEY (CarID) REFERENCES Cars(id);

ALTER TABLE Sales
ADD CONSTRAINT FK_SalesUsers
FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);

ALTER TABLE Make
ADD CONSTRAINT FK_MakeUsers
FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);

ALTER TABLE Model
ADD CONSTRAINT FK_ModelUsers
FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);

ALTER TABLE Model
ADD CONSTRAINT FK_ModelMake
FOREIGN KEY (MakeID) REFERENCES Make(id);

ALTER TABLE Cars
ADD CONSTRAINT FK_CarsInterior
FOREIGN KEY (InteriorID) REFERENCES Interior(id);

ALTER TABLE Cars
ADD CONSTRAINT FK_CarsColor
FOREIGN KEY (ColorID) REFERENCES Color(id);

ALTER TABLE Cars
ADD CONSTRAINT FK_CarsModel
FOREIGN KEY (ModelID) REFERENCES Model(id);
GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'DropDB'
)
BEGIN
DROP PROCEDURE [DropDB]
END
GO

CREATE PROCEDURE [DropDB]
AS

IF DB_ID('CarSite') IS NOT NULL
DROP DATABASE [CarSite]
GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'DropTables'
)
BEGIN
DROP PROCEDURE [DropTables]
END
GO

CREATE PROCEDURE [DropTables]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales')) 
BEGIN
ALTER TABLE Sales
DROP CONSTRAINT FK_SalesPurchaseType;
ALTER TABLE Sales
DROP CONSTRAINT FK_SalesCarID;
ALTER TABLE Sales
DROP CONSTRAINT FK_SalesUsers;
DROP TABLE Sales
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
ALTER TABLE Cars
DROP CONSTRAINT FK_CarsInterior;
ALTER TABLE Cars
DROP CONSTRAINT FK_CarsColor;
ALTER TABLE Cars
DROP CONSTRAINT FK_CarsModel;
DROP TABLE [Cars]
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Color')) 
BEGIN
DROP TABLE Color
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Contacts')) 
BEGIN
DROP TABLE Contacts
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Interior')) 
BEGIN
DROP TABLE Interior
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Model')) 
BEGIN
ALTER TABLE Model
DROP CONSTRAINT FK_ModelUsers;
ALTER TABLE Model
DROP CONSTRAINT FK_ModelMake;
DROP TABLE Model
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Make')) 
BEGIN
ALTER TABLE Make
DROP CONSTRAINT FK_MakeUsers;
DROP TABLE Make
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'PurchaseType')) 
BEGIN
DROP TABLE PurchaseType
END
GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateTables'
)
BEGIN
DROP PROCEDURE [CreateTables]
END
GO

CREATE PROCEDURE [CreateTables]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales')) 
BEGIN
ALTER TABLE Sales
DROP CONSTRAINT FK_SalesPurchaseType;
ALTER TABLE Sales
DROP CONSTRAINT FK_SalesCarID;
ALTER TABLE Sales
DROP CONSTRAINT FK_SalesUsers;
DROP TABLE Sales
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
ALTER TABLE Cars
DROP CONSTRAINT FK_CarsInterior;
ALTER TABLE Cars
DROP CONSTRAINT FK_CarsColor;
ALTER TABLE Cars
DROP CONSTRAINT FK_CarsModel;
DROP TABLE [Cars]
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Color')) 
BEGIN
DROP TABLE Color
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Contacts')) 
BEGIN
DROP TABLE Contacts
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Interior')) 
BEGIN
DROP TABLE Interior
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Model')) 
BEGIN
ALTER TABLE Model
DROP CONSTRAINT FK_ModelUsers;
ALTER TABLE Model
DROP CONSTRAINT FK_ModelMake;
DROP TABLE Model
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Make')) 
BEGIN
ALTER TABLE Make
DROP CONSTRAINT FK_MakeUsers;
DROP TABLE Make
END
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'PurchaseType')) 
BEGIN
DROP TABLE PurchaseType
END

CREATE TABLE [Contacts]
([id] INT Primary Key Identity(1,1),
[Name] nvarchar(50) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[Phone] nvarchar(50) NOT NULL,
[Message] nvarchar(500) NOT NULL)

CREATE TABLE [Sales]
([id] INT Primary Key Identity(1,1),
[PurchaseType] INT NOT NULL,
[Name] nvarchar(50) NOT NULL,
[Email] nvarchar(50) NOT NULL,
[Street1] nvarchar(50) NOT NULL,
[Street2] nvarchar(50) NULL,
[City] nvarchar(50) NOT NULL,
[State] nvarchar(50) NOT NULL,
[Zip] varchar(10) NOT NULL,
[Phone] nvarchar(50) NOT NULL,
[CarID] int NOT NULL,
[UserID] nvarchar(128) NOT NULL,
[PurchasePrice] decimal(15,2) NOT NULL)

CREATE TABLE [Interior]
([id] INT Primary Key Identity (1,1),
[Interior] nvarchar(50) NOT NULL)

CREATE TABLE [Color]
([id] INT Primary Key Identity (1,1),
[Color] nvarchar(50) NOT NULL)

CREATE TABLE [PurchaseType]
([id] INT Primary Key Identity (1,1),
[Type] nvarchar(50) NOT NULL)

CREATE TABLE [Cars]
([id] INT PRIMARY KEY IDENTITY (1,1),
[ModelID] INT NOT NULL,
[Year] INT NOT NULL,
[BodyStyle] nvarchar(50) NOT NULL,
[Transmission] nvarchar(50) NOT NULL,
[PictureSrc] nvarchar(100) NOT NULL,
[InteriorID] INT NOT NULL,
[Mileage] INT NOT NULL,
[VIN] nvarchar(50) NOT NULL,
[SalePrice] decimal(15,2) NOT NULL,
[MSRP] decimal(15,2) NOT NULL,
[Featured] bit NOT NULL,
[ColorID] INT NOT NULL)

CREATE TABLE [Make]
([id] INT PRIMARY KEY IDENTITY(1,1),
[MakeName] nvarchar(50) NOT NULL,
[DateAdded] DATE NOT NULL,
[UserID] nvarchar(128) NOT NULL)

CREATE TABLE [Model]
([id] INT PRIMARY KEY IDENTITY(1,1),
[ModelName] nvarchar(50) NOT NULL,
[MakeID] INT NOT NULL,
[DateAdded] DATE NOT NULL,
[UserID] nvarchar(128) NOT NULL)

ALTER TABLE Sales
ADD CONSTRAINT FK_SalesPurchaseType
FOREIGN KEY (PurchaseType) REFERENCES PurchaseType(id);

ALTER TABLE Sales
ADD CONSTRAINT FK_SalesCarID
FOREIGN KEY (CarID) REFERENCES Cars(id);

ALTER TABLE Sales
ADD CONSTRAINT FK_SalesUsers
FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);

ALTER TABLE Make
ADD CONSTRAINT FK_MakeUsers
FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);

ALTER TABLE Model
ADD CONSTRAINT FK_ModelUsers
FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id);

ALTER TABLE Model
ADD CONSTRAINT FK_ModelMake
FOREIGN KEY (MakeID) REFERENCES Make(id);

ALTER TABLE Cars
ADD CONSTRAINT FK_CarsInterior
FOREIGN KEY (InteriorID) REFERENCES Interior(id);

ALTER TABLE Cars
ADD CONSTRAINT FK_CarsColor
FOREIGN KEY (ColorID) REFERENCES Color(id);

ALTER TABLE Cars
ADD CONSTRAINT FK_CarsModel
FOREIGN KEY (ModelID) REFERENCES Model(id);

GO
--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'GetAll'
--)
--BEGIN
--	DROP PROCEDURE GetAll
--END
--GO

--CREATE PROCEDURE GetAll
--AS

--SELECT *
--FROM DVDsADO
--ORDER BY [DVD ID]

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'GetByID'
--)
--BEGIN
--	DROP PROCEDURE GetByID
--END
--GO

--CREATE PROCEDURE GetByID(
--	@ID int
--)
--AS

--SELECT *
--FROM DVDsADO
--WHERE [DVD ID] = @ID
--ORDER BY [DVD ID]

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'GetByTitle'
--)
--BEGIN
--	DROP PROCEDURE GetByTitle
--END
--GO

--CREATE PROCEDURE GetByTitle(
--	@Title nvarchar(50)
--)
--AS

--SELECT *
--FROM DVDsADO
--WHERE [Title] LIKE @Title
--ORDER BY [DVD ID]

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'GetByYear'
--)
--BEGIN
--	DROP PROCEDURE GetByYear
--END
--GO

--CREATE PROCEDURE GetByYear(
--	@Year int
--)
--AS

--SELECT *
--FROM DVDsADO
--WHERE [Release Year] = @Year
--ORDER BY [DVD ID]

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'GetByDirector'
--)
--BEGIN
--	DROP PROCEDURE GetByDirector
--END
--GO

--CREATE PROCEDURE GetByDirector(
--	@Name nvarchar(50)
--)
--AS

--SELECT *
--FROM DVDsADO
--WHERE [Director] LIKE @Name
--ORDER BY [DVD ID]

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'GetByRating'
--)
--BEGIN
--	DROP PROCEDURE GetByRating
--END
--GO

--CREATE PROCEDURE GetByRating(
--	@Rating nvarchar(50)
--)
--AS

--SELECT *
--FROM DVDsADO
--WHERE [Rating] = @Rating
--ORDER BY [DVD ID]

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'NewDVD'
--)
--BEGIN
--	DROP PROCEDURE NewDVD
--END
--GO

--CREATE PROCEDURE NewDVD(
--	@Title nvarchar(50),
--	@Year int,
--	@Name nvarchar(50),
--	@Rating nvarchar(50),
--	@Notes nvarchar(50)
--)
--AS

--INSERT INTO DVDsADO
--([Title],[Release Year],[Director],[Rating],[Notes])
--VALUES
--(@Title,@Year,@Name,@Rating,@Notes);

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'UpdateDVD'
--)
--BEGIN
--	DROP PROCEDURE UpdateDVD
--END
--GO

--CREATE PROCEDURE UpdateDVD(
--	@ID int,
--	@Title nvarchar(50),
--	@Year int,
--	@Name nvarchar(50),
--	@Rating nvarchar(50),
--	@Notes nvarchar(50)
--)
--AS

--UPDATE DVDsADO
--SET Title = @Title, [Release Year] = @Year, [Director] = @Name, [Rating] = @Rating, [Notes] = @Notes
--WHERE [DVD ID] = @ID;

--GO

--IF EXISTS(
--	SELECT *
--	FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'DeleteDVD'
--)
--BEGIN
--	DROP PROCEDURE DeleteDVD
--END
--GO

--CREATE PROCEDURE DeleteDVD(
--	@ID int
--)
--AS

--DELETE FROM DVDsADO
--WHERE [DVD ID] = @ID;

--GO