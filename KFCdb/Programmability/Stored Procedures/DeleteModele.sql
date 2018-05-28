CREATE PROCEDURE [dbo].[DeleteModele]	
	@Id int
AS 
	DECLARE @Dependances int;
	SELECT @Dependances=COUNT(*) FROM Voiture WHERE idModele=@Id;
	IF (@Dependances=0) BEGIN
		DELETE Modele WHERE idModele=@Id;
		RETURN 1
	END
RETURN 0
GO