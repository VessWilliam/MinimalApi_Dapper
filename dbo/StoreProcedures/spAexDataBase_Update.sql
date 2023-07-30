CREATE PROCEDURE [dbo].[spAexDataBase_Update]
	@UserLocation nvarchar(50),
	@MacAddress nvarchar(500)
AS
begin
    update dbo.Aexdatabase
	set UserLocation = @UserLocation
	where MacAddress = @MacAddress ;
end
