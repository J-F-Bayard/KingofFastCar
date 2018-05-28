CREATE PROCEDURE [dbo].[AddFournisseur]
	@Name nvarchar(100) ,
	@Account nvarchar(100),
	@Tva int,
	@Street nvarchar(100),
	@Number nvarchar(100),
	@Zip int,
	@Locality nvarchar(100),
	@Country nvarchar(100),
	@Email nvarchar(100) ,
	@Phone nvarchar(100)
AS
	
	INSERT INTO Fournisseur(nom,numCompte,tva,rue,numero,cp,localite,pays,email,telephone) 
	VALUES (@Name,@Account,@Tva,@Street,@Number,@Zip,@Locality,@Country,@Email,@Phone);
	
	
	SELECT @@IDENTITY;
