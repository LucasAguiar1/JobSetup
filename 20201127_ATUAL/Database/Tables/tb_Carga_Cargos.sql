
CREATE TABLE dbo.tb_Carga_Cargos
(
	  id_cargo			varchar(200) NOT NULL
	, nm_cargo			varchar(200) NOT NULL
	, st_cargo			varchar(200) NOT NULL
	, CONSTRAINT UC_Carga_Cargos
		 UNIQUE (id_cargo)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do cargo', 'user', dbo, 'table', 'tb_Carga_Cargos', 'column', 'id_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Nome do cargo', 'user', dbo, 'table', 'tb_Carga_Cargos', 'column', 'nm_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Situação do cargo', 'user', dbo, 'table', 'tb_Carga_Cargos', 'column', 'st_cargo'
GO
