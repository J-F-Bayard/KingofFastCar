CREATE VIEW [dbo].[V_Dossier]
	AS	SELECT 
			[idDossier], 
			[idVoiture], 
			[idVendeur],
			[idAcheteur],
			[prixAchat], 
			[prixVente],
			[dateAchat],
			[dateVente],
			[factureAchat],
			[factureVente]
		FROM [Dossier] 
		WHERE [actif] = 1
