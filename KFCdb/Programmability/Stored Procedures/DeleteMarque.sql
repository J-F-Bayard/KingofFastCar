CREATE PROCEDURE [dbo].[DeleteMarque]	
	@Id int
AS 
	DECLARE @Dependances int;
	SELECT @Dependances=COUNT(*) FROM Modele WHERE idMarque=@Id;
	IF (@Dependances=0) BEGIN
		DELETE Marque WHERE idMarque=@Id;
		RETURN 1
	END
RETURN 0
GO