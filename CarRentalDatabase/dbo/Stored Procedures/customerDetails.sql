CREATE PROCEDURE [dbo].[customerDetails](@CustomerID int)
	
AS
	SELECT * FROM Customer WHERE CustomerID=@CustomerID
