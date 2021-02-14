
-- exec sp_tipo_consultar
CREATE PROCEDURE dbo.sp_tipo_consultar
AS begin
SET NOCOUNT ON

SELECT id_tipo, nm_tipo
  FROM tb_Tipos
 WHERE id_situacao = 1
 ORDER BY nm_tipo

END
GO






