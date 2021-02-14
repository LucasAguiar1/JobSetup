USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_perguntaFormulario]    Script Date: 09/02/2021 10:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[sp_consulta_perguntaFormulario]
	   @id_Formulario			INT = NULL
AS 
BEGIN
		 
			SELECT distinct( p.id), 
				p.id_formulario,
				p.status,
				p.nome,
				p.id_tipoResposta,
				p.id_obrigatorio,
				p.id_tess,
				p.ordemApresentacao,
				p.tipo,
				p.idUsuario,
				p.dataRegistro,
				p.id_obrigatorio,
				p.id_tess,
				P.ordemApresentacao,
				f.nome as formulario,
				R.tipoResposta as Resposta,
				f.id_maquina,
				f.id_parteMaquina ,
				m.id_departamento,
				m.nome as maquina,
				m.i_Pk_Maquina, 
				m.vc_Descripcion, 
				m.codigoTess,
				mp.nome as maquinaParte,
				dp.nome as departamento,
				f.nome as nomeFormulario,
				p.idsAlternativa,
					CASE WHEN ISNULL(pf.id_Filho,0) <> 0 THEN 1 ELSE 0 END as idPai
				FROM tb_PerguntaPai as p
				INNER JOIN tb_Formulario as f ON p.id_formulario = f.id 
				INNER JOIN tb_tipoResposta as R on R.id = p.id_tipoResposta
				INNER JOIN tb_maquina as m on m.id = f.id_maquina
				INNER JOIN tb_maquinaParte as mp on mp.id = f.id_parteMaquina
				INNER JOIN tb_Departamento AS dp on dp.id = m.id_departamento
				LEFT JOIN tb_perguntaFilho AS pf on pf.id_perguntaPai = p.id
				WHERE f.id = @id_Formulario
		
END 


