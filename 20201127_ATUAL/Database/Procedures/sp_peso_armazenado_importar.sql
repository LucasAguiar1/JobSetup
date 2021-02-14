
-- exec sp_peso_armazenado_importar
CREATE PROCEDURE sp_peso_armazenado_importar
AS
BEGIN
SET NOCOUNT ON

DECLARE @controle		DATE,
		@parametroEmail	INT = 5,
		@parametro		INT = 6,
		@query			VARCHAR(1000) = '',
		@categoria		VARCHAR(50) = '',
		@totalLBS		NUMERIC(18,8)

DECLARE @HtmlHeader		NVARCHAR(MAX) = '',
		@HtmlTable		NVARCHAR(MAX) = '',
		@HtmlBody		NVARCHAR(MAX) = '',
		@EmailDestino   VARCHAR(2000) = '',
		@EmailAssunto	NVARCHAR(MAX) = ''

CREATE TABLE #Armazenado
(
	categoria	varchar(50)		NOT NULL,	
	total_kg	numeric(18,8)	NOT NULL,
	total_lbs	numeric(18,8)	NOT NULL,
	categoriaId int				NOT NULL
)

/**********************************************************************/
/*** PARÂMETRO DA PRÓXIMA DATA A SER PROCESSADA ***********************/
/**********************************************************************/
SELECT @controle = CONVERT(DATE, vl_parametro) 
  FROM tb_parametros
 WHERE id_parametro = @parametro

IF DATEADD(DD, 1,  @controle) < GETDATE() BEGIN
	/**********************************************************************/
	/*** REMOÇÃO DOS PESOS IMPORTADOS NA DATA DE PROCESSAMENTO ************/
	/**********************************************************************/
	DELETE tb_pesos_armazenados
	 WHERE dt_referencia = @controle

	/**********************************************************************/
	/*** DADOS IMPORTADOS VIA LINKED SERVER *******************************/
	/**********************************************************************/
	SET @query = '
		INSERT INTO #Armazenado (categoria, total_kg, total_lbs, categoriaId)
			SELECT RTRIM(LTRIM(CATEGORIA)), TOTAL_KG, TOTAL_LBS, 0
			  FROM OPENQUERY (DASH_ORAPROD, ''SELECT CATEGORIA, TOTAL_KG, TOTAL_LBS FROM DASH.VW_WEIGHT_DAY_CATEG where yyyymmdd=' + 
				REPLACE(CONVERT(VARCHAR, @controle, 111),'/','') + ''')'
	EXEC (@query)

	-- Atualização de ORS para A2 interna
	UPDATE #Armazenado SET categoria = 'A2' WHERE categoria = 'ORS'

	UPDATE a
	   SET a.categoriaId = c.id_categoria
	  FROM #Armazenado a
			INNER JOIN tb_Categorias c
				ON a.categoria = c.nm_categoria

	INSERT INTO tb_pesos_armazenados (id_categoria, dt_referencia, qt_peso_armazenado)
		SELECT categoriaId, @controle, total_lbs
		  FROM #Armazenado WHERE categoriaId > 0

	/**********************************************************************/
	/*** PREPARAÇÃO PARA ENVIO DE EMAIL ***********************************/
	/**********************************************************************/
	SET @HtmlHeader = '<HTML><HEADER>
							<STYLE type="text/css">
							.f0 { color:black; font: 12px verdana; }
							.f1 { color:black; font: 12px arial,verdana;}
							.f2 { color:red; font: 12px arial,verdana;}
							td { align-self:center; align-content:center; align-items:center; }
							</STYLE></HEADER><BODY>
							<FONT class="f0">Prezado administrador,</FONT><BR><BR>'

	SELECT @EmailDestino = vl_parametro 
	  FROM tb_parametros
	 WHERE id_parametro = @parametroEmail


	/**********************************************************************/
	/*** VALIDAÇÃO DE ERROS DE IMPORTAÇÃO *********************************/
	/**********************************************************************/
	IF EXISTS (SELECT 1 FROM #Armazenado WHERE categoriaId = 0) BEGIN
		SET @EmailAssunto = 'LHH Importação com PROBLEMAS - Pesos Armazenados - Data ' + CONVERT(VARCHAR, @controle, 103)

		SET @HtmlHeader = @HtmlHeader +
				'<FONT class="f1">Processamento da importação dos pesos armazenados com </FONT><FONT class="f2"><b>PROBLEMAS:</b></FONT><BR><BR>'

		/**********************************************************************/
		DECLARE c_Erros CURSOR READ_ONLY FOR
			SELECT categoria, total_lbs FROM #Armazenado WHERE categoriaId = 0
		OPEN c_Erros

		FETCH NEXT FROM c_Erros 
			INTO @categoria, @totalLBS

		WHILE (@@fetch_status <> -1) BEGIN
			IF (@@fetch_status <> -2) BEGIN
				SET @HtmlHeader = @HtmlHeader + '<FONT class="f1">Categoria <b>' + @categoria + '</b> com peso armazenado de <b>' + 
													REPLACE(CONVERT(VARCHAR, @totalLBS), '.', ',') + '</b> libras não configurada</FONT><BR>'
				FETCH NEXT FROM c_Erros 
					INTO @categoria, @totalLBS
				END
			END

		CLOSE c_Erros
		DEALLOCATE c_Erros

		SET @HtmlHeader = @HtmlHeader + '<BR><FONT class="f1">Qualquer dúvida informar a Tecnologia da Informação</FONT>'
		END
	ELSE BEGIN
		SET @EmailAssunto = 'LHH Importação com SUCESSO - Pesos Armazenados - Data ' + CONVERT(VARCHAR, @controle, 103)

		SET @HtmlHeader = @HtmlHeader +
				'<FONT class="f1">Processamento da importação do peso armazenado realizada com SUCESSO.</FONT><BR><BR>
				<FONT class="f1">Qualquer problema encontrado informar a Tecnologia da Informação</FONT>'
		END


	/**********************************************************************/
	/*** ATUALIZAÇÃO DO PARÂMETRO *****************************************/
	/**********************************************************************/
	SET @HtmlBody   = @HtmlHeader + @HtmlTable + '</BODY></HTML>'

	EXEC MSDB.DBO.SP_SEND_DBMAIL 
			@RECIPIENTS = @EmailDestino,
			@SUBJECT = @EmailAssunto,
			@BODY = @HtmlBody,
			@BODY_FORMAT = 'HTML',
			@ATTACH_QUERY_RESULT_AS_FILE = 0;


	/**********************************************************************/
	/*** ATUALIZAÇÃO DO PARÂMETRO *****************************************/
	/**********************************************************************/
	UPDATE tb_parametros
	   SET vl_parametro = CONVERT(VARCHAR, DATEADD(DD, 1, @controle), 23)
	 WHERE id_parametro = @parametro
	END

/**********************************************************************/
DROP TABLE #Armazenado

END
GO


