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

select * from Dishes