-- exec sp_contrato_rateio_excluir 25, ''
CREATE PROCEDURE sp_contrato_rateio_excluir
(
	@contrato_funcao	int,
	@usuario			varchar(50)
) 
AS BEGIN
SET NOCOUNT ON

DECLARE @descricao  VARCHAR(1000),
		@nrContrato VARCHAR(30),
		@funcao	    INT,
		@contrato   INT

SELECT @descricao = ('idContrato:' + convert(varchar, cf.id_contrato) + 
						', nrContrato: ' + c.nr_contrato + 
						', idFuncao: ' + convert(varchar, cf.id_funcao) + 
						', idClassif: ' + convert(varchar, isnull(cf.id_classificacao, 0)) + 
						', percentual: ' + convert(varchar, cf.vl_percentual) + 
						', rateio: ' + convert(varchar, cf.vl_rateio)),
		@nrContrato = c.nr_contrato,
		@funcao = cf.id_funcao,
		@contrato = c.id_contrato
  FROM tb_contratos_funcoes cf
		INNER JOIN tb_contratos c
			ON cf.id_contrato =  c.id_contrato
 WHERE cf.id_contrato_funcao = @contrato_funcao
	
DELETE tb_contratos_funcoes WHERE id_contrato_funcao = @contrato_funcao

DELETE tb_Contratos_Rateio_Funcoes 
 WHERE nr_contrato = @nrContrato
   AND id_funcao = @funcao

UPDATE tb_contratos SET dv_conferido = 0 WHERE id_contrato = @contrato

-- Gravação do Log de Processos
EXEC dbo.sp_log_processo_incluir 'Contratos_Funcoes', 'EXC', @contrato_funcao, @usuario, @descricao

END
GO
