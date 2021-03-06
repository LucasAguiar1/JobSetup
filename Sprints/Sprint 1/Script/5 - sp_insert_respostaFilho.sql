use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_respostaFilho]    Script Date: 12/01/2021 09:02:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_respostaFilho](
	 @idFilho						INT
	 ,@idPai						INT
	 ,@valor                 		nvarchar(max)
	 ,@id_tipoResposta				INT
	 ,@idUsuario                    nvarchar(50)
	 ,@nomeUsuario                  nvarchar(max)
	 ,@idPreenchimento				bigint
	 ,@idsAlternativa               nvarchar(max)  
	 ,@idRetorno					INT OUTPUT)
	AS
	BEGIN
	SET NOCOUNT ON 

	INSERT INTO dbo.tb_RespostaFilho(
				idFilho			
				,idPai			
				,valor
				,id_tipoResposta	
				,idUsuario
				,nomeUsuario
				,dataResposta
				,idPreenchimento
				,idsAlternativa 
				)
		VALUES(
				@idFilho			
				,@idPai			
				,@valor
				,@id_tipoResposta	
				,@idUsuario
				,@nomeUsuario
				,GETDATE()
				,@idPreenchimento
				,@idsAlternativa 
				);

	SET @idRetorno=SCOPE_IDENTITY()
	RETURN  @idRetorno

	END;