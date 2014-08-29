use master
go

drop database Lunch
go

create database Lunch
go

use Lunch
go

create table Dishes
(
	Id int identity not null primary key,
	Name nvarchar(100) not null,
	Price decimal(9, 2) not null
)
go

insert into Dishes (Name, Price) values (N'Dagens pizza', 55)
insert into Dishes (Name, Price) values (N'Dagens pasta', 49)
insert into Dishes (Name, Price) values (N'Sallad', 50)
insert into Dishes (Name, Price) values (N'Kebabtallrik', 59)
go

create table Orders
(
	Id int identity not null primary key,
	Email nvarchar(100) not null
)
go

create table OrderDetails
(
	Id int identity not null primary key,
	OrderId int not null foreign key references Orders (Id),
	DishId int not null,
	Quantity int not null
)
go

select * from Dishes
select * from Orders
select * from OrderDetails
