CREATE PROCEDURE [dbo].[isCarFree] (@CarID int, @beginOfRenting datetime, @endOfRenting datetime)
AS
	SELECT COUNT(*) FROM RentedCars WHERE (CarId=@CarID AND (beginOfRenting > @endOfRenting OR endOfRenting < @beginOfRenting));