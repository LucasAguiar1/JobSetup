
CREATE TABLE dbo.tb_Carga_Tipos_Verbas
(
	  id_tipo_verba		varchar(200) NOT NULL
	, ds_tipo_verba		varchar(200) NOT NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do tipo de verba', 'user', dbo, 'table', 'tb_Carga_Tipos_Verbas', 'column', 'id_tipo_verba'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Descrição do tipo de verba', 'user', dbo, 'table', 'tb_Carga_Tipos_Verbas', 'column', 'ds_tipo_verba'
GO
