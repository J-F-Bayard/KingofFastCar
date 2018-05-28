CREATE PROCEDURE [dbo].[GetUserByEmail]
	@Email nvarchar(100)
AS
	select idUser as IdUser,nom as LastName,prenom as FirstName,email as Email,mdp as [Password] from [V_User] where email=@Email;
RETURN 
Go

