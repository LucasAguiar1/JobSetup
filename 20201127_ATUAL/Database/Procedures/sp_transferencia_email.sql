
-- EXEC sp_transferencia_email 1, 2, 8, '2019-04-03'
CREATE PROCEDURE [dbo].sp_transferencia_email
(
	@ccOrigem		int,
	@ccDestino		int,
	@horas			numeric(5,2),
	@referencia		date
)	
AS
BEGIN
DECLARE @datCurrent	   Datetime = GetDate(),
		@ccOrigemDesc  VarChar(200),
		@emailOrigem   VarChar(200),
		@ccDestinoDesc VarChar(200),
		@emailDestino  VarChar(200);

SELECT @ccOrigemDesc = ISNULL(cc.cd_cc, '') + ' - ' + ISNULL(cc.nm_cc, ''),
	   @emailOrigem = ISNULL(cc.ds_lista_email, '')
  FROM tb_CentroCusto cc WITH(NOLOCK) 
 WHERE cc.id_cc = @ccOrigem

SELECT @ccDestinoDesc = ISNULL(cc.cd_cc, '') + ' - ' + ISNULL(cc.nm_cc, ''),
	   @emailDestino = ISNULL(cc.ds_lista_email, '')
  FROM tb_CentroCusto cc WITH(NOLOCK)
 WHERE cc.id_cc = @ccDestino

/***********************************************************************************************************/
/**** GERA HTML DE SAIDA ***********************************************************************************/
/***********************************************************************************************************/
DECLARE @HtmlHeader			AS NVARCHAR(MAX) = ''
DECLARE @HtmlTable			AS NVARCHAR(MAX) = ''
DECLARE @HtmlContent		AS NVARCHAR(MAX) = ''
DECLARE @HtmlBody			AS NVARCHAR(MAX) = ''
DECLARE @HtmlLegend			AS NVARCHAR(MAX) = ''
DECLARE @EmailAssunto		AS NVARCHAR(MAX) = 'LHH Horas de Transferência de Recurso - Dia ' + CONVERT(VARCHAR, @referencia, 103)

DECLARE @EmailDestinatarios AS VARCHAR(8000) = ''

IF LEN(@emailDestino) > 0 OR LEN(@emailOrigem) > 0 BEGIN
	SET @EmailDestinatarios = @emailOrigem + '; ' + @emailDestino

	SET @HtmlHeader = '<HTML><HEADER>
							<STYLE type="text/css">
							.f0 { color:black; font: 12px verdana; }
							.f1 { color:black; font: 12px arial,verdana;}
							.f2 { color:red; font: 12px arial,verdana;}
							td { align-self:center; align-content:center; align-items:center; }
							</STYLE></HEADER>
							<BODY>
							<FONT class="f0">Prezado, departamento <b>' + @ccDestinoDesc + '</b></FONT><BR><BR>
							<FONT class="f1">O departamento <b>' + @ccOrigemDesc + 
									'</b>, está transferindo <b>' + CONVERT(VARCHAR, @horas) +
								 '</b> horas do dia <b>' + CONVERT(VARCHAR, @referencia, 103) + 
								 '</b> para seu departamento.</FONT><BR><BR>
							<FONT class="f1"><B>ATENÇÃO</B><BR>
								A transferência dessa hora tem impacto </FONT>' +
								'<FONT class="f2"><b>NEGATIVO</b></FONT>' +
								'<FONT class="f1"> no seus indicadores de produtividade, mão de obra e custo.<BR><BR>
								Qualquer dúvida procure seu Engenheiro Industrial</FONT>'

	SET @HtmlBody   = @HtmlHeader + @HtmlTable + '<BR>' + @HtmlLegend + '</BODY></HTML>'

	EXEC MSDB.DBO.SP_SEND_DBMAIL 
			@RECIPIENTS = @EmailDestinatarios,
			@SUBJECT = @EmailAssunto,
			@BODY = @HtmlBody,
			@BODY_FORMAT = 'HTML',
			@ATTACH_QUERY_RESULT_AS_FILE = 0;
	END

END
GO
