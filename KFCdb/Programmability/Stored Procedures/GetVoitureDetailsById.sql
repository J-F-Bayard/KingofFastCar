CREATE PROCEDURE [dbo].[GetVoitureDetailsById]
	@IdCar int
AS
	SELECT * FROM V_Voiture_Details
	WHERE IdCar=@IdCar;
RETURN 


		