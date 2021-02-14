
CREATE  TABLE dbo.tb_Listas(
	  id_lista								int				not null	IDENTITY PRIMARY KEY
	, nm_lista								varchar (150)	not null
	, id_dominio							int				not null	references dbo.tb_Dominios
	, CONSTRAINT UC_Listas
		 UNIQUE (id_dominio, nm_lista)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Listas', 'column', 'id_lista'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do item da lista', 'user', dbo, 'table', 'tb_Listas', 'column', 'nm_lista'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador de domínio', 'user', dbo, 'table', 'tb_Listas', 'column', 'id_dominio'
GO

INSERT INTO tb_Listas VALUES ('Gerente', 5)
INSERT INTO tb_Listas VALUES ('Supervisor', 5)
INSERT INTO tb_Listas VALUES ('Especialista', 5)
