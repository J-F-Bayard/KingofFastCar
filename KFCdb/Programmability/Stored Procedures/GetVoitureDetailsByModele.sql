CREATE PROCEDURE [dbo].[GetVoitureDetailsByModele]
	@IdModel int
AS
	SELECT * FROM V_Voiture_Details
	WHERE IdModel=@IdModel;
RETURN
Go