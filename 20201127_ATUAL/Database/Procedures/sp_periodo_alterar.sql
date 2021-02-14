/*
DECLARE @mensagem		varchar(200)
exec sp_periodo_alterar 'radm', 2, 1.23, 3.54, @mensagem OUTPUT
SELECT @mensagem
*/
CREATE PROCEDURE dbo.sp_periodo_alterar
( 
	@usuario		varchar(50),
	@periodo		int,
	@diasBridge		numeric(7, 5) = 0,  
	@pesoAjustado	numeric(18, 8) = 0,
	@mensagem		varchar(200) OUTPUT
) 
AS begin
SET NOCOUNT ON

DECLARE @log				varchar(1000) = '',
		@diasBridge_atual	numeric(7, 5),   
		@pesoAjustado_atual	numeric(18, 8),
		@situacao			int = 0

SET @mensagem = ''

SELECT @diasBridge_atual = nr_dia_bridge, 
	   @pesoAjustado_atual = vl_peso_ajustado,
	   @situacao = id_situacao
  FROM tb_periodos
 WHERE id_periodo = @periodo

IF @situacao = 3 BEGIN
	UPDATE tb_periodos
	   SET nr_dia_bridge = @diasBridge, 
		   vl_peso_ajustado = @pesoAjustado
	 WHERE id_periodo = @periodo

	SET @log = 'dias: { new: ' + convert(varchar, @diasBridge) + ', old: ' + convert(varchar, @diasBridge_atual) + 
					' }, peso: { new: ' + convert(varchar, @pesoAjustado) + ', old: ' + convert(varchar, @pesoAjustado_atual) + ' }'

	EXEC dbo.sp_log_processo_incluir 'Periodos', 'UPD', @periodo, @usuario, @log
	END
ELSE BEGIN
	SET @mensagem = 'Periodo fechado não pode ser alterado!'
	END

END
GO

