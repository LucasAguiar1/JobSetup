USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_maquina]    Script Date: 16/01/2021 09:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_update_Formulario_Ordem] (
	@id_formulario         INT = NULL, 
	@id				       INT = NULL,
	@id_formulario_Filho   INT = NULL,
	@idusuarioAlt		   nvarchar(max) = NULL,
	@tipo                NVARCHAR(1) = NULL,
	@id_departamento	   INT = NULL,
	@ordem				   INT = NULL
	)
AS
BEGIN

	UPDATE tb_Formulario_Ordem
	set
	idusuarioAlt	= @idusuarioAlt ,dataRegistroAlt =  GETDATE() ,tipo = @tipo ,ordem =@ordem				
	WHERE id_departamento	 = @id_departamento	 
	AND   id   = @id AND  id_formulario_Filho = @id_formulario_Filho 
	AND  id_formulario   = @id_formulario      
	

END;
