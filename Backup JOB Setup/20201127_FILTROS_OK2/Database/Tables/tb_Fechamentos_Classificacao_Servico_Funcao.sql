
CREATE TABLE dbo.tb_Fechamentos_Classificacao_Servico_Funcao
(
	  id_periodo			int			  NOT NULL	REFERENCES dbo.tb_Periodos
	, id_funcao				int			  NOT NULL	REFERENCES dbo.tb_Funcoes
	, id_classificacao		int			  NOT NULL	REFERENCES dbo.tb_Classificacoes
	, qt_horas				numeric(9,2)  NOT NULL
	, CONSTRAINT UC_Fechamentos_Classificacao_Servico_Funcao
		 UNIQUE (id_periodo, id_funcao, id_classificacao)
)
go


EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Funcao', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador de Função', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Funcao', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador da Classificacao', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Funcao', 'column', 'id_classificacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Funcao', 'column', 'qt_horas'
GO


CREATE NONCLUSTERED INDEX IX_Fechamentos_Classificacao_Servico_Funcao
    ON tb_Fechamentos_Classificacao_Servico_Funcao (id_periodo);   
GO
