
CREATE TABLE dbo.tb_Periodos_Recursos(
	  id_periodo_recurso		int			NOT NULL IDENTITY PRIMARY KEY
	, id_periodo				int			NOT NULL REFERENCES tb_Periodos
	, id_recurso				int			NOT NULL REFERENCES tb_Recursos
	, qt_horas_trabalhadas		int			NOT NULL
	, qt_horas_excecoes			int			NOT NULL
	, qt_horas_transferidas		int			NOT NULL
	, id_cc					    int			NULL	 REFERENCES tb_CentroCusto
	, id_funcao					int			NULL	 REFERENCES tb_Funcoes
	, dv_calculo_remover		int			NULL
	, CONSTRAINT UC_Periodos_Recursos				
		 UNIQUE (id_periodo, id_recurso)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave primária', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'id_periodo_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do periodo', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do recurso', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'id_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número de horas trabalhadas', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'qt_horas_trabalhadas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número de horas de exceção', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'qt_horas_excecoes'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número de horas transferidas', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'qt_horas_transferidas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador de centro de custo', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da função', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador se o recurso deve ser removido dos cálculos', 'user', dbo, 'table', 'tb_Periodos_Recursos', 'column', 'dv_calculo_remover'
GO


