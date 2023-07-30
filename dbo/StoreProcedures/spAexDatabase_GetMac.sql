CREATE PROCEDURE [dbo].[spAexDatabase_GetMac]
  @mac nvarchar(500)
AS
begin
 select * from dbo.[Aexdatabase] where MacAddress = @mac;
end
