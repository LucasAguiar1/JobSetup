
CREATE TABLE dbo.tb_Funcoes(
	  id_funcao								int				NOT NULL	IDENTITY PRIMARY KEY
	, cd_operacao							varchar(50)		not null
	, nm_funcao								varchar(150)	not null
	, id_classificacao						int				not null	REFERENCES dbo.tb_Classificacoes
	, dv_participa_pmh						bit				not null
	, dv_participa_cmh						bit				not null
	, dv_contabiliza_separado				bit				not null
	, id_situacao							int				not null	REFERENCES dbo.tb_Situacoes
	, vl_hora_servico						numeric(7,2)    null
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'chave prim�ria da fun��o', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'id_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'c�digo da opera��o a ser exercida', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'cd_operacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome da fun��o a ser exercida por determinado(s) recurso(s)', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'nm_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'refer�ncia a tabela de Classifica��es de fun��es', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'id_classificacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identifica se participa da contabiliza��o PMH', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'dv_participa_pmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identifica se participa da contabiliza��o CMH', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'dv_participa_cmh'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identifica se sumariza separadamente no relat�rio', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'dv_contabiliza_separado'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'situa��o l�gica da fun��o', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'id_situacao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'valor por hora de presta��o de servi�o', 'user', dbo, 'table', 'tb_Funcoes', 'column', 'vl_hora_servico'
GO









