CREATE PROCEDURE [dbo].[AddVendeur]
	@Name nvarchar(100) ,
	@Tva int,
	@Email nvarchar(100) ,
	@Phone nvarchar(100),
	@Street nvarchar(100),
	@Number nvarchar(100),
	@Zip int,
	@Locality nvarchar(100),
	@Country nvarchar(100),
	@Account  nvarchar(100)
AS
	INSERT INTO Vendeur (nom,tva,email,telephone,rue,numero,cp,localite,pays,numCompte) 
	VALUES 
	(@Name,@Tva,@Email,@Phone,@Street,@Number,@Zip,@Locality,@Country,@Account);
	
	SELECT @@IDENTITY;
