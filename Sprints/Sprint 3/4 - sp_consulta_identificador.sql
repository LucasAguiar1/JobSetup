USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_maquinas]    Script Date: 10/02/2021 14:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_consulta_identificador]
		@idPreenchimento int = NULL
AS
BEGIN
	
	select 
	id,
	idPreenchimento,
	identificadoLote
	FROM 
	tb_identificador
	WHERE idPreenchimento = @idPreenchimento
	
END;
