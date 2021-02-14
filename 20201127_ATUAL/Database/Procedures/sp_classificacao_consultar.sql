-- exec sp_classificacao_consultar 3
CREATE PROCEDURE sp_classificacao_consultar
(
	@classificacao	int
) 
AS begin
SET NOCOUNT ON

/******************************************************************************************/
/*** RETORNO DE DADOS *********************************************************************/
/******************************************************************************************/
IF @classificacao > 0 
	SELECT id_classificacao, nm_classificacao, id_situacao
	  FROM tb_classificacoes
	 WHERE id_situacao = 1
	   AND id_classificacao = @classificacao
ELSE 
	SELECT id_classificacao, nm_classificacao, id_situacao
	  FROM tb_classificacoes
	 WHERE id_situacao = 1
/******************************************************************************************/

END
GO
