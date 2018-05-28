CREATE PROCEDURE [dbo].[GetDossierByCarId]
	@IdCar int
AS
	select idDossier as IdHistory,idVoiture as IdCar, idVendeur as IdSeller ,idAcheteur as IdBuyer, 
		   prixAchat as BuyingPrice , prixVente as SellingPrice
	from V_Dossier where idVoiture=@IdCar;
RETURN 
Go