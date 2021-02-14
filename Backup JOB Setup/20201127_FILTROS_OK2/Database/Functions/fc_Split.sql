CREATE FUNCTION fc_Split (
	@InputString	VARCHAR(8000)
	, @Delimiter	VARCHAR(3)
) RETURNS @Items	TABLE (
	Item			VARCHAR(8000)
)
AS BEGIN

	IF @Delimiter = ' '
	BEGIN

		SET @Delimiter = ','
		SET @InputString = REPLACE(@InputString, ' ', @Delimiter)
	END

	IF (@Delimiter IS NULL OR @Delimiter = '') begin
		SET @Delimiter = ','
	end


	DECLARE @Item           VARCHAR(8000)
	DECLARE @ItemList       VARCHAR(8000)
	DECLARE @DelimIndex     INT

	SET @ItemList = @InputString
	SET @DelimIndex = CHARINDEX(@Delimiter, @ItemList, 0)

	WHILE (@DelimIndex != 0) BEGIN
		SET @Item = rtrim ( ltrim ( SUBSTRING(@ItemList, 0, @DelimIndex) ) ) 
		INSERT INTO @Items VALUES ( @Item )

		-- um item a menos
		SET @ItemList = SUBSTRING(@ItemList, @DelimIndex+1, LEN(@ItemList)-@DelimIndex)
		SET @DelimIndex = CHARINDEX(@Delimiter, @ItemList, 0)
	END

	-- Pelo menos um delimitador foi encontrado em @InputString
	IF @Item IS NOT NULL BEGIN
		SET @Item = rtrim ( ltrim ( @ItemList ) ) 
		INSERT INTO @Items VALUES (@Item)
		
	END else begin -- Nenhum delimitador foi encontrado em @InputString, portanto, apenas retorne @InputString

		INSERT INTO @Items VALUES (@InputString)
	end

	RETURN

end
GO

--GRANT EXECUTE ON fc_Split TO public
go

