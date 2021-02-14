
CREATE TABLE tb_Contratos_Importacao (
	  nr_linha				int				NOT NULL
	, ds_periodo			varchar(10)		NOT NULL
	, cd_cc_externo			varchar(30)		NOT NULL
	, ds_texto_pedido		varchar(500)	NOT NULL
	, cd_documento_compra	varchar(30)		NOT NULL
	, nr_contrato			varchar(30)		NOT NULL
	, ds_empresa			varchar(30)		NOT NULL
	, dt_lancamento			datetime		NOT NULL
	, nr_total_entrada		numeric(10,3)	NOT NULL
	, vl_total_entrada		numeric(18,2)	NOT NULL
	, dt_entrada			datetime		NOT NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'número da linha de importação', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'nr_linha'	
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do periodo externo', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'ds_periodo'	
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'código do centro de custo de origem', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'cd_cc_externo'
GO	
EXECUTE sp_addextendedproperty 'MS_Description', 'texto do pedido', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'ds_texto_pedido'	
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número do documento de compras', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'cd_documento_compra'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número do contrato', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'nr_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'descrição da empresa', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'ds_empresa'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de lançamento', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'dt_lancamento'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número total de entrada', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'nr_total_entrada'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor total de entrada', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'vl_total_entrada'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data da entrada', 'user', dbo, 'table', 'tb_Contratos_Importacao', 'column', 'dt_entrada'
GO	
