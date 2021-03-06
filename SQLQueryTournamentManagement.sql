CREATE DATABASE TournamentManagement
GO
  USE TournamentManagement
GO
  CREATE TABLE Tournaments (
    id INT IDENTITY PRIMARY KEY,
    tournamentName NVARCHAR(100) NOT NULL,
    entryFee FLOAT NOT NULL DEFAULT 0,
    isCompleted BIT NOT NULL DEFAULT 0
  )
GO
  CREATE TABLE Teams (
    id INT IDENTITY PRIMARY KEY,
    teamName NVARCHAR(100) NOT NULL
  )
GO
  CREATE TABLE Prizes (
    id INT IDENTITY PRIMARY KEY,
    placeNumber INT NOT NULL,
    placeName NVARCHAR(100) NOT NULL,
    prizeAmount MONEY,
    prizePercentage FLOAT
  )
GO
  CREATE TABLE TournamentEntries (
    id INT IDENTITY PRIMARY KEY,
    tournamentID INT NOT NULL,
    teamID INT NOT NULL,
    FOREIGN KEY(tournamentID) REFERENCES Tournaments(id) ON DELETE CASCADE,
    FOREIGN KEY(teamID) REFERENCES Teams(id) ON DELETE CASCADE
  )
GO
  CREATE TABLE TournamentPrizes (
    id INT IDENTITY PRIMARY KEY,
    tournamentID INT NOT NULL,
    prizeID INT NOT NULL,
    FOREIGN KEY(tournamentID) REFERENCES Tournaments(id) ON DELETE CASCADE,
    FOREIGN KEY(prizeID) REFERENCES Prizes(id) ON DELETE CASCADE
  )
GO
  CREATE TABLE People (
    id INT IDENTITY PRIMARY KEY,
    firstName NVARCHAR(100) NOT NULL,
    lastName NVARCHAR(100) NOT NULL,
    emailAddress NVARCHAR(100) NOT NULL,
    phoneNumber NVARCHAR(100) NOT NULL
  )
GO
  CREATE TABLE TeamMembers (
    id INT IDENTITY PRIMARY KEY,
    teamID INT NOT NULL,
    personID INT NOT NULL,
    FOREIGN KEY(teamID) REFERENCES Teams(id) ON DELETE CASCADE,
    FOREIGN KEY(personID) REFERENCES People(id) ON DELETE CASCADE
  )
GO
  CREATE TABLE Matchups (
    id INT IDENTITY PRIMARY KEY,
    teamWinnerID INT NULL,
    matchupRound INT NOT NULL,
    tournamentID INT NOT NULL,
    FOREIGN KEY(teamWinnerID) REFERENCES Teams(id) ON DELETE CASCADE,
    FOREIGN KEY (tournamentID) REFERENCES Tournaments(id) ON DELETE CASCADE
  )
GO
  CREATE TABLE MatchupEntries (
    id INT IDENTITY PRIMARY KEY,
    score FLOAT NOT NULL DEFAULT 0,
    matchupID INT NOT NULL,
    teamCompetingID INT NULL,
    parentMatchupID INT NULL,
    FOREIGN KEY(matchupID) REFERENCES Matchups(id) ON DELETE CASCADE,
    FOREIGN KEY(teamCompetingID) REFERENCES Teams(id),
    FOREIGN KEY(parentMatchupID) REFERENCES Matchups(id),
  )
GO
  CREATE PROCEDURE insertPrizes @placeNumber INT,
  @placeName NVARCHAR(100),
  @prizeAmount MONEY,
  @prizePercentage FLOAT,
  @id INT = 0 OUTPUT AS BEGIN
INSERT INTO
  Prizes(
    placeNumber,
    placeName,
    prizeAmount,
    prizePercentage
  )
VALUES
  (
    @placeNumber,
    @placeName,
    @prizeAmount,
    @prizePercentage
  )
SELECT
  @id = SCOPE_IDENTITY()
END
GO
  CREATE PROCEDURE insertPeople @firstName NVARCHAR(100),
  @lastName NVARCHAR(100),
  @emailAddress NVARCHAR(100),
  @phoneNumber NVARCHAR(100),
  @id INT = 0 OUTPUT AS BEGIN
INSERT INTO
  People(firstName, lastName, emailAddress, phoneNumber)
VALUES
  (
    @firstName,
    @lastName,
    @emailAddress,
    @phoneNumber
  )
SELECT
  @id = SCOPE_IDENTITY() -- select the last id we have created, scope is the procedure
END
GO
  CREATE PROCEDURE selectPeople AS BEGIN
SELECT
  *
FROM
  People
END
GO
  CREATE PROCEDURE PROC_insertTeams @teamName NVARCHAR(100),
  @id INT = 0 OUTPUT AS BEGIN
SET
  NOCOUNT ON;

INSERT INTO
  Teams(teamName)
VALUES
  (@teamName)
SELECT
  @id = SCOPE_IDENTITY()
END
GO
  CREATE PROCEDURE PROC_insert_TeamMembers @teamID INT,
  @personID INT,
  @id INT = 0 OUTPUT AS BEGIN
SET
  NOCOUNT ON;

INSERT INTO
  TeamMembers(teamID, personID)
VALUES
  (@teamID, @personID)
SELECT
  @id = SCOPE_IDENTITY()
END
GO
  CREATE PROCEDURE PROC_selectTeams AS BEGIN
SET
  NOCOUNT ON;

SELECT
  *
FROM
  Teams
END
GO
  CREATE PROCEDURE Get_Teams_Rates AS BEGIN
SELECT
  TOP 10 teamName as TeamName,
  SUM(me.score) as Score
FROM
  Teams as t
  INNER JOIN MatchupEntries as me ON me.teamCompetingID = t.id
GROUP BY
  TeamName
ORDER BY
  Score DESC
END
GO
  CREATE PROCEDURE PROC_selectTeamMembErs_GetByTeam @teamID INT AS BEGIN
SET
  NOCOUNT ON;

SELECT
  p.*
FROM
  TeamMembers m
  INNER JOIN People p on m.personID = p.id
WHERE
  m.teamID = @teamID
END
GO
  CREATE PROCEDURE PROC_selectTournaments AS BEGIN
SET
  NOCOUNT ON;

SELECT
  *
FROM
  Tournaments
END
GO
  CREATE PROCEDURE PROC_selectPrizes_GetByTournament @tournamentID INT AS BEGIN
SET
  NOCOUNT ON;

SELECT
  p.*
FROM
  TournamentPrizes tp
  INNER JOIN Prizes p ON tp.prizeID = p.id
WHERE
  tp.id = @tournamentID
END
GO
  CREATE PROCEDURE PROC_selectTeams_GetByTournament @tournamentID INT AS BEGIN
SET
  NOCOUNT ON;

SELECT
  t.*
FROM
  Teams t
  INNER JOIN TournamentEntries te on te.teamID = t.id
WHERE
  te.tournamentID = @tournamentID
END
GO
  CREATE PROCEDURE PROC_selectMatchups_GetByTournament @tournamentID INT AS BEGIN
SET
  NOCOUNT ON;

SELECT
  m.*
FROM
  Matchups m
WHERE
  m.tournamentID = @tournamentID
ORDER BY
  matchupRound
END
GO
  CREATE PROCEDURE PROC_selectMatchupEntries_GetByMatchup @matchupID INT AS BEGIN
SET
  NOCOUNT ON;

SELECT
  *
FROM
  MatchupEntries
WHERE
  matchupID = @matchupID
END
GO
  CREATE PROCEDURE PROC_insertTournament @tournamentName NVARCHAR(100),
  @entryFee FLOAT,
  @isCompleted BIT = 0,
  @id INT = 0 OUTPUT AS BEGIN
SET
  NOCOUNT ON;

INSERT
  Tournaments(tournamentName, entryFee, isCompleted)
VALUES
  (@tournamentName, @entryFee, @isCompleted)
SELECT
  @id = SCOPE_IDENTITY()
END
GO
  CREATE PROCEDURE PROC_completeTournament @id INT AS BEGIN
UPDATE
  Tournaments
SET
  isCompleted = 1
WHERE
  id = @id;

END
GO
  CREATE PROCEDURE PROC_deleteTournament @id INT AS BEGIN
DELETE FROM
  Tournaments
WHERE
  id = @id;

END
GO
  CREATE PROCEDURE PROC_insert_TournamentEntries @tournamentID INT,
  @teamID INT,
  @id INT = 0 OUTPUT AS BEGIN
SET
  NOCOUNT ON;

INSERT INTO
  TournamentEntries(tournamentID, teamID)
VALUES
  (@tournamentID, @teamID)
SELECT
  @id = SCOPE_IDENTITY()
END
GO
  CREATE PROCEDURE PROC_insert_TournamentPrizes @tournamentID INT,
  @prizeID INT,
  @id INT = 0 OUTPUT AS BEGIN
SET
  NOCOUNT ON;

INSERT INTO
  TournamentPrizes(tournamentID, prizeID)
VALUES
  (@tournamentID, @prizeID)
SELECT
  @id = SCOPE_IDENTITY()
END
GO
  CREATE PROCEDURE PROC_insertMatchups @tournamentID INT,
  @matchupRound INT,
  @id INT = 0 OUTPUT AS BEGIN
SET
  NOCOUNT ON;

INSERT INTO
  Matchups(tournamentID, matchupRound)
VALUES
  (@tournamentID, @matchupRound)
SELECT
  @id = SCOPE_IDENTITY();

END
GO
  CREATE PROCEDURE PROC_insertMatchupEntries @matchupID INT,
  @parentMatchupID INT,
  @teamCompetingID INT,
  @id INT = 0 OUTPUT AS BEGIN
SET
  NOCOUNT ON;

INSERT INTO
  MatchupEntries(matchupID, parentMatchupID, teamCompetingID)
VALUES
  (@matchupID, @parentMatchupID, @teamCompetingID)
SELECT
  @id = SCOPE_IDENTITY()
END
GO
  CREATE PROCEDURE PROC_updateMatchups @id INT,
  @winnerID INT AS BEGIN
SET
  NOCOUNT ON;

UPDATE
  Matchups
SET
  teamWinnerID = @winnerID
WHERE
  id = @id
END
GO
  CREATE PROCEDURE PROC_updateMatchupEntries @id INT,
  @teamCompetingID INT = NULL,
  @score FLOAT = NULL AS BEGIN
SET
  NOCOUNT ON;

UPDATE
  MatchupEntries
SET
  teamCompetingID = @teamCompetingID,
  score = @score
WHERE
  id = @id
END