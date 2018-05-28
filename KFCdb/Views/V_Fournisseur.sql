CREATE VIEW [dbo].[V_Fournisseur]
	AS	SELECT 
			[idFournisseur], 
			[nom], 
			[numCompte], 
			[tva], 
			[rue], 
			[numero], 
			[cp], 
			[localite], 
			[pays], 
			[email], 
			[telephone] 
		FROM [Fournisseur] 
		WHERE [actif] = 1
