
CREATE TABLE dbo.tb_Recursos_PontosRH (
	  id_recurso_pontoRH	int			NOT NULL	IDENTITY PRIMARY KEY
	, id_periodo_recurso	int			NOT NULL	REFERENCES tb_Periodos_Recursos
	, dt_referencia			datetime	NOT NULL
	, qt_horas				numeric(5,2) NOT NULL
	, dt_inicio				datetime	NULL
	, dt_fim				datetime	NULL
	, id_situacao			int			NOT NULL
	, CONSTRAINT UC_Recursos_PontosRH			
		 UNIQUE (id_periodo_recurso, dt_referencia)
)
GO

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave primária', 'user', dbo, 'table', 'tb_Recursos_PontosRH', 'column', 'id_recurso_pontoRH'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'referência a tabela de Recursos', 'user', dbo, 'table', 'tb_Recursos_PontosRH', 'column', 'id_periodo_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de referência', 'user', dbo, 'table', 'tb_Recursos_PontosRH', 'column', 'dt_referencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'quantidade de horas', 'user', dbo, 'table', 'tb_Recursos_PontosRH', 'column', 'qt_horas'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data e hora de inicio do ponto', 'user', dbo, 'table', 'tb_Recursos_PontosRH', 'column', 'dt_inicio'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data e hora final do ponto', 'user', dbo, 'table', 'tb_Recursos_PontosRH', 'column', 'dt_fim'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação lógica dos pontos RH no recurso', 'user', dbo, 'table', 'tb_Recursos_PontosRH', 'column', 'id_situacao'
GO