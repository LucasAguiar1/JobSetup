
/*
declare @retorno varchar(200)
exec sp_funcao_excluir 449, 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_funcao_excluir
(
	@funcao			int,
	@usuario		varchar(50),
	@mensagem		varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

SET @mensagem = ''

IF EXISTS (SELECT 1 FROM TB_RECURSOS WITH(NOLOCK) WHERE id_funcao = @funcao) BEGIN
	SET @mensagem = 'Função não pode ser excluída devido a Recursos vinculados. Altere os recursos e execute a operação novamente.'
	END
ELSE BEGIN
	UPDATE tb_funcoes 
	   SET id_situacao = 2
	 WHERE id_funcao = @funcao

	-- Gravação do Log de Processos
	EXEC dbo.sp_log_processo_incluir 'FUNÇÃO', 'DEL', @funcao, @usuario, ''
	END

END
GO
