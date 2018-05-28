CREATE PROCEDURE [dbo].[GetHash]
	@Email varchar(384),
	@Passwd varchar(512),
	@hashPasswd varbinary(512) output
AS
	set @Email=LTRIM(RTRIM(@Email));
    declare @maxLength int = LEN(@Email);
    declare @concat nvarchar(512) = concat(SUBSTRING(@Email, 1, @maxLength/2), @Passwd, SUBSTRING(@Email, (@maxLength/2)+1, @maxLength));
    declare @SHIFTNO tinyint = 1;
    declare @Etext varchar(500) = '';
    declare @pc varchar(1);
    declare @i smallint = 1;
    declare @n smallint;
    set @n = len(@concat);
    set @concat = upper(@concat);
    while @i <= @n
		BEGIN
		set @pc = SUBSTRING(@concat, @i, 1)
		if ascii(@pc) between 64 and 90
            if ascii(@pc)+@SHIFTNO > 90
				set @pc = char((ascii(@pc)+@SHIFTNO)-90+64)
			else
				set @pc = char((ascii(@pc)+@SHIFTNO))
        set @Etext = @Etext + @pc
        Set @i = @i + 1
    END
    set @hashPasswd = HASHBYTES('SHA2_512', @Etext);
RETURN 0