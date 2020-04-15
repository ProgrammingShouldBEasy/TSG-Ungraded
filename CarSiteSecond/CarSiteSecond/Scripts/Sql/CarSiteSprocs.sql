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
[Name] nvarchar(50) ,
[Email] nvarchar(50) ,
[Phone] nvarchar(50) ,
[Message] nvarchar(500) )

CREATE TABLE [Sales]
([id] INT Primary Key Identity(1,1),
[PurchaseType] INT ,
[Name] nvarchar(50) ,
[Email] nvarchar(50) ,
[Street1] nvarchar(50) ,
[Street2] nvarchar(50) NULL,
[City] nvarchar(50) ,
[State] nvarchar(50) ,
[Zip] varchar(10) ,
[Phone] nvarchar(50) ,
[CarID] int ,
[UserID] nvarchar(128) ,
[PurchasePrice] decimal(15,2),
[Date] date)

CREATE TABLE [Interior]
([id] INT Primary Key Identity (1,1),
[InteriorName] nvarchar(50) )

CREATE TABLE [Color]
([id] INT Primary Key Identity (1,1),
[ColorName] nvarchar(50) )

CREATE TABLE [PurchaseType]
([id] INT Primary Key Identity (1,1),
[Type] nvarchar(50) )

CREATE TABLE [Cars]
([id] INT PRIMARY KEY IDENTITY (1,1),
[ModelID] INT,
[Year] INT,
[BodyStyle] nvarchar(50),
[Transmission] nvarchar(50),
[PictureSrc] nvarchar(100),
[InteriorID] INT,
[Mileage] INT,
[VIN] nvarchar(50),
[SalePrice] decimal(15,2),
[MSRP] decimal(15,2),
[Featured] bit,
[ColorID] INT,
[Description] nvarchar(500))

CREATE TABLE [Make]
([id] INT PRIMARY KEY IDENTITY(1,1),
[MakeName] nvarchar(50) ,
[DateAdded] DATE ,
[UserID] nvarchar(128) )

CREATE TABLE [Model]
([id] INT PRIMARY KEY IDENTITY(1,1),
[ModelName] nvarchar(50) ,
[MakeID] INT ,
[DateAdded] DATE ,
[UserID] nvarchar(128) )

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

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Specials')) 
BEGIN
DROP TABLE Specials
END

CREATE TABLE [Specials]
([id] INT Primary Key Identity(1,1),
[Title] nvarchar(50) ,
[Text] nvarchar(500) )

CREATE TABLE [Contacts]
([id] INT Primary Key Identity(1,1),
[Name] nvarchar(50) ,
[Email] nvarchar(50),
[Phone] nvarchar(50),
[Message] nvarchar(500))

CREATE TABLE [Sales]
([id] INT Primary Key Identity(1,1),
[PurchaseType] INT,
[Name] nvarchar(50),
[Email] nvarchar(50),
[Street1] nvarchar(50),
[Street2] nvarchar(50),
[City] nvarchar(50),
[State] nvarchar(50),
[Zip] varchar(10),
[Phone] nvarchar(50),
[CarID] int,
[UserID] nvarchar(128),
[PurchasePrice] decimal(15,2),
[Date] date)

CREATE TABLE [Interior]
([id] INT Primary Key Identity (1,1),
[InteriorName] nvarchar(50) )

CREATE TABLE [Color]
([id] INT Primary Key Identity (1,1),
[ColorName] nvarchar(50) )

CREATE TABLE [PurchaseType]
([id] INT Primary Key Identity (1,1),
[Type] nvarchar(50) )

CREATE TABLE [Cars]
([id] INT PRIMARY KEY IDENTITY (1,1),
[ModelID] INT ,
[Year] INT ,
[BodyStyle] nvarchar(50) ,
[Transmission] nvarchar(50) ,
[PictureSrc] nvarchar(100) ,
[InteriorID] INT ,
[Mileage] INT ,
[VIN] nvarchar(50) ,
[SalePrice] decimal(15,2) ,
[MSRP] decimal(15,2) ,
[Featured] bit ,
[ColorID] INT,
[Description] nvarchar(500))

CREATE TABLE [Make]
([id] INT PRIMARY KEY IDENTITY(1,1),
[MakeName] nvarchar(50) ,
[DateAdded] DATE ,
[UserID] nvarchar(128) )

CREATE TABLE [Model]
([id] INT PRIMARY KEY IDENTITY(1,1),
[ModelName] nvarchar(50) ,
[MakeID] INT ,
[DateAdded] DATE ,
[UserID] nvarchar(128) )

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
WHERE ROUTINE_NAME = 'GetUserRolesAll'
)
BEGIN
DROP PROCEDURE [GetUserRolesAll]
END
GO

CREATE PROCEDURE [GetUserRolesAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'AspNetUserRoles')) 
BEGIN
Select *
FROM [AspNetUserRoles]
ORDER BY [UserId]
END
GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetRolesAll'
)
BEGIN
DROP PROCEDURE [GetRolesAll]
END
GO

CREATE PROCEDURE [GetRolesAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'AspNetRoles')) 
BEGIN
Select *
FROM [AspNetRoles]
ORDER BY [Id]
END
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

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'AspNetUsers')) 
BEGIN
Select *
FROM [AspNetUsers]
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
@SalePrice decimal(15,2), @MSRP decimal(15,2), @Featured bit, @ColorID int, @Description nvarchar(500))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
INSERT INTO [Cars]
([ModelID],[Year],[BodyStyle],[Transmission],[PictureSrc],[InteriorID],[Mileage],[VIN],[SalePrice],[MSRP],[Featured],[ColorID],[Description])
VALUES
(@ModelID,@Year,@BodyStyle,@Transmission,@PictureSrc,@InteriorID,@Mileage,@VIN,@SalePrice,@MSRP,@Featured,@ColorID,@Description)
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
@SalePrice decimal(15,2), @MSRP decimal(15,2), @Featured bit, @ColorID int, @Description nvarchar(500))
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')) 
BEGIN
UPDATE [Cars]
SET [ModelID] = @ModelID, [Year] = @Year, [BodyStyle] = @BodyStyle, [Transmission] = @Transmission, [PictureSrc] = @PictureSrc,
[InteriorID] = @InteriorID, [Mileage] = @Mileage, [VIN] = @VIN, [SalePrice] = @SalePrice, [MSRP] = @MSRP, [Featured] = @Featured,
[ColorID] = @ColorID, [Description] = @Description
WHERE
[id] = @ID
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetPurchaseTypesAll'
)
BEGIN
DROP PROCEDURE [GetPurchaseTypesAll]
END
GO

CREATE PROCEDURE [GetPurchaseTypesAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'PurchaseType')) 
BEGIN
Select *
FROM [PurchaseType]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetPurchaseTypesOne'
)
BEGIN
DROP PROCEDURE [GetPurchaseTypesOne]
END
GO

CREATE PROCEDURE [GetPurchaseTypesOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'PurchaseType')) 
BEGIN
Select *
FROM [PurchaseType]
WHERE id = @ID
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetInteriorsAll'
)
BEGIN
DROP PROCEDURE [GetInteriorsAll]
END
GO

CREATE PROCEDURE [GetInteriorsAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Interior')) 
BEGIN
Select *
FROM [Interior]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetInteriorsOne'
)
BEGIN
DROP PROCEDURE [GetInteriorsOne]
END
GO

CREATE PROCEDURE [GetInteriorsOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Interior')) 
BEGIN
Select *
FROM [Interior]
WHERE id = @ID
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetColorsAll'
)
BEGIN
DROP PROCEDURE [GetColorsAll]
END
GO

CREATE PROCEDURE [GetColorsAll]
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Color')) 
BEGIN
Select *
FROM [Color]
ORDER BY [id]
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetColorsOne'
)
BEGIN
DROP PROCEDURE [GetColorsOne]
END
GO

CREATE PROCEDURE [GetColorsOne] (@ID int)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Color')) 
BEGIN
Select *
FROM [Color]
WHERE id = @ID
ORDER BY [id]
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

CREATE PROCEDURE [CreateSalesOne] (@PurchaseType int, @Name nvarchar(50), @Email nvarchar(50), @Street1 nvarchar(50), @Street2 nvarchar(50), @City nvarchar(50), @State nvarchar(50), @Zip varchar(10), @Phone nvarchar(50), @CarID int, @UserID nvarchar(50), @PurchasePrice decimal(15,2), @Date date)
AS

IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales')) 
BEGIN
INSERT INTO [Sales]
([PurchaseType], [Name], [Email], [Street1], [Street2], [City], [State], [Zip], [Phone], [CarID], [UserID], [PurchasePrice], [Date])
VALUES
(@PurchaseType, @Name, @Email, @Street1, @Street2, @City, @State, @Zip, @Phone, @CarID, @UserID, @PurchasePrice, @Date)
UPDATE [CARS]
SET [Featured] = 0
WHERE
[id] = @CarID
END

GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'InventoryReport'
)
BEGIN
DROP PROCEDURE [InventoryReport]
END
GO

CREATE PROCEDURE [InventoryReport]
AS
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')
AND exists(Select * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Make')
AND exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Model'))
BEGIN
SELECT Cars.Year, Model.ModelName as Model, Make.MakeName as Make,COUNT(DISTINCT Cars.id) as "Count", SUM(Cars.MSRP) as StockValue
FROM [Cars]
JOIN Model ON Model.id = Cars.ModelID
JOIN Make ON Make.id = Model.MakeID
GROUP BY Model.ModelName, Make.MakeName, Cars.Year
END
GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'SalesReport'
)
BEGIN
DROP PROCEDURE [SalesReport]
END
GO

CREATE PROCEDURE [SalesReport]
AS
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'AspNetUsers')
AND exists(Select * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')
AND exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales'))
BEGIN
SELECT AspNetUsers.UserName, SUM(Sales.PurchasePrice) as TotalSales, SUM(Sales.CarID) as TotalVehicles, Sales.[Date]
FROM AspNetUsers
JOIN Sales ON Sales.UserID = AspNetUsers.Id
GROUP BY AspNetUsers.UserName, Sales.[Date]
END
GO

IF EXISTS(
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'SalesReportParams'
)
BEGIN
DROP PROCEDURE [SalesReportParams]
END
GO

CREATE PROCEDURE [SalesReportParams](@fromDate Date, @toDate Date)
AS
IF (exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'AspNetUsers')
AND exists(Select * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Cars')
AND exists(SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sales'))
BEGIN
SELECT AspNetUsers.UserName, SUM(Sales.PurchasePrice) as TotalSales, SUM(Sales.CarID) as TotalVehicles
FROM AspNetUsers
JOIN Sales ON Sales.UserID = AspNetUsers.Id
WHERE Sales.[Date] BETWEEN @fromDate AND @toDate
GROUP BY AspNetUsers.UserName
END
GO