-- exec sp_funcao_centrocusto_consultar 21
CREATE PROCEDURE sp_funcao_centrocusto_consultar
(
	@funcao		int = 0
)
AS begin
SET NOCOUNT ON

SELECT cc.id_cc, cc.cd_cc, cc.cd_sap, cc.nm_cc, 
		a.nm_area, t.nm_tipo,
		ISNULL(fcc.id_funcao_cc, 0) id_funcao_cc
  FROM tb_centrocusto cc WITH(NOLOCK)
		INNER JOIN tb_areas a WITH(NOLOCK)
				ON a.id_area = cc.id_area
		INNER JOIN tb_tipos t WITH(NOLOCK)
				ON t.id_tipo = cc.id_tipo
		LEFT JOIN tb_funcoes_centrocusto fcc WITH(NOLOCK)
			ON fcc.id_cc = cc.id_cc 
		   AND fcc.id_funcao = @funcao
 WHERE cc.id_situacao = 1
 ORDER BY ISNULL(fcc.id_situacao, 0) desc, cc.cd_cc, cc.nm_cc

END
GO






