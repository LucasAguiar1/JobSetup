use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_RespostaFilho]    Script Date: 12/01/2021 11:51:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_consulta_RespostaFilho]
	   @id_Formulario			INT = NULL,
	   @id_Pai			INT = NULL
AS 
BEGIN
	SELECT 
		 F.id as chave
		 ,F.idFilho 
		,F.id_tipoResposta
		,F.valor
		,F.idPai
		,F.dataResposta
		,F.idPreenchimento
		,F.idsAlternativa
	FROM tb_RespostaFilho F
	LEFT JOIN tb_RespostaPai P on F.idPai = P.idPai
	WHERE P.id_Formulario = @id_Formulario and f.idPai = @id_Pai
	
		
END 



