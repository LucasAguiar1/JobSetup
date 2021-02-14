USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_OrdemFormularioformulario]    Script Date: 16/01/2021 08:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[sp_consulta_OrdemFormularioformulario]
				@id_Formulario int = NULL
				--@id_departamento int = NULL
AS
BEGIN
	
	SELECT id
      ,id_formulario
      ,id_formulario_filho
      ,dataRegistro
      ,idUsuarioAlt
      ,idUsuario
      ,dataRegistroAlt
      ,tipo
      ,id_departamento
      ,ordem
  FROM tb_Formulario_Ordem
  WHERE id_formulario = @id_Formulario
  
END;
