use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_RespostaPai]    Script Date: 12/01/2021 11:51:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_consulta_RespostaPai]
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
