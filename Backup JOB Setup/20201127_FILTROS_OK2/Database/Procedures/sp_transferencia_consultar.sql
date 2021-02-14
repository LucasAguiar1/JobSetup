/*
exec sp_transferencia_consultar 3
*/
CREATE PROCEDURE dbo.sp_transferencia_consultar
( 
	@periodoRecurso	int
)
AS begin
SET NOCOUNT ON

SELECT rt.id_recurso_transferencia, rt.id_periodo_recurso,
       rt.dt_referencia, rt.qt_horas, 
	   rt.id_cc, cc.nm_cc, cc.cd_cc,
	   rt.id_funcao, f.nm_funcao, f.cd_operacao,
	   rt.id_situacao
  FROM dbo.tb_Recursos_Transferencias rt
		INNER JOIN [dbo].[tb_CentroCusto] cc
			ON rt.id_cc = cc.id_cc
		INNER JOIN [dbo].[tb_Funcoes] f
			ON rt.id_funcao = f.id_funcao
 WHERE rt.id_periodo_recurso = @periodoRecurso
 ORDER BY rt.dt_referencia

END
GO









