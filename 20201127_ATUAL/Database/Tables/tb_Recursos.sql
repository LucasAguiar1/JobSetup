
CREATE TABLE tb_Recursos(
	  id_recurso					int			NOT NULL	identity primary key
	, cd_rl						varchar(15)	not null
	, nm_recurso				varchar(150) not null
	, qt_dias_experiencia		int			not null
	, dv_calculo_remover		int			not null
	, ds_rh_status				varchar(30)	not null
	, ds_rh_regime_trabalho		varchar(10)	not null
	, ds_rh_cargo				varchar(50)	not null
	, dt_entrada				datetime	not null
	, id_cc						int			not null		references tb_CentroCusto
	, id_funcao					int			null			references tb_Funcoes
	, id_situacao				int			not null		references tb_Situacoes
	, ds_escala					varchar(50) not null
	, CONSTRAINT UC_Recursos
		 UNIQUE (cd_rl, nm_recurso)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave primária', 'user', dbo, 'table', 'tb_Recursos', 'column', 'id_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Nº do Registro Legal, oriundo do sistema RH', 'user', dbo, 'table', 'tb_Recursos', 'column', 'cd_rl'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Nome do Recurso', 'user', dbo, 'table', 'tb_Recursos', 'column', 'nm_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de dias para terminar a experiência de um recurso', 'user', dbo, 'table', 'tb_Recursos', 'column', 'qt_dias_experiencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador se o recurso deve ser removido dos cálculos', 'user', dbo, 'table', 'tb_Recursos', 'column', 'dv_calculo_remover'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Status informado pelo sistema de RH', 'user', dbo, 'table', 'tb_Recursos', 'column', 'ds_rh_status'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Regime de trabalho', 'user', dbo, 'table', 'tb_Recursos', 'column', 'ds_rh_regime_trabalho'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Cargo no RH', 'user', dbo, 'table', 'tb_Recursos', 'column', 'ds_rh_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Data de Entrada na área técnica', 'user', dbo, 'table', 'tb_Recursos', 'column', 'dt_entrada'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do centro de custo', 'user', dbo, 'table', 'tb_Recursos', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da função', 'user', dbo, 'table', 'tb_Recursos', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica do recurso', 'user', dbo, 'table', 'tb_Recursos', 'column', 'id_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'descrição da escala de trabalho', 'user', dbo, 'table', 'tb_Recursos', 'column', 'ds_escala'
GO
