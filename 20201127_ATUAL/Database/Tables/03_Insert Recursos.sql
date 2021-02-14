/*
-- select * from tb_CentroCusto
-- select * from tb_Funcoes_CentroCusto where id_cc = 1
-- select * from tb_recursos
-- select * from tb_Periodos_Recursos
-- select * from tb_calendarios
-- select * from tb_Periodos

update tb_Periodos set id_situacao = 5
-- select * from TB_FUNCOES
-- select * from tb_classificacoes
-- select * from TB_FUNCOES_CENTROCUSTO
*/



/*
--DBCC CHECKIDENT ('tb_recursos', RESEED, 0)
--DBCC CHECKIDENT ('tb_Periodos_Recursos', RESEED, 0)
--DBCC CHECKIDENT ('tb_Recursos_PontosRH', RESEED, 0)

INSERT INTO TB_RECURSOS (cd_rl, nm_recurso, qt_dias_experiencia, dv_calculo_remover, ds_rh_status, ds_rh_regime_trabalho, ds_rh_cargo, dt_entrada, id_cc, id_funcao, id_situacao, ds_escala)
    VALUES ('335841','WILSON APARECIDO SANTANA',0,0,'ativo','MENSALISTA','SUPERVISOR OFICINA','1979-10-24', 17, 46, 1, '6x1')

INSERT INTO TB_RECURSOS (cd_rl, nm_recurso, qt_dias_experiencia, dv_calculo_remover, ds_rh_status, ds_rh_regime_trabalho, ds_rh_cargo, dt_entrada, id_cc, id_funcao, id_situacao, ds_escala)
    VALUES ('483743','JOSE SERGIO MARCHIORI',0,0,'ativo','MENSALISTA','GERENTE PRODUCAO AREA','1980-01-25', 1, 21, 1, '6x1')

INSERT INTO tb_Periodos_Recursos VALUES (1, 3, 150, 0, 0, 1, 46, 0)
INSERT INTO tb_Periodos_Recursos VALUES (1, 4, 160, 0, 0, 21, 1, 0)

begin
declare @inicio datetime = '2020-01-01 06:00:00', @fim datetime = '2020-01-31 14:00:00', 
		@competencia date = '2020-01-01', @final date = '2020-02-01', 
		@periodoRecurso int = 2

while @competencia < @final begin
	insert into dbo.tb_Recursos_PontosRH values (@periodoRecurso, @competencia, 8, @inicio, @fim, 1)
	set @competencia = dateadd(dd, 1, @competencia)
	set @inicio = dateadd(dd, 1, @inicio)
	set @fim = dateadd(dd, 1, @fim)
	end
end 

begin
declare @inicio datetime = '2019-03-01', @fim datetime = '2019-03-31'

while @inicio < @fim begin
	insert into tb_calendarios values (@inicio, 0, null, null, null, 0, 2, 1); 
	set @inicio = dateadd(dd, 1, @inicio)
	end
end 

insert into tb_pesos_armazenados
select id_categoria, dateadd(mm, -1, dt_referencia), qt_peso_armazenado
 from tb_pesos_armazenados where dt_referencia between '2019-04-01' and '2019-04-30'

select * from tb_Recursos_PontosRH


INSERT INTO TB_RECURSOS (cd_rl, nm_recurso, qt_dias_experiencia, dv_calculo_remover, ds_rh_status, ds_rh_regime_trabalho, ds_rh_cargo, dt_entrada, id_cc, id_funcao, id_situacao)
    VALUES ('286557','JAUDI FERNANDES DE SOUZA',0,0,'ativo','HORISTAS','MECANICO MANUTENCAO','1974-05-16', 17, 46, 1)

INSERT INTO TB_RECURSOS (cd_rl, nm_recurso, qt_dias_experiencia, dv_calculo_remover, ds_rh_status, ds_rh_regime_trabalho, ds_rh_cargo, dt_entrada, id_cc, id_funcao, id_situacao)
    VALUES ('343305','YVAN NLADEN JURICIC',0,0,'ativo','MENSALISTA','TECNICO PROJETOS ELETRONICOS SR','1980-10-21', 57, 50, 1)
	
INSERT INTO TB_RECURSOS (cd_rl, nm_recurso, qt_dias_experiencia, dv_calculo_remover, ds_rh_status, ds_rh_regime_trabalho, ds_rh_cargo, dt_entrada, id_cc, id_funcao, id_situacao)
    VALUES ('487532','JOSÉ DA SILVA',0,0,'ativo','MENSALISTA','OPERADOR','1990-01-25', 63, 73, 1)

INSERT INTO tb_Periodos_Recursos VALUES (2, 1, 150, 0, 0, null, null)
INSERT INTO tb_Periodos_Recursos VALUES (2, 2, 160, 0, 0, null, null)
INSERT INTO tb_Periodos_Recursos VALUES (2, 3, 160, 0, 0, null, null)

update pr
  set pr.id_cc = p.id_cc, pr.id_funcao = p.id_funcao
 from tb_Periodos_Recursos pr 
		inner join tb_recursos p on p.id_recurso = pr.id_recurso

insert into [dbo].[tb_Recursos_Excecoes] values (6, '2019-04-12', 4, 1, 1)
insert into [dbo].[tb_Recursos_Excecoes] values (7, '2019-04-13', 4, 1, 1)
insert into [dbo].[tb_Recursos_Excecoes] values (7, '2019-04-18', 4, 3, 1)
insert into [dbo].[tb_Recursos_Excecoes] values (8, '2019-04-21', 8, 3, 1)
insert into [dbo].[tb_Recursos_Excecoes] values (9, '2019-04-28', 4, 1, 1)
insert into [dbo].[tb_Recursos_Excecoes] values (6, '2019-04-08', 4, 2, 1)

select * from tb_Periodos_Recursos
insert into dbo.tb_Recursos_PontosRH (id_periodo_recurso, dt_referencia, qt_horas, dt_inicio, dt_fim, id_situacao)

insert into dbo.tb_Recursos_PontosRH values (6, '2019-04-01', 8, '2019-04-01 06:00:00', '2019-04-01 14:00:00', 1)
insert into dbo.tb_Recursos_PontosRH values (6, '2019-04-02', 8, '2019-04-02 06:00:00', '2019-04-02 14:00:00', 1)

SELECT * FROM TB_FUNCOES
UPDATE TB_FUNCOES SET CD_OPERACAO = CONVERT(VARCHAR, ID_FUNCAO)
UPDATE TB_RECURSOS SET ID_FUNCAO = NULL WHERE ID_RECURSO = 3



insert into tb_Pesos_Armazenados values (1, '2019-04-19', 109440.992)
insert into tb_Pesos_Armazenados values (2, '2019-04-19', 104521.842)
insert into tb_Pesos_Armazenados values (4, '2019-04-19', 22853.754)
insert into tb_Pesos_Armazenados values (7, '2019-04-19', 9366.982)
insert into tb_Pesos_Armazenados values (3, '2019-04-19', 442669.865)
insert into tb_Pesos_Armazenados values (5, '2019-04-19', 15863.791)
insert into tb_Pesos_Armazenados values (6, '2019-04-19', 2093.974)

insert into tb_Pesos_Armazenados values (1, '2019-04-20', 109440.992)
insert into tb_Pesos_Armazenados values (2, '2019-04-20', 104521.842)
insert into tb_Pesos_Armazenados values (4, '2019-04-20', 22853.754)
insert into tb_Pesos_Armazenados values (7, '2019-04-20', 9366.982)
insert into tb_Pesos_Armazenados values (3, '2019-04-20', 442669.865)
insert into tb_Pesos_Armazenados values (5, '2019-04-20', 15863.791)
insert into tb_Pesos_Armazenados values (6, '2019-04-20', 2093.974)
*/