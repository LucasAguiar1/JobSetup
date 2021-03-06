USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_maquina]    Script Date: 10/02/2021 14:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insert_identificadorLote](
	 @idPreenchimento		  INT = NULL
	,@identificadoLote        NVARCHAR(50) = NULL
	,@idRetorno				  INT OUTPUT)
	AS
	BEGIN
	SET NOCOUNT ON 

	INSERT INTO dbo.tb_identificador (
				idPreenchimento ,
				identificadoLote

				)
		VALUES(
				@idPreenchimento,
				@identificadoLote);

	SET @idRetorno=SCOPE_IDENTITY()
	RETURN  @idRetorno

	END;
