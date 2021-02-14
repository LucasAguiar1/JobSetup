
-- exec sp_funcao_consultar 0, 0, 0, 0, 0, '', ''
CREATE PROCEDURE sp_funcao_consultar
(
	@funcao			int = 0,
	@classificacao	int = 0,
	@participaPpmh	int = 0,
	@participaPcmh	int = 0,
	@centroCusto	int = 0,
	@codigo			varchar(50) = '',
	@nome			varchar(150) = ''
) 
AS begin
SET NOCOUNT ON

DECLARE @query	varchar(4000)

SET @query =
	'SELECT f.id_funcao, f.cd_operacao, f.nm_funcao, f.id_classificacao, f.id_situacao,
		   f.dv_participa_pmh, f.dv_participa_cmh, f.dv_contabiliza_separado, 
		   c.nm_classificacao, ISNULL(f.vl_hora_servico, 0) vl_hora_servico
	  FROM tb_funcoes f WITH(NOLOCK)
			INNER JOIN tb_Classificacoes c WITH(NOLOCK)
				ON f.id_classificacao = c.id_classificacao'

IF @centroCusto > 0
	SET @query = @query + ' INNER JOIN tb_Funcoes_CentroCusto fcc WITH(NOLOCK) ON f.id_funcao = fcc.id_funcao'

SET @query = @query + ' WHERE f.id_situacao = 1'

IF @funcao > 0
	SET @query = @query + ' AND f.id_funcao = ' + CONVERT(VARCHAR, @funcao)

IF @classificacao > 0
	SET @query = @query + ' AND f.id_classificacao = ' + CONVERT(VARCHAR, @classificacao)

IF @centroCusto > 0
	SET @query = @query + ' AND fcc.id_cc = ' + CONVERT(VARCHAR, @centroCusto)

IF @participaPpmh > 0 BEGIN
	IF @participaPpmh = 1
		SET @query = @query + ' AND f.dv_participa_pmh = 1'
	ELSE 
		SET @query = @query + ' AND f.dv_participa_pmh = 0'
	END

IF @participaPcmh > 0 BEGIN
	IF @participaPcmh = 1
		SET @query = @query + ' AND f.dv_participa_cmh = 1'
	ELSE 
		SET @query = @query + ' AND f.dv_participa_cmh = 0'
	END

IF LEN(@codigo) > 0
	SET @query = @query + ' AND f.cd_operacao = ''' + @codigo + ''''

IF LEN(@nome) > 0
	SET @query = @query + ' AND f.nm_funcao LIKE ''%' + @nome + '%'''

SET @query = @query + ' ORDER BY f.nm_funcao'

EXEC(@query)

END
GO




