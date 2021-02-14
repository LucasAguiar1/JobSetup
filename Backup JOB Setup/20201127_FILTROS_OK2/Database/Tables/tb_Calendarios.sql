
CREATE TABLE dbo.tb_Calendarios(
	  id_calendario						int			    NOT NULL	IDENTITY PRIMARY KEY
	, dt_referencia						date			NOT NULL
	, id_ignorar_producao				smallint		NOT NULL
	, ds_ignorar_motivo					varchar(100)	NULL
	, hr_inicio							time			NULL
	, hr_fim							time			NULL
	, nr_horas_ajuste					numeric(5,2)	NULL
	, id_periodo						int				NOT NULL	REFERENCES dbo.tb_Periodos
	, id_situacao						int				NOT NULL	REFERENCES dbo.tb_Situacoes
	, CONSTRAINT UC_Calendarios				
		 UNIQUE (id_periodo, dt_referencia)
)
GO

EXECUTE sp_addextendedproperty 'MS_Description', 'id campo de chave primária', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'id_calendario'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'data de vigencia do calendário', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'dt_referencia'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador se o dia deve ser ignorado na produção diária', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'id_ignorar_producao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'descrição do motivo do dia ser ignorado na produção diária', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'ds_ignorar_motivo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'horário de inicio do ajuste parcial', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'hr_inicio'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'horário de fim do ajuste parcial', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'hr_fim'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'número de horas de ajuste', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'nr_horas_ajuste'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador chave do periodo', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'id_periodo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situação do dia do calendário', 'user', dbo, 'table', 'tb_Calendarios', 'column', 'id_situacao'
GO

