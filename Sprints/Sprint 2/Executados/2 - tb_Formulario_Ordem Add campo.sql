USE [JobSetupPREPROD]
GO
ALTER TABLE tb_Formulario_Ordem
ADD id_departamento int;
GO
ALTER TABLE tb_Formulario_Ordem
ADD ordem int;