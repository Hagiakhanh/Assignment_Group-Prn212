USE master
GO

CREATE DATABASE CarDbSet
GO

USE CarDbSet
GO

create table UserRole
(
Id int identity primary key,
Username nvarchar(250) unique,
Passphrase varchar(250),
UserRole int 
)
GO

insert into UserRole values ('admin','admin@123', 1)
insert into UserRole values ('staff','staff@123', 2)
GO

CREATE TABLE FuelTypes (
    FuelTypeID INT PRIMARY KEY IDENTITY(1,1),
    FuelTypeName VARCHAR(50) NOT NULL
);
GO

CREATE TABLE SellerTypes (
    SellerTypeID INT PRIMARY KEY IDENTITY(1,1),
    SellerTypeName VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Transmissions (
    TransmissionID INT PRIMARY KEY IDENTITY(1,1),
    TransmissionType VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Owners (
    OwnerID INT PRIMARY KEY IDENTITY(1,1),
    OwnerType VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    Year INT NOT NULL,
	SellingPrice DECIMAL(10, 2) NOT NULL,
    PresentPrice DECIMAL(10, 2) NOT NULL,
    KmsDriven INT NOT NULL,
    FuelTypeID INT,
    SellerTypeID INT,
    TransmissionID INT,
    OwnerID INT,
    FOREIGN KEY (FuelTypeID) REFERENCES FuelTypes(FuelTypeID),
    FOREIGN KEY (SellerTypeID) REFERENCES SellerTypes(SellerTypeID),
    FOREIGN KEY (TransmissionID) REFERENCES Transmissions(TransmissionID),
    FOREIGN KEY (OwnerID) REFERENCES Owners(OwnerID)
);
GO

