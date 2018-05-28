CREATE PROCEDURE [dbo].[DeleteFournisseur]	
	@Id int
AS 
	UPDATE Fournisseur SET actif=0 WHERE idFournisseur=@Id;
RETURN 
GO