CREATE VIEW [dbo].[V_Voiture]
	AS	SELECT 
			[idVoiture], 
			[numChassis], 
			[idModele], 
			[version], 
			[annee], 
			[typeChasssis], 
			[etat], 
			[kilometrage], 
			[puissance], 
			[cylindree], 
			[localisation], 
			[carburant], 
			[transmition], 
			[couleur], 
			[peintureMetal], 
			[carnetEntretient], 
			[volantGauche] 
		FROM [Voiture] 
		WHERE [actif] = 1
