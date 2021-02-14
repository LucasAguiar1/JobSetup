
CREATE TABLE dbo.tb_Pesos_Armazenados(
	  id_pesos_armazenados					int				not null	IDENTITY PRIMARY KEY
	, id_categoria							int				not null	REFERENCES dbo.tb_Categorias
	, dt_referencia							date			not null
	, qt_peso_armazenado					numeric(18,3)	not null
	, CONSTRAINT UC_Pesos_Armazenados				
		 UNIQUE (id_categoria, dt_referencia)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Pesos_Armazenados', 'column', 'id_pesos_armazenados'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da categoria', 'user', dbo, 'table', 'tb_Pesos_Armazenados', 'column', 'id_categoria'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de referência', 'user', dbo, 'table', 'tb_Pesos_Armazenados', 'column', 'dt_referencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'peso em libras armazenado', 'user', dbo, 'table', 'tb_Pesos_Armazenados', 'column', 'qt_peso_armazenado'
GO




