
CREATE TABLE tb_Contratos_Itens (
	  id_contrato_item		int				NOT NULL	identity primary key
	, id_contrato			int				NOT NULL	references tb_Contratos
	, id_cc					int				NOT NULL
	, cd_cc_externo			varchar(30)		NOT NULL
	, ds_texto_pedido		varchar(500)	NOT NULL
	, cd_documento_compra	varchar(30)		NOT NULL
	, ds_empresa			varchar(30)		NOT NULL
	, dt_lancamento			datetime		NOT NULL
	, nr_total_entrada		numeric(10,3)	NOT NULL
	, vl_total_entrada		numeric(18,2)	NOT NULL
	, id_situacao			int				NOT NULL
	, nr_horas_dia			numeric(9,2)    NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave prim�ria do item de contrato', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'id_contrato_item'	
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do contrato	Servi�os Contratados', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'id_contrato'
GO	
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do centro de custo', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'id_cc'	
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'c�digo do centro de custo de origem', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'cd_cc_externo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'texto do pedido	Servi�os Contratados', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'ds_texto_pedido'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'n�mero do documento de compras', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'cd_documento_compra'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'descri��o da empresa', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'ds_empresa'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de lan�amento', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'dt_lancamento'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'n�mero total de entrada', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'nr_total_entrada'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor total de entrada', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'vl_total_entrada'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situa��o do contrato', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'id_situacao'
GO	
EXECUTE sp_addextendedproperty 'MS_Description', 'horas calculado por dia', 'user', dbo, 'table', 'tb_Contratos_Itens', 'column', 'nr_horas_dia'
GO

