CREATE PROCEDURE [dbo].[AddModele]
	@idBrand int,
	@Name nvarchar(100)
AS
	
	INSERT INTO Modele(idMarque,nom) 
	VALUES(@idBrand,@Name);
	
	SELECT @@IDENTITY;

