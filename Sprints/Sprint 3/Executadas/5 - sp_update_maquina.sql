USE [JobSetupPREPROD]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_maquina]    Script Date: 06/02/2021 08:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_update_maquina] (
	 @id         		INT
	,@nome			    VARCHAR(100)= NULL
	,@status			INT = NULL
	,@tipo				NVARCHAR(1) = NULL
	,@idUsuarioAlt	    NVARCHAR(200) = NULL
	,@i_Pk_Maquina       INT = NULL
	,@vc_Descripcion     NVARCHAR(MAX)
	,@codigoTess         NVARCHAR(30)
	,@id_departamento   INT
	)
AS
BEGIN

	UPDATE tb_Maquina
	set  nome = @nome,
		 status = @status,
		  tipo = @tipo,
		  idUsuarioAlt = @idUsuarioAlt,
		  id_departamento = @id_departamento,
		  dataRegistroAlt = GETDATE(),
		  i_Pk_Maquina = @i_Pk_Maquina,
		  vc_Descripcion = @vc_Descripcion,
		  codigoTess = @codigoTess
	WHERE id   = @id


END;
