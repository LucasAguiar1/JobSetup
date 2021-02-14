
CREATE TABLE dbo.tb_Recursos_Excecoes(
	  id_recurso_excecao	int				NOT NULL	IDENTITY PRIMARY KEY
	, id_periodo_recurso	int				NOT NULL	REFERENCES tb_Periodos_Recursos
	, dt_referencia			datetime		NOT NULL
	, qt_horas				numeric(5,2)	NOT NULL
	, id_motivo				int				NOT NULL	REFERENCES tb_Motivos
	, id_situacao			int				NOT NULL	REFERENCES tb_Situacoes
	, CONSTRAINT UC_Recursos_Excecoes				
		 UNIQUE (id_periodo_recurso, dt_referencia)
)
GO

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave prim�ria', 'user', dbo, 'table', 'tb_Recursos_Excecoes', 'column', 'id_recurso_excecao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de Recursos', 'user', dbo, 'table', 'tb_Recursos_Excecoes', 'column', 'id_periodo_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de refer�ncia', 'user', dbo, 'table', 'tb_Recursos_Excecoes', 'column', 'dt_referencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'quantidade de horas', 'user', dbo, 'table', 'tb_Recursos_Excecoes', 'column', 'qt_horas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de Motivos de Exce��es', 'user', dbo, 'table', 'tb_Recursos_Excecoes', 'column', 'id_motivo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situa��o l�gica das exce��es no recurso', 'user', dbo, 'table', 'tb_Recursos_Excecoes', 'column', 'id_situacao'
GO







