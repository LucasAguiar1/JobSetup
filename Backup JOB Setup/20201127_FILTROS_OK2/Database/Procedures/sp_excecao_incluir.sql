
/*
declare @retorno varchar(200)
exec sp_excecao_incluir 3, 3, '2019-04-26', '2019-04-26', 1.2, 3, 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_excecao_incluir
(
	@periodo	int,
	@recurso	int,
	@inicio		date,
	@fim		date,
	@horas		numeric(5,2),
	@motivo		int,
	@usuario	varchar(50),
	@mensagem	varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

DECLARE @log				varchar(500),
		@valido				bit = 1,
		@recursoExcecao		int = 0,
		@periodoSituacao	int = 0,
		@referencia			date, 
		@periodoInicio		date, 
		@periodoFim			date, 
		@periodoRecurso		int

SET @mensagem = ''

SELECT @periodoInicio = p.dt_inicio, 
       @periodoFim = p.dt_fim, 
	   @periodoSituacao = p.id_situacao, 
	   @periodoRecurso = isnull(pr.id_periodo_recurso, 0)
  FROM tb_periodos p 
		LEFT JOIN tb_periodos_recursos pr
			ON p.id_periodo = pr.id_periodo AND pr.id_recurso = @recurso
 WHERE p.id_periodo = @periodo

IF @periodoSituacao <> 3 BEGIN
	SET @valido = 0
	SET @mensagem = 'Periodo fechado não permite inclusão de exceção!'
	END
ELSE BEGIN
	IF (@inicio > @fim) BEGIN
		SET @valido = 0
		SET @mensagem = 'A data de Início não pode ser maior que a Final!'
		END
	ELSE BEGIN
		IF ((@inicio < @periodoInicio) OR (@inicio > @periodoFim) OR (@fim > @periodoFim)) BEGIN
			SET @valido = 0
			SET @mensagem = 'Range de datas fora do permitido no período vigente: ' + CONVERT(VARCHAR, @periodoInicio, 103) + ' a ' + CONVERT(VARCHAR, @periodoFim, 103) + ' !'
			END
		ELSE BEGIN
			IF @periodoRecurso = 0 BEGIN
				SET @valido = 0
				SET @mensagem = 'Recurso escolhido não tem ponto registrado no periodo!'
				END
			ELSE BEGIN
				IF @horas > 10 BEGIN
					SET @valido = 0
					SET @mensagem = 'Horas de exceção limitado a 10h!'
					END
				ELSE BEGIN
					IF EXISTS (SELECT 1 FROM [dbo].[tb_Recursos_Excecoes] 
								WHERE id_periodo_recurso = @periodoRecurso
								  AND dt_referencia BETWEEN @inicio AND @fim) BEGIN
						SET @valido = 0
						SET @mensagem = 'Exceção já cadastrada para ao menos uma data no intervalo selecionado!'
						END
					END
				END
			END
		END
	END

IF @valido = 1 BEGIN
	SET @referencia = @inicio

	WHILE @referencia <= @fim BEGIN
		INSERT INTO [dbo].[tb_Recursos_Excecoes] (id_periodo_recurso, dt_referencia, qt_horas, id_motivo, id_situacao)
										  values (@periodoRecurso, @referencia, @horas, @motivo, 1)

		SET @recursoExcecao = @@IDENTITY

		SET @log = 'idPeriodoRecurso:' + convert(varchar, @periodoRecurso) + 
							', Referencia: ' + convert(varchar, @referencia, 102) + 
							', Horas: ' + convert(varchar, @horas) + 
							', Motivo: ' + convert(varchar, @motivo)

		-- Gravação do Log de Processos
		EXEC dbo.sp_log_processo_incluir 'Recursos_Excecoes', 'INC', @recursoExcecao, @usuario, @log

		SET @referencia = DATEADD(DAY, 1, @referencia)
		END
	END

END
GO




