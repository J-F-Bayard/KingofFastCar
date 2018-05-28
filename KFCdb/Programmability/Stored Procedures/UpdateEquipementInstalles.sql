CREATE PROCEDURE [dbo].[UpdateEquipementInstalles]
	@idInstalledEquipment int,
	@IdCar int,
	@IdEquipment int

AS 
UPDATE Equipement_Installes set idVoiture=@IdCar,idEquip=@IdEquipment where idEquipInst=@idInstalledEquipment
RETURN 0
