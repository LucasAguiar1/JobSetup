
CREATE TABLE dbo.tb_Tipos(
	  id_tipo								int				not null	IDENTITY PRIMARY KEY
	, cd_tipo								int				not null
	, nm_tipo								varchar (150)	not null
	, id_situacao							int				not null	references dbo.tb_Situacoes
	, CONSTRAINT UC_Tipos				
		 UNIQUE (nm_tipo)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Tipos', 'column', 'id_tipo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'código de controle do tipo', 'user', dbo, 'table', 'tb_Tipos', 'column', 'cd_tipo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do tipo', 'user', dbo, 'table', 'tb_Tipos', 'column', 'nm_tipo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica do tipo', 'user', dbo, 'table', 'tb_Tipos', 'column', 'id_situacao'
GO






