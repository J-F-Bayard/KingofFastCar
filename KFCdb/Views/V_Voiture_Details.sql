CREATE VIEW [dbo].[V_Voiture_Details]
	AS
		SELECT	Voiture.idVoiture as IdCar,
	        Voiture.numChassis as ChassisNumber,
	        Marque.nom as BrandName,
	        Marque.idMarque as IdBrand,
	        Modele.nom as ModelName,
	        Modele.idModele as IdModel,	        
	        Voiture.[version] as [Version],
	        Voiture.annee as [Year],
	        Voiture.typeChasssis as ChassisType,
	        Voiture.etat as Condition, 
	        Voiture.kilometrage as Mileage, 
	        Voiture.puissance as [Power], 
	        Voiture.cylindree as Cylinder, 
	        Voiture.localisation as [Location], 
	        Voiture.carburant as Fuel, 
	        Voiture.transmition As Transmition, 
	        Voiture.couleur As Color, 
	        Voiture.peintureMetal as MetalPainting, 
	        Voiture.carnetEntretient as ServiceBook, 
	        Voiture.volantGauche as LeftHand,
			Dossier.idDossier as IdHistory
		FROM [Voiture] 
			INNER JOIN [Modele] ON [Voiture].[idModele]=[Modele].[idModele]
			INNER JOIN [Marque] ON [Modele].[idMarque]=[Marque].[idMarque]
			INNER JOIN [Dossier] ON [Voiture].[idVoiture]=[Dossier].[idVoiture]
		WHERE [Voiture].[actif] = 1