/*
exec sp_excecao_consultar 3
*/
CREATE PROCEDURE dbo.sp_excecao_consultar
( 
	@periodoRecurso	int
)
AS begin
SET NOCOUNT ON

SELECT re.id_recurso_excecao, re.id_periodo_recurso,
       re.dt_referencia, re.qt_horas, 
	   re.id_motivo, m.DS_motivo, 
	   re.id_situacao
  FROM [dbo].[tb_Recursos_Excecoes] re
		INNER JOIN [dbo].[tb_motivos] m
			ON re.id_motivo = m.id_motivo
 WHERE re.id_periodo_recurso = @periodoRecurso
 ORDER BY re.dt_referencia

END
GO




