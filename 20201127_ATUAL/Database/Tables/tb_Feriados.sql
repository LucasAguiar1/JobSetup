
CREATE  TABLE dbo.tb_Feriados(
	  id_feriado							int		not null	IDENTITY PRIMARY KEY
	, dt_feriado							date	not null
	, CONSTRAINT UC_Feriados
		 UNIQUE (dt_feriado)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave primária interna', 'user', dbo, 'table', 'tb_Feriados', 'column', 'id_feriado'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data do feriado', 'user', dbo, 'table', 'tb_Feriados', 'column', 'dt_feriado'
GO


