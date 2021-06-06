CREATE PROCEDURE [dbo].[InsertEntity]
    @entityName as nvarchar(200)
AS
BEGIN
    INSERT INTO dbo.Entities([EntityName])
	Values (@entityName)

	
  
END