-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[SexButtonLabelValue]
(
	-- Add the parameters for the function here
	@inputVal int
)
RETURNS nvarchar(1)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar nvarchar(1)

	-- Add the T-SQL statements to compute the return value here
	IF @inputVal = 1
	   BEGIN
	      SET @ResultVar = '男'
	   END
	ELSE IF @inputVal = 2
	   BEGIN
	      SET @ResultVar = '女'
	   END
	-- Return the result of the function
	RETURN @ResultVar;

END

GO

