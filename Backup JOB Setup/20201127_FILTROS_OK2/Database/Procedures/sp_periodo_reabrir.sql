/*
DECLARE @mensagem		varchar(200)
exec sp_periodo_reabrir 'radm', 2, sp_periodo_reabrir@mensagem OUTPUT
SELECT @mensagem
*/
CREATE PROCEDURE dbo.sp_periodo_reabrir
( 
	@usuario		varchar(50),
	@periodo		int,
	@mensagem		varchar(200) OUTPUT
) 
AS begin
SET NOCOUNT ON

DECLARE @log				varchar(1000) = '',
		@situacao			int = 0

SET @mensagem = ''

SELECT @situacao = id_situacao
  FROM tb_periodos
 WHERE id_periodo = @periodo

IF @situacao = 5 BEGIN
	UPDATE tb_periodos
	   SET id_situacao = 3
	 WHERE id_periodo = @periodo

	UPDATE pr
	   SET pr.dv_calculo_remover = ISNULL(r.dv_calculo_remover, 0),
		   pr.id_cc = r.id_cc,
		   pr.id_funcao = r.id_funcao 
	  FROM tb_periodos_recursos pr
			INNER JOIN tb_recursos r
				ON pr.id_recurso = r.id_recurso
     WHERE pr.id_periodo = @periodo

	SET @log = 'situacao: { new: 3, old: ' + convert(varchar, @situacao) + ' }'

	EXEC dbo.sp_log_processo_incluir 'Periodos', 'RBR', @periodo, @usuario, @log
	END
ELSE BEGIN
	SET @mensagem = 'Periodo aberto não pode ser reaberto!'
	END

END
GO

