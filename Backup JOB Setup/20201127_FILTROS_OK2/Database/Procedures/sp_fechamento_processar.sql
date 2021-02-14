
-- exec sp_fechamento_processar 5, 0, 1
CREATE PROCEDURE dbo.sp_fechamento_processar
( 
	@periodo	int,
	@diario		bit = 0,
	@mensal		bit = 0
)
AS begin
SET NOCOUNT ON

DECLARE @diaBridge		numeric(7,5) = 0,
	    @pesoAjustado	numeric	(18,8) = 0,
		@pesoArmazenado	numeric	(18,8) = 0,
		@inicio			date,
		@fim			date

DECLARE @centroCusto	int = 0, 
		@categoria		int = 0, 
		@horasTMH		numeric	(18,2) = 0, 
		@horasPMH		numeric	(18,2) = 0, 
		@horasCMH		numeric	(18,2) = 0, 
		@horasCategTMH	numeric	(18,2) = 0, 
		@horasCategPMH	numeric	(18,2) = 0, 
		@horasCategCMH	numeric	(18,2) = 0,
		@diferenca		numeric	(9,2) = 0 

DECLARE @recursoPontoRH int = 0, 
		@horasIgnorar	numeric(5,2) = 0,
		@horas			numeric(5,2) = 0,
		@horasExcecao	numeric(5,2) = 0,
		@horasTransf	numeric(5,2) = 0,
		@horaInicioPonto time,
		@horaFimPonto	time,
		@horaInicio		time,
		@horaFim		time,
		@horaInicioAux	time,
		@horaFimAux		time,
		@horasSemPonto	numeric(5,2) = 0

SELECT @diaBridge = nr_dia_bridge,
	   @pesoAjustado = vl_peso_ajustado,
	   @inicio = dt_inicio,
	   @fim = dt_fim
  FROM tb_periodos 
 WHERE id_periodo = @periodo

/**********************************************************************************/
/*** TABELAS TEMPORÁRIAS PARA TRATAMENTO DOS DADOS ********************************/
/**********************************************************************************/
CREATE TABLE #Pontos
(
id_recurso_pontoRH		int not null,
id_periodo_recurso		int not null,
id_recurso				int not null,
dt_referencia			date not null,
qt_horas				numeric(5,2) not null,
dt_inicio				datetime null,
dt_fim					datetime null,
id_cc					int not null,
cd_cc					varchar(50) not null,
nm_cc					varchar(100) not null,
id_tipo					int not null,
id_funcao				int not null,
nm_funcao				varchar(100) not null,
id_classificacao		int not null,
dv_participa_pmh		bit not null,
dv_participa_cmh		bit not null,
dv_contabiliza_separado	bit not null,
qt_dias_experiencia		int not null,
qt_horas_ignorar		numeric(5,2) not null,
qt_horas_exc			numeric(5,2) not null,
id_motivo_exc			int not null,
qt_horas_trf			numeric(5,2) not null,
id_cc_trf				int not null,
id_funcao_trf			int not null,
dv_ajuste				bit not null,
dv_considerar			bit	not null
)
CREATE NONCLUSTERED INDEX iPonto1 ON #Pontos (dv_considerar);

CREATE TABLE #Servico
(
id_cc					int not null,
qt_horas_servico		numeric(18,2) not null
)
CREATE CLUSTERED INDEX iServico1 ON #Servico (id_cc);

CREATE TABLE #Pesos
(
id_categoria		int				NOT NULL,
qt_peso_armazenado	numeric(18, 3)	NOT NULL,
qt_peso_ajustado	numeric(18, 3)	NOT NULL
)
CREATE CLUSTERED INDEX iPeso1 ON #Pesos (id_categoria);

CREATE TABLE #Categorias
(
id_cc				int			  NOT NULL,
id_categoria		int			  NOT NULL,
pc_distribuicao		numeric(5, 2) NOT NULL  
)
CREATE NONCLUSTERED INDEX iCategoria1 ON #Categorias (id_categoria);

CREATE TABLE #Mensal
(
id_cc				int			  NOT NULL,
id_tipo				int			  NOT NULL,
qt_horas_tmh		numeric(9,2)  NOT NULL,
qt_horas_pmh		numeric(9,2)  NOT NULL,
qt_horas_cmh		numeric(9,2)  NOT NULL,
qt_horas_cedidas	numeric(9,2)  NOT NULL,
qt_horas_recebidas	numeric(9,2)  NOT NULL,
qt_horas_excecoes	numeric(9,2)  NOT NULL
)

CREATE TABLE #Calendario
(
dt_referencia		date	  NOT NULL,
id_ignorar_producao	smallint  NOT NULL,
nr_dia_semana		int		  NOT NULL,
hr_inicio			time	  NULL,
hr_fim				time	  NULL
)
CREATE CLUSTERED INDEX iCalendario ON #Calendario (dt_referencia);

SET DATEFIRST 1
INSERT INTO #Calendario (dt_referencia, id_ignorar_producao, nr_dia_semana, hr_inicio, hr_fim)
	SELECT dt_referencia, id_ignorar_producao, 
		   datepart(weekday, dt_referencia),
	       hr_inicio, hr_fim
	  FROM tb_calendarios WITH(NOLOCK)
	 WHERE id_periodo = @periodo


/**********************************************************************************/
/*** PONTOS GERADOS AUTOMATICAMENTE PARA RECURSOS SEM PONTO ***********************/ 
/**********************************************************************************/
SELECT @horasSemPonto = CONVERT(numeric(5,2), replace(vl_parametro, ',', '.'))
	FROM tb_Parametros 
	WHERE id_parametro = 7

IF @horasSemPonto > 0 BEGIN
	INSERT INTO tb_Recursos_PontosRH (id_periodo_recurso, 
										dt_referencia, qt_horas, 
										dt_inicio, dt_fim, id_situacao)
		SELECT p.id_periodo_recurso, p.dt_referencia, @horasSemPonto, 
				DATEADD(hh, 8, p.dt_referencia),
				DATEADD(hh, 17, p.dt_referencia), 1
			FROM (SELECT CONVERT(datetime, c.dt_referencia) dt_referencia, 
						r1.id_periodo_recurso 
					FROM #Calendario c,
						(SELECT pr.id_periodo_recurso
							FROM tb_periodos_recursos pr WITH(NOLOCK)
								INNER JOIN tb_recursos r
									ON r.id_recurso = pr.id_recurso
								INNER JOIN (SELECT NM_LISTA DS_CARGO FROM tb_Listas WHERE ID_DOMINIO = 5) c
									ON r.DS_RH_CARGO = c.DS_CARGO
							WHERE pr.id_periodo = @periodo
							AND r.id_situacao = 9) r1
					WHERE c.nr_dia_semana < 6	-- Apenas dias úteis
					  AND c.dt_referencia NOT IN (SELECT dt_feriado FROM tb_feriados WHERE YEAR(dt_feriado) = YEAR(@inicio))
					) p
					LEFT JOIN tb_Recursos_PontosRH rp
						ON rp.id_periodo_recurso = p.id_periodo_recurso
						AND rp.dt_referencia = p.dt_referencia
			WHERE rp.id_recurso_pontoRH IS NULL
	END
/**********************************************************************************/


/**********************************************************************************/
/*** LEITURA DOS DADOS DE PONTO DOS RECURSOS **************************************/
/**********************************************************************************/
INSERT INTO #Pontos
	SELECT prh.id_recurso_pontoRH, prh.id_periodo_recurso, r.id_recurso,
		   prh.dt_referencia, ISNULL(prh.qt_horas, 0), prh.dt_inicio, prh.dt_fim,
		   ISNULL(pr.id_cc, 0), ISNULL(cc.cd_cc, ''), ISNULL(cc.nm_cc, ''), 
		   ISNULL(cc.id_tipo, 0), ISNULL(pr.id_funcao, 0), 
		   ISNULL(f.nm_funcao, ''), ISNULL(f.id_classificacao, 0), 
		   ISNULL(f.dv_participa_pmh, 0), ISNULL(f.dv_participa_cmh, 0), 
		   ISNULL(f.dv_contabiliza_separado, 0), ISNULL(r.qt_dias_experiencia, 0), 0,
		   ISNULL(re.qt_horas, 0) qt_horas_exc, ISNULL(re.id_motivo, 0) id_motivo_exc,
		   ISNULL(rt.qt_horas, 0) qt_horas_trf, ISNULL(rt.id_cc, 0) id_cc_trf, 
		   ISNULL(rt.id_funcao, 0) id_funcao_trf, 0, 1
	  FROM tb_Recursos_PontosRH prh WITH(NOLOCK)
			INNER JOIN tb_periodos_recursos pr WITH(NOLOCK)
				ON prh.id_periodo_recurso = pr.id_periodo_recurso
			INNER JOIN tb_recursos r WITH(NOLOCK)
				ON pr.id_recurso = r.id_recurso
			INNER JOIN tb_centrocusto cc WITH(NOLOCK)
				ON cc.id_cc = pr.id_cc
			INNER JOIN tb_funcoes f WITH(NOLOCK)
				ON f.id_funcao = pr.id_funcao
			LEFT JOIN tb_Recursos_Excecoes re WITH(NOLOCK)
				ON re.id_periodo_recurso = pr.id_periodo_recurso
					AND re.dt_referencia = prh.dt_referencia
			LEFT JOIN tb_Recursos_Transferencias rt WITH(NOLOCK)
				ON rt.id_periodo_recurso = pr.id_periodo_recurso
					AND rt.dt_referencia = prh.dt_referencia
	 WHERE pr.id_periodo = @periodo
	   AND pr.dv_calculo_remover = 0
/**********************************************************************************/


/**********************************************************************************/
/*** TRATAMENTO DAS HORAS TRANSFERIDAS ENTRE CENTROS DE CUSTO *********************/
/**********************************************************************************/
DECLARE c_IgnorarProducao CURSOR READ_ONLY FAST_FORWARD FOR
	SELECT p.id_recurso_pontoRH, p.qt_horas, p.qt_horas_exc, p.qt_horas_trf,
		   convert(time, p.dt_inicio) hr_inicio_ponto, c.hr_inicio,
		   convert(time, p.dt_fim) hr_fim_ponto, c.hr_fim, 0, '00:00', '00:00'
	  FROM #pontos p
			INNER JOIN #Calendario c
				ON c.dt_referencia = p.dt_referencia
	 where c.id_ignorar_producao = 2
	 ORDER BY p.dt_referencia 
 		 		  	
OPEN c_IgnorarProducao
FETCH NEXT FROM c_IgnorarProducao
	INTO @recursoPontoRH, @horas, @horasExcecao, @horasTransf,
		 @horaInicioPonto, @horaInicio, @horaFimPonto, @horaFim, 
		 @horasIgnorar, @horaInicioAux,	@horaFimAux

WHILE (@@fetch_status <> -1) BEGIN
	IF (@@fetch_status <> -2) BEGIN
		IF @horaInicioPonto < @horaFimPonto BEGIN
			IF @horaInicio >= @horaInicioPonto BEGIN
				IF @horaInicio < @horaFimPonto BEGIN
					SET @horaInicioAux = @horaInicio

					IF @horaInicio < @horaFim  BEGIN
						IF @horaFim <= @horaFimPonto BEGIN
							SET @horaFimAux = @horaFim
							END
						ELSE BEGIN
							SET @horaFimAux = @horaFimPonto
							END
						END
					ELSE BEGIN
						IF @horaFim > @horaFimPonto BEGIN
							SET @horaFimAux = @horaFim 
							END
						ELSE BEGIN
							SET @horaFimAux = @horaFimPonto
							END
						END
					END
				END
			ELSE BEGIN
				IF @horaFim > @horaInicioPonto BEGIN
					SET @horaInicioAux = @horaInicioPonto

					IF @horaFim > @horaFimPonto BEGIN
						SET @horaFimAux = @horaFimPonto
						END
					ELSE BEGIN
						SET @horaFimAux = @horaFim
						END
					END				
				END
			END
		ELSE BEGIN
			IF @horaInicio >= @horaInicioPonto BEGIN
				SET @horaInicioAux = @horaInicio

				IF @horaFim > @horaInicioPonto BEGIN
					SET @horaFimAux = @horaFim
					END
				ELSE BEGIN
					IF @horaFim < @horaInicio BEGIN
						IF @horaFim > @horaFimPonto BEGIN
							SET @horaFimAux = @horaFimPonto
							END
						ELSE BEGIN
							SET @horaFimAux = @horaFim
							END
						END
					END
				END
			ELSE BEGIN
				IF @horaFim > @horaInicioPonto BEGIN
					SET @horaInicioAux = @horaInicioPonto
					SET @horaFimAux = @horaFim
					END
				ELSE BEGIN
					IF @horaFim < @horaInicio BEGIN
						SET @horaInicioAux = @horaInicioPonto

						IF @horaFim > @horaFimPonto BEGIN
							SET @horaFimAux = @horaFimPonto
							END
						ELSE BEGIN
							SET @horaFimAux = @horaFim
							END
						END
					END
				END
			END

		IF (@horaInicioAux <> '00:00' OR @horaFimAux <> '00:00') BEGIN
			IF @horaInicioAux < @horaFimAux BEGIN
				SET @horasIgnorar = 
					((DATEPART(hh, @horaFimAux) * 60) +  DATEPART(mi, @horaFimAux)) -
					((DATEPART(hh, @horaInicioAux) * 60) +  DATEPART(mi, @horaInicioAux))
				END
			ELSE BEGIN
				SET @horasIgnorar = 
					((DATEPART(hh, @horaFimAux) * 60) +  DATEPART(mi, @horaFimAux)) +
					((24 * 60) - ((DATEPART(hh, @horaInicioAux) * 60) +  DATEPART(mi, @horaInicioAux)))
				END
			END

		-- SELECT @recursoPontoRH, @horas, @horasExcecao, @horasTransf, @horaInicioPonto, 
		-- 		  @horaFimPonto, @horaInicio, @horaFim, @horasIgnorar, @horaInicioAux, @horaFimAux

		IF @horasIgnorar > 0 BEGIN
			SET @horasIgnorar = @horasIgnorar / 60

			SET @horas = @horas - @horasIgnorar

			IF @horas < (@horasExcecao + @horasTransf) BEGIN
				IF @horasExcecao > 0 AND @horasTransf > 0 BEGIN
					IF @horasExcecao > @horas BEGIN
						SET @horasExcecao = @horas
						SET @horasTransf = 0
						END
					ELSE BEGIN
						SET @horasTransf = @horas - @horasExcecao
						END					
					END
				ELSE BEGIN
					IF @horasExcecao > 0 BEGIN
						SET @horasExcecao = @horas
						END
					ELSE BEGIN
						SET @horasTransf = @horas
						END
					END
				END

			UPDATE #pontos
			   SET qt_horas = @horas,
			       qt_horas_ignorar = @horasIgnorar,
				   qt_horas_exc = @horasExcecao,
				   qt_horas_trf = @horasTransf
			 WHERE id_recurso_pontoRH = @recursoPontoRH
			END

		FETCH NEXT FROM c_IgnorarProducao 
			INTO @recursoPontoRH, @horas, @horasExcecao, @horasTransf,
				 @horaInicioPonto, @horaInicio, @horaFimPonto, @horaFim, 
				 @horasIgnorar, @horaInicioAux,	@horaFimAux
		END
	END

CLOSE c_IgnorarProducao
DEALLOCATE c_IgnorarProducao
/**********************************************************************************/

--SELECT qt_horas, qt_horas_ignorar, qt_horas_exc, qt_horas_trf, id_periodo_recurso, id_recurso, dt_referencia
--  FROM #PONTOS
-- where qt_horas_ignorar > 0
-- exec sp_fechamento_processar 3, 1, 1

/**********************************************************************************/
/*** TRATAMENTO DAS HORAS TRANSFERIDAS ENTRE CENTROS DE CUSTO *********************/
/**********************************************************************************/
INSERT INTO #Pontos
	SELECT p.id_recurso_pontoRH, p.id_periodo_recurso, p.id_recurso,
		   p.dt_referencia, p.qt_horas_trf, p.dt_inicio, p.dt_fim, p.id_cc_trf,
		   ISNULL(cc.cd_cc, ''), ISNULL(cc.nm_cc, ''), ISNULL(cc.id_tipo, 0),
		   p.id_funcao_trf, ISNULL(f.nm_funcao, ''), ISNULL(f.id_classificacao, 0),
		   ISNULL(f.dv_participa_pmh, 0), ISNULL(f.dv_participa_cmh, 0),
		   p.dv_contabiliza_separado, p.qt_dias_experiencia, 0, 0, 0, 0, 0, 0, 1, 1
	  FROM #Pontos p
			INNER JOIN tb_centrocusto cc WITH(NOLOCK)
				ON cc.id_cc = p.id_cc_trf
			INNER JOIN tb_funcoes f WITH(NOLOCK)
				ON f.id_funcao = p.id_funcao_trf
	 WHERE p.id_cc_trf > 0
	   AND p.qt_horas_trf > 0

UPDATE #Pontos
   SET qt_horas = qt_horas - qt_horas_trf
 WHERE id_cc_trf > 0
/**********************************************************************************/


/**********************************************************************************/
/*** REMOÇÃO DO CÁLCULO DOS DIAS DE EXPERIÊNCIA E EXCEÇÕES DO CALENDÁRIO **********/
/**********************************************************************************/
-- Dias de Experiência
UPDATE p
   SET p.dv_considerar = 0
  FROM #pontos p
		INNER JOIN tb_experiencias e WITH(NOLOCK)
			ON p.dt_referencia = e.dt_experiencia
		   AND p.id_recurso = e.id_recurso
		INNER JOIN #Calendario c
			ON c.dt_referencia = e.dt_experiencia

-- Ignorar Produção Total Calendário
UPDATE p
   SET p.dv_considerar = 0
  FROM #pontos p
		INNER JOIN #Calendario c
			ON c.dt_referencia = p.dt_referencia
 WHERE c.id_ignorar_producao = 1
 /**********************************************************************************/


/**********************************************************************************/
/*** CALCULO DO TMH/PMH/CMH DIÁRIO POR CENTRO DE CUSTO  ***************************/
/**********************************************************************************/
IF @diario = 1 BEGIN
	DELETE tb_Fechamentos_CentroCusto_Diario WHERE id_periodo = @periodo

	INSERT INTO tb_Fechamentos_CentroCusto_Diario
			(id_periodo, dt_referencia, id_cc, id_tipo, 
			 qt_horas_tmh, qt_horas_pmh, qt_horas_cmh)
		SELECT @periodo, dt_referencia, id_cc, id_tipo, 
			   SUM(qt_horas) TMH,
			   SUM(CASE WHEN dv_participa_pmh = 1 THEN (qt_horas - qt_horas_exc) ELSE 0 END) PMH,
			   SUM(CASE WHEN dv_participa_cmh = 1 THEN (qt_horas - qt_horas_exc) ELSE 0 END) CMH
		  FROM #Pontos
		 WHERE dv_considerar = 1
		 GROUP BY dt_referencia, id_cc, id_tipo
	END
/**********************************************************************************/


/**********************************************************************************/
/*** CALCULO DO TMH/PMH/CMH MENSAL POR CENTRO DE CUSTO  ***************************/
/**********************************************************************************/
IF @mensal = 1 BEGIN
	DELETE tb_Fechamentos_Categoria_Mensal WHERE id_periodo = @periodo
	DELETE tb_Fechamentos_CentroCusto_Mensal WHERE id_periodo = @periodo
	DELETE tb_Fechamentos_CentroCusto_Mensal_Categoria WHERE id_periodo = @periodo

	INSERT INTO #Servico (id_cc, qt_horas_servico)
		SELECT ci.id_cc, SUM(ISNULL(ci.nr_horas_dia, 0)) * @diaBridge
		  FROM tb_contratos_itens ci WITH(NOLOCK)
				INNER JOIN tb_contratos c WITH(NOLOCK)
					ON ci.id_contrato = c.id_contrato
		 WHERE c.id_periodo = @periodo
		 GROUP BY ci.id_cc

	INSERT INTO #Categorias (id_cc, id_categoria, pc_distribuicao)
		SELECT id_cc, id_categoria, pc_distribuicao
		  FROM tb_CentroCusto_Categorias
		 WHERE id_cc IN (SELECT DISTINCT id_cc FROM #Pontos WHERE dv_considerar = 1)

	INSERT INTO #Mensal (id_cc, id_tipo, qt_horas_tmh, qt_horas_pmh,
						 qt_horas_cmh, qt_horas_cedidas, qt_horas_recebidas, qt_horas_excecoes)
		SELECT p.id_cc, p.id_tipo, SUM(p.qt_horas) horas_TMH,
				SUM(CASE WHEN p.dv_participa_pmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_PMH,
				SUM(CASE WHEN p.dv_participa_cmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_CMH,
				SUM(p.qt_horas_trf) horas_Cedidas,
				SUM(CASE WHEN p.dv_ajuste = 1 THEN p.qt_horas ELSE 0 END) horas_Recebidas,
				SUM(p.qt_horas_exc) horas_Excecoes
		 FROM #Pontos p
		WHERE p.dv_considerar = 1
		GROUP BY p.id_cc, p.id_tipo

	INSERT INTO #Pesos
		SELECT id_categoria, sum(qt_peso_armazenado), 0
	      FROM tb_pesos_armazenados
	     WHERE dt_referencia between @inicio and @fim
	     GROUP BY id_categoria

	SELECT @pesoArmazenado = SUM(qt_peso_armazenado) FROM #Pesos

	UPDATE #Pesos
	   SET qt_peso_ajustado = (qt_peso_armazenado * @pesoAjustado) / @pesoArmazenado

	INSERT INTO tb_Fechamentos_Categoria_Mensal (id_periodo, id_categoria, qt_peso_armazenado, qt_peso_ajustado)
		SELECT @periodo, id_categoria, qt_peso_armazenado, qt_peso_ajustado FROM #Pesos

	INSERT INTO tb_Fechamentos_CentroCusto_Mensal
			(id_periodo, id_cc, id_tipo, qt_horas_tmh, qt_horas_pmh, qt_horas_cmh, qt_horas_servicos,
			 qt_peso_ajustado, qt_horas_cedidas, qt_horas_recebidas, qt_horas_excecoes)
		SELECT @periodo, pt.id_cc, pt.id_tipo, pt.qt_horas_tmh, pt.qt_horas_pmh, (pt.qt_horas_cmh + ISNULL(s.qt_horas_servico, 0)) horas_CMH,
			   ISNULL(s.qt_horas_servico, 0), isnull(pa.qt_peso_ajustado, 0), pt.qt_horas_cedidas, 
			   pt.qt_horas_recebidas, pt.qt_horas_excecoes
		  FROM #Mensal pt
				 LEFT JOIN #Servico s
					ON pt.id_cc = s.id_cc
				 LEFT JOIN (SELECT c.id_cc, SUM(ps.qt_peso_ajustado) qt_peso_ajustado
							  FROM #Categorias c
									INNER JOIN #Pesos ps
										ON ps.id_categoria = c.id_categoria
							GROUP BY c.id_cc) pa
					ON pa.id_cc = pt.id_cc

	INSERT INTO tb_Fechamentos_CentroCusto_Mensal_Categoria
			(id_periodo, id_cc, id_categoria, pc_distribuicao, qt_horas_tmh, qt_horas_pmh, qt_horas_cmh)
		SELECT @periodo, m.id_cc, c.id_categoria, c.pc_distribuicao, 
			   convert(numeric(9,2), (m.qt_horas_tmh * c.pc_distribuicao / 100)) qt_horas_categ_tmh, 
			   convert(numeric(9,2), (m.qt_horas_pmh * c.pc_distribuicao / 100)) qt_horas_categ_pmh, 
			   convert(numeric(9,2), ((m.qt_horas_cmh + ISNULL(s.qt_horas_servico, 0)) * c.pc_distribuicao / 100)) qt_horas_categ_cmh
		  FROM #Mensal m
				INNER JOIN #Categorias c
					ON m.id_cc = c.id_cc
				 LEFT JOIN #Servico s
					ON m.id_cc = s.id_cc

	DECLARE c_Arredondamento CURSOR READ_ONLY FOR
		SELECT ccm.id_cc, 
			   ccm.qt_horas_tmh, ccc.qt_horas_tmh,
			   ccm.qt_horas_pmh, ccc.qt_horas_pmh, 
			   ccm.qt_horas_cmh, ccc.qt_horas_cmh
		  FROM dbo.tb_Fechamentos_CentroCusto_Mensal ccm WITH(NOLOCK)
				INNER JOIN (SELECT id_cc, 
								   SUM(qt_horas_tmh) qt_horas_tmh, 
								   SUM(qt_horas_pmh) qt_horas_pmh, 
								   SUM(qt_horas_cmh) qt_horas_cmh
							  FROM dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria WITH(NOLOCK)
							 WHERE id_periodo = @periodo
							 GROUP BY id_cc
							) ccc
					ON ccm.id_cc = ccc.id_cc
		 WHERE ccm.id_periodo = @periodo
		   AND ((ccm.qt_horas_tmh <> ccc.qt_horas_tmh)
		     OR (ccm.qt_horas_pmh <> ccc.qt_horas_pmh)
			 OR (ccm.qt_horas_cmh <> ccc.qt_horas_cmh))
		 		  	
	OPEN c_Arredondamento
	FETCH NEXT FROM c_Arredondamento 
		INTO @centroCusto, @horasTMH, @horasCategTMH, @horasPMH, @horasCategPMH, @horasCMH, @horasCategCMH

	WHILE (@@fetch_status <> -1) BEGIN
		IF (@@fetch_status <> -2) BEGIN
			IF @horasTMH <> @horasCategTMH BEGIN
				SET @diferenca = @horasTMH - @horasCategTMH

				SET @categoria = 
					(SELECT TOP 1 id_categoria
					   FROM dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria WITH(NOLOCK)
				      WHERE id_periodo = @periodo
						AND id_cc = @centroCusto
					  ORDER BY qt_horas_tmh DESC)

				UPDATE dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria 
				   SET qt_horas_tmh = qt_horas_tmh + @diferenca
				 WHERE id_periodo = @periodo
				   AND id_cc = @centroCusto
				   AND id_categoria = @categoria
				END

			IF @horasPMH <> @horasCategPMH BEGIN
				SET @diferenca = @horasPMH - @horasCategPMH

				SET @categoria = 
					(SELECT TOP 1 id_categoria
					   FROM dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria WITH(NOLOCK)
				      WHERE id_periodo = @periodo
						AND id_cc = @centroCusto
					  ORDER BY qt_horas_pmh DESC)

				UPDATE dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria 
				   SET qt_horas_pmh = qt_horas_pmh + @diferenca
				 WHERE id_periodo = @periodo
				   AND id_cc = @centroCusto
				   AND id_categoria = @categoria
				END

			IF @horasCMH <> @horasCategCMH BEGIN
				SET @diferenca = @horasCMH - @horasCategCMH

				SET @categoria = 
					(SELECT TOP 1 id_categoria
					   FROM dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria WITH(NOLOCK)
				      WHERE id_periodo = @periodo
						AND id_cc = @centroCusto
					  ORDER BY qt_horas_cmh DESC)

				UPDATE dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria 
				   SET qt_horas_cmh = qt_horas_cmh + @diferenca
				 WHERE id_periodo = @periodo
				   AND id_cc = @centroCusto
				   AND id_categoria = @categoria
				END

			FETCH NEXT FROM c_Arredondamento 
				INTO @centroCusto, @horasTMH, @horasCategTMH, @horasPMH, @horasCategPMH, @horasCMH, @horasCategCMH
			END
		END

	CLOSE c_Arredondamento
	DEALLOCATE c_Arredondamento


	/**********************************************************************************/
	/***   DADOS PARA GERAÇÂO DO HEADCOUNT   ******************************************/
	/**********************************************************************************/
	DELETE tb_Fechamentos_Classificacao_CentroCusto WHERE id_periodo = @periodo
	DELETE tb_Fechamentos_Classificacao_Motivo WHERE id_periodo = @periodo
	DELETE tb_Fechamentos_Classificacao_Categoria WHERE id_periodo = @periodo
	DELETE tb_Fechamentos_Classificacao_Funcao WHERE id_periodo = @periodo
	DELETE tb_Fechamentos_Classificacao_Servico_Funcao WHERE id_periodo = @periodo
	DELETE tb_Fechamentos_Classificacao_Servico_Categoria WHERE id_periodo = @periodo

	INSERT INTO tb_Fechamentos_Classificacao_CentroCusto 
		(id_periodo, id_cc, id_classificacao, nr_recursos, 
		 qt_horas_tmh, qt_horas_pmh, qt_horas_cmh)
		SELECT @periodo, p1.id_cc, p1.id_classificacao, COUNT(1) head_Count,
			   SUM(p1.horas_TMH) horas_TMH, SUM(p1.horas_PMH) horas_PMH, 
			   SUM(p1.horas_CMH) horas_CMH
		  FROM (SELECT p.id_cc, p.id_recurso, p.id_classificacao,
						SUM(p.qt_horas) horas_TMH,
						SUM(CASE WHEN p.dv_participa_pmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_PMH,
						SUM(CASE WHEN p.dv_participa_cmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_CMH
				 FROM #Pontos p
				WHERE p.dv_considerar = 1
				GROUP BY p.id_cc, p.id_recurso, p.id_classificacao) p1
			GROUP BY p1.id_cc, p1.id_classificacao

	INSERT INTO tb_Fechamentos_Classificacao_Funcao 
		(id_periodo, id_funcao, id_classificacao, nr_recursos, 
		 qt_horas_tmh, qt_horas_pmh, qt_horas_cmh)
		SELECT @periodo, p1.id_funcao, p1.id_classificacao, COUNT(1) head_Count,
			   SUM(p1.horas_TMH) horas_TMH, SUM(p1.horas_PMH) horas_PMH, 
			   SUM(p1.horas_CMH) horas_CMH
		  FROM (SELECT p.id_funcao, p.id_recurso, p.id_classificacao,
						SUM(p.qt_horas) horas_TMH,
						SUM(CASE WHEN p.dv_participa_pmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_PMH,
						SUM(CASE WHEN p.dv_participa_cmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_CMH
				 FROM #Pontos p
				WHERE p.dv_considerar = 1
				GROUP BY p.id_funcao, p.id_recurso, p.id_classificacao) p1
			GROUP BY p1.id_funcao, p1.id_classificacao

	INSERT INTO tb_Fechamentos_Classificacao_Motivo 
		(id_periodo, id_motivo, id_classificacao, nr_recursos, qt_horas)
		SELECT @periodo, p1.id_motivo_exc, p1.id_classificacao, 
				COUNT(1) head_Count,
			    SUM(p1.qt_horas_exc) qt_horas_exc
		  FROM (SELECT p.id_motivo_exc, p.id_recurso, p.id_classificacao, SUM(p.qt_horas_exc) qt_horas_exc
				 FROM #Pontos p
				WHERE p.dv_considerar = 1
				  AND p.id_motivo_exc > 0
				GROUP BY p.id_motivo_exc, p.id_recurso, p.id_classificacao) p1
			GROUP BY p1.id_motivo_exc, p1.id_classificacao

	INSERT INTO tb_Fechamentos_Classificacao_Categoria
			(id_periodo, id_categoria, id_classificacao, nr_recursos, 
			 qt_horas_tmh, qt_horas_pmh, qt_horas_cmh)
		SELECT @periodo, p2.id_categoria, p2.id_classificacao, COUNT(1) head_Count,
			   SUM(p2.horas_TMH) horas_TMH, SUM(p2.horas_PMH) horas_PMH, 
			   SUM(p2.horas_CMH) horas_CMH
		  FROM (SELECT c.id_categoria, p1.id_classificacao, p1.id_recurso,
					   convert(numeric(9,2), (p1.horas_TMH * c.pc_distribuicao / 100)) horas_TMH, 
					   convert(numeric(9,2), (p1.horas_PMH * c.pc_distribuicao / 100)) horas_PMH, 
					   convert(numeric(9,2), ((p1.horas_CMH + ISNULL(s.qt_horas_servico, 0)) * c.pc_distribuicao / 100)) horas_CMH
				  FROM (SELECT p.id_cc, p.id_recurso, p.id_classificacao,
								SUM(p.qt_horas) horas_TMH,
								SUM(CASE WHEN p.dv_participa_pmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_PMH,
								SUM(CASE WHEN p.dv_participa_cmh = 1 THEN (p.qt_horas - p.qt_horas_exc) ELSE 0 END) horas_CMH
						 FROM #Pontos p
						WHERE p.dv_considerar = 1
						GROUP BY p.id_cc, p.id_recurso, p.id_classificacao
						) p1
							INNER JOIN #Categorias c
								ON c.id_cc = p1.id_cc
							LEFT JOIN #Servico s
								ON s.id_cc = p1.id_cc
				) p2
			GROUP BY p2.id_categoria, p2.id_classificacao

	INSERT INTO tb_Fechamentos_Classificacao_Servico_Funcao
			(id_periodo, id_funcao, id_classificacao, qt_horas)
		SELECT @periodo, cf1.id_funcao, cf1.id_classificacao, 
		       (sum(cf1.nr_horas_dia) * @diaBridge) nr_horas
		  FROM (SELECT cf.id_funcao,
					   isnull(cf.nr_horas_dia, 0) nr_horas_dia, 
					   isnull(cf.id_classificacao, f.id_classificacao) id_classificacao
				  FROM tb_contratos_funcoes cf WITH(NOLOCK)
						INNER JOIN tb_contratos c WITH(NOLOCK)
							ON cf.id_contrato = c.id_contrato
						INNER JOIN tb_funcoes f WITH(NOLOCK)
							ON cf.id_funcao = f.id_funcao
				 WHERE c.id_periodo = @periodo
				 ) cf1
		 GROUP BY cf1.id_funcao, cf1.id_classificacao

	INSERT INTO tb_Fechamentos_Classificacao_Servico_Categoria
			(id_periodo, id_categoria, id_cc, qt_horas)
		SELECT @periodo, s1.id_categoria, s1.id_cc, SUM(s1.qt_horas) qt_horas
		  FROM (SELECT c.id_categoria, s.id_cc,  
					   convert(numeric(9,2), (s.qt_horas_servico * c.pc_distribuicao / 100)) qt_horas
				  FROM #servico s
	  				INNER JOIN tb_CentroCusto_Categorias c
						ON c.id_cc = s.id_cc
				) s1
		 GROUP BY s1.id_categoria, s1.id_cc

	END
/**********************************************************************************/

DROP TABLE #Pontos
DROP TABLE #Servico
DROP TABLE #Pesos
DROP TABLE #Categorias
DROP TABLE #Mensal
DROP TABLE #Calendario

END
GO
