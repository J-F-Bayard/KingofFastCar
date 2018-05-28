CREATE PROCEDURE [dbo].[DeleteDossier]	
	@Id int
AS 
	UPDATE Dossier SET actif=0 WHERE idDossier=@Id;
RETURN 
GO