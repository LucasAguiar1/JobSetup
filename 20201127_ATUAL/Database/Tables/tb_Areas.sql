
CREATE TABLE dbo.tb_Areas(
	  id_area								int				not null	IDENTITY PRIMARY KEY
	, nm_area								varchar (150)	not null
	, id_situacao							int				not null	references dbo.tb_Situacoes
	, CONSTRAINT UC_Areas				
		 UNIQUE (nm_area)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Areas', 'column', 'id_area'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome da area', 'user', dbo, 'table', 'tb_Areas', 'column', 'nm_area'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação da area', 'user', dbo, 'table', 'tb_Areas', 'column', 'id_situacao'
GO




