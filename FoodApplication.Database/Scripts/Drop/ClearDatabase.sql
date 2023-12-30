-- Usunięcie danych z tabeli FoodProductList
DELETE FROM FoodProductList;

-- Usunięcie danych z tabeli FoodProduct
DELETE FROM FoodProduct;

-- Usunięcie danych z tabeli FoodProductBase
DELETE FROM FoodProductBase;

-- Usunięcie danych z tabeli ProductType
DELETE FROM ProductType;

-- Usunięcie danych z tabeli MeasurUnit
DELETE FROM MeasurUnit;

-- Usunięcie danych z tabeli Users
DELETE FROM Users;

-- Resetowanie licznika Id w tabeli FoodProductList
DBCC CHECKIDENT ('FoodProductList', RESEED, 0);

-- Resetowanie licznika Id w tabeli FoodProduct
DBCC CHECKIDENT ('FoodProduct', RESEED, 0);

-- Resetowanie licznika Id w tabeli FoodProductBase
DBCC CHECKIDENT ('FoodProductBase', RESEED, 0);

-- Resetowanie licznika Id w tabeli ProductType
DBCC CHECKIDENT ('ProductType', RESEED, 0);

-- Resetowanie licznika Id w tabeli MeasurUnit
DBCC CHECKIDENT ('MeasurUnit', RESEED, 0);