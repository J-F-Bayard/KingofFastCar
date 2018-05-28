CREATE PROCEDURE [dbo].[AddMarque]
	@Name nvarchar(100)
AS
	INSERT INTO Marque(nom)VALUES(@Name);
	
	SELECT SCOPE_IDENTITY();
