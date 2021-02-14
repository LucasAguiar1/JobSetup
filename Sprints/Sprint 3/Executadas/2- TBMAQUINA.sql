USE JobSetupPREPROD

ALTER TABLE tb_maquina ADD i_Pk_Maquina INT;
ALTER TABLE tb_maquina ADD vc_Descripcion NVARCHAR(MAX)
ALTER TABLE tb_maquina ADD codigoTess NVARCHAR(30)