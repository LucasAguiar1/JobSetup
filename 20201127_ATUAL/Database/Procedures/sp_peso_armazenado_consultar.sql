
-- exec sp_peso_armazenado_consultar 3, 1, 2
CREATE PROCEDURE sp_peso_armazenado_consultar
(
	@periodo	int,
	@categoria	int = 0,
	@dia		int = 0
) 

AS begin
SET NOCOUNT ON

DECLARE @consulta	VarChar(1000),
		@inicio		Date,
		@fim		Date,
		@referencia	Date = NULL

SELECT @inicio = dt_inicio, 
	   @fim = dt_fim
  FROM tb_periodos
 WHERE id_periodo = @periodo

IF @categoria = 0 SET @categoria = NULL

IF @dia > 0
	SET @referencia = CONVERT(VARCHAR, YEAR(@inicio)) + '-' +  CONVERT(VARCHAR, MONTH(@inicio)) + '-' + CONVERT(VARCHAR, @dia)

SELECT pa.id_pesos_armazenados, pa.id_categoria, pa.dt_referencia,
	   pa.qt_peso_armazenado, c.nm_categoria
  FROM tb_Pesos_Armazenados pa	WITH(NOLOCK)
			INNER JOIN tb_categorias c WITH(NOLOCK)
				ON pa.id_categoria = c.id_categoria
 WHERE pa.dt_referencia BETWEEN @inicio AND @fim
   AND pa.id_categoria = ISNULL(@categoria, pa.id_categoria)
   AND pa.dt_referencia = ISNULL(@referencia, pa.dt_referencia)
 ORDER BY pa.dt_referencia, c.nr_ordem

END
GO
