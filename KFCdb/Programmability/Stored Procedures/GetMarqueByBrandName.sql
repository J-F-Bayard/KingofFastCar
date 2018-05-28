CREATE PROCEDURE [dbo].[GetMarqueByBrandName]
	@BrandName nvarchar(100)
AS
	select idMarque as IdBrand,nom as Name	
	from V_Marque where nom Like '@BrandName%';
RETURN 
Go