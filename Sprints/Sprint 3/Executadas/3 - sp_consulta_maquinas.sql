USE [JobSetupPREPROD]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_maquinas]    Script Date: 06/02/2021 07:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_consulta_maquinas]
		@id_departamento int = NULL
AS
BEGIN
	
	IF (@id_departamento IS NOT NULL)
	   BEGIN
		      select 
				M.nome,
					M.id,
					M.status,		
					M.tipo,
					d.CODIGO,
					M.idUsuario,
					M.dataRegistro,
					m.id_departamento,
					D.nome as departamento,
					M.i_Pk_Maquina,
					M.vc_Descripcion,
					M.codigoTess
				 from tb_Maquina M INNER JOIN tb_Departamento D on D.ID = M.id_departamento
				 AND M.id_departamento = @id_departamento
				-- where M.DATAREGISTRO IN (SELECT  MAX(T.DATAREGISTRO)  FROM tb_Maquina T WHERE T.id_departamento = 26  GROUP BY  T.id_departamento, t.NOME)
		 END 
	 ELSE 
	    BEGIN
				    select 
				DISTINCT(M.nome),
					M.id,
					M.status,		
					M.tipo,
					d.CODIGO,
					M.idUsuario,
					M.dataRegistro,
					m.id_departamento,
					D.nome as departamento,
					M.i_Pk_Maquina,
					M.vc_Descripcion,
					M.codigoTess
				 from tb_Maquina M INNER JOIN tb_Departamento D
				 on D.ID = M.id_departamento
				-- where M.id IN (SELECT  MAX(T.[ID])  FROM tb_Maquina T  GROUP BY  T.id_departamento)


		 END 
	
END;
