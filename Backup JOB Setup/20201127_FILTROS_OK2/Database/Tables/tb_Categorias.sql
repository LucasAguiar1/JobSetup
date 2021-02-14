
CREATE TABLE dbo.tb_Categorias
(
	  id_categoria							int				not null	IDENTITY PRIMARY KEY
	, nm_categoria							varchar (50)	not null
	, nm_grupo								varchar (50)	not null
	, id_situacao							int				not null	references dbo.tb_Situacoes
	, nr_ordem								int				not null
	, CONSTRAINT UC_Categorias				
		 UNIQUE (nm_categoria)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Categorias', 'column', 'id_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome da categoria', 'user', dbo, 'table', 'tb_Categorias', 'column', 'nm_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do grupo', 'user', dbo, 'table', 'tb_Categorias', 'column', 'nm_grupo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica da categoria', 'user', dbo, 'table', 'tb_Categorias', 'column', 'id_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'ordenação para apresentação em relatórios', 'user', dbo, 'table', 'tb_Categorias', 'column', 'nr_ordem'
GO






