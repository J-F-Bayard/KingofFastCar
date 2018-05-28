CREATE PROCEDURE [dbo].[DeleteEquipementInstalles]	
	@Id int
AS 
	DECLARE @IdVoiture int,
			@IdEquip int,
			@Dependances int,
			@Dependances2 int;
	SELECT @IdVoiture=idVoiture, @IdEquip=idEquip FROM Equipement_Installes WHERE idEquipInst=@Id;
	SELECT @Dependances=COUNT(*) FROM Voiture WHERE idVoiture=@IdVoiture;
	SELECT @Dependances2=COUNT(*) FROM Equipement WHERE idEquip=@IdEquip;
	IF ((@Dependances+@Dependances2)=0) BEGIN
		DELETE Equipement_Installes WHERE idEquipInst=@Id;
		RETURN 1
	END
RETURN 0
GO