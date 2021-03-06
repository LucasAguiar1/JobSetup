USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_notificacaolider]    Script Date: 19/01/2021 17:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	--SELECT * FROM TB_NOTIFICACAO

			--DELETE FROM TB_NOTIFICACAO
--EXEC  sp_consulta_notificacaolider 20,0,0,'Vinicius'
ALTER PROCEDURE [dbo].[sp_consulta_notificacaolider](
		@id_formulario       INT = NULL,
		@respondidas         INT = null,
		@idDepartamento      int = null,
		@id_lider           NVARCHAR(50)


)
AS
BEGIN

		IF(@respondidas = 0 AND @id_formulario != 0)
		BEGIN
			select 
			N.id
			,N.id_nomeOperador
			, N.dataNotificacao
			,N.dataLeitura
			,N.dataObsLider
			,N.notificacao
			,N.observacaoLider
			,N.nomeLider
			,F.nome AS 'Formulario'
			,M.nome AS 'Maquina'
			,MP.nome AS 'MaquinaParte'
			,N.id_lider 
			,d.nome as 'Departamento'
			from tb_Notificacao N
			INNER JOIN tb_Formulario F
			ON F.ID = N.id_formulario
			INNER JOIN tb_maquina M
			ON M.id = F.id_maquina
			INNER JOIN tb_maquinaParte MP 
			ON MP.id = F.id_parteMaquina
			INNER JOIN tb_Departamento  D
			ON d.id = m.id_departamento 
			WHERE N.id_formulario = @id_formulario  AND dataObsLider IS  NULL OR( N.id_lider = '0' and N.id_lider = @id_lider)
			ORDER BY 
			N.dataNotificacao ASC
       END
	   ELSE IF (@respondidas = 1 AND @idDepartamento = 0 and  @id_formulario != 0)
	   BEGIN
	   	select 
			N.id
			,N.id_nomeOperador
			, N.dataNotificacao
			,N.dataLeitura
			,N.dataObsLider
			,N.notificacao
			,N.observacaoLider
			,N.nomeLider
			,F.nome AS 'Formulario'
			,M.nome AS 'Maquina'
			,MP.nome AS 'MaquinaParte'
			,N.id_lider 
			,d.nome as 'Departamento'
			from tb_Notificacao N
			INNER JOIN tb_Formulario F
			ON F.ID = N.id_formulario
			INNER JOIN tb_maquina M
			ON M.id = F.id_maquina
			INNER JOIN tb_maquinaParte MP 
			ON MP.id = F.id_parteMaquina
			INNER JOIN tb_Departamento  D
			ON d.id = m.id_departamento 
			WHERE N.id_formulario = @id_formulario AND dataObsLider IS NOT NULL   OR( N.id_lider = '0' and N.id_lider = @id_lider)
			ORDER BY 
			N.dataNotificacao ASC
			
	   END
	   ELSE
	   BEGIN
	  select 
			N.id
			,N.id_nomeOperador
			, N.dataNotificacao
			,N.dataLeitura
			,N.dataObsLider
			,N.notificacao
			,N.observacaoLider
			,N.nomeLider
			,F.nome AS 'Formulario'
			,M.nome AS 'Maquina'
			,MP.nome AS 'MaquinaParte'
			,N.id_lider 
			,d.nome as 'Departamento'
			from tb_Notificacao N
			INNER JOIN tb_Formulario F
			ON F.ID = N.id_formulario
			INNER JOIN tb_maquina M
			ON M.id = F.id_maquina
			INNER JOIN tb_maquinaParte MP 
			ON MP.id = F.id_parteMaquina
			INNER JOIN tb_Departamento  D
			ON d.id = m.id_departamento 
			WHERE  dataObsLider IS  NULL and  d.codigo = @idDepartamento   OR( N.id_lider = '0' and N.id_lider = @id_lider)
			ORDER BY 
			N.dataNotificacao ASC

	   END 

END



