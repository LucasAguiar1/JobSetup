/*
declare @retorno varchar(200)
exec sp_transferencia_excluir 7, 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_transferencia_excluir
(
	@transferencia	int,
	@usuario	varchar(50),
	@mensagem	varchar(200) OUTPUT
) 
AS BEGIN
SET NOCOUNT ON

DECLARE @log				varchar(500),
		@PeriodoSituacao	Int = 0

SET @mensagem = ''

SELECT @log = ('idPeriodoRecurso:' + convert(varchar, rt.id_periodo_recurso) + 
						', Referencia: ' + convert(varchar, rt.dt_referencia, 102) + 
						', Horas: ' + convert(varchar, rt.qt_horas) + 
						', Funcao: ' + convert(varchar, rt.id_funcao) + 
						', CC: ' + convert(varchar, rt.id_cc)),
	   @PeriodoSituacao = p.id_situacao
  FROM tb_recursos_transferencias rt
		INNER JOIN tb_periodos_recursos pr
			ON rt.id_periodo_recurso =  pr.id_periodo_recurso
		INNER JOIN tb_periodos p
			ON pr.id_periodo =  p.id_periodo
 WHERE rt.id_recurso_transferencia = @transferencia
	
IF @PeriodoSituacao = 0 BEGIN
	SET @mensagem = 'Item de Transferência inválido!'
	END
ELSE BEGIN
	IF @PeriodoSituacao <> 3 BEGIN
		SET @mensagem = 'Período Fechado, transferência não pode ser excluída!'
		END
	ELSE BEGIN
		DELETE tb_recursos_transferencias 
		 WHERE id_recurso_transferencia = @transferencia

		-- Gravação do Log de Processos
		EXEC dbo.sp_log_processo_incluir 'Recursos_Transferencias', 'EXC', @transferencia, @usuario, @log
		END
	END

END
GO




