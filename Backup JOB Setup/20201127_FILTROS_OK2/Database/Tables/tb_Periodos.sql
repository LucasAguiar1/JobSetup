
CREATE TABLE dbo.tb_Periodos(
	  id_periodo					int			NOT NULL	IDENTITY PRIMARY KEY
	, dt_competencia				datetime	NOT NULL
	, dt_inicio						datetime	NOT NULL
	, dt_fim						datetime	NOT NULL
	, nr_dia_bridge					numeric(7,5)	NOT NULL
	, vl_peso_ajustado				numeric(18,8)	NOT NULL
	, id_situacao					int			NOT NULL	REFERENCES dbo.tb_Situacoes
	, CONSTRAINT UC_Periodos				
		 UNIQUE (dt_competencia)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave primária do período', 'user', dbo, 'table', 'tb_Periodos', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'competência do período', 'user', dbo, 'table', 'tb_Periodos', 'column', 'dt_competencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de Início da vigência do período', 'user', dbo, 'table', 'tb_Periodos', 'column', 'dt_inicio'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data Final da vigência do período', 'user', dbo, 'table', 'tb_Periodos', 'column', 'dt_fim'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor de dias bridgestone válidos para cálculo', 'user', dbo, 'table', 'tb_Periodos', 'column', 'nr_dia_bridge'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor de referência do peso ajustado da produção', 'user', dbo, 'table', 'tb_Periodos', 'column', 'vl_peso_ajustado'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica do período', 'user', dbo, 'table', 'tb_Periodos', 'column', 'id_situacao'
GO

