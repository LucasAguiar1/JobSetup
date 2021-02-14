
CREATE TABLE dbo.tb_Situacoes(
	  id_situacao			int			not null	IDENTITY PRIMARY KEY
	, nm_situacao			varchar(30) not null
	, id_dominio			int			not null	REFERENCES dbo.tb_dominios
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave prim�ria da situa��o', 'user', dbo, 'table', 'tb_Situacoes', 'column', 'id_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome da situa��o', 'user', dbo, 'table', 'tb_Situacoes', 'column', 'nm_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador de agrupamento da situa��o', 'user', dbo, 'table', 'tb_Situacoes', 'column', 'id_dominio'
GO
