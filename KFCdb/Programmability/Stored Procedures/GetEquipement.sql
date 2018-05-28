CREATE PROCEDURE [dbo].[GetEquipement]		
AS
SELECT idEquip as IdEquipment,nom as Name, [description] as [Description] from V_Equipement
RETURN
GO