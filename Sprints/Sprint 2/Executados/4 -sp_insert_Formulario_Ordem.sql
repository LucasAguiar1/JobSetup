USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_departamento]    Script Date: 16/01/2021 09:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



	ALTER PROCEDURE [dbo].[sp_insert_Formulario_Ordem] 
	@id_formulario         INT = NULL, 
	@id_formulario_Filho   INT = NULL,
	@idUsuario			   nvarchar(max) = NULL,
	@tipo                NVARCHAR(1) = NULL,
	@id_departamento	   INT = NULL,
	@ordem				   INT = NULL,
	@idRetorno			  INT OUTPUT




	AS
	BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.tb_Formulario_Ordem(
				 id_formulario      
				,id_formulario_Filho
				,dataRegistro		
				,idUsuario			
				,tipo               
				,id_departamento	
				,ordem				
				)
		VALUES(
				@id_formulario      
				,@id_formulario_Filho
				,GETDATE()		
				,@idUsuario			
				,@tipo               
				,@id_departamento	
				,@ordem				
				);

	SET @idRetorno=SCOPE_IDENTITY()
	RETURN  @idRetorno

	END;
