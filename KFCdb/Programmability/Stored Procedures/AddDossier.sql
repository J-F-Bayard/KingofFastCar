Create PROCEDURE [dbo].[AddDossier]
	@IdVoiture int,
	@IdVendeur int,
	@IdAcheteur int,	
	@PrixAchat int,
	@PrixVente int,
	@DateVente date,
	@FactureVente nvarchar(100),
	@FactureAchat nvarchar(100),
	@DateAchat date

AS
	INSERT INTO Dossier(idVoiture,idVendeur,idAcheteur,prixAchat,prixVente,dateAchat,dateVente,factureAchat,factureVente) 
	VALUES(@IdVoiture,@IdVendeur,@IdAcheteur,@PrixAchat,@PrixVente,@DateAchat,@DateVente,@FactureAchat,@FactureVente);	   
																		   				 
	SELECT @@IDENTITY;													   
