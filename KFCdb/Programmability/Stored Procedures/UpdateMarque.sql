CREATE PROCEDURE [dbo].[UpdateMarque]
	@IdBrand int,
	@Name nvarchar(100)
AS
	UPDATE Marque set nom=@Name where idMarque=@IdBrand;
RETURN 0
