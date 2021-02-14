
CREATE  TABLE dbo.tb_Cargos(
	  id_cargo								int				not null	IDENTITY PRIMARY KEY
	, id_cargo_origem						int				not null
	, nm_cargo								varchar (150)	not null
	, id_situacao							int				not null	references dbo.tb_Situacoes
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Cargos', 'column', 'id_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do cargo na origem', 'user', dbo, 'table', 'tb_Cargos', 'column', 'id_cargo_origem'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do cargo', 'user', dbo, 'table', 'tb_Cargos', 'column', 'nm_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação do cargo', 'user', dbo, 'table', 'tb_Cargos', 'column', 'id_situacao'
GO
