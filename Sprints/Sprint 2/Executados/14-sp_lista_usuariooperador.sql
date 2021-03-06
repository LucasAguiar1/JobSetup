USE [JobSetupPREPROD]
GO
/****** Object:  StoredProcedure [dbo].[sp_lista_usuariooperador]    Script Date: 21/01/2021 15:35:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec sp_lista_usuariooperador 'LIDER','49'
ALTER PROCEDURE [dbo].[sp_lista_usuariooperador](
		@ds_permissao		VARCHAR(50) = NULL
		,@id_departamento	INT = NULL
		)
		AS
BEGIN

	SELECT u.cd_rl
		,u.nm_usuario
		,u.id_departamento
		,d.nome as 'Departamento'
		,u.ds_login
	FROM tb_Usuario as u
	inner join tb_Departamento D
	on D.id = u.id_departamento
	WHERE 
	u.id_permissao = (SELECT p.id_permissao FROM tb_Permissao as p where p.ds_permissao = @ds_permissao OR @ds_permissao IS NULL)
			AND (u.id_departamento = @id_departamento OR @id_departamento IS NULL )
	END;



	

	
