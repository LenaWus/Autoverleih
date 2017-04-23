CREATE PROCEDURE [dbo].[rentCar] (@CustomerID int, @CarID int, @beginOfRenting datetime, @endOfRenting datetime)

AS
	INSERT INTO RentedCars (CustomerID, CarID, beginOfRenting, endOfRenting, done)
	VALUES (@CustomerID, @CarID, @beginOfRenting, @endOfRenting, 0);