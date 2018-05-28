CREATE PROCEDURE [dbo].[GetVoiture]
AS
	SELECT idVoiture as IdCar, 
			numChassis as ChassisNumber, 
			idModele as IdModel,      
	        [version] as [Version],
	        annee as [Year],
			typeChasssis as ChassisType, 
			etat as Condition, 
			kilometrage as Mileage, 
			puissance as [Power], 
			cylindree as Cylinder, 
			localisation as [Location], 
			carburant as Fuel, 
			transmition As Transmition, 
			couleur As Color, 
			peintureMetal as MetalPainting, 
			carnetEntretient as ServiceBook, 
			volantGauche as LeftHand
	from V_Voiture;
RETURN
Go