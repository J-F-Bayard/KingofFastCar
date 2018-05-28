CREATE PROCEDURE [dbo].[GetFraisByHistory]
	@IdHistory int
AS
	select idFournisseur as IdFrais,idFournisseur as IdFournisseur,idDossier as IdDossier,intitule as Entitled, montant as Amount,numFacture as BillNumber,datePrestation as DeliveryDate
	from V_Frais where idDossier=@IdHistory;
RETURN
GO


