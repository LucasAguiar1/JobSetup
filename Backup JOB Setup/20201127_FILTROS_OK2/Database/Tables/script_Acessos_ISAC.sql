use ISAC_1
GO

insert into [dbo].tblSystem values ('Libras', 'Novo Sistema Libras Homem Hora')    -- 114
-- select * from tblSystem where chrs_name = 'Libras' order by 2

insert into [dbo].tblprofile values ('LHH Adm', 'Acesso Total ao Sistema Libras')  -- 157
insert into [dbo].tblprofile values ('LHH Lider', 'Acesso de Lider')			   -- 158
-- select * from tblprofile order by 2

insert into [dbo].tblSystem_profile values (157, 114)
insert into [dbo].tblSystem_profile values (158, 114)
-- select * from tblSystem_profile where ints_id = 114

insert into [dbo].tblSystem_Plant values ('15', 114)
-- select * from tblSystem_Plant where ints_id = 114

-- select * from tblUser where chrfirstname like '%ricardo%'						   -- RADM --78155	--Ricardo Afonso de Melo --RADM
-- select * from tblUser where chrfirstname like '%tiago%' and chrlogin = 'TIWR'      -- TIWR --463181	--Tiago Wilson Ribeiro   --RibeiroTiago
update tblUser set chrNetworkLogin = 'RibeiroTiago' where chrfirstname like '%tiago%' and chrlogin = 'TIWR'

insert into [dbo].tblUser_Profile values (157, 'RADM', 114)
insert into [dbo].tblUser_Profile values (157, 'TIWR', 114)
-- select * from tblUser_Profile where ints_id in (114)

insert into [dbo].tblFunction values ('LHH_C_FCH', 'Acesso ao Calend�rio')
insert into [dbo].tblFunction values ('LHH_E_FCH', 'Permiss�o de Edi��o no Calend�rio')
insert into [dbo].tblFunction values ('LHH_C_CC', 'Acesso ao Centro de Custo')
insert into [dbo].tblFunction values ('LHH_E_CC', 'Permiss�o de Edi��o no Centro de Custo')
insert into [dbo].tblFunction values ('LHH_C_CTT', 'Acesso aos Valores de Servi�os e contratos')
insert into [dbo].tblFunction values ('LHH_E_CTT', 'Permiss�o de edi��o nos Servi�os e contratos')
insert into [dbo].tblFunction values ('LHH_I_CTT', 'Importa��o das planilhas de contratos de servi�os')

insert into [dbo].tblFunction values ('LHH_P_FCH', 'Processa Fechamento')
insert into [dbo].tblFunction values ('LHH_C_FNC', 'Acesso ao formul�rio principal - �Fun��es"')
insert into [dbo].tblFunction values ('LHH_E_FNC', 'Acesso ao formul�rio de edi��o - �Fun��es"')
insert into [dbo].tblFunction values ('LHH_C_PRM', 'Acesso ao formul�rio principal - �Par�metros"')
insert into [dbo].tblFunction values ('LHH_E_PRM', 'Acesso ao formul�rio de inclus�o - �Par�metros"')
insert into [dbo].tblFunction values ('LHH_C_PSA', 'Acesso ao formul�rio principal - �Peso Armazenado"')
insert into [dbo].tblFunction values ('LHH_C_REC', 'Acesso ao formul�rio principal - �Recursos�')
insert into [dbo].tblFunction values ('LHH_C_REL', 'Acesso ao formul�rio principal - �Relat�rios"')

insert into [dbo].tblFunction values ('LHH_D_CTT', 'Detalhamento do Contrato de Servi�o')
insert into [dbo].tblFunction values ('LHH_C_SBU', 'Consulta da distribui��o do produtivo de Categoria')
insert into [dbo].tblFunction values ('LHH_E_SBU', 'Edi��o da distribui��o do produtivo de Categoria')
insert into [dbo].tblFunction values ('LHH_K_REC', 'C�lculo da distribui��o do produtivo de Categoria')
insert into [dbo].tblFunction values ('LHH_E_REC', 'Acesso a atribui��o de fun��o ao recurso')
insert into [dbo].tblFunction values ('LHH_C_EXC', 'Consulta de Exce��o de Recurso')
insert into [dbo].tblFunction values ('LHH_E_EXC', 'Edi��o de Exce��o de Recurso')
insert into [dbo].tblFunction values ('LHH_C_TRF', 'Consulta de Transfer�ncia de Recurso')
insert into [dbo].tblFunction values ('LHH_E_TRF', 'Edi��o de Transfer�ncia de Recurso')


-- select * from tblFunction order by 2

select * from tblFunction where chrfunction like 'LHH_%' ORDER BY 1
select * from [dbo].tblFunction_Profile where chrfunction like 'LHH_%' order by 1

update tblFunction set chrfunction = 'LHH_E_FCH' where intf_id = 189
update [dbo].tblFunction_Profile set chrfunction = 'LHH_E_FCH', chrf_desc = 'LHH_E_FCH' where chrfunction = 'LHH_E_CALEND'


insert into [dbo].tblFunction_Profile values ('LHH_C_FCH', 114, 'LHH_C_FCH', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_FCH', 114, 'LHH_E_CALEND', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_CC', 114, 'LHH_C_CC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_CC', 114, 'LHH_E_CC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_CTT', 114, 'LHH_C_CTT', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_CTT', 114, 'LHH_E_CTT', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_I_CTT', 114, 'LHH_I_CTT', 157, 1)

insert into [dbo].tblFunction_Profile values ('LHH_P_FCH', 114, 'LHH_P_FCH', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_FNC', 114, 'LHH_C_FNC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_FNC', 114, 'LHH_E_FNC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_PRM', 114, 'LHH_C_PRM', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_PRM', 114, 'LHH_E_PRM', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_PSA', 114, 'LHH_C_PSA', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_REC', 114, 'LHH_C_REC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_REL', 114, 'LHH_C_REL', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_D_CTT', 114, 'LHH_D_CTT', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_SBU', 114, 'LHH_C_SBU', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_SBU', 114, 'LHH_E_SBU', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_K_REC', 114, 'LHH_K_REC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_REC', 114, 'LHH_E_REC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_EXC', 114, 'LHH_C_EXC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_E_EXC', 114, 'LHH_E_EXC', 157, 1)
insert into [dbo].tblFunction_Profile values ('LHH_C_TRF', 114, 'LHH_C_TRF', 157, 1)

-- select * from tblFunction_Profile where ints_id = 114

insert into [dbo].tblFunction_system values (188, 114)
insert into [dbo].tblFunction_system values (190, 114)
insert into [dbo].tblFunction_system values (195, 114)
insert into [dbo].tblFunction_system values (189, 114)
insert into [dbo].tblFunction_system values (191, 114)
insert into [dbo].tblFunction_system values (197, 114)
insert into [dbo].tblFunction_system values (194, 114)

insert into [dbo].tblFunction_system values (198, 114)
insert into [dbo].tblFunction_system values (202, 114)
insert into [dbo].tblFunction_system values (203, 114)
insert into [dbo].tblFunction_system values (204, 114)
insert into [dbo].tblFunction_system values (205, 114)
insert into [dbo].tblFunction_system values (206, 114)
insert into [dbo].tblFunction_system values (207, 114)
insert into [dbo].tblFunction_system values (214, 114)
insert into [dbo].tblFunction_system values (216, 114)
insert into [dbo].tblFunction_system values (217, 114)
insert into [dbo].tblFunction_system values (218, 114)
insert into [dbo].tblFunction_system values (219, 114)
insert into [dbo].tblFunction_system values (220, 114)
insert into [dbo].tblFunction_system values (221, 114)
insert into [dbo].tblFunction_system values (222, 114)
insert into [dbo].tblFunction_system values (223, 114)
insert into [dbo].tblFunction_system values (224, 114)
-- select * from tblFunction_system where ints_id = 114
