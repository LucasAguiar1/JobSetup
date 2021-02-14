/*
exec sp_recurso_alterar 'radm', 3, '', 3, 0, 0
exec sp_recurso_alterar 'radm', 0, ',2,3', 14, 0, 0, 0, 0
*/
CREATE PROCEDURE dbo.sp_recurso_alterar
( 
	@usuario		 varchar(50),
	@recurso		 int,
	@recursoLista	 varchar(4000) = '',
	@funcao			 int = 0,
	@calculo		 bit = 0,
	@calculoRemover  bit = 0,
	@experiencia	 bit = 0,
	@diasExperiencia int = 0
) 
AS begin
SET NOCOUNT ON
DECLARE @log					varchar(1000) = '',
		@recurso_atual			int = 0,
		@funcao_atual			int = 0,
		@calculoRemover_atual	bit = 0,
		@diasExperiencia_atual  int = 0

/*********************************************************************/
/*** LISTAGEM DOS RECURSOS A SEREM PROCESSADOS ***********************/
/*********************************************************************/
CREATE TABLE #Recurso
(
	  id_recurso			int				NOT NULL
	, id_funcao				int				NULL
	, dv_calculo_remover	bit				NOT NULL
	, qt_dias_experiencia	int				NOT NULL
)

IF @recurso > 0 BEGIN
	INSERT INTO #Recurso (id_recurso, id_funcao, dv_calculo_remover, qt_dias_experiencia)
		SELECT id_recurso, isnull(id_funcao, 0), dv_calculo_remover, qt_dias_experiencia
		  FROM tb_Recursos WITH(NOLOCK)
		 WHERE id_recurso = @recurso
	END
ELSE BEGIN
	IF (LEN(@recursoLista) > 0) BEGIN
		INSERT INTO #Recurso (id_recurso, id_funcao, dv_calculo_remover, qt_dias_experiencia)
			SELECT r.id_recurso, isnull(r.id_funcao, 0), r.dv_calculo_remover, r.qt_dias_experiencia
			  FROM tb_Recursos r WITH(NOLOCK)
					INNER JOIN (SELECT CONVERT(INT, item) id_recurso 
								  FROM dbo.fc_Split(@recursoLista, ',') WHERE item <> '') l
						ON r.id_recurso = l.id_recurso
		END
	END

/*********************************************************************/
/*** PROCESSAMENTO INDIVIDUAL DOS RECURSOS ***************************/
/*********************************************************************/
DECLARE c_Recursos CURSOR READ_ONLY FOR
	SELECT id_recurso, id_funcao, dv_calculo_remover, qt_dias_experiencia FROM #Recurso
		  	
OPEN c_Recursos
FETCH NEXT FROM c_Recursos 
	INTO @recurso_atual, @funcao_atual, @calculoRemover_atual, @diasExperiencia_atual

WHILE (@@fetch_status <> -1) BEGIN
	IF (@@fetch_status <> -2) BEGIN
		/*********************************************************************/
		/*** ATUALIZAÇÃO DOS DADOS *******************************************/
		/*********************************************************************/
		IF @calculo = 1 AND @funcao > 0 BEGIN
			UPDATE tb_Recursos
			   SET id_funcao = @funcao,
				   dv_calculo_remover = @calculoRemover
			 WHERE id_recurso = @recurso_atual
			END
		ELSE BEGIN
			IF @funcao > 0 BEGIN
				UPDATE tb_Recursos
				   SET id_funcao = @funcao
				 WHERE id_recurso = @recurso_atual
				END
			ELSE BEGIN
				IF @calculo = 1 BEGIN
					UPDATE tb_Recursos
					   SET dv_calculo_remover = @calculoRemover
					 WHERE id_recurso = @recurso_atual
					END
				ELSE IF @experiencia = 1 BEGIN
					UPDATE tb_Recursos
					   SET qt_dias_experiencia = @diasExperiencia
					 WHERE id_recurso = @recurso_atual
					END
				END
			END 


		/*********************************************************************/
		/*** ATUALIZAÇÃO DOS PARÂMETROS DE CONTROLE DO RECURSO ***************/
		/*********************************************************************/
		UPDATE pr
		   SET pr.dv_calculo_remover = ISNULL(r.dv_calculo_remover, 0),
			   pr.id_cc = r.id_cc,
			   pr.id_funcao = r.id_funcao 
		  FROM tb_periodos_recursos pr
				INNER JOIN tb_recursos r
					ON pr.id_recurso = r.id_recurso
				INNER JOIN tb_periodos p
					ON pr.id_periodo = p.id_periodo
		 WHERE pr.id_recurso = @recurso_atual
		   AND p.id_situacao = 3


		/*********************************************************************/
		/*** GRAVAÇÃO DO LOG DE PROCESSOS ************************************/
		/*********************************************************************/
		SET @log = ''

		IF @funcao > 0
			SET @log = ', funcao: { new: ' + convert(varchar, @funcao) + ', old: ' + convert(varchar, @funcao_atual) + ' }'

		IF @calculo = 1
			SET @log = @log + ', dv_remover: { new: ' + convert(varchar, @calculoRemover) + ', old: ' + convert(varchar, @calculoRemover_atual) + ' }'

		IF @experiencia = 1
			SET @log = @log + ', qt_dias_experiencia: { new: ' + convert(varchar, @diasExperiencia) + ', old: ' + convert(varchar, @diasExperiencia_atual) + ' }'

		SET @log = substring(@log, 3, len(@log) - 1)

		EXEC dbo.sp_log_processo_incluir 'Recursos', 'UPD', @recurso_atual, @usuario, @log

		/*********************************************************************/
		FETCH NEXT FROM c_Recursos 
			INTO @recurso_atual, @funcao_atual, @calculoRemover_atual, @diasExperiencia_atual
		END
	END

CLOSE c_Recursos
DEALLOCATE c_Recursos

DROP TABLE #Recurso

END
GO
