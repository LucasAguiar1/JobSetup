
-- exec sp_categoria_consultar 
CREATE PROCEDURE sp_categoria_consultar

AS begin
SET NOCOUNT ON

SELECT id_categoria, nm_categoria, nm_grupo
  FROM tb_categorias
 WHERE id_situacao = 1
 ORDER BY nr_ordem

END
GO




