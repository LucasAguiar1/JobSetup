
/*
declare @retorno varchar(200)
exec sp_transferencia_incluir 3, 3, '2019-04-10', '2019-04-11', 2, 43, 3, 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_transferencia_incluir
(
	@periodo	int,
	@recurso	int,
	@inicio		date,
	@fim		date,
	@horas		numeric(5,2),
	@centroCusto int,
	@funcao		int,
	@usuario	varchar(50),
	@mensagem	varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

DECLARE @log				varchar(500),
		@valido				bit = 1,
		@recursoTransferencia int = 0,
		@recursoCentroCusto	int = 0,
		@periodoSituacao	int = 0,
		@referencia			date, 
		@periodoInicio		date, 
		@periodoFim			date, 
		@periodoRecurso		int

SET @mensagem = ''

SELECT @periodoInicio = p.dt_inicio, 
       @periodoFim = p.dt_fim, 
	   @periodoSituacao = p.id_situacao, 
	   @periodoRecurso = isnull(pr.id_periodo_recurso, 0),
	   @recursoCentroCusto = isnull(r.id_cc, 0)
  FROM tb_periodos p 
		LEFT JOIN tb_periodos_recursos pr
			ON p.id_periodo = pr.id_periodo AND pr.id_recurso = @recurso
		LEFT JOIN tb_recursos r
			ON r.id_recurso = pr.id_recurso
 WHERE p.id_periodo = @periodo

IF @periodoSituacao <> 3 BEGIN
	SET @valido = 0
	SET @mensagem = 'Periodo fechado não permite inclusão de transferência!'
	END
ELSE BEGIN
	IF (@inicio > @fim) BEGIN
		SET @valido = 0
		SET @mensagem = 'A data de Início não pode ser maior que a Final!'
		END
	ELSE BEGIN
		IF ((@inicio < @periodoInicio) OR (@inicio > @periodoFim) OR (@fim > @periodoFim)) BEGIN
			SET @valido = 0
			SET @mensagem = 'Range de datas fora do permitido no periodo vigente: ' + CONVERT(VARCHAR, @periodoInicio, 103) + ' a ' + CONVERT(VARCHAR, @periodoFim, 103) + ' !'
			END
		ELSE BEGIN
			IF @periodoRecurso = 0 BEGIN
				SET @valido = 0
				SET @mensagem = 'Recurso escolhido não tem ponto registrado no periodo!'
				END
			ELSE BEGIN
				IF @horas > 10 BEGIN
					SET @valido = 0
					SET @mensagem = 'Horas de transferência limitadas a 10h!'
					END
				ELSE BEGIN
					IF EXISTS (SELECT 1 FROM [dbo].[tb_Recursos_Transferencias] 
								WHERE id_periodo_recurso = @periodoRecurso
								  AND dt_referencia BETWEEN @inicio AND @fim) BEGIN
						SET @valido = 0
						SET @mensagem = 'Transferência já cadastrada para ao menos uma data no intervalo selecionado!'
						END
					ELSE BEGIN
						IF @recursoCentroCusto = @centroCusto BEGIN
							SET @valido = 0
							SET @mensagem = 'O Centro de Custo selecionado deve ser diferente do Centro de Custo atual do recurso!'
							END
						END
					END
				END
			END
		END
	END

IF @valido = 1 BEGIN
	SET @referencia = @inicio

	WHILE @referencia <= @fim BEGIN
		INSERT INTO [dbo].[tb_Recursos_Transferencias] (id_periodo_recurso, dt_referencia, qt_horas, id_cc, id_funcao, id_situacao)
										  values (@periodoRecurso, @referencia, @horas, @centroCusto, @funcao, 1)

		SET @recursoTransferencia = @@IDENTITY

		SET @log = 'idPeriodoRecurso:' + convert(varchar, @periodoRecurso) + 
							', Referencia: ' + convert(varchar, @referencia, 102) + 
							', Horas: ' + convert(varchar, @horas) + 
							', Funcao: ' + convert(varchar, @funcao) + 
							', CC: ' + convert(varchar, @centroCusto)

		-- Gravação do Log de Processos
		EXEC dbo.sp_log_processo_incluir 'Recursos_Transferencias', 'INC', @recursoTransferencia, @usuario, @log

		EXEC dbo.sp_transferencia_email @recursoCentroCusto, @centroCusto, @horas, @referencia

		SET @referencia = DATEADD(DAY, 1, @referencia)
		END
	END

END
GO




