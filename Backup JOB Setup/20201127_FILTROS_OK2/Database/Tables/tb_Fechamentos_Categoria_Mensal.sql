
CREATE TABLE dbo.tb_Fechamentos_Categoria_Mensal
(
	  id_periodo			int			  NOT NULL	REFERENCES dbo.tb_Periodos
	, id_categoria			int			  NOT NULL	REFERENCES dbo.tb_Categorias
	, qt_peso_armazenado	numeric(18,3)  NOT NULL
	, qt_peso_ajustado		numeric(18,3)  NOT NULL
	, CONSTRAINT UC_Fechamentos_Categoria_Mensal
		 UNIQUE (id_periodo, id_categoria)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador do período', 'user', dbo, 'table', 'tb_Fechamentos_Categoria_Mensal', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Identificador da Categoria', 'user', dbo, 'table', 'tb_Fechamentos_Categoria_Mensal', 'column', 'id_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de Peso Armazenado em Libras', 'user', dbo, 'table', 'tb_Fechamentos_Categoria_Mensal', 'column', 'qt_peso_armazenado'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Quantidade de Peso Ajustado em Libras', 'user', dbo, 'table', 'tb_Fechamentos_Categoria_Mensal', 'column', 'qt_peso_ajustado'
GO
