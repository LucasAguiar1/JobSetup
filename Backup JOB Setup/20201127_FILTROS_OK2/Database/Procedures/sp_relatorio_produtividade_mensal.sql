
-- exec sp_relatorio_produtividade_mensal 1
CREATE PROCEDURE dbo.sp_relatorio_produtividade_mensal
( 
	@periodo		int
) 
AS begin
SET NOCOUNT ON

CREATE TABLE #Mensal
(
id_cc				int				not null,
id_tipo				int				not null,
qt_horas_tmh		numeric(9,2)	not null,
qt_horas_pmh		numeric(9,2)	not null,
qt_horas_cmh		numeric(9,2)	not null,
qt_horas_servicos	numeric(9,2)	not null,
qt_peso_ajustado	numeric(18,2)	not null,
qt_horas_cedidas	numeric(9,2)	not null,
qt_horas_recebidas	numeric(9,2)	not null,
qt_horas_excecoes	numeric(9,2)	not null
)

INSERT INTO #Mensal (id_cc, id_tipo, qt_horas_tmh, qt_horas_pmh, qt_horas_cmh, 
					 qt_horas_servicos, qt_peso_ajustado, qt_horas_cedidas,
					 qt_horas_recebidas, qt_horas_excecoes)
	SELECT ccm.id_cc,
		   ccm.id_tipo,
		   ccm.qt_horas_tmh, ccm.qt_horas_pmh, ccm.qt_horas_cmh,
		   ccm.qt_horas_servicos, ccm.qt_peso_ajustado, 
		   ccm.qt_horas_cedidas, ccm.qt_horas_recebidas, ccm.qt_horas_excecoes
	  FROM tb_Fechamentos_CentroCusto_Mensal ccm
	 WHERE id_periodo = @periodo

SELECT m.id_cc, cc.cd_cc, cc.nm_cc,
	   m.id_tipo, t.nm_tipo,
	   m.qt_horas_tmh, m.qt_horas_pmh, 
	   m.qt_horas_cmh, m.qt_horas_servicos, 
	   m.qt_peso_ajustado, m.qt_horas_cedidas,
	   m.qt_horas_recebidas, m.qt_horas_excecoes,
	   convert(numeric(9,2), (case when m.qt_horas_tmh > 0 then (m.qt_peso_ajustado / m.qt_horas_tmh) else 0 end)) nr_tmh, 
	   convert(numeric(9,2), (case when m.qt_horas_pmh > 0 then (m.qt_peso_ajustado / m.qt_horas_pmh) else 0 end)) nr_pmh, 
       convert(numeric(9,2), (case when m.qt_horas_cmh > 0 then (m.qt_peso_ajustado / m.qt_horas_cmh) else 0 end)) nr_cmh
  FROM #Mensal m
		INNER JOIN tb_centrocusto cc WITH(NOLOCK)
			ON cc.id_cc = m.id_cc
		INNER JOIN tb_tipos t WITH(NOLOCK)
			ON t.id_tipo = m.id_tipo

DROP TABLE #Mensal

END
GO

