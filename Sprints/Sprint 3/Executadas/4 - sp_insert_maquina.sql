USE [JobSetupPREPROD]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_maquina]    Script Date: 06/02/2021 07:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_insert_maquina](
	 @nome			  NVARCHAR(100)= NULL
	,@status				  INT = NULL
	,@idUsuario       NVARCHAR(200)= NULL
	,@tipo            NVARCHAR(1)= NULL
	,@id_departamento		  INT = NULL
	,@i_Pk_Maquina            INT = NULL
	,@vc_Descripcion          NVARCHAR(MAX) = NULL
	,@codigoTess              NVARCHAR(30) = NULL
	,@idRetorno				  INT OUTPUT)
	AS
	BEGIN
	SET NOCOUNT ON 

	INSERT INTO dbo.tb_maquina (
				nome			 
				,status		
				,idUsuario      
				,tipo           
				,id_departamento
				,dataRegistro
				,i_Pk_Maquina
				,vc_Descripcion
				,codigoTess
				
				)
		VALUES(
				 @nome			 
				,@status		
				,@idUsuario      
				,@tipo           
				,@id_departamento
				,GETDATE()
				,@i_Pk_Maquina
				,@vc_Descripcion
				,@codigoTess
				);

	SET @idRetorno=SCOPE_IDENTITY()
	RETURN  @idRetorno

	END;
