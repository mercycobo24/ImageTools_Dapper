CREATE PROCEDURE [dbo].[InsertImage]
	@EntityId as integer,
	@URL as varchar(500)
AS
	Insert Into Images ([URL],EntityId)
    Values (@URL,@EntityId)
	
RETURN 0