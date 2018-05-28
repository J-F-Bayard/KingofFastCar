CREATE PROCEDURE [dbo].[AddEquipementInstalles]
	@IdVoiture int,
	@IdEquipment int

AS 
INSERT INTO Equipement_Installes(idVoiture,idEquip) 
	VALUES(@IdVoiture,@IdEquipment);
	
	SELECT @@IDENTITY;
