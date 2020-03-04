USE master;
GO
IF db_id('MovieCatalogue') IS NULL 
	CREATE DATABASE MovieCatalogue
GO
USE MovieCatalogue;
CREATE TABLE MovieCatalogue.dbo.Movie
(
	MovieID INT Primary Key Identity(1,1),
	GenreID INT NOT NULL,
	DirectorID INT null,
	RatingID INT null,
	Title nvarchar(128) NOT NULL,
	[Release Date] DATE null,
);

CREATE TABLE MovieCatalogue.dbo.Genre
(
	GenreID INT Primary Key Identity(1,1),
	GenreName nvarchar(30) NOT NULL
);

CREATE TABLE MovieCatalogue.dbo.Director
(
	DirectorID INT Primary Key Identity(1,1),
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	BirthDate DATE null
);

CREATE TABLE MovieCatalogue.dbo.Rating
(
	RatingID INT Primary Key Identity(1,1),
	RatingName nchar(5) NOT NULL
);

CREATE TABLE MovieCatalogue.dbo.Actor
(
	ActorID INT Primary Key identity(1,1),
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	BirthDate DATE null
);

CREATE TABLE MovieCatalogue.dbo.CastMembers
(
	CastMemberID INT Primary Key Identity(1,1),
	ActorID INT NOT NULL,
	MovieID INT NOT NULL,
	Role nvarchar(50) NOT NULL
);

ALTER TABLE Movie
	ADD CONSTRAINT FK_MovieGenre FOREIGN KEY (GenreID)
	REFERENCES Genre (GenreID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
;

ALTER TABLE Movie
	ADD CONSTRAINT FK_MovieDirector FOREIGN KEY (DirectorID)
	REFERENCES Director (DirectorID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
;

ALTER TABLE Movie
	ADD CONSTRAINT FK_MovieRating FOREIGN KEY (RatingID)
	REFERENCES Rating (RatingID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
;

ALTER TABLE CastMembers
	ADD CONSTRAINT FK_CastMembersActor FOREIGN KEY (ActorID)
	REFERENCES Actor (ActorID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
;

ALTER TABLE CastMembers
	ADD CONSTRAINT FK_CastMembersMovie FOREIGN KEY (MovieID)
	REFERENCES Movie (MovieID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
;