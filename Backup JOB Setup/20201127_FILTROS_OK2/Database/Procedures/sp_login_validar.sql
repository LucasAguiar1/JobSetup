--GO
/*
BEGIN
DECLARE @permissoes varchar(4000) = '', @valido	bit = 0, @usuario	varchar(50)	
EXEC sp_login_validar 'radm', '123', 0, @usuario	OUTPUT, @valido OUTPUT, @permissoes OUTPUT
SELECT @usuario, @valido, @permissoes
END

SELECT * FROM [ISAC_1].[dbo].tblUser WHERE chrNetworkLogin = 'RADM'
SELECT * FROM [ISAC_1].[dbo].tblUser WHERE chrlogin = 'RADM'

EXEC [ISAC_1].[dbo].[stp_LoginUser] 'RADM', '123a', @iResposta OUTPUT
EXEC [ISAC_1].[dbo].[stp_GetUserAccess] 'RADM', 114, '123', @iResposta OUTPUT
END
*/
CREATE PROCEDURE dbo.sp_login_validar
(
	@login		varchar(50),
	@senha		varchar(50),
	@validoAD	bit = 0,
	@usuario	varchar(50)			OUTPUT,
	@valido		bit = 0				OUTPUT,
	@permissoes varchar(4000) = ''	OUTPUT
) 
AS 
BEGIN
SET NOCOUNT ON

DECLARE @sistema		int = 114,
		@usuarioLogin	varchar(50) ='',
		@senhaISAC   AS varbinary(100)

set @permissoes = ''

IF @validoAD = 0 BEGIN
	-- Busca os dados na tabela de usuario
	SELECT @senhaISAC = chrpassword,
		   @usuario = chrfirstname
	  FROM [ISAC_1].[dbo].tblUser WHERE chrlogin = @login 

	SET @valido = (SELECT pwdCompare(@senha, @senhaISAC, 0) AS Resultado)
	SET @usuarioLogin = @login
	END
ELSE BEGIN
	SELECT @usuarioLogin = chrlogin, 
	       @usuario = chrfirstname
      FROM [ISAC_1].[dbo].tblUser WHERE chrNetworkLogin = @login

	IF LEN(@usuarioLogin) > 0 BEGIN
		SET @valido = 1
		END
	END

IF @valido = 1 BEGIN
	SET @permissoes = (SELECT (',' + LTRIM(RTRIM(FP.chrfunction)))  AS 'data()' 
					  FROM [ISAC_1].[dbo].tblUser_Profile UP (NOLOCK)
							INNER JOIN [ISAC_1].[dbo].tblProfile P (NOLOCK)			ON UP.intp_id = P.intp_id 
							INNER JOIN [ISAC_1].[dbo].tblSystem_Profile SP (NOLOCK)	ON P.intp_id = SP.intp_id 
							INNER JOIN [ISAC_1].[dbo].tblFunction_Profile FP  (NOLOCK) ON P.intp_id = FP.intp_id AND SP.ints_id = FP.ints_id 
					 WHERE UP.chrlogin = @usuarioLogin
					   AND SP.ints_id = @sistema
					 ORDER BY 1
					   FOR XML PATH('') 
					)

	SET @permissoes = REPLACE(@permissoes, 'LHH_', '')
	END

IF LEN(@permissoes) = 0 OR @permissoes IS NULL BEGIN
	SET @valido	= 0
	SET @usuario = null
	END

--SET @permissoes = (
--	SELECT (',' + LTRIM(RTRIM(ds_acesso)))  AS 'data()'
--	  FROM dbo.tb_usuarios
--	 WHERE nm_login = @login
--	 ORDER BY 1
--	   FOR XML PATH('') )

--IF LEN(@permissoes) > 0 BEGIN
--	SET @valido = 1
--	SET @usuario = 	(SELECT TOP 1 nm_usuario FROM dbo.tb_usuarios WHERE nm_login = 'radm')
--	SET @permissoes = REPLACE(@permissoes, 'LHH_', '')
--	END

END
GO




