-- exec sp_centrocusto_consultar 0, 0, 0, '', '', 'RADM'
CREATE PROCEDURE sp_centrocusto_consultar
(
	@centroCusto	int = 0,
	@area			int = 0,
	@tipo			int = 0,
	@codigo			varchar(50) = '',
	@nome			varchar(50) = '',
	@usuario		varchar(50) = ''
)
AS begin
SET NOCOUNT ON

DECLARE @query	varchar(2000)

SET @query = 
	'SELECT cc.id_cc, cc.cd_cc, cc.cd_sap, cc.nm_cc, 
		   cc.id_area, a.nm_area,
		   cc.id_tipo, t.nm_tipo,
		   ISNULL(cc.ds_usuario_lider, '''') ds_usuario_lider, 
		   ISNULL(cc.ds_lista_email, '''') ds_lista_email,
		   cc.id_situacao
	  FROM tb_centrocusto cc WITH(NOLOCK)
			INNER JOIN tb_areas a WITH(NOLOCK)
					ON a.id_area = cc.id_area
			INNER JOIN tb_tipos t WITH(NOLOCK)
					ON t.id_tipo = cc.id_tipo
	 WHERE cc.id_situacao = 1'

IF @centroCusto > 0
	SET @query = @query + ' AND cc.id_cc = ' + CONVERT(VARCHAR, @centroCusto)

IF @area > 0
	SET @query = @query + ' AND cc.id_area = ' + CONVERT(VARCHAR, @area)

IF @tipo > 0
	SET @query = @query + ' AND cc.id_tipo = ' + CONVERT(VARCHAR, @tipo)

IF LEN(@codigo) > 0
	SET @query = @query + ' AND cc.cd_cc = ''' + @codigo + ''''

IF LEN(@nome) > 0
	SET @query = @query + ' AND cc.nm_cc LIKE ''%' + @nome + '%'''

IF LEN(@usuario) > 0
	SET @query = @query + ' AND cc.ds_usuario_lider LIKE ''%' + @usuario + '%'''

SET @query = @query + ' ORDER BY cc.nm_cc'

PRINT @query

/******************************************************************************************/
/*** RETORNO DE DADOS *********************************************************************/
/******************************************************************************************/
EXEC (@query)
/******************************************************************************************/

END
GO






