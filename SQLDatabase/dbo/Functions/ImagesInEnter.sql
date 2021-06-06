
CREATE FUNCTION [ImagesInEnter] 
(
	@ImageId int
	)
RETURNS  varchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ReturnValue varchar(max);

	Set @ReturnValue = (Select 'Type of the entity from images with URL ' + URL  from Images where Images.id= @ImageId) 
	-- Return the result of the function
	RETURN @ReturnValue

END