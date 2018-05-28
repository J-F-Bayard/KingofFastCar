CREATE PROCEDURE [dbo].[UpdateAcheteur]
	@IdBuyer int,
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
	UPDATE Acheteur SET nom=@LastName , prenom=@FirstName , email=@Email , telephone=@Phone , rue=@Street , numero=@Number , 
						cp=@Zip , localite=@Locality , pays=@Country , numCompte=@Account
	WHERE idAcheteur= @IdBuyer;
RETURN 0
