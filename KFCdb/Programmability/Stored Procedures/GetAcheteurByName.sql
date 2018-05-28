CREATE PROCEDURE [dbo].[GetAcheteurByName]
	@LastName nvarchar(100)
AS 
select  idAcheteur as IdBuyer,nom as LastName,prenom as FirstName,email as Email, telephone as Phone ,rue as Street,numero as Number,
		cp as Zip,localite as Locality,pays as Country,numCompte as Account	
	from V_Acheteur where nom like '@LastName%' or prenom like '@LastName%';
RETURN 
GO