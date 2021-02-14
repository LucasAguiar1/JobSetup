/*
declare @mensagem varchar(200)
exec sp_periodo_calendario_alterar 'radm', 2, 2, '10:00', '12:00', 'teste', @mensagem OUTPUT
select @mensagem
*/
CREATE PROCEDURE sp_periodo_calendario_alterar
(
	@usuario		varchar(50),
	@calendario	 	int,
	@ignorarDia		int = 0,
	@horaInicio		time = '', 
	@horaFim		time = '',
	@motivo			varchar(100),
	@mensagem		varchar(200) OUTPUT
) 
AS begin
SET NOCOUNT ON

DECLARE @log				varchar(1000) = '',
		@periodoSituacao	varchar(50) = '',
		@ignorarDia_atual	int	= 0,
		@horaInicio_atual	time = '', 
		@horaFim_atual		time = '', 
		@horasAjuste	    numeric(5,2) = 0,
		@horasAjuste_atual	numeric(5,2) = 0,
		@motivo_atual		varchar(100) = ''

IF @motivo IS NULL SET @motivo = ''

SELECT @periodoSituacao = p.id_situacao,
		@ignorarDia_atual = isnull(c.id_ignorar_producao, 0), 
		@horaInicio_atual = isnull(c.hr_inicio, ''),
		@horaFim_atual = isnull(c.hr_fim, ''),
		@horasAjuste_atual = isnull(c.nr_horas_ajuste, 0),
		@motivo_atual = isnull(c.ds_ignorar_motivo, '')
  FROM tb_periodos p
		INNER JOIN tb_calendarios c
			ON p.id_periodo = c.id_periodo
 WHERE c.id_calendario = @calendario
	
IF @periodoSituacao = 0 BEGIN
	SET @mensagem = 'Calendário inválido!'
	END
ELSE BEGIN
	IF @PeriodoSituacao <> 3 BEGIN
		SET @mensagem = 'Período Fechado, calendário não pode ser alterado!'
		END
	ELSE BEGIN
		IF @ignorarDia_atual = @ignorarDia AND @motivo_atual = @motivo 
				AND @horaInicio = @horaInicio_atual AND @horaFim = @horaFim_atual BEGIN
			SET @mensagem = 'Nenhuma alteração solicitada para esse dia do calendário!'
			END
		ELSE BEGIN
			UPDATE tb_calendarios 
			   SET id_ignorar_producao = @ignorarDia, 
				   hr_inicio = @horaInicio,
				   hr_fim = @horaFim,
				   nr_horas_ajuste = @horasAjuste,
				   ds_ignorar_motivo = @motivo
			 WHERE id_calendario = @calendario

			SET @log = @log + 'id_ignorar_producao { new: ' + convert(varchar, @ignorarDia) + ', old: ' + convert(varchar, @ignorarDia_atual) + 
								+ '}, ds_motivo { new: ' + @motivo + ', old: ' + @motivo_atual + 
								+ '}, hr_inicio { new: ' + convert(varchar, @horaInicio) + ', old: ' + convert(varchar, @horaInicio_atual) + 
								+ '}, hr_fim { new: ' + convert(varchar, @horaFim) + ', old: ' + convert(varchar, @horaFim_atual) + 
								+ '}, nr_horas_ajuste { new: ' + convert(varchar, @horasAjuste) + ', old: ' + convert(varchar, @horasAjuste_atual) + '}'

			EXEC dbo.sp_log_processo_incluir 'Calendario', 'UPD', @calendario, @usuario, @log
			END
		END
	END
END
GO




