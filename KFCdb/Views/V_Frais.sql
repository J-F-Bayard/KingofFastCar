CREATE VIEW [dbo].[V_Frais]
	AS	SELECT 
			[idFrais], 
			[idDossier], 
			[idFournisseur], 
			[intitule], 
			[montant], 
			[numFacture], 
			[datePrestation] 
		FROM [Frais] 
		WHERE [actif] = 1
