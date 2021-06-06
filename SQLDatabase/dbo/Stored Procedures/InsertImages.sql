


CREATE PROCEDURE [dbo].[InsertImages]
	@images UDTImagesTable readonly
AS
begin
	INSERT INTO dbo.Images(EntityId, URL) SELECT EntityId, URL FROM @images
end