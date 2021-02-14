
CREATE TABLE tb_Contratos_Funcoes
(
	  id_contrato_funcao	int				NOT NULL	identity primary key
	, id_contrato			int				NOT NULL	references dbo.tb_Contratos
	, id_funcao				int				NOT NULL	references dbo.tb_Funcoes
	, vl_percentual			numeric(5,2)	NOT NULL
	, vl_rateio				numeric(18,2)	NOT NULL
	, id_classificacao		int				NULL
	, id_situacao			int				NOT NULL
	, nr_horas_dia			numeric(9,2)    NULL
	, CONSTRAINT UC_Contratos_Funcoes
		 UNIQUE (id_contrato, id_funcao)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave primária', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'id_contrato_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do contrato', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'id_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'referência a tabela de Funções', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor percentual', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'vl_percentual'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor rateado', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'vl_rateio'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nova classificação atribuida a função no contrato', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'id_classificacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica da função no contrato', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'id_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'horas calculado por dia', 'user', dbo, 'table', 'tb_Contratos_Funcoes', 'column', 'nr_horas_dia'
GO
