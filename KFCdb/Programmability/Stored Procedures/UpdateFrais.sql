CREATE PROCEDURE [dbo].[UpdateFrais]
	@IdCharge int,
	@IdHistory int,
	@IdProvider int,
	@Entitled nvarchar(100),
	@Amount float,
	@BillNumber nvarchar(100),
	@DeliveryDate date
AS
	UPDATE Frais set idDossier=@IdHistory,idFournisseur=@IdProvider,intitule=@Entitled,montant=@Amount,
					 numFacture=@BillNumber,datePrestation=@DeliveryDate where idFrais=@IdCharge;
RETURN 0
