CREATE PROCEDURE [dbo].[spAexDatabase_Get]
	@Id int 
AS
begin
 select Id,UserName,UserLocation,Email,MacAddress,PhoneNumber,DateRegister,DateExpire from dbo.[Aexdatabase]
 where Id = @Id;
end
