CREATE PROCEDURE [dbo].[GetVendeur]	
AS
	select idVendeur as IdSeller,nom as Name,tva As Tva,email as Email,telephone as Phone ,rue as Street,numero as Number,
		cp as Zip,localite as Locality,pays as Country,numCompte as Account	
	from V_Vendeur;
RETURN
GO