USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_formulario]    Script Date: 18/01/2021 16:47:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_consulta_formulario_ordem]
@id_parteMaquina int = NULL
AS
BEGIN
	IF(@id_parteMaquina IS NULL)
	BEGIN
	select 
		F.ID,
		F.ID_MAQUINA,
		F.ID_PARTEMAQUINA,
		F.NOME, 
		F.STATUS,
		F.TIPO,
		F.IDUSUARIO,
		F.DATAREGISTRO,
		M.NOME AS MAQUINA,
		P.NOME AS PARTEMAQUINA,
		D.nome AS DEPARTAMENTO,
		D.id as id_departamento
	from tb_formulario F  INNER JOIN TB_MAQUINA M ON F.ID_MAQUINA = M.ID
						  INNER JOIN TB_MAQUINAPARTE P ON P.ID = F.ID_PARTEMAQUINA
						  INNER JOIN tb_Departamento D ON D.id = M.id_departamento
    --where F.id IN (SELECT  MAX(T.[ID])  FROM tb_formulario T  GROUP BY  T.ID_MAQUINA)
	END
	ELSE
		BEGIN
	select 
		F.ID,
		F.ID_MAQUINA,
		F.ID_PARTEMAQUINA,
		F.NOME, 
		F.STATUS,
		F.TIPO,
		F.IDUSUARIO,
		F.DATAREGISTRO,
		M.NOME AS MAQUINA,
		P.NOME AS PARTEMAQUINA,
		D.nome AS DEPARTAMENTO,
		D.id as id_departamento
	from tb_formulario F  INNER JOIN TB_MAQUINA M ON F.ID_MAQUINA = M.ID
						  INNER JOIN TB_MAQUINAPARTE P ON P.ID = F.ID_PARTEMAQUINA
						  INNER JOIN tb_Departamento D ON D.id = M.id_departamento
							  WHERE F.ID_PARTEMAQUINA = @id_parteMaquina
		END 
END;
