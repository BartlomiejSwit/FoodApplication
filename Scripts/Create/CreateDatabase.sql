﻿--IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = 'FoodApplicationUsers')
--BEGIN
--    CREATE DATABASE FoodApplicationUsers;
--END
--GO

--USE FoodApplicationUsers;

--IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE [table_name] = 'Users')
--BEGIN
--    CREATE TABLE Users
--    (
--        Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
--        FirstName NVARCHAR(100),
--        LastName NVARCHAR(100),
--        Email NVARCHAR(100),
--        UserName NVARCHAR(100),
--        UserPassword NVARCHAR(100)
--    );
--END
--GO

IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = 'FoodApplicationDB')
BEGIN
    CREATE DATABASE FoodApplicationDB;
END
GO

USE FoodApplicationDB;

--Tabela Users
IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE [table_name] = 'Users')
BEGIN
    CREATE TABLE Users
    (
        Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
        FirstName NVARCHAR(100),
        LastName NVARCHAR(100),
        Email NVARCHAR(100),
        UserName NVARCHAR(100),
        UserPassword NVARCHAR(100)
    );
END

-- Tabela MeasurUnit
IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE [table_name] = 'MeasurUnit')
BEGIN
    CREATE TABLE MeasurUnit
    (
        Id INT IDENTITY (1,1) PRIMARY KEY,
        MeasureName NVARCHAR(100)
    );
END

-- Tabela ProductType
IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE [table_name] = 'ProductType')
BEGIN
    CREATE TABLE ProductType
    (
        Id INT IDENTITY (1,1) PRIMARY KEY,
        ProductTypeName NVARCHAR(100)
    );
END

-- Tabela FoodProductBase
IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE [table_name] = 'FoodProductBase')
BEGIN
    CREATE TABLE FoodProductBase
    (
        Id INT IDENTITY (1,1) PRIMARY KEY,
        Name NVARCHAR(100),
        ProductType INT,
        MeasureUnit INT,
        FOREIGN KEY (ProductType) REFERENCES ProductType(Id),
        FOREIGN KEY (MeasureUnit) REFERENCES MeasurUnit(Id)
    );
END

-- Tabela FoodProduct
IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE [table_name] = 'FoodProduct')
BEGIN
    CREATE TABLE FoodProduct
    (
        Id INT IDENTITY (1,1) PRIMARY KEY,
        FoodProductBaseId INT,
        Quantity INT,
        FOREIGN KEY (FoodProductBaseId) REFERENCES FoodProductBase(Id),
    );
END

-- Tabela FoodProductList
IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE [table_name] = 'FoodProductList')
BEGIN
    CREATE TABLE FoodProductList
    (
        Id INT IDENTITY (1,1) PRIMARY KEY,
        FoodProductId INT,
        UserId UNIQUEIDENTIFIER,
        FOREIGN KEY (FoodProductId) REFERENCES FoodProduct(Id),
        FOREIGN KEY (UserId) REFERENCES Users(Id)
    );
END



--DROP DATABASE IF EXISTS FoodApplicationDB;
--DROP DATABASE IF EXISTS FoodApplicationUsers;