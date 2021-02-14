
CREATE TABLE dbo.tb_Fechamentos_Classificacao_Motivo
(
	  id_periodo			int			  NOT NULL	REFERENCES dbo.tb_Periodos
	, id_motivo				int			  NOT NULL	REFERENCES dbo.tb_Motivos
	, id_classificacao		int			  NOT NULL	REFERENCES dbo.tb_Classificacoes
	, nr_recursos			int			  NOT NULL
	, qt_horas				numeric(9,2)  NOT NULL
	, CONSTRAINT UC_Fechamentos_Classificacao_Motivo
		 UNIQUE (id_periodo, id_motivo, id_classificacao)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Motivo', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do Motivo', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Motivo', 'column', 'id_motivo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador da Classificacao', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Motivo', 'column', 'id_classificacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de Recursos', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Motivo', 'column', 'nr_recursos'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Motivo', 'column', 'qt_horas'
GO

CREATE NONCLUSTERED INDEX IX_Fechamentos_Classificacao_Motivo
    ON tb_Fechamentos_Classificacao_Motivo (id_periodo);   
GO
