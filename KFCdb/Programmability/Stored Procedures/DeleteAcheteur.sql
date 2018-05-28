CREATE PROCEDURE [dbo].[DeleteAcheteur]	
	@Id int
AS 
	UPDATE Acheteur SET actif=0 WHERE idAcheteur=@Id;
RETURN 
GO