-- exec sp_contrato_item_consultar 316
CREATE PROCEDURE sp_contrato_item_consultar
(
	@contrato	int
) 
AS begin
SET NOCOUNT ON

DECLARE @valor				numeric(18,2),
		@percentual			numeric(5,2),
		@diferenca			numeric(5,2),
		@idContratoItem		int

/******************************************************************************************/
/*** TABELAS TEMPORÁRIAS ******************************************************************/
/******************************************************************************************/
CREATE TABLE #Importacao 
(
	  id_contrato_item		int				NOT NULL
	, id_cc					int				NOT NULL
	, cd_cc					varchar(20)		NOT NULL
	, nm_cc					varchar(150)	NOT NULL
	, cd_cc_externo			varchar(30)		NOT NULL
	, ds_texto_pedido		varchar(500)	NOT NULL
	, cd_documento_compra	varchar(30)		NOT NULL
	, dt_lancamento			datetime		NOT NULL
	, nr_total_entrada		numeric(10,3)	NOT NULL
	, vl_total_entrada		numeric(18,2)	NOT NULL
	, pc_total_entrada		numeric(5,2)	NOT NULL
)
/******************************************************************************************/

/******************************************************************************************/
/*** CARGA DOS DADOS DOS ITENS DE CONTRATO ************************************************/
/******************************************************************************************/
SELECT @valor = vl_contrato
  FROM tb_contratos c WITH(NOLOCK)
 WHERE id_contrato = @contrato

INSERT INTO #Importacao (id_contrato_item, id_cc, cd_cc, nm_cc, cd_cc_externo,
						 ds_texto_pedido, cd_documento_compra, dt_lancamento,
						 nr_total_entrada, vl_total_entrada, pc_total_entrada)
	SELECT ci.id_contrato_item,
		   ci.id_cc,
		   cc.cd_cc,
		   cc.nm_cc, 
		   ci.cd_cc_externo, 
		   ci.ds_texto_pedido, 
		   ci.cd_documento_compra, 
		   ci.dt_lancamento, 
		   ci.nr_total_entrada, 
		   ci.vl_total_entrada,
		   CONVERT(NUMERIC(18,2), ((ci.vl_total_entrada * 100) / @valor)) pc_total_entrada
	  FROM tb_contratos_itens ci WITH(NOLOCK)
			INNER JOIN tb_centrocusto cc WITH(NOLOCK)
				ON ci.id_cc = cc.id_cc 
	 WHERE id_contrato = @contrato
/******************************************************************************************/

/******************************************************************************************/
/*** VALIDANDO OS TOTAIS PERCENTUAIS ******************************************************/
/******************************************************************************************/
SELECT @percentual = SUM(pc_total_entrada)
  FROM #Importacao

SET @diferenca = 100 - @percentual

IF @diferenca <> 0 BEGIN
	SET @idContratoItem = (SELECT TOP 1 id_contrato_item FROM #Importacao
							ORDER BY vl_total_entrada DESC)

	UPDATE #Importacao 
	   SET pc_total_entrada = pc_total_entrada + @diferenca
	 WHERE id_contrato_item = @idContratoItem
	END
/******************************************************************************************/

/******************************************************************************************/
/*** RETORNO DE DADOS *********************************************************************/
/******************************************************************************************/
SELECT * FROM #Importacao
/******************************************************************************************/

END
GO
