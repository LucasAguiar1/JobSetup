-- exec sp_contrato_funcao_consultar 1
CREATE PROCEDURE sp_contrato_funcao_consultar
(
	@contrato	int
) 
AS begin
SET NOCOUNT ON

/******************************************************************************************/
/*** RETORNO DE DADOS *********************************************************************/
/******************************************************************************************/
SELECT cf.id_contrato_funcao, cf.id_contrato, cf.id_funcao, cf.vl_percentual, cf.vl_rateio, 
	   cf.id_situacao, f.cd_operacao, f.nm_funcao, f.id_classificacao, cl.nm_classificacao,
	   ISNULL(cf.id_classificacao, 0) id_reclassificacao, 
	   ISNULL(rcl.nm_classificacao, '') nm_reclassificacao
  FROM tb_contratos_funcoes cf WITH(NOLOCK)
		INNER JOIN tb_funcoes f WITH(NOLOCK)
			ON cf.id_funcao = f.id_funcao
		INNER JOIN tb_classificacoes cl WITH(NOLOCK)
			ON f.id_classificacao = cl.id_classificacao
		LEFT JOIN tb_classificacoes rcl WITH(NOLOCK)
			ON cf.id_classificacao = rcl.id_classificacao
 WHERE cf.id_contrato = @contrato
/******************************************************************************************/

--SELECT * FROM tb_log_processos


END
GO
