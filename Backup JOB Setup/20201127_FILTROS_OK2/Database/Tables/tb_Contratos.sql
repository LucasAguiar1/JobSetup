
CREATE TABLE tb_Contratos (
	  id_contrato			int				NOT NULL	identity primary key
	, id_periodo			int				NOT NULL	references dbo.tb_Periodos
	, nr_contrato			varchar(30)		NOT NULL
	, dt_contrato			datetime		NOT NULL
	, ds_contrato			varchar(500)	NOT NULL
	, vl_contrato			numeric(18,2)   NOT NULL
	, dv_conferido			bit				NOT NULL
	, nm_arquivo_importacao	varchar(200)	NOT NULL
	, id_situacao			int				NOT NULL	references dbo.tb_Situacoes
	, CONSTRAINT UC_Contratos				
		 UNIQUE (id_periodo, nr_contrato)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave primária do contrato', 'user', dbo, 'table', 'tb_Contratos', 'column', 'id_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do período de apuração', 'user', dbo, 'table', 'tb_Contratos', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número do contrato do serviço', 'user', dbo, 'table', 'tb_Contratos', 'column', 'nr_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'período a que se refere o serviço contratado', 'user', dbo, 'table', 'tb_Contratos', 'column', 'dt_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'descrição sobre o serviço contratado', 'user', dbo, 'table', 'tb_Contratos', 'column', 'ds_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor total do contrato', 'user', dbo, 'table', 'tb_Contratos', 'column', 'vl_contrato'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'flag de conferido', 'user', dbo, 'table', 'tb_Contratos', 'column', 'dv_conferido'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do arquivo de importação', 'user', dbo, 'table', 'tb_Contratos', 'column', 'nm_arquivo_importacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação do contrato', 'user', dbo, 'table', 'tb_Contratos', 'column', 'id_situacao'
GO

