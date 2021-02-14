use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PerguntaPai]    Script Date: 12/01/2021 08:33:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_Preenchimento](
	 @id_formulario		INT = NULL	
	,@idRetorno					  INT OUTPUT)
	AS
	BEGIN

	SET NOCOUNT ON 

	INSERT INTO dbo.tb_Preenchimento(
				id_formulario
				)
		VALUES(
				@id_formulario
				);

	SET @idRetorno=SCOPE_IDENTITY()
	RETURN  @idRetorno

	END;