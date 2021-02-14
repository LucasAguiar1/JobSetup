
CREATE TABLE tb_CentroCusto_Categorias(
	  id_centroCusto_categoria			int				NOT NULL	IDENTITY PRIMARY KEY
	, id_cc								int				NOT NULL	REFERENCES tb_CentroCusto
	, id_categoria						int				NOT NULL	REFERENCES tb_Categorias
	, pc_distribuicao					numeric(5,2)	NOT NULL
	, CONSTRAINT UC_CentroCusto_Categorias			
		 UNIQUE (id_cc, id_categoria)
)
GO

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave prim�ria', 'user', dbo, 'table', 'tb_CentroCusto_Categorias', 'column', 'id_centroCusto_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de Centro de Custo', 'user', dbo, 'table', 'tb_CentroCusto_Categorias', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de Categoria', 'user', dbo, 'table', 'tb_CentroCusto_Categorias', 'column', 'id_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'percentual de distribui��o da categoria no Centro de Custo', 'user', dbo, 'table', 'tb_CentroCusto_Categorias', 'column', 'pc_distribuicao'
GO
