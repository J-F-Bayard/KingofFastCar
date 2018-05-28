CREATE PROCEDURE [dbo].[AddUser]
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Email nvarchar(384),
	@Passwd varchar(512) 
AS
	set @Email=LTRIM(RTRIM(@Email));
	declare @hashPasswd varbinary(512);
    exec GetHash @Email=@Email, @Passwd=@Passwd, @hashPasswd=@hashPasswd output;

    insert into [User] (nom, prenom, email, mdp) values(@LastName, @FirstName, @Email, @hashPasswd);
	
	SELECT @@IDENTITY;
