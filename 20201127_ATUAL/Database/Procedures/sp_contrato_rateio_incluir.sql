/*
begin
declare @mensagem varchar(100) 
exec sp_contrato_rateio_incluir 383, 2, 25, 0, 'radm', @mensagem output
select @mensagem
end
*/
CREATE PROCEDURE sp_contrato_rateio_incluir
(
	@contrato		int,
	@funcao			int, 
	@percentual		numeric(5,2),
	@classificacao	int,
	@usuario		varchar(50),
	@mensagem		varchar(100) output
) 
AS BEGIN
SET NOCOUNT ON

DECLARE @rateio				numeric(18,2) = 0,
		@situacao			int = 1,
		@log				varchar(1000),
		@nrContrato			varchar(30),
		@vlContrato			numeric(18,2),
		@contrato_funcao	int,
		@totalPercentual	numeric(5,2) = 0,
		@totalRateio		numeric(18,2) = 0,
		@valido				bit = 1,
		@diferenca			numeric(5,2) = 0,
		@reclassificacao	int,
		@conferido			bit = 0

SET @mensagem = ''
IF @classificacao > 0 SET @reclassificacao = @classificacao

/*********************************************************************/
/*** BUSCA AS INFORMAÇÕES DE NÚMERO DO CONTRATO E VALOR TOTAL ********/
/*********************************************************************/
SELECT @nrContrato = nr_contrato,
	   @vlContrato = vl_contrato
  FROM tb_contratos
 WHERE id_contrato = @contrato

IF @vlContrato > 0
	SET @rateio = @vlContrato * @percentual / 100

/*********************************************************************/
/*** VALIDAÇÃO SE O TOTAL PERCENTUAL NÃO ULTRAPASSA 100% *************/
/**     E O TOTAL DE RATEIO É IGUAL AO TOTAL DO CONTRATO *************/
/*********************************************************************/
SELECT @totalPercentual = ISNULL(SUM(vl_percentual), 0), 
	   @totalRateio = ISNULL(SUM(vl_rateio), 0)
  FROM tb_contratos_funcoes
 WHERE id_contrato = @contrato

IF (@totalPercentual + @percentual) > 100 BEGIN
	SET @mensagem = 'Percentual total é maior que 100% (máx. ' + replace(convert(varchar, (100 - @totalPercentual)),'.',',') + '%)'
	SET @valido = 0
	END
ELSE BEGIN
	IF EXISTS (SELECT 1 FROM tb_contratos_funcoes WHERE id_contrato = @contrato AND id_funcao = @funcao) BEGIN
		SET @mensagem = 'A função selecionada já tem rateio cadastrado!'
		SET @valido = 0
		END
	ELSE BEGIN
		IF (@totalPercentual + @percentual) = 100 BEGIN
			SET @conferido = 1
			SET @diferenca = @vlContrato - (@totalRateio + @rateio)
	
			IF @diferenca <> 0
				SET @rateio = @rateio + @diferenca
			END
		END
	END
/*********************************************************************/

IF @valido = 1 BEGIN
	/*********************************************************************/
	/*** INSERÇÃO NAS TABELAS DE FUNÇÃO E DE RATEIO PADRÃO ***************/
	/*********************************************************************/
	INSERT INTO tb_contratos_funcoes (id_contrato, id_funcao, vl_percentual, vl_rateio, id_classificacao, id_situacao)
		VALUES (@contrato, @funcao, @percentual, @rateio, @reclassificacao, @situacao)

	SET @contrato_funcao = SCOPE_IDENTITY()

	INSERT INTO tb_Contratos_Rateio_Funcoes (id_funcao, nr_contrato, vl_percentual)
		 VALUES (@funcao, @nrContrato, @percentual)

	/*********************************************************************/
	/*** ATUALIZAÇÃO DO STATUS DE CONFERIDO DO CONTRATO ******************/
	/*********************************************************************/
	IF @conferido = 1 BEGIN
		UPDATE tb_contratos SET dv_conferido = 1 
		 WHERE id_contrato = @contrato

		EXEC dbo.sp_contrato_rateio_calculo @contrato
		END

	/*********************************************************************/
	/*** GRAVAÇÃO DO LOG DE PROCESSOS ************************************/
	/*********************************************************************/
	SET @log = 'idContrato:' + convert(varchar, @contrato) + 
				', idFuncao: ' + convert(varchar,@funcao) + 
				', idClassif: ' + convert(varchar, isnull(@reclassificacao, 0)) + 
				', percentual: ' + convert(varchar, @percentual) + 
				', rateio: ' + convert(varchar, @rateio)

	EXEC dbo.sp_log_processo_incluir 'Contratos_Funcoes', 'INC', @contrato_funcao, @usuario, @log
	END

END
GO
