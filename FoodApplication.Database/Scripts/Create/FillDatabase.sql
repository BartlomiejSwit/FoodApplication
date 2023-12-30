-- Wstawianie danych do tabeli Users
INSERT INTO Users (FirstName, LastName, Email, UserName, UserPassword)
VALUES ('John', 'Doe', 'john.doe@example.com', 'Uzytkownik1', 'Haslo1'),
	   ('Alice', 'Smith', 'alice.smith@example.com', 'Uzytkownik2', 'Haslo2'),
	   ('Bob', 'Johnson', 'bob.johnson@example.com', 'Uzytkownik3', 'Haslo3'),
	   ('Emily', 'Davis', 'emily.davis@example.com', 'Uzytkownik4', 'Haslo4'),
	   ('Michael', 'Brown', 'michael.brown@example.com', 'Uzytkownik5', 'Haslo5'),
	   ('Samantha', 'Taylor', 'samantha.taylor@example.com', 'Uzytkownik6', 'Haslo6'),
	   ('David', 'Miller', 'david.miller@example.com', 'Uzytkownik7', 'Haslo7'),
	   ('Emma', 'Williams', 'emma.williams@example.com', 'Uzytkownik8', 'Haslo8'),
	   ('Matthew', 'Anderson', 'matthew.anderson@example.com', 'Uzytkownik9', 'Haslo9'),
	   ('Olivia', 'Moore', 'olivia.moore@example.com', 'Uzytkownik10', 'Haslo110');

-- Pobieranie Id użytkowników z tabeli Users
DECLARE 
  @UserId1 UNIQUEIDENTIFIER, @UserId2 UNIQUEIDENTIFIER, @UserId3 UNIQUEIDENTIFIER,
  @UserId4 UNIQUEIDENTIFIER, @UserId5 UNIQUEIDENTIFIER, @UserId6 UNIQUEIDENTIFIER,
  @UserId7 UNIQUEIDENTIFIER, @UserId8 UNIQUEIDENTIFIER, @UserId9 UNIQUEIDENTIFIER,
  @UserId10 UNIQUEIDENTIFIER;

SELECT @UserId1 = Id FROM Users WHERE UserName = 'Uzytkownik1';
SELECT @UserId2 = Id FROM Users WHERE UserName = 'Uzytkownik2';
SELECT @UserId3 = Id FROM Users WHERE UserName = 'Uzytkownik3';
SELECT @UserId4 = Id FROM Users WHERE UserName = 'Uzytkownik4';
SELECT @UserId5 = Id FROM Users WHERE UserName = 'Uzytkownik5';
SELECT @UserId6 = Id FROM Users WHERE UserName = 'Uzytkownik6';
SELECT @UserId7 = Id FROM Users WHERE UserName = 'Uzytkownik7';
SELECT @UserId8 = Id FROM Users WHERE UserName = 'Uzytkownik8';
SELECT @UserId9 = Id FROM Users WHERE UserName = 'Uzytkownik9';
SELECT @UserId10 = Id FROM Users WHERE UserName = 'Uzytkownik10';

-- Wstawianie danych do tabeli MeasurUnit
INSERT INTO MeasurUnit (Name)
VALUES ('mg'),
       ('g'),
	   ('kg'),
       ('l'),
	   ('cl'),
       ('ml'),
       ('szkl'),
       ('łyżeczka'),
       ('łyżka'),
       ('szt');

-- Wstawianie danych do tabeli ProductType
INSERT INTO ProductType (Name)
VALUES ('PRODUKTY ZBOŻOWE'),
       ('MLEKO I JEGO PRZETWORY'),
	   ('JAJA'),
	   ('MIĘSO, RYBY, DRÓB, WĘDLINY'),
       ('MASŁO I ŚMIETANA'),
	   ('INNE TŁUSZCZE'),
       ('ZIEMNIAKI'),
	   ('WARZYWA I OWOCE BOGATE W WITAMINĘ C'),
       ('WARZYWA I OWOCE BOGATE W BETA-KAROTEN'),
	   ('INNE WARZYWA I OWOCE'),
       ('SUCHE NASIONA ROŚLIN STRĄCZKOWYCH'),
       ('CUKIER I SŁODYCZE');

-- Wstawianie danych do tabeli FoodProductBase
INSERT INTO FoodProductBase (Name, ProductType, MeasureUnit)
VALUES ('Jabłka', 9, 3),
       ('Masło', 5, 2),
       ('Jaja', 3, 7);

-- Wstawianie danych do tabeli FoodProduct
INSERT INTO FoodProduct (FoodProductBaseId, Quantity)
VALUES (1, 2),
       (2, 100),
       (3, 10);

-- Wstawianie danych do tabeli FoodProductList z użyciem pobranych Id użytkowników
INSERT INTO FoodProductList (FoodProductId, UserId)
VALUES (1, @UserId1),
       (2, @UserId2),
       (3, @UserId3);