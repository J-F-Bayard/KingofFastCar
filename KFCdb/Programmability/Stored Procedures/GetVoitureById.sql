CREATE PROCEDURE [dbo].[GetVoitureById]
	@IdCar int
AS
	SELECT idVoiture as IdCar, 
			numChassis as ChassisNumber, 
			idModele as IdModel, 
			[version] as VersionCar, 
			annee as YearCar, 
			typeChasssis as ChassisType, 
			etat as Condition, 
			kilometrage as Mileage, 
			puissance as PowerCar, 
			cylindree as Cylinder, 
			localisation as LocationCar, 
			carburant as Fuel, 
			transmition As Transmition, 
			couleur As Color, 
			peintureMetal as MetalPainting, 
			carnetEntretient as ServiceBook, 
			volantGauche as LeftHand
	from V_Voiture where idVoiture=@IdCar;
RETURN
Go