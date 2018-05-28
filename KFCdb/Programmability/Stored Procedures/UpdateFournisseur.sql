CREATE PROCEDURE [dbo].[UpdateFournisseur]
	@IdProvider int,
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
	Update Fournisseur SET nom=@Name,numCompte=@Account,tva=@Tva,rue=@Street,numero=@Number,cp=@Zip,localite=@Locality,
			pays=@Country,email=@Email,telephone=@Phone where idFournisseur=@IdProvider
RETURN 0
