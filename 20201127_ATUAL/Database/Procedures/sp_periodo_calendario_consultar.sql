
-- exec sp_periodo_calendario_consultar 3 
CREATE PROCEDURE sp_periodo_calendario_consultar
(
	@periodo	int = 0
) 
AS begin
SET NOCOUNT ON

SELECT c.id_calendario, c.dt_referencia, 
	   c.id_periodo, c.id_ignorar_producao, 
	   ISNULL(c.ds_ignorar_motivo, '') ds_ignorar_motivo, 
	   isnull(c.hr_inicio, '') hr_inicio, 
	   isnull(c.hr_fim, '') hr_fim, 
	   ISNULL(c.nr_horas_ajuste, 0) nr_horas_ajuste,
	   c.id_situacao, s.nm_situacao
  FROM [dbo].[tb_Calendarios] c
		INNER JOIN tb_situacoes s
			ON c.id_situacao = s.id_situacao
 WHERE c.id_situacao = 1
   AND c.id_periodo = @periodo
 ORDER BY c.dt_referencia

END
GO