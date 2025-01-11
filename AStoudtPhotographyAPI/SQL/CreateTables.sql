



--Photographer info
CREATE TABLE Photographer(
ID int NOT NULL PRIMARY KEY,
FirstName varchar(80),
LastName varchar(255),
CompanyName varchar(255),
EmailAddress varchar(255),
PhoneNumner varchar (30))

--Client Info
CREATE TABLE  Client(
ID int NOT NULL PRIMARY KEY,
FirstName varchar(80),
LastName varchar(255),
EmailAddress varchar(255),
PhoneNumner varchar (30))

--Gallery Type(Wedding, Elopment, Events, Family Portraits, Landscape...)
CREATE TABLE Gallery(
ID int NOT NULL PRIMARY KEY,
Name varchar(255))


--Each Photo belongs into a session, which has a photographer Id, and a client Id
CREATE TABLE PhotoSession(
ID INT NOT NULL PRIMARY KEY,
PhotgrapherID INT NOT NULL FOREIGN KEY REFERENCES Photographer(ID),
ClientID int NOT NULL FOREIGN KEY REFERENCES Client(ID)
);

--each photo has a location, client id, and Gallery Id
CREATE TABLE Photo(
ID int NOT NULL PRIMARY KEY,
PhotoSession int NOT NULL FOREIGN KEY REFERENCES PhotoSession(ID),
PhotoLocation varchar(255),
GalleryID int NOT NULL FOREIGN KEY REFERENCES Gallery(ID),
IsPrivate bit);





--PhotographerTable
--Id
--FirstName
--LastName
--EmailAddress
--PhoneNumber
--Expertise (do i include this and include phototypes? in the future..)


--ClientTable
--Id
--FirstName
--LastName
--Email
--PhoneNumber


--Will i use this to help produce inmages dynamically based on selections/funnels ?
--PhotoGalleryTable contains the gallery and photographer and customer
--ID
--GalleryName (Private==Customer,everthing else is public... Wedding, Elopment, Family Portraits, Landscape) 
-- PhotographerId
-- CustomerId


