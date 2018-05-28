CREATE PROCEDURE [dbo].[DeleteFrais]	
	@Id int
AS 
	UPDATE Frais SET actif=0 WHERE idFrais=@Id;
RETURN 
GO