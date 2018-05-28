CREATE PROCEDURE [dbo].[GetModeleByModelName]
	@ModelName nvarchar(100)
AS
	select idModele as IdModel, nom as Name, idMarque as IdBrand
	from V_Modele where nom LIKE '@ModelName%'
RETURN 
Go