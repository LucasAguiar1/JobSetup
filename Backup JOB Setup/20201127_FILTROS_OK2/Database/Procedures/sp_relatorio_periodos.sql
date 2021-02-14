
-- exec sp_relatorio_periodos
CREATE PROCEDURE dbo.sp_relatorio_periodos
AS begin
SET NOCOUNT ON
SET LANGUAGE Portuguese

SELECT id_periodo, 
		convert(varchar, year(dt_competencia)) + ' ' + UPPER(SUBSTRING(DATENAME(month, dt_competencia), 1, 3)) nm_periodo
  FROM tb_Periodos
 ORDER BY dt_competencia DESC

END
GO



