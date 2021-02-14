
-- exec sp_recurso_consultar 5, 0, 0, '', '', '', 0, 0, ''
CREATE PROCEDURE dbo.sp_recurso_consultar
( 
	@periodo		int,
	@centroCusto	int = 0,
	@funcao			int = 0,
	@cargo			varchar(100) = '',
	@rl				varchar(10) = '',
	@nome			varchar(100) = '',
	@experiencia	int = 0,
	@calculoRemover int = 0,
	@usuario		varchar(50) = ''
)
AS begin
SET NOCOUNT ON

DECLARE @query	varchar(2000)

SET @query = 
	'SELECT pr.id_periodo_recurso,
	        r.id_recurso,
			r.cd_rl, 
			r.nm_recurso, 
			r.qt_dias_experiencia,
			pr.dv_calculo_remover, 
			r.ds_rh_status, 
			r.ds_rh_regime_trabalho, 
			r.ds_rh_cargo,
			ISNULL(r.ds_escala, '''') ds_escala, 
			r.dt_entrada, 
			pr.qt_horas_trabalhadas,
			pr.qt_horas_excecoes,
			pr.qt_horas_transferidas,
			pr.id_cc, 
			cc.cd_cc,
			cc.nm_cc,
			a.nm_area,
			ISNULL(pr.id_funcao, 0) id_funcao,
			ISNULL(f.cd_operacao, '''') cd_operacao, 
			ISNULL(f.nm_funcao, '''') nm_funcao,
			ISNULL(c.nm_classificacao, '''') nm_classificacao,
			r.id_situacao,
			p.dt_competencia,
			(CASE WHEN f.dv_participa_pmh = 1 AND f.dv_participa_cmh = 1 
				THEN ''P-C'' 
				ELSE (CASE WHEN f.dv_participa_pmh = 1 
						THEN ''P'' 
						ELSE (CASE WHEN f.dv_participa_cmh = 1 
								THEN ''C'' 
								ELSE ''''
							END)
					END)
			END) ds_relatorios
	  FROM tb_Periodos_Recursos pr with(nolock) 
			INNER JOIN tb_Periodos p with(nolock)
				ON pr.id_periodo = p.id_periodo
			INNER JOIN tb_Recursos r with(nolock)
				ON pr.id_recurso = r.id_recurso
			INNER JOIN tb_CentroCusto cc with(nolock)
				ON pr.id_cc = cc.id_cc
			INNER JOIN tb_Areas a with(nolock)
				ON a.id_area = cc.id_area
			LEFT JOIN tb_Funcoes f with(nolock)
				ON pr.id_funcao = f.id_funcao
			LEFT JOIN tb_Classificacoes c with(nolock)
				ON c.id_classificacao = f.id_classificacao 
	 WHERE pr.id_periodo = ' + CONVERT(VARCHAR, @periodo)

IF @centroCusto > 0
	SET @query = @query + ' AND pr.id_cc = ' + CONVERT(VARCHAR, @centroCusto)

IF @funcao > 0
	SET @query = @query + ' AND pr.id_funcao = ' + CONVERT(VARCHAR, @funcao)

IF LEN(@cargo) > 0
	SET @query = @query + ' AND r.ds_rh_cargo like ''%' + @cargo + '%'''

IF LEN(@rl) > 0
	SET @query = @query + ' AND r.cd_rl like ''%' + @rl + '%'''

IF LEN(@nome) > 0
	SET @query = @query + ' AND r.nm_recurso like ''%' + @nome + '%'''

IF LEN(@usuario) > 0
	SET @query = @query + ' AND cc.ds_usuario_lider like ''%' + @usuario + '%'''

IF @experiencia = 1
	SET @query = @query + ' AND r.qt_dias_experiencia > 0'
ELSE IF @experiencia = 2
	SET @query = @query + ' AND r.qt_dias_experiencia = 0'

IF @calculoRemover = 1
	SET @query = @query + ' AND pr.dv_calculo_remover = 1'
ELSE IF @calculoRemover = 2
	SET @query = @query + ' AND pr.dv_calculo_remover = 0'

EXEC (@query)

END
GO




