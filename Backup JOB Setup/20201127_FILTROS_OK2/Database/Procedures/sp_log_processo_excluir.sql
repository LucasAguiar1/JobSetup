
-- EXEC dbo.sp_log_processo_excluir
CREATE PROCEDURE dbo.sp_log_processo_excluir
AS 
BEGIN
SET NOCOUNT ON

DECLARE @dias		Int	= 180,
		@referencia	Date

SET @referencia = dateadd(dd, (@dias * -1), GetDate())

DELETE tb_log_processos 
 WHERE dt_log_processo < @referencia

END
GO
