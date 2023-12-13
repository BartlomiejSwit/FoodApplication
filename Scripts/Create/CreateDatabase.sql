IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = 'FoodApplicationDB')
begin
	Create Database FoodApplicationDB
end
go
Use FoodApplicationDB
IF OBJECT_ID (N'FoodProduct', N'U') IS NULL 
begin
create table FoodProduct
(
	Id int identity (1,1),
	Name nvarchar (100),
	quantity int,
	measureUnit int
)
end