
CREATE TABLE dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria
(
	  id_periodo			int			  NOT NULL	REFERENCES dbo.tb_Periodos
	, id_cc					int			  NOT NULL	REFERENCES dbo.tb_CentroCusto
	, id_categoria			int			  NOT NULL	REFERENCES dbo.tb_Categorias
	, pc_distribuicao		numeric(5, 2) NOT NULL  
	, qt_horas_tmh			numeric(9,2)  NOT NULL
	, qt_horas_pmh			numeric(9,2)  NOT NULL
	, qt_horas_cmh			numeric(9,2)  NOT NULL
	, CONSTRAINT UC_Fechamentos_CentroCusto_Mensal_Categoria
		 UNIQUE (id_periodo, id_cc, id_categoria)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal_Categoria', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do Centro de Custo', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal_Categoria', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador da Categoria', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal_Categoria', 'column', 'id_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Percentual de distribuição realizado', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal_Categoria', 'column', 'pc_distribuicao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas TMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal_Categoria', 'column', 'qt_horas_tmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas PMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal_Categoria', 'column', 'qt_horas_pmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas CMH', 'user', dbo, 'table', 'tb_Fechamentos_CentroCusto_Mensal_Categoria', 'column', 'qt_horas_cmh'
GO
