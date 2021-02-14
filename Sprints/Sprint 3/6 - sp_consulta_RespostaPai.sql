USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_RespostaPai]    Script Date: 11/02/2021 15:24:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_consulta_RespostaPai]
	   @id_Formulario			INT = NULL
AS 
BEGIN
		SELECT 
			 id AS chave
			,idPai
			,id_Formulario
			,valor
			,status
			,id_tipoResposta
			,idPreenchimento
			,idsAlternativa
		FROM tb_RespostaPai 
		
		WHERE id_Formulario = @id_Formulario

		
				
		
END 
