
CREATE TABLE dbo.tb_Motivos(
	  id_motivo								int				NOT NULL	IDENTITY PRIMARY KEY
	, ds_motivo								varchar(150)	NOT NULL
	, id_situacao							int				not null	REFERENCES dbo.tb_situacoes
	, id_dominio							int				not null	REFERENCES dbo.tb_dominios
	, CONSTRAINT UC_Motivos				
		 UNIQUE (ds_motivo)
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave prim�ria da classifica��o', 'user', dbo, 'table', 'tb_Motivos', 'column', 'id_motivo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'Informa��o de descri��o do motivo', 'user', dbo, 'table', 'tb_Motivos', 'column', 'ds_motivo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situa��o l�gica do motivo', 'user', dbo, 'table', 'tb_Motivos', 'column', 'id_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador de grupo de dom�nio do motivo', 'user', dbo, 'table', 'tb_Motivos', 'column', 'id_dominio'
GO





