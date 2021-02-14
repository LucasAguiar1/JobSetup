
CREATE TABLE dbo.tb_Classificacoes(
	  id_classificacao						int				NOT NULL	IDENTITY PRIMARY KEY
	, nm_classificacao						varchar (150)	NOT NULL
	, id_situacao							int				NOT NULL	REFERENCES dbo.tb_Situacoes
	, CONSTRAINT UC_Classificacoes				
		 UNIQUE (nm_classificacao)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave primária da classificação', 'user', dbo, 'table', 'tb_Classificacoes', 'column', 'id_classificacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome da classificação', 'user', dbo, 'table', 'tb_Classificacoes', 'column', 'nm_classificacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica da classificação', 'user', dbo, 'table', 'tb_Classificacoes', 'column', 'id_situacao'
GO




