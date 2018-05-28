CREATE PROCEDURE [dbo].[CheckLogin]
	@Email varchar(512),
	@Passwd varchar(512),
	@Authentified bit=0 output
AS
	set @Email=LTRIM(RTRIM(@Email));
	declare @hashPasswd varbinary(512);
    exec GetHash @Email=@Email, @Passwd=@Passwd, @hashPasswd=@hashPasswd output;
	declare @count int;
    select @count=count(*) from [User] where mdp=@hashPasswd AND email=@Email;
	if (@count=1) BEGIN
		set @Authentified=1;
		select * from [V_User] where mdp=@hashPasswd AND email=@Email;
	END else set @Authentified=0;
	
