USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_RespostasPergunta]    Script Date: 17/01/2021 09:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC sp_consulta_RespostasPergunta 20 ,'A'
ALTER PROCEDURE [dbo].[sp_consulta_RespostasPergunta]
	   @id_formulario			INT = NULL
AS 
BEGIN
		
			SELECT  Distinct( p.id), 
			p.id_formulario,
			p.status,
			p.nome as 'pergunta',
			p.id_tipoResposta,
			--p.id_obrigatorio,
			--p.id_tess,
			--p.ordemApresentacao,
			--p.tipo,
			--p.idUsuario,
			--p.dataRegistro,
			p.id_obrigatorio,
			--p.id_tess,
			P.ordemApresentacao,
			f.nome as formulario,
			R.tipoResposta as Resposta,
			f.id_maquina,
			f.id_parteMaquina ,
			m.id_departamento,
			m.nome as maquina,
			mp.nome as maquinaParte,
			dp.nome as departamento,
			p.idsAlternativa,
			RP.valor,
			 RP.idPreenchimento,
			 RP.idPai as 'idPai',
			  RP.[status] as 'statusFormulario',
			CASE WHEN ISNULL(pf.id_Filho,0) <> 0 THEN 1 ELSE 0 END as idPai
			FROM tb_PerguntaPai as p
			INNER JOIN tb_Formulario as f ON p.id_formulario = f.id 
			INNER JOIN tb_tipoResposta as R on R.id = p.id_tipoResposta
			INNER JOIN tb_maquina as m on m.id = f.id_maquina
			INNER JOIN tb_maquinaParte as mp on mp.id = f.id_parteMaquina
			INNER JOIN tb_Departamento AS dp on dp.id = m.id_departamento
			LEFT JOIN tb_perguntaFilho AS pf on pf.id_perguntaPai = p.id
			LEFT JOIN tb_RespostaPai AS RP ON RP.idPai = p.id 
			INNER JOIN tb_Preenchimento AS PE on PE.id = RP.idPreenchimento
			where p.id_formulario = @id_formulario
			AND PE.id_formulario = @id_formulario
			AND  RP.[status] = 'F'

END 








