
/*
declare @retorno varchar(200)
exec sp_centrocusto_lider_alterar 86, '', 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_centrocusto_lider_alterar
(
	@centrocusto	int,
	@lideres		varchar(1000),
	@usuario		varchar(50),
	@mensagem		varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

SET @mensagem = ''

DECLARE @log			varchar(500) = '',
		@lideresOld		varchar(1000) = '',
		@situacao		int = 0

SELECT @lideresOld = isnull(ds_usuario_lider, ''),
	   @situacao = id_situacao
  FROM tb_centrocusto
 WHERE id_cc = @centrocusto

IF @situacao = 1 BEGIN
	SET @lideres = LOWER(@lideres)

	UPDATE tb_centrocusto
		SET ds_usuario_lider = @lideres
		WHERE id_cc = @centrocusto

	SET @log = 'usuario_lider : { new: "' + @lideres + '", old: "' + @lideresOld + '" } '

	EXEC dbo.sp_log_processo_incluir 'CentroCusto', 'UPD', @centrocusto, @usuario, @log
	END
ELSE BEGIN
	SET @mensagem = 'Centro de Custo inativo não pode ser alterado!'
	END

END
GO




