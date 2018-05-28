CREATE PROCEDURE [dbo].[GetEquipementInstallesById]	
	@IdInstalledEquipment int
AS
	SELECT idEquipInst as IdInstalledEquipment,idVoiture as IdCar , idEquip as IdEquipment
	from V_Equipement_Installes where idEquipInst=@IdInstalledEquipment; 
RETURN 
GO
