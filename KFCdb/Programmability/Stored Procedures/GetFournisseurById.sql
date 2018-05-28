CREATE PROCEDURE [dbo].[GetFournisseurById]
	@IdProvider int
AS
	select idFournisseur as IdProvider,nom as Name,numCompte as Account,tva As Tva,rue as Street,numero as Number,
		   cp as Zip,localite as Locality,pays as Country,email as Email,telephone as Phone	
	from V_Fournisseur where idFournisseur=@IdProvider;
RETURN 
Go