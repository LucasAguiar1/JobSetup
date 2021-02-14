
 -- exec sp_relatorio_acompanhamento_mensal 3
CREATE PROCEDURE dbo.sp_relatorio_acompanhamento_mensal
( 
	@periodo		int
) 
AS begin
SET NOCOUNT ON

CREATE TABLE #Mensal
(
id_cc				int NOT NULL, 
id_categoria		int NOT NULL, 
pc_distribuicao		numeric(5,2) NOT NULL, 
qt_horas_pmh_categ	numeric(9,2) NOT NULL,
qt_horas_cmh_categ	numeric(9,2) NOT NULL,
qt_horas_tmh		numeric(9,2) NOT NULL,
qt_horas_pmh		numeric(9,2) NOT NULL,
qt_horas_cmh		numeric(9,2) NOT NULL, 
qt_horas_servicos	numeric(9,2) NOT NULL, 
qt_peso_ajustado	numeric(18,2) NOT NULL
)

INSERT INTO #Mensal
	SELECT ccc.id_cc, ccc.id_categoria, ccc.pc_distribuicao,
		   ISNULL(ccc.qt_horas_pmh, 0) qt_horas_pmh_categ, 
		   ISNULL(ccc.qt_horas_cmh, 0) qt_horas_cmh_categ,
		   ISNULL(ccm.qt_horas_tmh, 0), ISNULL(ccm.qt_horas_pmh, 0), 
		   ISNULL(ccm.qt_horas_cmh, 0), ISNULL(ccm.qt_horas_servicos, 0), 
		   ISNULL(ccm.qt_peso_ajustado, 0)
	  FROM tb_Fechamentos_CentroCusto_Mensal_Categoria ccc WITH(NOLOCK)
			INNER JOIN tb_Fechamentos_CentroCusto_Mensal ccm WITH(NOLOCK)
				ON ccm.id_periodo = ccc.id_periodo AND ccm.id_cc = ccc.id_cc
	 WHERE ccc.id_periodo = @periodo

/********************************************************************************************/
/*** CALCULO DOS VALORES TOTAIS POR CATEGORIA ***********************************************/
/********************************************************************************************/
INSERT INTO #Mensal
	SELECT cc.id_cc, c.id_categoria, 0, 
		   c.qt_horas_pmh_categ, c.qt_horas_cmh_categ,
		   cc.qt_horas_tmh, cc.qt_horas_pmh, 
		   cc.qt_horas_cmh, cc.qt_horas_servicos,
		   cc.qt_peso_ajustado
	  FROM (SELECT SUM(m.qt_horas_tmh) qt_horas_tmh, 
				   SUM(m.qt_horas_pmh) qt_horas_pmh, 
				   SUM(m.qt_horas_cmh) qt_horas_cmh,
				   SUM(m.qt_horas_servicos) qt_horas_servicos,
				   SUM(m.qt_peso_ajustado) qt_peso_ajustado, 
				   0 id_cc
			  FROM (SELECT id_cc, qt_horas_tmh, qt_horas_pmh, qt_horas_cmh,
						   qt_horas_servicos, qt_peso_ajustado
					  FROM #Mensal
					 GROUP BY id_cc, qt_horas_tmh, qt_horas_pmh, qt_horas_cmh,
							  qt_horas_servicos, qt_peso_ajustado) m
			) cc
				INNER JOIN (SELECT SUM(qt_horas_pmh_categ) qt_horas_pmh_categ,
									SUM(qt_horas_cmh_categ) qt_horas_cmh_categ,
									id_categoria, 0 id_cc
							   FROM #Mensal
							  GROUP BY id_categoria) c
					ON cc.id_cc = c.id_cc


/********************************************************************************************/
/*** DADOS PARA GERAÇÃO DO RELATÓRIO ********************************************************/
/********************************************************************************************/
SELECT m.id_cc, cc.cd_cc, (cc.cd_cc + ' - ' + cc.nm_cc) nm_cc, 
	   a.id_area, a.nm_area, c.nr_ordem, m.pc_distribuicao,
	   m.qt_horas_tmh, m.qt_horas_pmh, m.qt_horas_cmh,
       m.qt_horas_servicos, m.qt_peso_ajustado,
	   m.id_categoria, c.nm_categoria,
	   m.qt_horas_pmh_categ, m.qt_horas_cmh_categ
  FROM #Mensal m
		LEFT JOIN tb_centrocusto cc WITH(NOLOCK)
			ON cc.id_cc = m.id_cc
		LEFT JOIN tb_Categorias c WITH(NOLOCK)
			ON c.id_categoria = m.id_categoria
		LEFT JOIN tb_Areas a WITH(NOLOCK)
			ON a.id_area = cc.id_area
 ORDER BY a.nm_area, cc.nm_cc, c.nr_ordem

DROP TABLE #Mensal

END
GO
