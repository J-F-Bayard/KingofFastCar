CREATE PROCEDURE [dbo].[UpdateEquipement]
	@IdEquipment int,
	@Name nvarchar(100),
	@Description nvarchar(100)

AS 
UPDATE Equipement Set nom=@Name,[description] = @Description where idEquip=@IdEquipment;
RETURN 0
