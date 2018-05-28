CREATE VIEW [dbo].[V_Vendeur]
	AS	SELECT
			[idVendeur], 
			[nom], 
			[tva], 
			[email], 
			[telephone],
			[rue], 
			[numero], 
			[cp], 
			[localite], 
			[pays], 
			[numCompte] 
		FROM [Vendeur] 
		WHERE [actif] = 1
