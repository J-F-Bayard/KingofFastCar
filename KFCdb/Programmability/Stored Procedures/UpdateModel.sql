CREATE PROCEDURE [dbo].[UpdateModel]
	@IdModel int,
	@IdBrand int,
	@Name nvarchar(100)
AS
	UPDATE Modele set idMarque=@IdBrand,nom=@Name 
	WHERE idModele=@IdModel;
RETURN 0
