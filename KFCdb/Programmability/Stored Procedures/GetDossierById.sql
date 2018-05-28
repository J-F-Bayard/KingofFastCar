CREATE PROCEDURE [dbo].[GetDossierById]
	@IdHistory int
AS
	select idDossier as IdHistory,idVoiture as IdCar, idVendeur as IdSeller ,idAcheteur as IdBuyer, 
		   prixAchat as BuyingPrice , prixVente as SellingPrice, dateAchat as BuyingDate, dateVente as SoldDate, factureAchat as BuyindBill, factureVente as SoldBill 

	from V_Dossier where idDossier=@IdHistory 
RETURN 
Go



	