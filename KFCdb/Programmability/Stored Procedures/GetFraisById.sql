CREATE PROCEDURE [dbo].[GetFraisById]
	@IdCharge int
AS
	select idFrais as IdCharge,idFournisseur as IdProvider,idDossier as IdHistory,intitule as Entitled, montant as Amount,numFacture as BillNumber,
	datePrestation as DeliveryDate
	from V_Frais where idFrais=@IdCharge;
RETURN
GO


