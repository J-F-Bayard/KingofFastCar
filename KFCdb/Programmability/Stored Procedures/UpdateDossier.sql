CREATE PROCEDURE [dbo].[UpdateDossier]
	@IdHistory int,
	@IdCar int,
	@IdSeller int,	
	@IdBuyer int,	
	@BuyPrice int,
	@SoldPrice int,
	@BuyingDate date,
	@SoldDate date,
	@BuyingBill nvarchar(100),
	@SoldBill nvarchar(100)
AS
	UPDATE Dossier set idVoiture=@IdCar,idVendeur=@IdSeller,idAcheteur=@IdBuyer,prixAchat=@BuyPrice,prixVente=@SoldPrice,dateAchat=@BuyingDate,dateVente=@SoldDate,factureAchat=@BuyingBill,factureVente=@SoldBill
	where idDossier=@IdHistory;
	
RETURN 0
