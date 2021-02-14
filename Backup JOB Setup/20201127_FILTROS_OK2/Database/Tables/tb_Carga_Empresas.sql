
CREATE TABLE dbo.tb_Carga_Empresas
(
	  id_empresa		varchar(200) NOT NULL
	, ds_empresa		varchar(200) NOT NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador da empresa', 'user', dbo, 'table', 'tb_Carga_Empresas', 'column', 'id_empresa'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Descrição da empresa', 'user', dbo, 'table', 'tb_Carga_Empresas', 'column', 'ds_empresa'
GO
