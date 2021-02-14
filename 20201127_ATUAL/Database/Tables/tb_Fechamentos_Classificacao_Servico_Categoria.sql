
CREATE TABLE dbo.tb_Fechamentos_Classificacao_Servico_Categoria
(
	  id_periodo			int			  NOT NULL	REFERENCES dbo.tb_Periodos
	, id_categoria			int			  NOT NULL	REFERENCES dbo.tb_Categorias
	, id_cc					int			  NOT NULL	REFERENCES dbo.tb_centrocusto
	, qt_horas				numeric(9,2)  NOT NULL
	, CONSTRAINT UC_Fechamentos_Classificacao_Servico_Categoria
		 UNIQUE (id_periodo, id_categoria, id_cc)
)
go


EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Categoria', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador de Categoria', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Categoria', 'column', 'id_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador de Centro de Custo', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Categoria', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de horas', 'user', dbo, 'table', 'tb_Fechamentos_Classificacao_Servico_Categoria', 'column', 'qt_horas'
GO


CREATE NONCLUSTERED INDEX IX_Fechamentos_Classificacao_Servico_Categoria
    ON tb_Fechamentos_Classificacao_Servico_Categoria (id_periodo);   
GO
