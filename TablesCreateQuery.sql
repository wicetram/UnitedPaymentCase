-- Veritabanını oluştur
CREATE DATABASE TestDb;
GO

-- TestDb veritabanını kullan
USE TestDb;
GO

-- Transactions tablosunu oluştur
CREATE TABLE Transactions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TransactionId VARCHAR(50),
    CustomerId VARCHAR(50),
    OrderId VARCHAR(50),
    [Type] VARCHAR(50),
    Amount VARCHAR(50),
    Pan VARCHAR(50),
    CVV VARCHAR(10),
    ExpMonth VARCHAR(2),
    ExpDay VARCHAR(2)
);

-- Customers tablosunu oluştur
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId VARCHAR(50),
    Name VARCHAR(50),
    Surname VARCHAR(50),
    BirthDate VARCHAR(10),
    IdentityNo VARCHAR(20),
    IdentityNoVerified VARCHAR(5),
    Status VARCHAR(50)
);
