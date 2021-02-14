
CREATE TABLE dbo.tb_Fechamentos_Classificacao_Funcao
(
	  id_periodo			int			  NOT NULL	REFERENCES dbo.tb_Periodos
	, id_funcao				int			  NOT NULL	REFERENCES dbo.tb_Funcoes
	, id_classificacao		int			  NOT NULL	REFERENCES dbo.tb_Classificacoes
	, nr_recursos			int			  NOT NULL
	, qt_horas_tmh			numeric(9,2)  NOT NULL
	, qt_horas_pmh			numeric(9,2)  NOT NULL
	, qt_horas_cmh			numeric(9,2)  NOT NULL
	, CONSTRAINT UC_Fechamentos_Classificacao_Funcao
		 UNIQUE (id_periodo, id_funcao, id_classificacao)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Funcao', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador de Função', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Funcao', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador da Classificacao', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Funcao', 'column', 'id_classificacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de Recursos', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Funcao', 'column', 'nr_recursos'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas TMH', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Funcao', 'column', 'qt_horas_tmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas PMH', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Funcao', 'column', 'qt_horas_pmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas CMH', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Funcao', 'column', 'qt_horas_cmh'
GO

CREATE NONCLUSTERED INDEX IX_Fechamentos_Classificacao_Funcao
    ON tb_Fechamentos_Classificacao_Funcao (id_periodo);   
GO
