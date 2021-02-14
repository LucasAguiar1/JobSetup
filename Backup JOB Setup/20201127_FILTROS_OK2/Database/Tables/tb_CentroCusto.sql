
CREATE TABLE dbo.tb_CentroCusto(
	  id_cc									int				not null	IDENTITY PRIMARY KEY
	, cd_cc									varchar(20)		not null
	, cd_sap								varchar(20)		not null
	, nm_cc									varchar (150)	not null
	, id_area								int				not null	references dbo.tb_Areas
	, id_tipo								int				not null	references dbo.tb_Tipos
	, id_situacao							int				not null	references dbo.tb_Situacoes
	, ds_usuario_lider						varchar(1000)	null
	, ds_lista_email						varchar(1000)	null
	, CONSTRAINT UC_CentroCusto				
		 UNIQUE (cd_cc)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador de chave prim�ria do centro de custo', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'c�digo do centro de custo oriundo do sistema de RH', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'cd_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'c�digo do centro de custo oriundo do SAP', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'cd_sap'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do centro de custo', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'nm_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de �rea', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'id_area'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de tipo', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'id_tipo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situa��o l�gica do centro de custo', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'id_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'lista de usu�rios com permiss�o de edi��o no centro de custo', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'ds_usuario_lider'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'lista de email para comunica��o do centro de custo', 'user', dbo, 'table', 'tb_CentroCusto', 'column', 'ds_lista_email'
GO
