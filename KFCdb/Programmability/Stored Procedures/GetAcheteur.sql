/*
La base de données doit avoir un groupe de fichiers MEMORY_OPTIMIZED_DATA
avant de créer l'objet mémoire optimisé.
*/

CREATE PROCEDURE [dbo].[GetAcheteur]	
AS 
select idAcheteur as IdBuyer, nom as LastName,prenom as FirstName,email as Email, telephone as Phone ,rue as Street,numero as Number,
		cp as Zip,localite as Locality,pays as Country,numCompte as Account	
	from V_Acheteur;
RETURN 
GO