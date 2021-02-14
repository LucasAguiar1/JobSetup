
CREATE TABLE dbo.tb_Contratos_Rateio_Funcoes
(
	  id_funcao				int				NOT NULL	references dbo.tb_Funcoes
	, nr_contrato			varchar(30)		NOT NULL
	, vl_percentual			numeric(5,2)	NOT NULL
	, id_classificacao		int				NULL		references dbo.tb_Classificacoes
)
go

--ALTER TABLE dbo.tb_Contratos_Rateio_Funcoes
--  ADD CONSTRAINT PK_Contratos_Rateio_Funcoes
--	PRIMARY KEY (id_funcao, nr_contrato);

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da função', 'user', dbo, 'table', 'tb_Contratos_Rateio_Funcoes', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número do contrato', 'user', dbo, 'table', 'tb_Contratos_Rateio_Funcoes', 'column', 'nr_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor do percentual', 'user', dbo, 'table', 'tb_Contratos_Rateio_Funcoes', 'column', 'vl_percentual'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'código da reclassificação', 'user', dbo, 'table', 'tb_Contratos_Rateio_Funcoes', 'column', 'id_classificacao'
GO

