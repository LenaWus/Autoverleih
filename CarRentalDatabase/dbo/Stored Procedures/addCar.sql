CREATE PROCEDURE [dbo].[addCar] (@CarID int, @make varchar(50)=NULL, @name varchar(50)=NULL, @pricePerHour decimal, @colour varchar(50)=NULL)
AS
	INSERT INTO Car (CarID, make, name, pricePerHour, colour)
	VALUES (@CarID, @make, @name, @pricePerHour, @colour);
