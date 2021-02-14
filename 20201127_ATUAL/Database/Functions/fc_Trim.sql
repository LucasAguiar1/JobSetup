CREATE FUNCTION dbo.fc_Trim (
	@InputString	VARCHAR(8000)
) 
RETURNS VARCHAR(8000)
AS 
BEGIN

SET @InputString = REPLACE(@InputString, char(0), char(32))
SET @InputString = REPLACE(@InputString, char(1), char(32))
SET @InputString = REPLACE(@InputString, char(9), char(32))
SET @InputString = REPLACE(@InputString, char(10), char(32))
SET @InputString = REPLACE(@InputString, char(11), char(32))
SET @InputString = REPLACE(@InputString, char(12), char(32))
SET @InputString = REPLACE(@InputString, char(13), char(32))
SET @InputString = REPLACE(@InputString, char(160), char(32))

SET @InputString = LTRIM(RTRIM(@InputString))

RETURN @InputString

END
GO



