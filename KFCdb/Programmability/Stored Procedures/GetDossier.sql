CREATE PROCEDURE [dbo].[GetDossier]
AS
	select idDossier as IdHistory,idVoiture as IdCar, idVendeur as IdSeller ,idAcheteur as IdBuyer, 
		   prixAchat as BuyingPrice , prixVente as SellingPrice, dateAchat as BuyDate, dateVente as SoldDate, factureAchat as BuyBill, factureVente as SoldBill 
	from V_Dossier
RETURN 
Go
