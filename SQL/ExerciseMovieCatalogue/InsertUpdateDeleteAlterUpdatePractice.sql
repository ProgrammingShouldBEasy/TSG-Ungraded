USE MovieCatalogue

INSERT INTO Actor ([FirstName], [LastName], [BirthDate])
VALUES
('Bill', 'Murray', '9/21/1950'),
('Dan', 'Aykroyd', '7/1/1952'),
('John', 'Candy', '10/31/1950'),
('Steve', 'Martin', NULL),
('Sylvester', 'Stallone', NULL);

INSERT INTO Director ([FirstName], [LastName], [BirthDate])
VALUES
('Ivan', 'Reitman', '10/27/1946'),
('Ted', 'Kotcheff', NULL);

INSERT INTO Rating ([RatingName])
VALUES
('G'),
('PG'),
('PG-13'),
('R');

INSERT INTO Genre ([GenreName])
VALUES
('Action'),
('Comedy'),
('Drama'),
('Horror');

INSERT INTO Movie ([GenreID], [DirectorID], [RatingID], [Title], [Release Date])
VALUES
(1,2,4, 'Rambo: First Blood', '10/22/1982'),
(2, NULL, 4, 'Planes, Trains & Automobiles', '11/25/1987'),
(2,1,2, 'Ghostbusters', NULL),
(2, NULL, 2, 'The Great Outdoors', '6/17/1988');

INSERT INTO CastMmebers ([ActorID], [MovieID], [Role])
VALUES
(5,1,'John Rambo'),
(4,2, 'Neil Page'),
(3,2, 'Del Griffith'),
(1,3, 'Dr. Peter Venkman'),
(2,3, 'Dr. Raymond Stanz'),
(2,4, 'Roman Craig'),
(3,4, 'Chet Ripley');

UPDATE Movie
SET [Title] = 'Ghostbusters (1984)', [Release Date] = '6/8/1984'
WHERE [Title] = 'Ghostbusters'
;

UPDATE Genre
SET [GenreName] = 'Action/Adventure'
WHERE [GenreName] = 'Action'
;

DELETE FROM Movie WHERE [Title] = 'Rambo: First Blood'
;
GO
ALTER TABLE Actor
	ADD [DateOfDeath] DATE
;
GO
UPDATE Actor
SET [DateOfDeath] = '3/4/1994'
WHERE [FirstName] = 'John' and [LastName] = 'Candy'
;