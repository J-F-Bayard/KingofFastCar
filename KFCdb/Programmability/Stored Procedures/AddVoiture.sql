CREATE PROCEDURE [dbo].[AddVoiture]
	@ChassisNumber nvarchar(100),
	@IdModel int,
	@Version nvarchar(100),
	@Year date,
	@ChassisType nvarchar(100),
	@Condition nvarchar(100),
	@Mileage int,
	@Power int,
	@Cylinder int,
	@Location nvarchar(100),
	@Fuel nvarchar(100),
	@Transmition nvarchar(100),
	@Color nvarchar(100),
	@MetalPainting bit,
	@ServiceBook bit,
	@LeftHand bit
AS
	INSERT INTO Voiture(numChassis,idModele,[version],annee,typeChasssis,etat,kilometrage,puissance,
						 cylindree,localisation,carburant,transmition,couleur,peintureMetal,
						 carnetEntretient,volantGauche)
	VALUES(@ChassisNumber,@IdModel,@Version,@Year,@ChassisType,@Condition,@Mileage, 
			@Power,@Cylinder,@Location,@Fuel,@Transmition, 
			@Color,@MetalPainting,@ServiceBook,@LeftHand);

	SELECT @@IDENTITY;
