
-- exec sp_contrato_rateio_calculo 383
CREATE PROCEDURE dbo.sp_contrato_rateio_calculo
(
	@contrato		int
) 
AS BEGIN
SET NOCOUNT ON

DECLARE @vl_base_diaria		numeric(7,2) = 0,
		@nr_horas_total		numeric(9,2) = 0,
		@vl_contrato		numeric(18,2) = 0,
		@nr_horas_itens		numeric(9,2) = 0,
		@nr_diferenca		numeric(5,2) = 0,
		@contrato_item		int

-- Valor parametrizado de cálculo das horas por dia
SELECT @vl_base_diaria = convert(numeric(7,2), replace(vl_parametro, ',', '.')) FROM tb_parametros WHERE id_parametro = 3

-- Atualização das horas diárias para cada contrato de serviço rateado em funções
UPDATE cf
   SET cf.nr_horas_dia = (cf.vl_rateio / f.vl_hora_servico) / @vl_base_diaria
  FROM tb_contratos_funcoes cf
		INNER JOIN tb_funcoes F
			ON cf.id_funcao = f.id_funcao
 WHERE id_contrato = @contrato

-- Soma das horas calculadas
SELECT @nr_horas_total = SUM(nr_horas_dia)
  FROM tb_contratos_funcoes
 WHERE id_contrato = @contrato

-- Valor total do contrato
SELECT @vl_contrato = vl_contrato
  FROM tb_contratos
 WHERE id_contrato = @contrato

-- Rateio das horas nos centros de custo do contrato
UPDATE ci
   SET ci.nr_horas_dia = ((@nr_horas_total * ci.vl_total_entrada) / @vl_contrato)
  FROM tb_contratos_itens ci
 WHERE ci.id_contrato = @contrato

-- Ajustes de rateio
SELECT @nr_horas_itens = SUM(nr_horas_dia)
  FROM tb_contratos_itens
 WHERE id_contrato = @contrato

SET @nr_diferenca = @nr_horas_itens - @nr_horas_total

IF @nr_diferenca <> 0 BEGIN
	SET @contrato_item =
		(SELECT TOP 1 id_contrato_item
		  FROM tb_contratos_itens
		 WHERE id_contrato = @contrato
		 ORDER BY nr_horas_dia DESC)

	UPDATE tb_contratos_itens
	   SET nr_horas_dia = nr_horas_dia - @nr_diferenca
	 WHERE id_contrato_item = @contrato_item
	END
	
END
GO
