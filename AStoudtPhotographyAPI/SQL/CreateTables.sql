USE [master]

IF db_id('PhotoPortfolioApp') IS NULL
  CREATE DATABASE [PhotoPortfolioApp]
GO

USE [PhotoPortfolioApp]
GO

DROP TABLE IF EXISTS [dbo.Photo];
DROP TABLE IF EXISTS [dbo.Gallery];
DROP TABLE IF EXISTS [dbo.PhotoSession];
DROP TABLE IF EXISTS [dbo.Photographer];
DROP TABLE IF EXISTS [dbo.Client];

GO

--Photographer info
CREATE TABLE Photographer(
ID int IDENTITY(1,1) PRIMARY KEY,
FirstName varchar(80),
LastName varchar(255),
CompanyName varchar(255),
EmailAddress varchar(255),
PhoneNumner varchar (30))

--Client Info
CREATE TABLE  [Client](
ID int IDENTITY(1,1) PRIMARY KEY,
FirstName varchar(80),
LastName varchar(255),
EmailAddress varchar(255),
PhoneNumner varchar (30))

--Gallery Type(Wedding, Elopment, Events, Family Portraits, Landscape...)
CREATE TABLE [Gallery](
ID int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255))


--Each Photo belongs into a session, which has a photographer Id, and a client Id
CREATE TABLE [PhotoSession](
ID INT IDENTITY(1,1) PRIMARY KEY,
PhotgrapherID INT NOT NULL,
ClientID int NOT NULL,
SessionLocation varchar(255)
);

--Each photo has a file location, session id, client id, and Gallery Id, private flag, and dataTime created
CREATE TABLE [Photo](
ID int IDENTITY(1,1) PRIMARY KEY,
SessionID int NOT NULL,
GalleryID int NOT NULL,
ClientID int NOT NULL,
FileLocation varchar(255),
IsPrivate bit,
CreatedDateTime datetime2);

GO;


