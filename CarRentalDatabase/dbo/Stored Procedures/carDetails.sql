CREATE PROCEDURE [dbo].[carDetails](@CarID int)
	
AS
	SELECT * FROM Car WHERE (CarID = @CarID)
