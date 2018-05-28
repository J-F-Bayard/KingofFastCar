CREATE PROCEDURE [dbo].[GetEquipementByName]	
	@NameEquipement nvarchar(100)	
AS
SELECT idEquip as IdEquipement,nom as Name, description as Description from Equipement where nom Like '%@NameEquipement%'
RETURN
GO