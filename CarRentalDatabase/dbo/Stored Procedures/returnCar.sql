CREATE PROCEDURE [dbo].[returnCar] (@CustomerID int, @CarID int, @endOfRenting datetime)

AS
	UPDATE Rent
	SET done=1
	WHERE (@CustomerID=CustomerID AND @CarID=CarID AND @endOfRenting=endOfRenting);