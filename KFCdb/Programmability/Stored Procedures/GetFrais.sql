CREATE PROCEDURE [dbo].[GetFrais]	
AS
	select idFrais as IdFrais,idFournisseur as IdFournisseur,idDossier as IdDossier,intitule as Entitled, montant as Amount
	,numFacture as BillNumber,datePrestation as DeliveryDate
	from V_Frais;
RETURN
GO


