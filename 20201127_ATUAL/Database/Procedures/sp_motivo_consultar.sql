/*
exec sp_motivo_consultar 3
*/
CREATE PROCEDURE dbo.sp_motivo_consultar
( 
	@dominio	int
)
AS begin
SET NOCOUNT ON

SELECT m.id_motivo, m.ds_motivo
  FROM tb_motivos m
 WHERE m.id_dominio = @dominio
   AND m.id_situacao = 1
 ORDER BY m.ds_motivo

END
GO






