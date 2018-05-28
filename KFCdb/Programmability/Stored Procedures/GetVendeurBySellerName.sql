CREATE PROCEDURE [dbo].[GetVendeurBySellerName]
	@SellerName nvarchar(100)
AS
	select idVendeur as IdSeller,nom as Name,tva As Tva,email as Email,telephone as Phone ,rue as Street,numero as Number,
		cp as Zip,localite as Locality,pays as Country,numCompte as Account	
	from V_Vendeur where nom  like '@SellerName%';
RETURN
GO