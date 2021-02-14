
CREATE PROCEDURE dbo.sp_log_processo_incluir
(
	@tabela		varchar(50),
	@tipo		char(3),
	@chave		int,
	@usuario	varchar(20),
	@descricao	varchar(4000) = ''
) 
AS 
BEGIN
SET NOCOUNT ON

INSERT INTO tb_log_processos (dt_log_processo, nm_tabela, nm_tipo_processo, id_chave, cd_usuario, ds_log_processo)
					  VALUES (GETDATE(), @tabela, @tipo, @chave, @usuario, @descricao)

END
GO


