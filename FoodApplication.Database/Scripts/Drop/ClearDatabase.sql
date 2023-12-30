-- Usunięcie danych z tabeli FoodProductList
DELETE FROM FoodProductList;
-- Resetowanie licznika Id w tabeli FoodProductList
DBCC CHECKIDENT ('FoodProductList', RESEED, 0);

-- Usunięcie danych z tabeli FoodProduct
DELETE FROM FoodProduct;
-- Resetowanie licznika Id w tabeli FoodProduct
DBCC CHECKIDENT ('FoodProduct', RESEED, 0);

-- Usunięcie danych z tabeli FoodProductBase
DELETE FROM FoodProductBase;
-- Resetowanie licznika Id w tabeli FoodProductBase
DBCC CHECKIDENT ('FoodProductBase', RESEED, 0);

-- Usunięcie danych z tabeli ProductType
DELETE FROM ProductType;
-- Resetowanie licznika Id w tabeli ProductType
DBCC CHECKIDENT ('ProductType', RESEED, 0);

-- Usunięcie danych z tabeli MeasurUnit
DELETE FROM MeasurUnit;
-- Resetowanie licznika Id w tabeli MeasurUnit
DBCC CHECKIDENT ('MeasurUnit', RESEED, 0);

-- Usunięcie danych z tabeli Users
DELETE FROM Users;

