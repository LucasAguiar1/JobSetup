
CREATE TABLE tb_Recursos_Transferencias(
	  id_recurso_transferencia			int			NOT NULL	IDENTITY PRIMARY KEY
	, id_periodo_recurso				int			not null	REFERENCES tb_Periodos_Recursos
	, dt_referencia						datetime	NOT NULL
	, qt_horas							numeric(5,2) NOT NULL
	, id_cc								int			NOT NULL	REFERENCES tb_CentroCusto
	, id_funcao							int			NOT NULL	REFERENCES tb_Funcoes
	, id_situacao						int			NOT NULL
	, CONSTRAINT UC_Recursos_Transferencias				
		 UNIQUE (id_periodo_recurso, dt_referencia)
)
GO

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave primária', 'user', dbo, 'table', 'tb_Recursos_Transferencias', 'column', 'id_recurso_transferencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'referência a tabela de Recursos', 'user', dbo, 'table', 'tb_Recursos_Transferencias', 'column', 'id_periodo_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de referência', 'user', dbo, 'table', 'tb_Recursos_Transferencias', 'column', 'dt_referencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'quantidade de horas', 'user', dbo, 'table', 'tb_Recursos_Transferencias', 'column', 'qt_horas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'referência a tabela de Centros de Custos', 'user', dbo, 'table', 'tb_Recursos_Transferencias', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'referência a tabela de Funções', 'user', dbo, 'table', 'tb_Recursos_Transferencias', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica das transferências no recurso', 'user', dbo, 'table', 'tb_Recursos_Transferencias', 'column', 'id_situacao'
GO

