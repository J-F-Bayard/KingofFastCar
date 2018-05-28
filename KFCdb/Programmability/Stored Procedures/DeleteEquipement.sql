CREATE PROCEDURE [dbo].[DeleteEquipement]	
	@Id int
AS 
	DECLARE @Dependances int;
	SELECT @Dependances=COUNT(*) FROM Equipement_Installes WHERE idEquip=@Id;
	IF (@Dependances=0) BEGIN
		DELETE Equipement WHERE idEquip=@Id;
		RETURN 1
	END
RETURN 0
GO