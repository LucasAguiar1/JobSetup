
CREATE TABLE tb_Experiencias(
	  id_experiencia			int		NOT NULL	IDENTITY PRIMARY KEY
	, id_recurso				int		NOT NULL	REFERENCES tb_Recursos
	, dt_experiencia			date	NOT NULL
	, CONSTRAINT UC_Experiencias		
		 UNIQUE (id_recurso, dt_experiencia)
)
GO

EXECUTE sp_addextendedproperty 'MS_Description', 'chave primária da experiência', 'user', dbo, 'table', 'tb_Experiencias', 'column', 'id_experiencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do recurso', 'user', dbo, 'table', 'tb_Experiencias', 'column', 'id_recurso'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de experiência', 'user', dbo, 'table', 'tb_Experiencias', 'column', 'dt_experiencia'
GO






