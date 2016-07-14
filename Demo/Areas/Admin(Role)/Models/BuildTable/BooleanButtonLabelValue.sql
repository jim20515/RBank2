-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[BooleanButtonLabelValue]
(
	-- Add the parameters for the function here
	@inputVal bit
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar nvarchar(3)

	-- Add the T-SQL statements to compute the return value here
	IF @inputVal = 0
	   BEGIN
	      SET @ResultVar = '未啟用'
	   END
	ELSE IF @inputVal = 1
	   BEGIN
	      SET @ResultVar = '啟用中'
	   END
	-- Return the result of the function
	RETURN @ResultVar;

END

GO

