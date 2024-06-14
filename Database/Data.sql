--Database Queries for FilmX 

-- Creating the Schema and tables
Create database FILMX;

use FILMX;

create schema Foundation;

CREATE TABLE Foundation.Producers(
	PK_Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(max) NOT NULL,
	Sex VARCHAR(max) NOT NULL,
	Dob DATE NOT NULL,
	Bio VARCHAR(max) NOT NULL
);

CREATE TABLE Foundation.Actors(
	PK_Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(max) NOT NULL,
	Sex VARCHAR(max) NOT NULL,
	Dob DATE NOT NULL,
	Bio VARCHAR(max) NOT NULL
);

CREATE TABLE Foundation.Movies(
	PK_Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(max) NOT NULL,
	YearOfRelease INT NOT NULL,
	Plot VARCHAR(max) NOT NULL,
	Poster VARCHAR(max) NOT NULL,
	FK_ProducerId INT FOREIGN KEY REFERENCES Foundation.Producers(PK_Id) ON DELETE CASCADE NOT NULL 
);

CREATE TABLE Foundation.Actors_Movies (
	FK_MovieId INT FOREIGN KEY REFERENCES Foundation.Movies(PK_Id) ON DELETE CASCADE NOT NULL ,
	FK_ActorId INT FOREIGN KEY REFERENCES Foundation.Actors(PK_Id) ON DELETE CASCADE NOT NULL 
);

--Adding 2 columns for CreatedAt and UpdatedAt
ALTER TABLE Foundation.Movies ADD CreatedAt DATETIME, UpdatedAt DATETIME;
ALTER TABLE Foundation.Actors_Movies ADD CreatedAt DATETIME, UpdatedAt DATETIME;
ALTER TABLE Foundation.Actors ADD CreatedAt DATETIME, UpdatedAt DATETIME;
ALTER TABLE Foundation.Producers ADD CreatedAt DATETIME, UpdatedAt DATETIME;

--Adding Default constraints for CreatedAt
ALTER TABLE Foundation.Movies ADD CONSTRAINT DF_MoviesCreatedAt DEFAULT GETDATE() FOR CreatedAt;
ALTER TABLE Foundation.Actors_Movies ADD CONSTRAINT DF_Actors_MoviesCreatedAt DEFAULT GETDATE() FOR CreatedAt;
ALTER TABLE Foundation.Actors ADD CONSTRAINT DF_ActorsCreatedAt DEFAULT GETDATE() FOR CreatedAt;
ALTER TABLE Foundation.Producers ADD CONSTRAINT DF_ProducersCreatedAt DEFAULT GETDATE() FOR CreatedAt;

ALTER TABLE Foundation.Movies ADD Language VARCHAR(max),Profit DECIMAL(18,2);

--TRIGGER FOR UpdatedAt
CREATE TRIGGER Foundation.TU_Movies
ON Foundation.Movies
FOR UPDATE
AS
UPDATE T SET UpdatedAt = GETDATE() FROM   Foundation.Movies AS T JOIN inserted AS i ON T.PK_Id = i.PK_Id;


-- Inserting Data into the tables.
INSERT INTO Foundation.Actors (Name,Sex,Dob,Bio) VALUES ('Leonardo DiCaprio','Male','1978-02-12','hero hero'),
	('Tom Cruise','Male','1999-08-21','hero hero'),
	('Robert','Male','1988-02-12','hero hero'),
	('Jon','Male','1999-08-22','hero hero'),
	('Will Smith','Male','1979-02-05','hero hero'),
	('Johnny Depp','Male','1996-08-12','hero hero'),
	('Chris','Male','1996-09-01','hero hero'),
	('Scarlett','Female','1993-09-15','hero hero'),
	('Vin Disel','Male','1986-07-20','hero hero');


INSERT INTO Foundation.Producers (Name,Sex,Dob,Bio) VALUES('Jerry','Male','1996-08-22','great producer'),
	('Kevin','Male','1989-02-05','great producer'),
	('Steven','Male','1986-08-12','great producer'),
	('Kathleen','Male','1976-09-01','great producer'),
	('Avi','Female','1991-09-15','great producer'),
	('Charles','Male','1976-07-20','great producer');


INSERT INTO Foundation.Movies (Name,YearOfRelease,Plot,Poster,FK_ProducerId,Language,Profit) VALUES('Inception',2003,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',3,'English',236000000),
	('Avatar',2014,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',3,'English',125000000.52),
	('Avengers',1995,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',3,'Telugu',175000000.25),
	('Thor',2001,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',6,'Tamil',302000000.23),
	('Hulk',2004,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',5,'English',112000000),
	('Captain America',2000,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',1,'Telugu',263000000),
	('Spider Man',2013,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',6,'Tamil',452000000),
	('Dune',2010,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',6,'Hindi',223000000),
	('James Bond',1969,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',5,'English',335000000),
	('Jurassic Park',2005,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',4,'Hindi',115000000.25),
	('Shang Chi',1996,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',2,'English',129000000),
	('Mission Impossible',2003,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',4,'Telugu',365000000.45),
	('The Matrix',2011,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',3,'Hindi',116000000.20),
	('Aladdin',2004,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',2,'English',452000000),
	('Toy Story',2020,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',5,'Telugu',132000000),
	('Interstellar',1994,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',5,'Tamil',172000000),
	('Doctor Strange',1994,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',4,'Telugu',146000000.85),
	('Iron Man 2',2012,'Inferior dislocation of right humerus, initial encounter','xyz.jpeg',2,'English',192000000);
 

INSERT INTO Foundation.Actors_Movies (FK_MovieId,FK_ActorId) VALUES(1,5),(1,3),
	(2,8), (2,6),
	(3,6), (3,7), (3,2),
	(4,5), (4,9), (4,1),
	(5,6), (5,8), (5,1),
	(6,1), (6,7), 
	(7,4), (7,9), 
	(8,3), (8,2), (8,4),
	(9,6), (9,5), (9,2),
	(10,7),(10,8),
	(11,1),(11,7),(11,9),
	(12,2),(12,3),(12,8),(12,1),
	(13,9),(13,6),
	(14,3),(14,5),
	(15,8),(15,2),(15,6),
	(16,4),(16,5),(16,9),
	(17,3),(17,6),
	(18,1),(18,8),(18,3);

-- ***********Stored Procedures**************
-- Sp for inserting Movie (1)
CREATE PROCEDURE Foundation.usp_InsertMovie
@Name VARCHAR(MAX), 
@YearOfRelease INT,
@Plot VARCHAR(MAX),
@Poster VARCHAR(MAX),
@ActorIds VARCHAR(MAX),
@ProducerId INT,
@Language VARCHAR(200),
@Profit DECIMAL(18,2)
AS
BEGIN
INSERT INTO Foundation.Movies (Name,YearOfRelease,Plot,Poster,FK_ProducerId,Language,Profit) VALUES(@Name,@YearOfRelease,@Plot,@Poster,@ProducerId,@Language,@Profit)
DECLARE @MID INT
SET @MID = Scope_Identity()
INSERT INTO Foundation.Actors_Movies (FK_MovieId,FK_ActorId) (SELECT @MID , value FROM string_split(@ActorIds,' '));
END


-- SP To Delete Movie By Id
CREATE PROC Foundation.usp_DeleteMovieById
@MovieId INT
AS
BEGIN
DELETE Foundation.Movies WHERE PK_Id=@MovieId --(It also deletes all Foreign key references because DELETE CASCADE is used.)
END;


-- SP To Delete Producer By Id
CREATE PROC Foundation.usp_DeleteProducerById
@ProducerId INT
AS
BEGIN
DELETE Foundation.Producers WHERE PK_Id=@ProducerId --(It also deletes all Foreign key references because DELETE CASCADE is used.)
END


-- SP To Delete Actor By Id
CREATE PROC Foundation.usp_DeleteActorById
@ActorId INT
AS
BEGIN
DELETE Foundation.Actors WHERE PK_Id=@ActorId --(It also deletes all Foreign key references because DELETE CASCADE is used.)
END


-- Few queries on FilmX Database.

--Query for the total no of days of actors of given name (1)
SELECT Name , DATEDIFF(DAY, Dob, GETDATE()) AS [Age in No Of Days]
FROM Foundation.Actors;

--All Actors who have worked with given Producer (2)
SELECT DISTINCT AM.FK_ActorId AS [Actor Id], A.Name AS [Actor Name], P.NAME AS [Producer Name]
FROM Foundation.Producers P
INNER JOIN Foundation.Movies M
ON M.FK_ProducerId = P.PK_Id
INNER JOIN Foundation.Actors_Movies AM
ON AM.FK_MovieId=M.PK_Id
INNER JOIN Foundation.Actors A
ON A.PK_Id = AM.FK_ActorId
WHERE P.Name = 'Steven';

--ACTORS WHO HAVE ACTED TOGETHER IN 2 OR MORE MOVIES (3)
SELECT AM1.FK_ActorId AS [Actorid 1],AM2.FK_ActorId AS [Actorid 2],COUNT(AM1.FK_ActorId) AS [No Of Times Acted]
FROM Foundation.Actors_Movies AM1
JOIN Foundation.Actors_Movies AM2
ON AM1.FK_MovieId = AM2.FK_MovieId AND AM1.FK_ActorId<AM2.FK_ActorId
GROUP BY AM1.FK_ActorId,AM2.FK_ActorId
HAVING COUNT(AM1.FK_ActorId)>=2;

SELECT * FROM Foundation.Actors_Movies;

--Youngest Actor (4)
SELECT TOP 1 Name,Dob
FROM Foundation.Actors
ORDER BY Dob DESC;

SELECT Name AS [Actor Name]
FROM Foundation.Actors
WHERE Dob = (SELECT MAX(Dob) FROM Foundation.Actors);


-- List of Actors who have Never Worked together (5)
SELECT DISTINCT AM1.FK_ActorId,AM2.FK_ActorId
FROM Foundation.Actors_Movies AM1
JOIN Foundation.Actors_Movies AM2
ON AM1.FK_ActorId<>AM2.FK_ActorId AND AM1.FK_ActorId<AM2.FK_ActorId
EXCEPT(
SELECT DISTINCT AM1.FK_ActorId,AM2.FK_ActorId
FROM Foundation.Actors_Movies AM1
JOIN Foundation.Actors_Movies AM2
ON AM1.FK_MovieId=AM2.FK_MovieId AND AM1.FK_ActorId<AM2.FK_ActorId);

--No Of Movies in Each Language (6)
SELECT COUNT(PK_Id) AS [Movies on each Language],Language
FROM Foundation.Movies
GROUP BY Language;

--TOTAL PROFIT OF ALL MOVIES IN EACH LANGUAGE (7)
SELECT Language ,SUM(Profit)
FROM Foundation.Movies
GROUP BY Language;

--TOTAL PROFIT ON EACH LANGUAGE WHERE X ACTOR ACTED (8)
SELECT SUM(Profit) AS [Total Profit on each language],M.Language
FROM Foundation.Movies M
LEFT JOIN Foundation.Actors_Movies AM
ON M.PK_Id = AM.FK_MovieId
LEFT JOIN Foundation.Actors A
ON A.PK_Id = AM.FK_ActorId
WHERE A.Name = 'Will Smith'
GROUP BY Language;