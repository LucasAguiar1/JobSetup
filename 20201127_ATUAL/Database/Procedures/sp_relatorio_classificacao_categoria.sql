
-- exec sp_relatorio_classificacao_categoria 2019, 2
CREATE PROCEDURE sp_relatorio_classificacao_categoria
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
		   ct.id_categoria, ct.nm_categoria,
		   c.id_classificacao, c.nm_classificacao,
		   fcc.nr_recursos, fcc.qt_horas_tmh, 
		   fcc.qt_horas_pmh, fcc.qt_horas_cmh
	  FROM tb_Fechamentos_Classificacao_Categoria fcc
			INNER JOIN tb_Categorias ct WITH(NOLOCK)
				ON ct.id_categoria = fcc.id_categoria
			INNER JOIN tb_Classificacoes c WITH(NOLOCK)
				ON c.id_classificacao = fcc.id_classificacao
			INNER JOIN tb_Periodos p WITH(NOLOCK)
				ON p.id_periodo = fcc.id_periodo
	 WHERE p.id_periodo = @periodo
	END

END
GO

