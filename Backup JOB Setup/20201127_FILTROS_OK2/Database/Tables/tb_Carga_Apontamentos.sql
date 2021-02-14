
CREATE TABLE dbo.tb_Carga_Apontamentos
(
	  nr_matricula		varchar(200) NOT NULL
	, id_tipo_verba		varchar(200) NOT NULL
	, qt_horas			varchar(200) NOT NULL
	, dt_inicio			varchar(200) NOT NULL
	, dt_fim			varchar(200) NOT NULL
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Matrícula do Funcionário', 'user', dbo, 'table', 'tb_Carga_Apontamentos', 'column', 'nr_matricula'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Código do Tipo de Verba', 'user', dbo, 'table', 'tb_Carga_Apontamentos', 'column', 'id_tipo_verba'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Horas trabalhadas no formato HH:MM:SS para o tipo de verba/funcionário', 'user', dbo, 'table', 'tb_Carga_Apontamentos', 'column', 'qt_horas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Data hora do apontamento de entrada (AAAA-MM-DD HH:MM:SS)', 'user', dbo, 'table', 'tb_Carga_Apontamentos', 'column', 'dt_inicio'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Data e hora do apontamento da saída (AAAA-MM-DD HH:MM:SS)', 'user', dbo, 'table', 'tb_Carga_Apontamentos', 'column', 'dt_fim'
GO
