CREATE PROCEDURE [dbo].[addCustomer](@CustomerID int, @firstname varchar(50), @lastname varchar(50), @title varchar(50)=NULL, @age int, @notes varchar(100)=NULL)

AS
	INSERT INTO Customer (CustomerID, firstname, lastname, title, age, notes) 

	VALUES(@CustomerID, @firstname, @lastname, @title, @age, @notes);
