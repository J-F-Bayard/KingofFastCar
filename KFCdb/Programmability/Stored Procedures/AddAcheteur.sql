CREATE PROCEDURE [dbo].[AddAcheteur]
	@LastName nvarchar(100) ,
	@FirstName nvarchar(100) ,
	@Email nvarchar(100) ,
	@Phone nvarchar(100),
	@Street nvarchar(100),
	@Number nvarchar(100),
	@Zip int,
	@Locality nvarchar(100),
	@Country nvarchar(100),
	@Account  nvarchar(100)
AS
	INSERT INTO Acheteur (nom,prenom,email,telephone,rue,numero,cp,localite,pays,numCompte) 
	VALUES 
	(@LastName,@FirstName,@Email,@Phone,@Street,@Number,@Zip,@Locality,@Country,@Account);

	
	SELECT @@IDENTITY;
