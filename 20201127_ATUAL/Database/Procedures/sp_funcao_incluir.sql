
/*
declare @funcao int
exec sp_funcao_incluir 'radm', @funcao output
select @funcao
*/
CREATE PROCEDURE sp_funcao_incluir
(
	@usuario		varchar(50),
	@funcao			int OUTPUT
)
AS BEGIN
SET NOCOUNT ON

SET @funcao = 0

SELECT @funcao = id_funcao
  FROM tb_funcoes WITH(NOLOCK)
 WHERE nm_funcao = ''

IF @funcao = 0 BEGIN
	INSERT INTO tb_funcoes (cd_operacao, nm_funcao, id_classificacao, dv_participa_pmh, dv_participa_cmh, 
							dv_contabiliza_separado, id_situacao, vl_hora_servico)
		VALUES ('', '', 1, 0, 0, 0, 1, 50)

	SET @funcao = @@IDENTITY

	-- Gravação do Log de Processos
	EXEC dbo.sp_log_processo_incluir 'FUNÇÃO', 'INC', @funcao, @usuario, ''
	END

END
GO
