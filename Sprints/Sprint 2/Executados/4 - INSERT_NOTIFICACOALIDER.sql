USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_notificacaolider]    Script Date: 19/01/2021 14:51:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_insert_notificacaolider](
	 @notificacao            	NVARCHAR(MAX)= NULL
	,@id_formulario				INT = NULL
	,@id_lider					NVARCHAR(MAX)= NULL
	,@id_usuario				NVARCHAR(MAX)= NULL
	,@id_nomeOperador			NVARCHAR(MAX)= NULL
	
	,@idRetorno					INT OUTPUT)
	AS
	BEGIN
	SET NOCOUNT ON 

	INSERT INTO dbo.tb_Notificacao(
				notificacao       
				,id_formulario		
				,id_lider			
				,id_usuario		
				,id_nomeOperador	
				,dataNotificacao	
				)
		VALUES(
				@notificacao       
				,@id_formulario		
				,@id_lider			
				,@id_usuario		
				,@id_nomeOperador	
				,GETDATE()	
				);

	SET @idRetorno=SCOPE_IDENTITY()
	RETURN  @idRetorno

	END;