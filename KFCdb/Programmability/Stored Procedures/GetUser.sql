CREATE PROCEDURE [dbo].[GetUser]
AS
	select idUser as IdUser,nom as LastName,prenom as FirstName,email as Email,mdp as [Password] from [V_User];
RETURN 
Go

