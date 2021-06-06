CREATE PROCEDURE [dbo].[GetEntityImages]
	@EntityId int 
AS
	

	SELECT Images.id,Entities.id as EntityId,Entities.EntityName as EntityName,Images.Id as ImageId,Images.URL
		FROM Entities
		Left join Images
		on Entities.Id=Images.EntityId
		where Entities.Id = @EntityId