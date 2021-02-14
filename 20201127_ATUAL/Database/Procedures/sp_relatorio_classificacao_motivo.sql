
 -- exec sp_relatorio_classificacao_motivo 2019, 2
 CREATE PROCEDURE sp_relatorio_classificacao_motivo
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
		   m.id_motivo, m.ds_motivo, 
		   c.id_classificacao, c.nm_classificacao,
		   fcm.nr_recursos, fcm.qt_horas
	  FROM tb_Fechamentos_Classificacao_Motivo fcm
			INNER JOIN tb_Motivos m WITH(NOLOCK)
				ON m.id_motivo = fcm.id_motivo
			INNER JOIN tb_Classificacoes c WITH(NOLOCK)
				ON c.id_classificacao = fcm.id_classificacao
			INNER JOIN tb_Periodos p WITH(NOLOCK)
				ON p.id_periodo = fcm.id_periodo
	 WHERE p.id_periodo = @periodo
	END

END
GO

