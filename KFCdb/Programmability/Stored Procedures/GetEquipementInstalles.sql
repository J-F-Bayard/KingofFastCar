CREATE PROCEDURE [dbo].[GetEquipementInstalles]	
AS
	SELECT idEquipInst as IdInstalledEquipment,idVoiture as IdCar , idEquip as IdEquipment
	from V_Equipement_Installes
RETURN 
GO
