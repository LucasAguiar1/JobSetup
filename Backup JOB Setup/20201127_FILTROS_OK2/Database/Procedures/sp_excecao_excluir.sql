/*
declare @retorno varchar(200)
exec sp_excecao_excluir 7, 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_excecao_excluir
(
	@excecao	int,
	@usuario	varchar(50),
	@mensagem	varchar(200) OUTPUT
) 
AS BEGIN
SET NOCOUNT ON

DECLARE @log				varchar(500),
		@PeriodoSituacao	Int = 0

SET @mensagem = ''

SELECT @log = ('idPeriodoRecurso:' + convert(varchar, re.id_periodo_recurso) + 
						', Referencia: ' + convert(varchar, re.dt_referencia, 102) + 
						', Horas: ' + convert(varchar, re.qt_horas) + 
						', Motivo: ' + convert(varchar, re.id_motivo)),
	   @PeriodoSituacao = p.id_situacao
  FROM tb_recursos_excecoes re
		INNER JOIN tb_periodos_recursos pr
			ON re.id_periodo_recurso =  pr.id_periodo_recurso
		INNER JOIN tb_periodos p
			ON pr.id_periodo =  p.id_periodo
 WHERE re.id_recurso_excecao = @excecao
	
IF @PeriodoSituacao = 0 BEGIN
	SET @mensagem = 'Item de Exceção inválido!'
	END
ELSE BEGIN
	IF @PeriodoSituacao <> 3 BEGIN
		SET @mensagem = 'Período Fechado, exceção não pode ser excluída!'
		END
	ELSE BEGIN
		DELETE tb_recursos_excecoes 
		 WHERE id_recurso_excecao = @excecao

		-- Gravação do Log de Processos
		EXEC dbo.sp_log_processo_incluir 'Recursos_Excecoes', 'EXC', @excecao, @usuario, @log
		END
	END

END
GO




