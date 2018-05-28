CREATE PROCEDURE [dbo].[GetMarque]
AS
	select idMarque as IdBrand,nom as Name	
	from V_Marque;
RETURN 
Go