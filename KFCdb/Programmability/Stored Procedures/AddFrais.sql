CREATE PROCEDURE [dbo].[AddFrais]
	@IdDossier int,	
	@IdProvider int,
	@Entitled nvarchar(100),
	@Amount float,
	@BillNumber nvarchar(100),
	@DeliveryDate date
AS
	INSERT INTO Frais(idDossier,idFournisseur,intitule,montant,numFacture,datePrestation) 
	VALUES(@IdDossier,@IdProvider,@Entitled,@Amount,@BillNumber,@DeliveryDate);
	
	
	SELECT @@IDENTITY;
