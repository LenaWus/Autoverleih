CREATE PROCEDURE [dbo].[carDetails](@Make varchar, @Name varchar)
	
AS
	SELECT * FROM Car WHERE (Make=@Make AND Name=@Name)
