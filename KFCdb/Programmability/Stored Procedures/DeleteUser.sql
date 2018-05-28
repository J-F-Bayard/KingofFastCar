CREATE PROCEDURE [dbo].[DeleteUser]	
	@Id int
AS 
	DECLARE @Nb int;
	SELECT @Nb=COUNT(*) FROM [User] WHERE idUser=@Id;
	IF (@Nb=1) BEGIN
		DELETE [User] WHERE idUser=@Id;
		RETURN 1
	END
RETURN 0
GO