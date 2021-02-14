USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_dataleituraLider]    Script Date: 20/01/2021 16:40:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_update_ObsLider] (
	 
	 @id         INT = NULL,
	 @nomeLider NVARCHAR(MAX),
	 @id_liderObs NVARCHAR(MAX),
	 @observacaoLider NVARCHAR(MAX),
	 @result INT OUTPUT
	)
AS
BEGIN

	UPDATE tb_Notificacao
	SET		
			id_liderObs = @id_liderObs,
			nomeLider  = @nomeLider,
			observacaoLider = @observacaoLider,
			dataObsLider = GETDATE()
	WHERE id   = @id
	
	SET @result = @@ROWCOUNT

END;




select * from tb_Notificacao