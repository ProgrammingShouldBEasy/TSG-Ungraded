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

CREATE TABLE [Specials]
([id] INT Primary Key Identity(1,1),
[Title] nvarchar(50) NOT NULL,
[Text] nvarchar(500) NOT NULL)

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
WHERE ROUTINE_NAME = 'GetUsersAll'
)
BEGIN
DROP PROCEDURE [GetUsersAll]
END
GO

CREATE PROCEDURE [GetUsersAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Users')) 
BEGIN
Select *
FROM [Users]
ORDER BY [Id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetSpecialsAll'
)
BEGIN
DROP PROCEDURE [GetSpecialsAll]
END
GO

CREATE PROCEDURE [GetSpecialsAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Specials')) 
BEGIN
Select *
FROM [Specials]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetSpecialsOne'
)
BEGIN
DROP PROCEDURE [GetSpecialsOne]
END
GO

CREATE PROCEDURE [GetSpecialsOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Specials')) 
BEGIN
Select *
FROM [Specials]
WHERE id = @ID
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateSpecialsOne'
)
BEGIN
DROP PROCEDURE [CreateSpecialsOne]
END
GO

CREATE PROCEDURE [CreateSpecialsOne] (@Title nvarchar(50), @Text nvarchar(500))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Specials')) 
BEGIN
INSERT INTO [Specials]
([Title], [Text])
VALUES
(@Title, @Text)
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'UpdateSpecialsOne'
)
BEGIN
DROP PROCEDURE [UpdateSpecialsOne]
END
GO

CREATE PROCEDURE [UpdateSpecialsOne] (@ID int, @Title nvarchar(50), @Text nvarchar(500))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Specials')) 
BEGIN
UPDATE [Specials]
SET [Title] = @Title, [Text] = @Text
WHERE
[id] = @ID
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'DeleteSpecialsOne'
)
BEGIN
DROP PROCEDURE [DeleteSpecialsOne]
END
GO

CREATE PROCEDURE [DeleteSpecialsOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Specials')) 
BEGIN
DELETE FROM 
Specials
WHERE
[id] = @ID
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetCarsAll'
)
BEGIN
DROP PROCEDURE [GetCarsAll]
END
GO

CREATE PROCEDURE [GetCarsAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
Select *
FROM [Cars]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetCarsOne'
)
BEGIN
DROP PROCEDURE [GetCarsOne]
END
GO

CREATE PROCEDURE [GetCarsOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
Select *
FROM [Cars]
WHERE id = @ID
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateCarsOne'
)
BEGIN
DROP PROCEDURE [CreateCarsOne]
END
GO

CREATE PROCEDURE [CreateCarsOne] (@ModelID int, @Year int, @BodyStyle nvarchar(50), 
@Transmission nvarchar(50), @PictureSrc nvarchar(100), @InteriorID int, @Mileage int, @VIN nvarchar(50),
@SalePrice decimal(15,2), @MSRP decimal(15,2), @Featured bit, @ColorID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
INSERT INTO [Cars]
([ModelID],[Year],[BodyStyle],[Transmission],[PictureSrc],[InteriorID],[Mileage],[VIN],[SalePrice],[MSRP],[Featured],[ColorID])
VALUES
(@ModelID,@Year,@BodyStyle,@Transmission,@PictureSrc,@InteriorID,@Mileage,@VIN,@SalePrice,@MSRP,@Featured,@ColorID)
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'UpdateCarsOne'
)
BEGIN
DROP PROCEDURE [UpdateCarsOne]
END
GO

CREATE PROCEDURE [UpdateCarsOne] (@ID int, @ModelID int, @Year int, @BodyStyle nvarchar(50), 
@Transmission nvarchar(50), @PictureSrc nvarchar(100), @InteriorID int, @Mileage int, @VIN nvarchar(50),
@SalePrice decimal(15,2), @MSRP decimal(15,2), @Featured bit, @ColorID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
UPDATE [Cars]
SET [ModelID] = @ModelID, [Year] = @Year, [BodyStyle] = @BodyStyle, [Transmission] = @Transmission, [PictureSrc] = @PictureSrc,
[InteriorID] = @InteriorID, [Mileage] = @Mileage, [VIN] = @VIN, [SalePrice] = @SalePrice, [MSRP] = @MSRP, [Featured] = @Featured,
[ColorID] = @ColorID
WHERE
[id] = @ID
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'DeleteCarsOne'
)
BEGIN
DROP PROCEDURE [DeleteCarsOne]
END
GO

CREATE PROCEDURE [DeleteCarsOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
DELETE FROM 
Cars
WHERE
[id] = @ID
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateContactsOne'
)
BEGIN
DROP PROCEDURE [CreateContactsOne]
END
GO

CREATE PROCEDURE [CreateContactsOne] (@Name nvarchar(50), @Email nvarchar(50), @Phone nvarchar(50), @Message nvarchar(500))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Contacts')) 
BEGIN
INSERT INTO [Contacts]
([Name],[Email],[Phone],[Message])
VALUES
(@Name,@Email,@Phone,@Message)
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetMakesAll'
)
BEGIN
DROP PROCEDURE [GetMakesAll]
END
GO

CREATE PROCEDURE [GetMakesAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Make')) 
BEGIN
Select *
FROM [Make]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetMakesOne'
)
BEGIN
DROP PROCEDURE [GetMakesOne]
END
GO

CREATE PROCEDURE [GetMakesOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Make')) 
BEGIN
Select *
FROM [Make]
WHERE id = @ID
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateMakesOne'
)
BEGIN
DROP PROCEDURE [CreateMakesOne]
END
GO

CREATE PROCEDURE [CreateMakesOne] (@MakeName nvarchar(50), @DateAdded date, @UserID nvarchar(128))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Make')) 
BEGIN
INSERT INTO [Make]
([MakeName],[DateAdded],[UserID])
VALUES
(@MakeName, @DateAdded, @UserID)
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetModelsAll'
)
BEGIN
DROP PROCEDURE [GetModelsAll]
END
GO

CREATE PROCEDURE [GetModelsAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Model')) 
BEGIN
Select *
FROM [Model]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetModelsOne'
)
BEGIN
DROP PROCEDURE [GetModelsOne]
END
GO

CREATE PROCEDURE [GetModelsOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Make')) 
BEGIN
Select *
FROM [Model]
WHERE id = @ID
ORDER BY [id]
END

GO


IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateModelsOne'
)
BEGIN
DROP PROCEDURE [CreateModelsOne]
END
GO

CREATE PROCEDURE [CreateModelsOne] (@ModelName nvarchar(50), @MakeID int, @DateAdded date, @UserID nvarchar(128))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Model')) 
BEGIN
INSERT INTO [Model]
([ModelName],[MakeID],[DateAdded],[UserID])
VALUES
(@ModelName, @MakeID, @DateAdded, @UserID)
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetSalesAll'
)
BEGIN
DROP PROCEDURE [GetSalesAll]
END
GO

CREATE PROCEDURE [GetSalesAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales')) 
BEGIN
Select *
FROM [Sales]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetSalesOne'
)
BEGIN
DROP PROCEDURE [GetSalesOne]
END
GO

CREATE PROCEDURE [GetSalesOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales')) 
BEGIN
Select *
FROM [Sales]
WHERE id = @ID
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'CreateSalesOne'
)
BEGIN
DROP PROCEDURE [CreateSalesOne]
END
GO

CREATE PROCEDURE [CreateSalesOne] (@PurchaseType int, @Name nvarchar(50), @Email nvarchar(50), @Street1 nvarchar(50), @Street2 nvarchar(50), @City nvarchar(50), @State nvarchar(50), @Zip varchar(10), @Phone nvarchar(50), @CarID int, @UserID nvarchar(50), @PurchasePrice decimal(15,2))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales')) 
BEGIN
INSERT INTO [Sales]
([PurchaseType], [Name], [Email], [Street1], [Street2], [City], [State], [Zip], [Phone], [CarID], [UserID], [PurchasePrice])
VALUES
(@PurchaseType, @Name, @Email, @Street1, @Street2, @City, @State, @Zip, @Phone, @CarID, @UserID, @PurchasePrice)
END

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