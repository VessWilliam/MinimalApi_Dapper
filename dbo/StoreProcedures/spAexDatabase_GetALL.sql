CREATE PROCEDURE [dbo].[spAexDatabase_GetALL]
As
begin
  Select Id, 
  UserName, 
  UserLocation, 
  Email,
  MacAddress, 
  PhoneNumber,
  DateRegister,
  DateExpire
  from dbo.[Aexdatabase]
end
 