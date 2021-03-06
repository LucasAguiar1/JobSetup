use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_update_respostapergunta]    Script Date: 13/01/2021 09:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_respostaFilho](
	  @id                   INT
	 ,@idFilho              INT
	 ,@idPai                INT 
	 ,@id_tipoResposta      INT   
	 ,@valor                NVARCHAR(MAX)
	 ,@nomeUsuario          NVARCHAR(MAX)
	 ,@idUsuario			NVARCHAR(50)
	,@idRetorno				INT OUTPUT
	)
AS
BEGIN

	UPDATE tb_RespostaFilho 
	SET valor = @valor,
	dataResposta = GETDATE(),
	nomeUsuario  = @nomeUsuario, 
	idUsuario	 = @idUsuario	
	WHERE id  = @id 
	AND idPai = @idPai 
	AND id_tipoResposta =@id_tipoResposta
	and idFilho = @idFilho
		
	SET @idRetorno = @@ROWCOUNT

END;
