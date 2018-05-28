CREATE PROCEDURE [dbo].[GetMarqueById]
	@IdBrand int
AS
	select idMarque as IdBrand,nom as [Name]	
	from V_Marque where idMarque=@IdBrand;
RETURN 
Go