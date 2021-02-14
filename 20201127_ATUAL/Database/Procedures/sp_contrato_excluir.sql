-- exec sp_contrato_excluir 1
-- SELECT * FROM tb_contratos
CREATE PROCEDURE sp_contrato_excluir
(
	@contrato	int
) 
AS BEGIN
SET NOCOUNT ON

DECLARE @periodo  int = 0,
		@situacao int = 0

SELECT @periodo = c.id_periodo,
	   @situacao = p.id_situacao
  FROM tb_contratos c with(nolock)
		INNER JOIN tb_periodos p with(nolock)
			ON c.id_periodo = p.id_periodo
 WHERE id_contrato = @contrato

IF @situacao = 3 BEGIN
	DELETE tb_Contratos_Funcoes WHERE id_contrato = @contrato
	DELETE tb_Contratos_Itens WHERE id_contrato = @contrato
	DELETE tb_Contratos WHERE id_contrato = @contrato
	END

END
GO




