
-- exec sp_area_consultar
CREATE PROCEDURE dbo.sp_area_consultar
AS begin
SET NOCOUNT ON

SELECT id_area, nm_area
  FROM tb_Areas
 WHERE id_situacao = 1
 ORDER BY nm_area

END
GO






