CREATE PROCEDURE [dbo].[DeleteVendeur]	
	@Id int
AS 
	UPDATE Vendeur SET actif=0 WHERE idVendeur=@Id;
RETURN 
GO