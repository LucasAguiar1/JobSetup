use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PerguntaPai]    Script Date: 12/01/2021 08:33:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_RespostaPai](
	 @idPai				INT= NULL
	,@id_tipoResposta	INT = NULL
	,@valor				nvarchar(max) = NULL
	,@status			nvarchar(10) = NULL
	,@idUsuario		    nvarchar(10) = NULL
	,@nomeUsuario		VARCHAR(max) = NULL
	,@id_formulario		INT = NULL
	,@idPreenchimento	bigint
	,@idsAlternativa    NVARCHAR(MAX)
	,@idRetorno					  INT OUTPUT)
	AS
	BEGIN

	SET NOCOUNT ON 

	INSERT INTO dbo.tb_RespostaPai(
				idPai,
				id_tipoResposta,
				valor,
				status,
				idUsuario,
				nomeUsuario,
				dataResposta,
				id_formulario,
				idPreenchimento,
				idsAlternativa 
				)
		VALUES(
				@idPai,
				@id_tipoResposta,
				@valor,
				@status,
				@idUsuario,
				@nomeUsuario,
				GETDATE(),
				@id_formulario,
				@idPreenchimento,
				@idsAlternativa 
				);

	SET @idRetorno=SCOPE_IDENTITY()
	RETURN  @idRetorno

	END;