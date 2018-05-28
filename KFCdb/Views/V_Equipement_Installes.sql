CREATE VIEW [dbo].[V_Equipement_Installes]
	AS	SELECT 
			[idEquipInst], 
			[idVoiture], 
			[idEquip] 
		FROM [Equipement_Installes]
