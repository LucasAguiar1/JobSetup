
CREATE TABLE dbo.tb_Dominios(
	  id_dominio			int			not null	IDENTITY PRIMARY KEY
	, nm_dominio			varchar(30) not null
	, CONSTRAINT UC_Dominios				
		 UNIQUE (nm_dominio)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave primária do domínio', 'user', dbo, 'table', 'tb_Dominios', 'column', 'id_dominio'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do domínio', 'user', dbo, 'table', 'tb_Dominios', 'column', 'nm_dominio'
GO

