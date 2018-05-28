CREATE PROCEDURE [dbo].[GetEquipementById]	
	@IdEquipment int	
AS
SELECT idEquip as IdEquipment,nom as Name, [description] as [Description] from V_Equipement where idEquip=@IdEquipment
RETURN
GO