
/*
declare @retorno varchar(200)
exec sp_funcao_centrocusto_alterar 1, '7, 9, 10, 11, 13, 14, 15, 16, 17, ', 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE dbo.sp_funcao_centrocusto_alterar
(
	@funcao		int,
	@listaCC	varchar(1000),
	@usuario	varchar(50),
	@mensagem	varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

SET @mensagem = ''

CREATE TABLE #lista (id_cc	INT NOT NULL, dv_incluir bit NOT NULL)
CREATE TABLE #atual (id_cc	INT NOT NULL, dv_remover bit NOT NULL)

INSERT INTO #atual (id_cc, dv_remover)
	SELECT id_cc, 0
	  FROM tb_Funcoes_CentroCusto WITH(NOLOCK)
	 WHERE id_funcao = @funcao
	   AND id_situacao = 1

INSERT INTO #lista (id_cc, dv_incluir)
	SELECT CONVERT(INT, item), 0 
	  FROM (SELECT item FROM dbo.fc_Split(@listaCC, ',')) a
	 WHERE len(item) > 0

-- Centros de Custo INCLUÍDOS
UPDATE #lista 
   SET dv_incluir = 1
 WHERE id_cc NOT IN (SELECT id_cc FROM #atual)

INSERT INTO tb_Funcoes_CentroCusto (id_funcao, id_cc, id_situacao)
	SELECT @funcao, id_cc, 1 FROM #lista WHERE dv_incluir = 1


-- Centros de Custo REMOVIDOS
UPDATE #atual
   SET dv_remover = 1
 WHERE id_cc NOT IN (SELECT id_cc FROM #lista)

DELETE tb_Funcoes_CentroCusto
 WHERE id_funcao = @funcao
   AND id_cc IN (SELECT id_cc FROM #atual WHERE dv_remover = 1)

EXEC dbo.sp_log_processo_incluir 'Funcao_CC', 'UPD', @funcao, @usuario, @listaCC

DROP TABLE #lista
DROP TABLE #atual

END
GO




