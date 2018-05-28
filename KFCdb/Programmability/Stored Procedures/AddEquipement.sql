/*
La base de données doit avoir un groupe de fichiers MEMORY_OPTIMIZED_DATA
avant de créer l'objet mémoire optimisé.
*/

CREATE PROCEDURE [dbo].[AddEquipement]
	@Name nvarchar(100),
	@Description nvarchar(100)

AS 
INSERT INTO Equipement(nom,description) 
	VALUES(@Name,@Description);
	
	SELECT @@IDENTITY;
