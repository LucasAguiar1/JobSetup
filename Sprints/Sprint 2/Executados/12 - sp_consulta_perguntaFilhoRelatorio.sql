USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_perguntaFilhoRelatorio]    Script Date: 17/01/2021 10:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_consulta_perguntaFilhoRelatorio]
	 @idPreenchimento	INT = NULL,
	 @idPai	INT = NULL,
	 @id_formulario	INT = NULL
AS 
BEGIN
	
	SELECT  PF.id_Filho, 
	PP.id_formulario, 
	PP.id, 
	RF.valor, 
	RF.idsAlternativa, 
	RF.idPreenchimento ,
	 RF.id_tipoResposta,
	 P.nome as 'nomePergunta'
	FROM tb_perguntaFilho PF
	INNER JOIN tb_perguntaPai PP ON PP.id = PF.id_perguntaPai
	LEFT JOIN tb_RespostaFilho RF ON RF.idPai = PP.id AND RF.idFilho = PF.id_Filho
	LEFT JOIN tb_perguntaPai p ON p.id = PF.id_Filho
	WHERE PP.id_formulario = @id_formulario
	AND RF.idPreenchimento = @idPreenchimento
	AND  RF.idPai = @idPai

	END;

	



	
