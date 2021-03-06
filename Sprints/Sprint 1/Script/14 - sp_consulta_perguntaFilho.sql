use JobSetupPREPROD
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_perguntaFilho]    Script Date: 14/01/2021 10:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--exec sp_consulta_perguntaFilho 66

ALTER PROCEDURE [dbo].[sp_consulta_perguntaFilho]
	 @id_pergunta_pai	INT = NULL
AS 
BEGIN

	select 
	P.id AS id_perguntaPai, 
	F.id AS id_filho,
	F.nome AS PerguntaFilho, 
	R.id AS id_tipoResposta, 
	R.tipoResposta AS Resposta,
	F.idsAlternativa,
	F.id_obrigatorio,
	F.[status]
	from tb_perguntaPai P
	INNER JOIN tb_perguntaFilho PF on P.id = PF.id_perguntaPai
	INNER JOIN tb_perguntaPai F on PF.id_Filho = F.id
	INNER JOIN tb_tipoResposta R ON R.id = F.id_tipoResposta
	
	WHERE P.id = @id_pergunta_pai



	

	

END 
