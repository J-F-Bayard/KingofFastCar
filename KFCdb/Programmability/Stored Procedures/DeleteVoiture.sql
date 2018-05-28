CREATE PROCEDURE [dbo].[DeleteVoiture]	
	@Id int
AS 
	UPDATE Voiture SET actif=0 WHERE idVoiture=@Id;
RETURN 
GO