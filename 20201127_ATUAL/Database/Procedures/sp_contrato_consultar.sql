-- exec sp_contrato_consultar 3, 324, ''
CREATE PROCEDURE sp_contrato_consultar
(
	@periodo	int,
	@contrato	int = 0,
	@filtro		varchar(100) = ''
) 
AS begin
SET NOCOUNT ON

IF LEN(@filtro) > 0 BEGIN
	SET @filtro = '%' + @filtro + '%'
	END

SELECT c.id_contrato, 
		c.id_periodo, 
		c.nr_contrato, 
		c.dt_contrato, 
		c.ds_contrato, 
		c.vl_contrato, 
		c.dv_conferido, 
		c.nm_arquivo_importacao, 
		c.id_situacao, 
		p.dt_competencia
  FROM tb_contratos c with(nolock)
		INNER JOIN tb_periodos p with(nolock)
			ON p.id_periodo = c.id_periodo
 WHERE c.id_situacao = 1
   and c.id_periodo = @periodo
   and (c.nr_contrato like @filtro
     or c.ds_contrato like @filtro
	 or @filtro = '')
   and (c.id_contrato = @contrato or @contrato = 0)
 ORDER BY c.dv_conferido, 
          c.nr_contrato

END
GO
