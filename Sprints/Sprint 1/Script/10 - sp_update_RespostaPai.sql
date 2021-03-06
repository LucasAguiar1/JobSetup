use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_update_RespostaPai]    Script Date: 13/01/2021 07:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_RespostaPai](
	 @id_Formulario			INT
	 ,@id                   INT
	 ,@idPai                INT 
	 ,@id_tipoResposta      INT   
	 ,@valor                NVARCHAR(MAX)
	 ,@idUsuario            NVARCHAR(10)
	 ,@nomeUsuario          NVARCHAR(MAX)
	 ,@status               NVARCHAR(10)
	,@idRetorno				INT OUTPUT
	)
AS
BEGIN

	UPDATE tb_RespostaPai 
	SET valor = @valor
	, [status]= @status
	, nomeUsuario = @nomeUsuario
	, dataResposta = GETDATE()
	WHERE id_Formulario = @id_Formulario 
	AND id  = @id 
	AND idPai = @idPai 
	AND id_tipoResposta =@id_tipoResposta
		
	SET @idRetorno = @@ROWCOUNT

END;