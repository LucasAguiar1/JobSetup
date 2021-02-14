
CREATE TABLE dbo.tb_Funcoes_CentroCusto(
	  id_funcao_cc		int		NOT NULL	IDENTITY PRIMARY KEY
	, id_funcao			int		NOT NULL	REFERENCES tb_Funcoes
	, id_cc				int		NOT NULL	REFERENCES tb_CentroCusto
	, id_situacao		int		NOT NULL
	, CONSTRAINT UC_Funcoes_CentroCusto				
		 UNIQUE (id_funcao, id_cc)
)
GO

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave prim�ria', 'user', dbo, 'table', 'tb_Funcoes_CentroCusto', 'column', 'id_funcao_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de Fun��es', 'user', dbo, 'table', 'tb_Funcoes_CentroCusto', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de Centros de Custos', 'user', dbo, 'table', 'tb_Funcoes_CentroCusto', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situa��o l�gica do relacionamento', 'user', dbo, 'table', 'tb_Funcoes_CentroCusto', 'column', 'id_situacao'
GO




