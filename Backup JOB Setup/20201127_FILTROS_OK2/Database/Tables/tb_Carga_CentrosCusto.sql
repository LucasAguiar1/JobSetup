
CREATE TABLE dbo.tb_Carga_CentrosCusto
(
	  id_cc			varchar(200) NOT NULL
	, nm_cc			varchar(200) NOT NULL
	, st_cc			varchar(200) NOT NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do centro de custo', 'user', dbo, 'table', 'tb_Carga_CentrosCusto', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Nome do centro de custo', 'user', dbo, 'table', 'tb_Carga_CentrosCusto', 'column', 'nm_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Situação do centro de custo', 'user', dbo, 'table', 'tb_Carga_CentrosCusto', 'column', 'st_cc'
GO
