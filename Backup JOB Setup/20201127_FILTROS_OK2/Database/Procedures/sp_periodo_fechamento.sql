/*
DECLARE @mensagem		varchar(200)
exec sp_periodo_fechamento 'radm', 4, @mensagem OUTPUT
SELECT @mensagem
*/
CREATE PROCEDURE dbo.sp_periodo_fechamento
( 
	@usuario		varchar(50),
	@periodo		int,
	@mensagem		varchar(200) OUTPUT
) 
AS begin
SET NOCOUNT ON

DECLARE @log				varchar(1000) = '',
		@situacao			int = 0,
		@competencia		date

SET @mensagem = ''

SELECT @situacao = id_situacao,
	   @competencia = dateadd(mm, 1, dt_competencia)
  FROM tb_periodos
 WHERE id_periodo = @periodo

IF @situacao = 3 BEGIN
	EXEC sp_fechamento_processar @periodo, 1, 1
	
	UPDATE tb_periodos
	   SET id_situacao = 5
	 WHERE id_periodo = @periodo

	SET @log = 'situacao: { new: 5, old: ' + convert(varchar, @situacao) + ' }'

	EXEC dbo.sp_log_processo_incluir 'Periodos', 'FCH', @periodo, @usuario, @log

	IF NOT EXISTS (SELECT 1 FROM tb_periodos 
			    WHERE dt_competencia = @competencia) BEGIN
		EXEC dbo.sp_periodo_criar @competencia, @usuario, @periodo OUTPUT, @log OUTPUT
		END
	END
ELSE BEGIN
	SET @mensagem = 'Periodo fechado não pode ser processado novamente!'
	END

END
GO

