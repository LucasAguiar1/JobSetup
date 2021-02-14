/*
INSERT INTO tb_Parametros VALUES ('Número de Dias de Experiência', '30')
INSERT INTO tb_Parametros VALUES ('Horas Produtivas por Dia', '7,33')
INSERT INTO tb_Parametros VALUES ('Base diária para Serviços contratados', '28,73')
INSERT INTO tb_parametros VALUES ('Controle Experiência', '2019-05-01', 1, 'DAT')
INSERT INTO tb_parametros VALUES ('Lista Distribuição por email do Sistema', 'meloricardo@prestador.la-bridgestone.com; ribeirotiago@la-bridgestone.com', 0, 'LST')
INSERT INTO tb_parametros VALUES ('Controle Peso Armazenado', '2019-05-01', 1, 'DAT')
INSERT INTO tb_parametros VALUES ('Recursos sem pontos Horas/Dia', '8,68', 0, 'NUM')

INSERT INTO tb_Dominios VALUES ('Geral')
INSERT INTO tb_Dominios VALUES ('Periodo')
INSERT INTO tb_Dominios VALUES ('Exceções')
insert into tb_Dominios values ('Recursos')

INSERT INTO tb_situacoes VALUES ('Ativo', 1)
INSERT INTO tb_situacoes VALUES ('Inativo', 1)
INSERT INTO tb_situacoes VALUES ('Aberto', 2)
INSERT INTO tb_situacoes VALUES ('Futuro', 2)
INSERT INTO tb_situacoes VALUES ('Fechado', 2)
insert into tb_Situacoes values ('Afastado', 4)
insert into tb_Situacoes values ('Demitido', 4)
insert into tb_Situacoes values ('Férias', 4)
insert into tb_Situacoes values ('Ativo', 4)

INSERT INTO TB_CATEGORIAS VALUES ('PSR', 'PSR/LTR', 1)
INSERT INTO TB_CATEGORIAS VALUES ('LTR', 'PSR/LTR', 1)
INSERT INTO TB_CATEGORIAS VALUES ('TBR', 'TBR', 1)
INSERT INTO TB_CATEGORIAS VALUES ('AGS', 'AGS', 1)
INSERT INTO TB_CATEGORIAS VALUES ('AGR', 'AGR', 1)
INSERT INTO TB_CATEGORIAS VALUES ('GRADDER', 'ORS', 1)
INSERT INTO TB_CATEGORIAS VALUES ('A2', 'ORS', 1)
INSERT INTO TB_CATEGORIAS VALUES ('ORR', 'ORR', 1)

INSERT INTO tb_tipos (cd_tipo, nm_tipo, id_situacao) VALUES (1, 'Produtivo', 1)
INSERT INTO tb_tipos (cd_tipo, nm_tipo, id_situacao) VALUES (2, 'Serviços', 1)
INSERT INTO tb_tipos (cd_tipo, nm_tipo, id_situacao) VALUES (3, 'Educação', 1)
INSERT INTO tb_tipos (cd_tipo, nm_tipo, id_situacao) VALUES (9, 'Outros', 1)

INSERT INTO tb_Areas(nm_area, id_situacao) VALUES ('Área 01', 1)
INSERT INTO tb_Areas(nm_area, id_situacao) VALUES ('Área 02', 1)
INSERT INTO tb_Areas(nm_area, id_situacao) VALUES ('Área 03', 1)
INSERT INTO tb_Areas(nm_area, id_situacao) VALUES ('Área 00', 1)

INSERT INTO [tb_Classificacoes] (nm_classificacao, id_situacao) VALUES ('Direct', 1)
INSERT INTO [tb_Classificacoes] (nm_classificacao, id_situacao) VALUES ('Indirect', 1)
INSERT INTO [tb_Classificacoes] (nm_classificacao, id_situacao) VALUES ('Light Duty', 1)
INSERT INTO [tb_Classificacoes] (nm_classificacao, id_situacao) VALUES ('Service', 1)
INSERT INTO [tb_Classificacoes] (nm_classificacao, id_situacao) VALUES ('NTP', 1)
INSERT INTO [tb_Classificacoes] (nm_classificacao, id_situacao) VALUES ('NTS', 1)

INSERT INTO tb_Motivos values ('Treinamento', 1, 3)
INSERT INTO tb_Motivos values ('Tratamento Médico', 1, 3)
INSERT INTO tb_Motivos values ('Novo Equipamento', 1, 3)
INSERT INTO tb_Motivos values ('Pintura de Máquina', 1, 3)
INSERT INTO tb_Motivos values ('Atuando em Serviços Externos', 1, 3)


insert into tb_Periodos values ('2019-02-01', '2019-02-01 00:00:00', '2019-02-28 23:59:59', 0, 0, 5)
insert into tb_Periodos values ('2019-03-01', '2019-03-01 00:00:00', '2019-03-31 23:59:59', 0, 0, 5)
insert into tb_Periodos values ('2019-04-01', '2019-04-01 00:00:00', '2019-04-30 23:59:59', 0, 0, 3)
insert into tb_calendarios values ('2019-04-01', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-02', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-03', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-04', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-05', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-06', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-07', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-08', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-09', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-10', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-11', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-12', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-13', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-14', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-15', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-16', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-17', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-18', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-19', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-20', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-21', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-22', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-23', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-24', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-25', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-26', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-27', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-28', 0, null, null, null, 0, 3, 1);
insert into tb_calendarios values ('2019-04-29', 0, null, null, null, 0, 3, 1); insert into tb_calendarios values ('2019-04-30', 0, null, null, null, 0, 3, 1);

select * from tb_calendarios
update tb_calendarios set dv_ignorar_producao_dia = 1, ds_ignorar_producao_dia_motivo = 'Piquete do Sindicato na Fábrica' where id_calendario = 1
update tb_calendarios set nr_horas_ajuste = 300, ds_ignorar_producao_dia_motivo = 'Falha Geral de Energia' where id_calendario = 2
*/
/*
 select * from tb_Dominios
 select * from tb_situacoes
 select * from tb_tipos
 select * from tb_Areas
 select * from tb_Classificacoes
 select * from tb_CentroCusto
 select * from tb_Motivos
 select * from tb_Periodos
 select * from tb_calendarios
 select * from tb_parametros
 select * from tb_Funcoes
 select * from tb_contratos
 select * from tb_contratos_itens
 select * from tb_contratos_funcoes
 select * from tb_Contratos_Importacao
 select * from tb_recursos
 select * from tb_recursos_pontosRH
 select top 20 * from tb_log_processos where dt_log_processo > '2019-05-02 06:39:27.833' order by 2 desc
*/

/*
delete tb_Contratos_Importacao
delete tb_contratos_funcoes
delete tb_contratos_itens
delete tb_contratos
delete [dbo].[tb_Contratos_Rateio_Funcoes]

delete [dbo].[tb_Fechamentos_Categoria_Mensal]
delete [dbo].[tb_Fechamentos_CentroCusto_Diario]
delete [dbo].[tb_Fechamentos_CentroCusto_Mensal]
delete [dbo].[tb_Fechamentos_CentroCusto_Mensal_Categoria]

delete tb_recursos_pontosRH
delete tb_Recursos_Excecoes
delete tb_Recursos_transferencias
delete tb_Periodos_Recursos
delete tb_Experiencias
delete tb_recursos

delete [dbo].[tb_CentroCusto_Categorias]
delete [dbo].[tb_Funcoes_CentroCusto]
delete tb_CentroCusto
delete tb_Funcoes
*/

/*
select * from tb_CentroCusto
select * from tb_CentroCusto_Categorias
select * from tb_Funcoes
select * from [tb_Contratos_Rateio_Funcoes]

select * from tb_recursos_pontosRH
select * from tb_Periodos_Recursos
select * from tb_recursos

delete [dbo].[tb_Funcoes_CentroCusto]

delete tb_Contratos_Importacao
delete tb_contratos_funcoes
delete tb_contratos_itens
delete tb_contratos
*/







