
-- exec sp_centrocusto_lider_consultar 1
CREATE PROCEDURE sp_centrocusto_lider_consultar
(
	@centroCusto	int
)
AS begin
SET NOCOUNT ON

DECLARE @lider VARCHAR(4000)

SELECT @lider = ds_usuario_lider
  FROM tb_CentroCusto WHERE id_cc = @centroCusto

SELECT ISNULL(a.id, 0) id_lider, ISNULL(a.usuario, '') nm_login, 
	   ISNULL(a.nome, '') nm_usuario, ISNULL(a.rede, '') nm_rede, 
	   CASE WHEN CHARINDEX(lower((a.usuario + ',')), @lider) > 0 
			THEN CONVERT(BIT, 1) 
			ELSE CONVERT(BIT, 0) 
		 END dv_lider 
  FROM (SELECT DISTINCT U.intu_id id, ltrim(rtrim(U.chrlogin)) usuario, U.chrfirstname nome, U.chrNetworkLogin rede
		  FROM [ISAC_1].[dbo].tblUser_Profile UP (NOLOCK)
					INNER JOIN [ISAC_1].[dbo].tblSystem_Profile SP (NOLOCK)	
						ON UP.intp_id = SP.intp_id 
					INNER JOIN [ISAC_1].[dbo].tblUser U (NOLOCK)	
						ON UP.chrlogin = U.chrlogin
		 WHERE SP.ints_id = 114) a
 ORDER BY a.usuario, a.nome

END
GO

