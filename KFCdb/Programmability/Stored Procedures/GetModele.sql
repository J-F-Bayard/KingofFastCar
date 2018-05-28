CREATE PROCEDURE [dbo].[GetModele]
AS
	select idModele as IdModel, nom as Name, idMarque as IdBrand
	from V_Modele;
RETURN 
Go