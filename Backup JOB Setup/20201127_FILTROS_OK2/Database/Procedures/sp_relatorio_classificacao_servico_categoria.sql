
-- exec sp_relatorio_classificacao_servico_categoria 2019, 2
CREATE PROCEDURE sp_relatorio_classificacao_servico_categoria
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
		   c.id_categoria, c.nm_categoria,
		   fcsc.qt_horas
	  FROM tb_Fechamentos_Classificacao_Servico_Categoria fcsc
			INNER JOIN tb_CentroCusto cc WITH(NOLOCK)
				ON cc.id_cc = fcsc.id_cc
			INNER JOIN tb_Categorias c WITH(NOLOCK)
				ON c.id_categoria = fcsc.id_categoria
			INNER JOIN tb_Periodos p WITH(NOLOCK)
				ON p.id_periodo = fcsc.id_periodo
	 WHERE p.id_periodo = @periodo
	END

END
GO

