USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_dataleituraLider]    Script Date: 20/01/2021 16:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_update_dataleituraLider] (
	 --@id_lider				  NVARCHAR(MAX),
	 @id            		  INT = NULL,
	 @nomeLider               NVARCHAR(MAX),
	 @result INT OUTPUT
	)
AS
BEGIN

	UPDATE tb_Notificacao
	SET  --id_lider = @id_lider,
			nomeLider  = @nomeLider,
		 dataLeitura = GETDATE()
	WHERE id   = @id
	
	SET @result = @@ROWCOUNT

END;


