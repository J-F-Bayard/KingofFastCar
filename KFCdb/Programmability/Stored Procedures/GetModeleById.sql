CREATE PROCEDURE [dbo].[GetModeleById]
	@IdModel int
AS
	select idModele as IdModel, Modele.nom as Name, Modele.idMarque as IdBrand
	from Modele join Marque on Modele.idMarque = Marque.idMarque where idModele=@IdModel;
RETURN 
Go