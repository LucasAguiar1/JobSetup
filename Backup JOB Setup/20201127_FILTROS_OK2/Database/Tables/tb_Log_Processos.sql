
CREATE TABLE dbo.tb_Log_Processos(
	  id_log_processo			int			not null	IDENTITY PRIMARY KEY
	, dt_log_processo			datetime	not null
	, nm_tabela					varchar(50) not null
	, nm_tipo_processo			char(3)		not null
	, id_chave					int			not null
	, cd_usuario				varchar(20) not	null
	, ds_log_processo			varchar(4000) not null
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Log_Processos', 'column', 'id_log_processo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de registro do log', 'user', dbo, 'table', 'tb_Log_Processos', 'column', 'dt_log_processo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome da tabela', 'user', dbo, 'table', 'tb_Log_Processos', 'column', 'nm_tabela'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do tipo de processo', 'user', dbo, 'table', 'tb_Log_Processos', 'column', 'nm_tipo_processo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave do processo na tabela de origem', 'user', dbo, 'table', 'tb_Log_Processos', 'column', 'id_chave'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'código do usuário do log', 'user', dbo, 'table', 'tb_Log_Processos', 'column', 'cd_usuario'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'detalhamento dos valores alterados', 'user', dbo, 'table', 'tb_Log_Processos', 'column', 'ds_log_processo'
GO
