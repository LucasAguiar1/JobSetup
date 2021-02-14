
-- exec sp_periodo_consultar 3 
CREATE PROCEDURE sp_periodo_consultar
(
	@periodo	int = 0
) 

AS begin
SET NOCOUNT ON

SELECT p.id_periodo, p.dt_competencia, p.dt_inicio, p.dt_fim, p.nr_dia_bridge, p.vl_peso_ajustado, p.id_situacao, s.nm_situacao
  FROM tb_periodos p
		INNER JOIN tb_situacoes s
			ON p.id_situacao = s.id_situacao
 WHERE p.id_situacao IN (3,5)
   AND (p.id_periodo = @periodo or @periodo = 0)
 ORDER BY p.dt_competencia DESC

END
GO




