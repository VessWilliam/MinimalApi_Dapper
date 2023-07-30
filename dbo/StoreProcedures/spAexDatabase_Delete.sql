CREATE PROCEDURE [dbo].[spAexDatabase_Delete]
	@id int 
AS
begin
    delete
    from dbo.[Aexdatabase] 
	where Id = @id;
end
