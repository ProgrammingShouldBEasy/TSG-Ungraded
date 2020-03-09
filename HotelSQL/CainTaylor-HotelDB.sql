USE [master]
GO

DROP DATABASE if exists [Hotel]
CREATE DATABASE [Hotel]

GO
USE [Hotel]

CREATE TABLE [Rooms]
([Room Number] INT Primary Key,
[Size] nvarchar(50) NOT NULL,
[ADA] bit NOT NULL)

CREATE TABLE [Room Type]
([Size] nvarchar(50) PRIMARY KEY ,
[Base Price] decimal(15,2) NOT NULL,
[Extra Person Charge] decimal(15,2) NULL,
[Standard Occupancy] INT NOT NULL,
[Maximum Occupancy] INT NOT NULL)

CREATE TABLE [Room to Amenities]
([Room Number] INT,
[AmenityID] INT,
PRIMARY KEY ([Room Number], [AmenityID]))

CREATE TABLE [Room to Reservation]
([Room Number] INT,
[ReservationID] INT,
[Adults] INT NOT NULL,
[Children] INT NOT NULL,
PRIMARY KEY ([Room Number], [ReservationID]))

CREATE TABLE [Amenities]
([AmenityID] INT PRIMARY KEY IDENTITY(1,1),
[Amenity Name] nvarchar(50) NOT NULL,
[Charge] decimal(15,2) NOT NULL)

CREATE TABLE [Reservation]
([ReservationID] INT Primary Key Identity(1,1),
[Start Date] Date NOT NULL,
[End Date] Date NOT NULL,
[GuestID] INT NOT NULL)

CREATE TABLE [Guests]
([GuestID] INT Primary Key Identity(1,1),
[Name] nvarchar(50) NOT NULL,
[Address] nvarchar(50) NOT NULL,
[City] nvarchar(50) NOT NULL,
[State] nvarchar(50) NOT NULL,
[Zip] INT NOT NULL,
[Phone] nvarchar(50) NOT NULL)

ALTER TABLE [Room to Amenities]
ADD CONSTRAINT fk_RoomNumber
FOREIGN KEY ([Room Number])
REFERENCES [Rooms]([Room Number])

ALTER TABLE [Room to Amenities]
ADD CONSTRAINT fk_AmenityID
FOREIGN KEY ([AmenityID])
REFERENCES [Amenities]([AmenityID])

ALTER TABLE [Rooms]
ADD CONSTRAINT fk_RoomSize
FOREIGN KEY ([Size])
REFERENCES [Room Type]([Size])

ALTER TABLE [Room to Reservation]
ADD CONSTRAINT fk_RoomNumbertoReservation
FOREIGN KEY ([Room Number])
REFERENCES [Rooms]([Room Number])

ALTER TABLE [Room to Reservation]
ADD CONSTRAINT fk_ReservationID
FOREIGN KEY ([ReservationID])
REFERENCES [Reservation]([ReservationID])

ALTER TABLE [Reservation]
ADD CONSTRAINT fk_GuestID
FOREIGN KEY ([GuestID])
REFERENCES [Guests]([GuestID])
GO