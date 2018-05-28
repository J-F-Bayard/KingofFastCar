CREATE PROCEDURE [dbo].[GetModeleByBrandName]
	@BrandName nvarchar(100)
AS
	select idModele as IdModel, Modele.nom as Name, Modele.idMarque as IdBrand
	from Modele join Marque on Modele.idMarque=Marque.idMarque where Marque.nom LIKE '@BrandName%'
RETURN 
Go
