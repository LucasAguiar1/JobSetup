
CREATE TABLE dbo.tb_Fechamentos_CentroCusto_Mensal
(
	  id_periodo			int			  NOT NULL	REFERENCES dbo.tb_Periodos
	, id_cc					int			  NOT NULL	REFERENCES dbo.tb_CentroCusto
	, id_tipo				int			  NOT NULL	REFERENCES dbo.tb_Tipos
	, qt_horas_tmh			numeric(9,2)  NOT NULL
	, qt_horas_pmh			numeric(9,2)  NOT NULL
	, qt_horas_cmh			numeric(9,2)  NOT NULL
	, qt_horas_servicos		numeric(9,2)  NOT NULL
	, qt_peso_ajustado		numeric(18,2) NOT NULL
	, qt_horas_cedidas		numeric(9,2)  NOT NULL
	, qt_horas_recebidas	numeric(9,2)  NOT NULL
	, qt_horas_excecoes		numeric(9,2)  NOT NULL
	, CONSTRAINT UC_Fechamentos_CentroCusto_Mensal
		 UNIQUE (id_periodo, id_cc)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do Centro de Custo', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do Tipo de Centro de Custo', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'id_tipo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas TMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_horas_tmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas PMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_horas_pmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas CMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_horas_cmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas dos serviços', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_horas_servicos'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Peso ajustado em libras', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_peso_ajustado'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas cedidas', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_horas_cedidas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas recebidas ', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_horas_recebidas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas de exceção', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal', 'column', 'qt_horas_excecoes'