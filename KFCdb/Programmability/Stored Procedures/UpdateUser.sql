CREATE PROCEDURE [dbo].[UpdateUser]
	@IdUser int,
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Email nvarchar(384),
	@Password varchar(512) 
AS
	set @Email=LTRIM(RTRIM(@Email));
	declare @hash varbinary(512);
    exec GetHash @Email=@Email, @Passwd=@Password, @hashPasswd=@hash output;

    UPDATE [User] SET nom=@LastName, prenom=@FirstName, email=@Email, mdp=@hash
	WHERE idUser = @IdUser;
RETURN 0
