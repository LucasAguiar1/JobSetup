
--exec sp_parametro_alterar 'radm', 1, ' 28'
CREATE PROCEDURE dbo.sp_parametro_alterar
( 
	@usuario		 varchar(50),
	@parametro		 int,
	@valor			 varchar(1000) 
) 
AS begin
SET NOCOUNT ON
DECLARE @log					varchar(1000) = '',
		@valor_atual			varchar(50) 

SELECT @valor_atual = vl_parametro
  FROM tb_parametros
 WHERE id_parametro = @parametro

UPDATE tb_parametros
   SET vl_parametro = @valor
 WHERE id_parametro = @parametro

SET @log = 'valor: { new: ' + @valor + ', old: ' + @valor_atual + ' }'

EXEC dbo.sp_log_processo_incluir 'Parametros', 'UPD', @parametro, @usuario, @log

END
GO


