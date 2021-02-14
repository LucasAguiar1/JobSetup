
CREATE TABLE dbo.tb_Fechamentos_CentroCusto_Diario
(
	  id_periodo			int			 NOT NULL	REFERENCES dbo.tb_Periodos
	, dt_referencia			date		 NOT NULL
	, id_cc					int			 NOT NULL	REFERENCES dbo.tb_CentroCusto
	, id_tipo				int			 NOT NULL	REFERENCES dbo.tb_Tipos
	, qt_horas_tmh			numeric(9,2) NOT NULL
	, qt_horas_pmh			numeric(9,2) NOT NULL
	, qt_horas_cmh			numeric(9,2) NOT NULL
	, CONSTRAINT UC_Fechamentos_CentroCusto_Diario
		 UNIQUE (id_periodo, dt_referencia, id_cc)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Diario', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data do resumo de horas', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Diario', 'column', 'dt_referencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do Centro de Custo', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Diario', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do Tipo de Centro de Custo', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Diario', 'column', 'id_tipo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas TMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Diario', 'column', 'qt_horas_tmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas PMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Diario', 'column', 'qt_horas_pmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas CMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Diario', 'column', 'qt_horas_cmh'
GO