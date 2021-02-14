
-- exec sp_parametro_consultar 
CREATE PROCEDURE sp_parametro_consultar

AS begin
SET NOCOUNT ON

SELECT p.id_parametro, p.nm_parametro, p.vl_parametro, p.id_tipo
  FROM tb_parametros p
 WHERE p.dv_interno = 0
 ORDER BY p.nm_parametro

END
GO




