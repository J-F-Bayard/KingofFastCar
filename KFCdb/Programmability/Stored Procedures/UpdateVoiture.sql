CREATE PROCEDURE [dbo].[UpdateVoiture]
	@IdCar int,
	@ChassisNumber nvarchar(100),
	@IdModel nvarchar(100),
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
	UPDATE Voiture set numChassis=@ChassisNumber,idModele=@IdModel,[version]=@Version,annee=@Year,typeChasssis=@ChassisType,etat=@Condition,
					   kilometrage=@Mileage,puissance=@Power,cylindree=@Cylinder,localisation=@Location,carburant=@Fuel,transmition=@Transmition,
					   couleur=@Color,peintureMetal=@MetalPainting,carnetEntretient=@ServiceBook,volantGauche=@LeftHand
	where idVoiture=@IdCar;
RETURN 0
