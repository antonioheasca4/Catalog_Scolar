--CREATE DATABASE Online_School_Catalog

--ON PRIMARY
--(
--  Name = School1,
--  FileName = 'D:\Baza_CATALOG_SCOLAR\School1.mdf',
--  size = 1MB,
--  maxsize = unlimited,
--  filegrowth = 1GB
--),
--(
--  Name = School2,
--  FileName = 'D:\Baza_CATALOG_SCOLAR\School2.mdf',
--  size = 1MB,
--  maxsize = unlimited,
--  filegrowth = 1GB
--),
--(
--  Name = School3,
--  FileName = 'D:\Baza_CATALOG_SCOLAR\School3.ndf',
--  size = 1MB,
--  maxsize = unlimited,
--  filegrowth = 1GB
--)
--LOG ON
--(
--  Name = SchoolLog,
--  FileName = 'D:\Baza_CATALOG_SCOLAR\SchoolLog.ldf',
--  size = 2MB,
--  maxsize = unlimited,
--  filegrowth = 1024MB
--),
--(
--  Name = SchoolLog1,
--  FileName = 'D:\Baza_CATALOG_SCOLAR\SchoolLog1.ldf',
--  size = 2MB,
--  maxsize = unlimited,
--  filegrowth = 1024MB
--) 

IF OBJECT_ID('Conturi', 'U') IS NOT NULL DROP TABLE Conturi
GO
CREATE TABLE Conturi (
  ContID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Email varchar(30) CHECK (Email LIKE '%@_%.%') unique not null,
  Rol INT NOT NULL, -- 0->ELEVI,1->PARINTI,2->PROFESORI,3->ADMINISTRATOR 
);

IF OBJECT_ID('Utilizatori', 'U') IS NOT NULL DROP TABLE Utilizatori
GO
CREATE TABLE Utilizatori (
  UtilizatorID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Parola NVARCHAR(30) not null ,
  Email varchar(30) CHECK (Email LIKE '%@_%.%') unique not null,
  Rol INT NOT NULL, -- 0->ELEVI,1->PARINTI,2->PROFESORI,3->ADMINISTRATOR 
  ImagineProfil NVARCHAR(30) null
);

IF OBJECT_ID('Profesori', 'U') IS NOT NULL DROP TABLE Profesori
GO
CREATE TABLE Profesori (
  ProfesorID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nume VARCHAR(50) NOT NULL,
  Prenume VARCHAR(50) NOT NULL,
  Grad VARCHAR(20) NOT NULL,
  Vechime INT NOT NULL,
  UtilizatorID INT NOT NULL FOREIGN KEY REFERENCES Utilizatori(UtilizatorID)
);


IF OBJECT_ID('Parinti', 'U') IS NOT NULL DROP TABLE Parinti
GO
CREATE TABLE Parinti (
  ParinteID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nume_parinte VARCHAR(50) NOT NULL,
  Prenume_parinte VARCHAR(50) NOT NULL,
  Numar_telefon VARCHAR(15) not NULL,
  UtilizatorID INT NOT NULL FOREIGN KEY REFERENCES Utilizatori(UtilizatorID)
);

IF OBJECT_ID('Clase', 'U') IS NOT NULL DROP TABLE Clase
GO
CREATE TABLE Clase (
  ClasaID NVARCHAR(10) NOT NULL PRIMARY KEY,
  An_scolar INT NOT NULL,
  Specializare VARCHAR(50) NOT NULL,
  Diriginte INT NOT NULL FOREIGN KEY REFERENCES Profesori(ProfesorID)
);



IF OBJECT_ID('Elevi', 'U') IS NOT NULL DROP TABLE Elevi
GO
CREATE TABLE Elevi (
  ElevID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nume VARCHAR(50) NOT NULL,
  Prenume VARCHAR(50) NOT NULL,
  Data_nasterii DATE NOT NULL,
  Adresa VARCHAR(100) NOT NULL,
  ClasaID NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Clase(ClasaID),
  ParinteID INT NOT NULL FOREIGN KEY REFERENCES Parinti(ParinteID),
  UtilizatorID INT NOT NULL FOREIGN KEY REFERENCES Utilizatori(UtilizatorID)
);




IF OBJECT_ID('Materii', 'U') IS NOT NULL DROP TABLE Materii
GO
CREATE TABLE Materii (
  MaterieID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nume_materie VARCHAR(50) NOT NULL,
);

IF OBJECT_ID('Predare', 'U') IS NOT NULL DROP TABLE Predare
GO
CREATE TABLE Predare (
  PredareID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  ProfesorID INT NOT NULL FOREIGN KEY REFERENCES Profesori(ProfesorID),
  MaterieID INT NOT NULL FOREIGN KEY REFERENCES Materii(MaterieID),
  ClasaID NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Clase(ClasaID)
);


IF OBJECT_ID('Note', 'U') IS NOT NULL DROP TABLE Note
GO
CREATE TABLE Note (
  NotaID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nota DECIMAL(4,2) NOT NULL,
  DataNota DATE NOT NULL,
  ElevID INT NOT NULL FOREIGN KEY REFERENCES Elevi(ElevID),
  PredareID INT NOT NULL FOREIGN KEY REFERENCES Predare(PredareID)
);

IF OBJECT_ID('Absente', 'U') IS NOT NULL DROP TABLE Absente
GO
CREATE TABLE Absente (
  AbsentaID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Data_absenta DATE NOT NULL,
  Motivata BIT NOT NULL,
  ElevID INT NOT NULL FOREIGN KEY REFERENCES Elevi(ElevID),
  PredareID INT NOT NULL FOREIGN KEY REFERENCES Predare(PredareID)
);

IF OBJECT_ID('Notificari', 'U') IS NOT NULL DROP TABLE Notificari
GO
CREATE TABLE Notificari (
  NotificareID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Data_Notificare DATE NOT NULL,
  Mesaj NVARCHAR(200) NOT NULL,
  ParinteID INT NOT NULL FOREIGN KEY REFERENCES Parinti(ParinteID)
);




