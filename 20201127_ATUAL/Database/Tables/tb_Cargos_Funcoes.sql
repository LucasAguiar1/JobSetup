
CREATE  TABLE dbo.tb_Cargos_Funcoes(
	  id_cargo_funcao		int				not null	IDENTITY PRIMARY KEY
	, id_cargo				int				not null
	, nm_cargo				varchar (150)	not null
	, id_cc					int				not null	references dbo.tb_CentroCusto
	, id_funcao				int				not null	references dbo.tb_Funcoes
)
go

EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da chave prim�ria interna', 'user', dbo, 'table', 'tb_Cargos_Funcoes', 'column', 'id_cargo_funcao'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do cargo', 'user', dbo, 'table', 'tb_Cargos_Funcoes', 'column', 'id_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'nome do cargo', 'user', dbo, 'table', 'tb_Cargos_Funcoes', 'column', 'nm_cargo'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador do centro de custo', 'user', dbo, 'table', 'tb_Cargos_Funcoes', 'column', 'id_cc'
GO
EXECUTE sp_addextendedproperty 'MS_Description', 'identificador da fun��o', 'user', dbo, 'table', 'tb_Cargos_Funcoes', 'column', 'id_funcao'
GO

-- select * from tb_Cargos_Funcoes


insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O',1,23)
insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O (PD)',7,12)
insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O (PD)',17,137)
insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O (PD)',18,137)
insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O (PD)',19,137)
insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O (PD)',5,34)
insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O (PD)',2,24)
insert into tb_Cargos_Funcoes values (1708, 'AUXILIAR DE PRODU��O (PD)',105,15)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTACAO MATERIAIS',1,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTACAO MATERIAIS',3,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTACAO MATERIAIS',11,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS',16,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS (PD) ',2,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS (PD) ',4,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS (PD) ',5,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS (PD) ',6,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS (PD) ',7,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS (PD) ',17,4)
insert into tb_Cargos_Funcoes values (2306, 'AUXILIAR MOVIMENTA��O MATERIAIS (PD) ',18,4)
insert into tb_Cargos_Funcoes values (1078, 'AUXILIAR PRODUCAO',16,137)
insert into tb_Cargos_Funcoes values (1078, 'AUXILIAR PRODUCAO',3,9)
insert into tb_Cargos_Funcoes values (1078, 'AUXILIAR PRODUCAO',11,74)
insert into tb_Cargos_Funcoes values (316, 'CONSTRUTOR PNEUS ACO',16,20)
insert into tb_Cargos_Funcoes values (346, 'CONSTRUTOR PNEUS D',16,20)
insert into tb_Cargos_Funcoes values (92, 'ESCRITURARIO',1,3)
insert into tb_Cargos_Funcoes values (92, 'ESCRITURARIO',16,3)
insert into tb_Cargos_Funcoes values (92, 'Escritur�rio',1,3)
insert into tb_Cargos_Funcoes values (92, 'Escritur�rio',2,3)
insert into tb_Cargos_Funcoes values (92, 'Escritur�rio',5,3)
insert into tb_Cargos_Funcoes values (92, 'Escritur�rio',11,3)
insert into tb_Cargos_Funcoes values (92, 'Escritur�rio',15,3)
insert into tb_Cargos_Funcoes values (92, 'ESCRITUR�RIO',3,3)
insert into tb_Cargos_Funcoes values (92, 'ESCRITUR�RIO',6,3)
insert into tb_Cargos_Funcoes values (92, 'ESCRITUR�RIO',7,3)
insert into tb_Cargos_Funcoes values (92, 'ESCRITUR�RIO',9,3)
insert into tb_Cargos_Funcoes values (92, 'ESCRITUR�RIO',17,3)
insert into tb_Cargos_Funcoes values (307, 'Lider',15,1)
insert into tb_Cargos_Funcoes values (307, 'Lider',16,1)
insert into tb_Cargos_Funcoes values (307, 'LIDER',1,1)
insert into tb_Cargos_Funcoes values (307, 'LIDER',3,1)
insert into tb_Cargos_Funcoes values (307, 'LIDER',11,1)
insert into tb_Cargos_Funcoes values (307, 'L�der',5,1)
insert into tb_Cargos_Funcoes values (307, 'L�der',14,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',7,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',16,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',2,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',4,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',6,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',9,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',10,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',17,1)
insert into tb_Cargos_Funcoes values (307, 'L�DER',18,1)
insert into tb_Cargos_Funcoes values (1895, 'LIDER DO SET UP',7,1)
insert into tb_Cargos_Funcoes values (1895, 'LIDER DO SET UP',15,1)
insert into tb_Cargos_Funcoes values (1895, 'LIDER DO SET UP',17,1)
insert into tb_Cargos_Funcoes values (433, 'MEC�NICO',2,2)
insert into tb_Cargos_Funcoes values (433, 'MEC�NICO',9,2)
insert into tb_Cargos_Funcoes values (433, 'MEC�NICO',10,2)
insert into tb_Cargos_Funcoes values (232, 'Mec�nico Kaizen',3,2)
insert into tb_Cargos_Funcoes values (232, 'Mec�nico Kaizen',5,2)
insert into tb_Cargos_Funcoes values (232, 'Mec�nico Kaizen',11,2)
insert into tb_Cargos_Funcoes values (232, 'Mec�nico Kaizen',15,2)
insert into tb_Cargos_Funcoes values (232, 'Mec�nico Kaizen',16,2)
insert into tb_Cargos_Funcoes values (232, 'MEC�NICO KAIZEN',17,2)
insert into tb_Cargos_Funcoes values (232, 'MEC�NICO KAIZEN',6,2)
insert into tb_Cargos_Funcoes values (232, 'MEC�NICO KAIZEN',7,2)
insert into tb_Cargos_Funcoes values (232, 'MEC�NICO KAIZEN',4,29)
insert into tb_Cargos_Funcoes values (232, 'Mec�nico Kaizen ',1,2)
insert into tb_Cargos_Funcoes values (2286, 'Monitor da qualidade',11,1)
insert into tb_Cargos_Funcoes values (2286, 'MONITOR DA QUALIDADE ',7,1)
insert into tb_Cargos_Funcoes values (2286, 'MONITOR DA QUALIDADE ',2,1)
insert into tb_Cargos_Funcoes values (2286, 'MONITOR DA QUALIDADE ',17,1)
insert into tb_Cargos_Funcoes values (2286, 'MONITOR DA QUALIDADE ',5,34)
insert into tb_Cargos_Funcoes values (2286, 'MONITOR DA QUALIDADE ',4,29)
insert into tb_Cargos_Funcoes values (2286, 'Monitor de Qualidade',15,1)
insert into tb_Cargos_Funcoes values (2286, 'Monitor de Qualidade',16,1)
insert into tb_Cargos_Funcoes values (2286, 'MONITOR DE QUALIDADE',3,1)
insert into tb_Cargos_Funcoes values (2286, 'MONITOR QUALIDADE',1,1)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',17,47)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',6,39)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',5,34)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',11,74)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',3,26)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',1,21)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',4,29)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',16,14)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',2,24)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',105,15)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',7,20)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',9,57)
insert into tb_Cargos_Funcoes values (2320, 'OPERADOR PRODUCAO I',10,16)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',11,73)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',17,46)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',8,56)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',10,72)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',16,78)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',5,34)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',3,26)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',1,21)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',4,29)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',6,38)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',2,24)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',105,15)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',7,20)
insert into tb_Cargos_Funcoes values (2321, 'OPERADOR PRODUCAO II',9,57)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',11,73)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',17,46)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',10,72)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',16,78)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',3,26)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',1,21)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',4,29)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',5,33)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',2,24)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',105,15)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',6,35)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',7,6)
insert into tb_Cargos_Funcoes values (2322, 'OPERADOR PRODUCAO III',9,11)
insert into tb_Cargos_Funcoes values (2317, 'OPERADOR VULCANIZACAO I',14,78)
insert into tb_Cargos_Funcoes values (2317, 'OPERADOR VULCANIZACAO I',16,78)
insert into tb_Cargos_Funcoes values (2317, 'OPERADOR VULCANIZACAO I',15,50)
insert into tb_Cargos_Funcoes values (2318, 'OPERADOR VULCANIZACAO II',15,50)
insert into tb_Cargos_Funcoes values (2318, 'OPERADOR VULCANIZACAO II',16,54)
insert into tb_Cargos_Funcoes values (2319, 'OPERADOR VULCANIZACAO III',15,50)
insert into tb_Cargos_Funcoes values (2319, 'OPERADOR VULCANIZACAO III',16,54)
insert into tb_Cargos_Funcoes values (134, 'PREPARADOR DE M�QUINA ',16,78)
insert into tb_Cargos_Funcoes values (134, 'PREPARADOR DE M�QUINA ',17,6)
insert into tb_Cargos_Funcoes values (134, 'PREPARADOR DE M�QUINA ',7,6)
insert into tb_Cargos_Funcoes values (134, 'PREPARADOR MAQUINAS',11,6)
insert into tb_Cargos_Funcoes values (122, 'TROCADOR',14,6)
insert into tb_Cargos_Funcoes values (122, 'TROCADOR',15,6)
insert into tb_Cargos_Funcoes values (122, 'TROCADOR',16,6)
insert into tb_Cargos_Funcoes values (159, 'Vulcanizador BIAS',14,49)
