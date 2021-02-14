
-- exec sp_processa_experiencia_atualizar 
CREATE PROCEDURE sp_processa_experiencia_atualizar
AS begin
SET NOCOUNT ON

DECLARE @controle DATE

SELECT @controle = CONVERT(DATE, vl_parametro) 
  FROM tb_parametros
 WHERE id_parametro = 4

CREATE TABLE #Recursos (id_recurso int not null)

INSERT INTO #Recursos (id_recurso)
	SELECT id_recurso 
	  FROM tb_recursos 
	 WHERE qt_dias_experiencia > 0
	   AND id_situacao = 1

INSERT INTO tb_Experiencias (id_recurso, dt_experiencia)
	SELECT id_recurso, @controle
	  FROM #Recursos

UPDATE r
   SET r.qt_dias_experiencia = r.qt_dias_experiencia - 1
  FROM tb_recursos r
		INNER JOIN #Recursos rt
			ON r.id_recurso = rt.id_recurso

UPDATE tb_parametros
   SET vl_parametro = CONVERT(VARCHAR, DATEADD(DD, 1, @controle), 23)
 WHERE id_parametro = 4

END
GO




