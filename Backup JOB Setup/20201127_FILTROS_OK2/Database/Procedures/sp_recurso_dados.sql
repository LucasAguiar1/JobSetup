/*
exec sp_recurso_dados 3, 3
*/
CREATE PROCEDURE dbo.sp_recurso_dados
( 
	@periodo		int,
	@recurso	    int
)
AS begin
SET NOCOUNT ON

SELECT pr.id_periodo_recurso,
	    r.id_recurso,
		r.cd_rl, 
		r.nm_recurso, 
		r.qt_dias_experiencia,		-- [EXPERIENCIA (>0 experiencia =0 apto)]
		r.dv_calculo_remover, 
		r.ds_rh_status, 
		r.ds_rh_regime_trabalho, 
		r.ds_rh_cargo, 
		r.dt_entrada, 
		pr.qt_horas_trabalhadas,
		pr.qt_horas_excecoes,
		pr.qt_horas_transferidas,
		r.id_cc, 
		cc.cd_cc,
		cc.nm_cc,
		a.nm_area,
		r.id_funcao,
		f.cd_operacao, 
		f.nm_funcao,
		c.nm_classificacao,
		r.id_situacao,
		p.dt_competencia,
		'P-C' ds_relatorios
	FROM tb_Periodos_Recursos pr with(nolock) 
		INNER JOIN tb_Periodos p with(nolock)
			ON pr.id_periodo = p.id_periodo
		INNER JOIN tb_Recursos r with(nolock)
			ON pr.id_recurso = r.id_recurso
		INNER JOIN tb_CentroCusto cc with(nolock)
			ON r.id_cc = cc.id_cc
		INNER JOIN tb_Areas a with(nolock)
			ON a.id_area = cc.id_area
		INNER JOIN tb_Funcoes f with(nolock)
			ON r.id_funcao = f.id_funcao
		INNER JOIN tb_Classificacoes c with(nolock)
			ON c.id_classificacao = f.id_classificacao 
	WHERE pr.id_periodo = @periodo
	  AND r.id_recurso = @recurso


END
GO




