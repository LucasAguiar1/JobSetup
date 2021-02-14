
-- exec sp_centrocusto_categoria_consultar 2
CREATE PROCEDURE sp_centrocusto_categoria_consultar
(
	@centroCusto	int
)
AS begin
SET NOCOUNT ON

SELECT isnull(ccc.id_centroCusto_categoria, 0) id_centroCusto_categoria, 
		@centroCusto id_cc, 
		c.id_categoria, 
		ISNULL(ccc.pc_distribuicao, 0) pc_distribuicao,
		c.nm_categoria,
		c.nm_grupo
  FROM tb_Categorias c
		LEFT JOIN tb_CentroCusto_Categorias ccc
			ON ccc.id_categoria = c.id_categoria
		   AND ccc.id_cc = @centroCusto
 ORDER BY c.nr_ordem

END
GO
