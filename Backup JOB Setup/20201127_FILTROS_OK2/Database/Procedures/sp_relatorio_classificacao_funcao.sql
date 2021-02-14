
-- exec sp_relatorio_classificacao_funcao 2019, 2
CREATE PROCEDURE sp_relatorio_classificacao_funcao
( 
	@ano		int,
	@mes		int
) 
AS begin
DECLARE @periodo		INT = 0,
	    @competencia	DATE

SET @competencia = CONVERT(DATE, CONVERT(VARCHAR, @ano) + '-' + CONVERT(VARCHAR, @mes) + '-01')

SELECT @periodo = id_periodo 
  FROM tb_periodos 
 WHERE dt_competencia = @competencia

IF @periodo > 0 BEGIN
	SELECT p.id_periodo, p.dt_competencia,
		   f.id_funcao, f.cd_operacao, f.nm_funcao,
		   c.id_classificacao, c.nm_classificacao,
		   fcf.nr_recursos, fcf.qt_horas_tmh, 
		   fcf.qt_horas_pmh, fcf.qt_horas_cmh
	  FROM tb_Fechamentos_Classificacao_Funcao fcf
			INNER JOIN tb_Funcoes f WITH(NOLOCK)
				ON f.id_funcao = fcf.id_funcao
			INNER JOIN tb_Classificacoes c WITH(NOLOCK)
				ON c.id_classificacao = fcf.id_classificacao
			INNER JOIN tb_Periodos p WITH(NOLOCK)
				ON p.id_periodo = fcf.id_periodo
	 WHERE p.id_periodo = @periodo
	END

END
GO

