USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Formulario_Ordem]    Script Date: 16/01/2021 11:35:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_Delete_Formulario_Ordem](
	--@id						INT = NULL,
	@id_formulario			INT = NULL,	  
	@id_formulario_Filho	INT = NULL,
	@id_departamento		INT = NULL
	)
	AS
	BEGIN
	SET NOCOUNT ON 

	DELETE FROM tb_Formulario_Ordem WHERE 
	--id = @id
	 id_formulario  =@id_formulario 
	AND id_formulario_Filho = @id_formulario_Filho
	AND id_departamento = @id_departamento


	END;
