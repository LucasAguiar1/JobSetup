
 -- exec sp_relatorio_classificacao_centrocusto 2019, 4
 CREATE PROCEDURE sp_relatorio_classificacao_centrocusto
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
		   cc.id_cc, cc.cd_cc, cc.nm_cc, 
		   c.id_classificacao, c.nm_classificacao,
		   fcc.nr_recursos, fcc.qt_horas_tmh, 
		   fcc.qt_horas_pmh, fcc.qt_horas_cmh
	  FROM tb_Fechamentos_Classificacao_CentroCusto fcc
			INNER JOIN tb_CentroCusto cc WITH(NOLOCK)
				ON cc.id_cc = fcc.id_cc
			INNER JOIN tb_Classificacoes c WITH(NOLOCK)
				ON c.id_classificacao = fcc.id_classificacao
			INNER JOIN tb_Periodos p WITH(NOLOCK)
				ON p.id_periodo = fcc.id_periodo
	 WHERE p.id_periodo = @periodo
	END

END
GO

