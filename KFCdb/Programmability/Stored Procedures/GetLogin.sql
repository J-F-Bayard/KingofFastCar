CREATE PROCEDURE [dbo].[GetLogin]
	@Email nvarchar(100),
	@Passwd nvarchar(100)
AS
	select email as Email from V_User where email=@Email and mdp=@Passwd;
RETURN 
Go

