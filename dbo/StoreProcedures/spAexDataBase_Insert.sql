CREATE PROCEDURE [dbo].[spAexdatabase_Insert]
	@UserName nvarchar(50),
	@UserLocation nvarchar(50),
	@Email nvarchar(500),
	@MacAddress nvarchar(500),
	@PhoneNumber nvarchar(50),
	@DateRegister date,
	@DateExpire date

AS IF NOT EXISTS
(
    SELECT MacAddress FROM dbo.Aexdatabase WHERE MacAddress = @MacAddress 
)
BEGIN
    insert into dbo.Aexdatabase ( UserName,UserLocation,Email,MacAddress, PhoneNumber,DateRegister,DateExpire)
	values (@UserName,@UserLocation,@Email,@MacAddress,@PhoneNumber,GETDATE(),DATEADD(YEAR,1,GETDATE()));
END