
CREATE TABLE dbo.tb_Carga_Funcionarios
(
	  id_empresa		varchar(200) NOT NULL
	, id_cargo			varchar(200) NOT NULL
	, id_cc				varchar(200) NOT NULL
	, st_funcionario	varchar(200) NOT NULL
	, ds_tipo			varchar(200) NOT NULL
	, nr_matricula		varchar(200) NOT NULL
	, nm_funcionario	varchar(200) NOT NULL
	, ds_situacao		varchar(200) NOT NULL
	, dt_inicio			varchar(200) NOT NULL
	, ds_escala			varchar(200) NOT NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador da empresa', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'id_empresa'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do cargo', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'id_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do centro de custo', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Situação do funcionário', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'st_funcionario'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Tipo de funcionário', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'ds_tipo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Número de matrícula', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'nr_matricula'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Nome do funcionário', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'nm_funcionario'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Ativo ou Demitido', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'ds_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Data de início', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'dt_inicio'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Escala de Trabalho', 'user', dbo, 'table', 'tb_Carga_Funcionarios', 'column', 'ds_escala'
GO

	
