CREATE VIEW [dbo].[V_Acheteur]
	AS	SELECT 
			[idAcheteur], 
			[nom], 
			[prenom], 
			[email], 
			[telephone], 
			[rue], 
			[numero], 
			[cp], 
			[localite], 
			[pays], 
			[numCompte] 
		FROM [Acheteur] 
		WHERE [actif] = 1
