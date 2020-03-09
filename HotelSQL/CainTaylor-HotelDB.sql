USE [master]
GO

DROP DATABASE if exists [Hotel]
CREATE DATABASE [Hotel]

GO
USE [Hotel]

CREATE TABLE [Rooms]
([Room Number] INT Primary Key,
[Type] nvarchar(50) NOT NULL,
[Microwave] bit NOT NULL,
[Jacuzzi]  bit NOT NULL,
[Fridge] bit NOT NULL,
[Oven] bit NOT NULL,
[ADA Accessible] bit NOT NULL,
[Standard Occupancy] INT NOT NULL,
[Maximum Occupancy] INT NOT NULL,
[Price] decimal(15,2) NOT NULL,
[Extra Person Cost] decimal(15,2) NULL)

CREATE TABLE [Reservations]
([ReservationID] INT Primary Key Identity(1,1),
[Room Number] INT NOT NULL,
[Adults] INT NOT NULL,
[Children] INT NOT NULL,
[Start Date] Date NOT NULL,
[End Date] Date NOT NULL,
[Cost] decimal(15,2) NOT NULL,
[GuestID] INT NOT NULL)

CREATE TABLE [Guests]
([GuestID] INT Primary Key Identity(1,1),
[Name] nvarchar(50) NOT NULL,
[Address] nvarchar(50) NOT NULL,
[City] nvarchar(50) NOT NULL,
[State] nvarchar(50) NOT NULL,
[Zip] INT NOT NULL,
[Phone] nvarchar(50) NOT NULL)

ALTER TABLE [Reservations]
ADD CONSTRAINT fk_RoomNumber
FOREIGN KEY ([Room Number])
REFERENCES Rooms([Room Number])
ON DELETE CASCADE
ON UPDATE CASCADE

ALTER TABLE [Reservations]
ADD CONSTRAINT fk_GuestID
FOREIGN KEY ([GuestID])
REFERENCES Guests([GuestID])
ON DELETE CASCADE
ON UPDATE CASCADE;
GO