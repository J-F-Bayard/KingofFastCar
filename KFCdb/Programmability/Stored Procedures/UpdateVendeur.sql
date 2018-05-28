CREATE PROCEDURE [dbo].[UpdateVendeur]
	@IdSeller int,
	@Name nvarchar(100) ,
	@Tva int ,
	@Email nvarchar(100) ,
	@Phone nvarchar(100),
	@Street nvarchar(100),
	@Number nvarchar(100),
	@Zip int,
	@Locality nvarchar(100),
	@Country nvarchar(100),
	@Account  nvarchar(100)
AS
	UPDATE Vendeur SET nom=@Name ,tva=@Tva, email=@Email , telephone=@Phone , rue=@Street , numero=@Number , 
						cp=@Zip , localite=@Locality , pays=@Country , numCompte=@Account
	WHERE idVendeur= @IdSeller;
RETURN 0
