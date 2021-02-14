
CREATE TABLE tb_Parametros(
	  id_parametro			int				NOT NULL IDENTITY PRIMARY KEY
	, nm_parametro			varchar(100)	NOT NULL
	, vl_parametro			varchar(1000)	NOT NULL
	, dv_interno			bit				NOT NULL
	, id_tipo				char(3)			NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave primária do parametro', 'user', dbo, 'table', 'tb_Parametros', 'column', 'id_parametro'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do parametro', 'user', dbo, 'table', 'tb_Parametros', 'column', 'nm_parametro'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor do parametro', 'user', dbo, 'table', 'tb_Parametros', 'column', 'vl_parametro'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'variável para controle interno', 'user', dbo, 'table', 'tb_Parametros', 'column', 'dv_interno'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador de tipo (CHR, EML, LST, INT, NUM, DAT)', 'user', dbo, 'table', 'tb_Parametros', 'column', 'id_tipo'
GO


