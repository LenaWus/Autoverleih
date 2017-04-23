CREATE PROCEDURE [dbo].[getAllRentedCars]

AS
	SELECT CarID FROM Rent WHERE (done=0);
