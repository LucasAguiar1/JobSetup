USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_status]    Script Date: 17/01/2021 09:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_consulta_tb_StatusFormulario]
	@id INT = NULL

AS
BEGIN
	IF(@id IS NULL )
	BEGIN
		select 
				id,
				status,
				Descricao
		 from   tb_StatusFormulario 
	 END 
	 else	
	 BEGIN
		select 
			id,
			status,
			Descricao
		 from tb_StatusFormulario where id = @id
	 
	 END
END
