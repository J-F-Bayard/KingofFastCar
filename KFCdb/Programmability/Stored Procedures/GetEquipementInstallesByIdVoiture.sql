CREATE PROCEDURE [dbo].[GetEquipementInstallesByIdVoiture]	
	@IdCar int
AS
	SELECT idEquipInst as IdInstalledEquipment,idVoiture as IdCar , idEquip as IdEquipment
	from V_Equipement_Installes where idVoiture=@IdCar; 
RETURN 
GO
