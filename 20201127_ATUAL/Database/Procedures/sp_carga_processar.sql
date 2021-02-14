
-- exec sp_carga_processar 0, 1, 1
CREATE PROCEDURE sp_carga_processar
(
	@cargos			bit = 1,
	@funcionarios	bit = 1,
	@ponto			bit = 1
)
AS BEGIN
SET NOCOUNT ON

DECLARE @funcaoBase		int = 1,
		@competencia	date,
		@periodo		int,
		@usuario 		varchar(50) = 'admin',
		@mensagem		varchar(200)

DECLARE @log			varchar(1000),
		@grupo			varchar(50)

DECLARE @HtmlHeader		AS NVARCHAR(MAX) = '', 
		@HtmlTable		AS NVARCHAR(MAX) = '',
		@HtmlBody		AS NVARCHAR(MAX) = '',
		@EmailAssunto	AS VARCHAR(200) = '',
		@EmailDestinatarios AS VARCHAR(4000) = ''

SET @funcaoBase = (SELECT id_funcao FROM tb_funcoes 
					WHERE cd_operacao = 999 AND nm_funcao = 'SFD')

CREATE TABLE #Cargos
(
id_cargo		int				NOT NULL,
id_cargo_origem	int				NOT NULL,
nm_cargo		varchar(150)	NOT NULL,
st_cargo		varchar(10)		NOT NULL,
id_situacao		int				NOT NULL
)
CREATE NONCLUSTERED INDEX iCargos ON #Cargos (id_cargo_origem);

CREATE TABLE #CentroCusto
(
id_cc			int				NOT NULL,
id_cc_origem	int				NOT NULL,
cd_cc			varchar(200)	NOT NULL,
nm_cc			varchar(150)	NOT NULL,
st_cc			varchar(10)		NOT NULL,
id_situacao		int				NOT NULL
)
CREATE NONCLUSTERED INDEX iCC ON #CentroCusto (id_cc_origem);

CREATE TABLE #Verbas
(
id_tipo_verba	int				NOT NULL,	
ds_tipo_verba	varchar(150)	NOT NULL
)
CREATE NONCLUSTERED INDEX iVerba ON #Verbas (id_tipo_verba);

CREATE TABLE #Funcionarios
(
id_cargo		int				NOT NULL,
id_cc_origem	int				NOT NULL,
st_funcionario	varchar(50)		NOT NULL,
ds_tipo_verba	int				NOT NULL,
ds_tipo			varchar(50)		NOT NULL,
nr_matricula	varchar(20)		NOT NULL,
nm_funcionario	varchar(200)	NOT NULL,
ds_situacao		varchar(20)		NOT NULL,
dt_inicio		date			NOT NULL,
ds_escala		varchar(50)		NOT NULL,
id_cc			int				NOT NULL, 
id_funcao		int				NOT NULL,
id_situacao		int				NOT NULL,
id_recurso		int				NOT NULL, 
nm_cargo		varchar(100)	NOT NULL
)
CREATE NONCLUSTERED INDEX iFuncionario ON #Funcionarios (nr_matricula);

CREATE TABLE #Pontos
(
id_recurso_ponto int		NOT NULL,
nr_matricula	varchar(20)	NOT NULL,
id_tipo_verba	int			NOT NULL,
qt_horas		time		NOT NULL,
dt_inicio		datetime	NOT NULL,
dt_fim			datetime	NOT NULL,
dt_competencia	date		NULL,
dt_referencia	date		NOT NULL,
id_recurso		int			NOT NULL,
id_periodo_recurso int		NOT NULL DEFAULT 0,
id_periodo		int			NOT NULL DEFAULT 0,
dt_inicio_atual	datetime	NULL,
dt_fim_atual	datetime	NULL
)
CREATE NONCLUSTERED INDEX iPonto ON #Pontos (nr_matricula);
CREATE NONCLUSTERED INDEX iPonto1 ON #Pontos (dt_competencia);
CREATE NONCLUSTERED INDEX iPonto2 ON #Pontos (id_periodo, id_recurso);
CREATE NONCLUSTERED INDEX iPonto3 ON #Pontos (id_recurso_ponto, dt_inicio_atual, dt_fim_atual);

CREATE TABLE #Log
(
nm_grupo		varchar(50)		NOT NULL,
ds_log			varchar(1000)	NOT NULL,
nr_ordem		int				NOT NULL
)

/*******************************************************************************/
/*** TRATAMENTO E IMPORTAÇÃO DE CARGOS *****************************************/
/*******************************************************************************/
INSERT INTO #Cargos (id_cargo, id_cargo_origem, nm_cargo, st_cargo, id_situacao)
	SELECT 0, id_cargo, nm_cargo, st_cargo, 
		   (CASE WHEN st_cargo = 'A' THEN 1 ELSE 2 END) id_situacao
	  FROM [dbo].[tb_Carga_Cargos]

IF @cargos = 1 BEGIN
	-- ATUALIZAÇÃO
	UPDATE c
	   SET c.nm_cargo = tc.nm_cargo, 
		   c.id_situacao = tc.id_situacao
	  FROM tb_cargos c
			INNER JOIN #Cargos tc
				ON c.id_cargo_origem = tc.id_cargo_origem

	-- INCLUSÃO
	INSERT INTO tb_cargos (id_cargo_origem, nm_cargo, id_situacao)
		SELECT id_cargo_origem, nm_cargo, id_situacao
		  FROM #Cargos 
		 WHERE id_cargo_origem NOT IN
			(SELECT id_cargo_origem FROM tb_cargos)
	END

-- CONTROLE
UPDATE tc
   SET tc.id_cargo = c.id_cargo
  FROM tb_cargos c
		INNER JOIN #Cargos tc
			ON c.id_cargo_origem = tc.id_cargo_origem
/*******************************************************************************/

/*******************************************************************************/
/*** TRATAMENTO E IMPORTAÇÃO DE CENTROS DE CUSTO *******************************/
/*******************************************************************************/
INSERT INTO #CentroCusto (id_cc, id_cc_origem, nm_cc, st_cc, cd_cc, id_situacao)
	SELECT 0, id_cc, nm_cc, st_cc,
			(SELECT TOP 1 ITEM FROM dbo.fc_Split(nm_cc, '-')) cd_cc,
		   (CASE WHEN st_cc = 'A' THEN 1 ELSE 2 END) id_situacao
	  FROM dbo.tb_Carga_CentrosCusto

UPDATE #CentroCusto 
   SET nm_cc = REPLACE(nm_cc, (cd_cc + '-'), ''),
       cd_cc = REPLACE(cd_cc, '0010', '')

-- CONTROLE
UPDATE tcc
   SET tcc.id_cc = cc.id_cc
  FROM tb_CentroCusto cc
		INNER JOIN #CentroCusto tcc
			ON cc.cd_cc = tcc.cd_cc
/*******************************************************************************/

/*******************************************************************************/
/*** TRATAMENTO E IMPORTAÇÃO DE VERBAS *****************************************/
/*******************************************************************************/
INSERT INTO #Verbas (id_tipo_verba, ds_tipo_verba)
	SELECT dbo.fc_Trim (id_tipo_verba) id_tipo_verba, 
		   dbo.fc_Trim (ds_tipo_verba) ds_tipo_verba
	  FROM dbo.tb_Carga_Tipos_Verbas
/*******************************************************************************/

/*******************************************************************************/
/*** TRATAMENTO E IMPORTAÇÃO DE FUNCIONÁRIOS ***********************************/
/*******************************************************************************/
INSERT INTO #Funcionarios 
		(id_cargo, id_cc_origem, st_funcionario, ds_tipo_verba, ds_tipo,
		 nr_matricula, nm_funcionario, ds_situacao, dt_inicio, ds_escala,
		 id_cc, id_funcao, id_situacao, id_recurso, nm_cargo)
	SELECT dbo.fc_Trim (cf.id_cargo) id_cargo, 
		   dbo.fc_Trim (cf.id_cc) id_cc,
		   dbo.fc_Trim (cf.st_funcionario) st_funcionario,
		   15, dbo.fc_Trim (cf.ds_tipo) ds_tipo,
		   dbo.fc_Trim (cf.nr_matricula) nr_matricula,
		   dbo.fc_Trim (cf.nm_funcionario) nm_funcionario,
		   dbo.fc_Trim (cf.ds_situacao) ds_situacao,
		   (dbo.fc_Trim (cf.dt_inicio) + '01') dt_inicio,
		   dbo.fc_Trim (cf.ds_escala) ds_escala,
		   ISNULL(cc.id_cc, 0) id_cc,
		   0, 0, 0, ''
	  FROM dbo.tb_Carga_Funcionarios cf
			LEFT JOIN #CentroCusto cc
				ON cc.id_cc_origem = cf.id_cc

UPDATE f
   SET f.id_situacao = ISNULL(s.id_situacao, 0),
	   f.id_funcao = ISNULL(cf.id_funcao, @funcaoBase),
	   f.nm_cargo = ISNULL(c.nm_cargo, ''),
	   f.id_recurso = ISNULL(r.id_recurso, 0)
  FROM #Funcionarios f
		LEFT JOIN tb_recursos r
			ON r.cd_rl = f.nr_matricula
		LEFT JOIN tb_Situacoes s
			ON s.nm_situacao = f.st_funcionario AND s.id_dominio = 4
		LEFT JOIN #Cargos c
			ON c.id_cargo_origem = f.id_cargo
		LEFT JOIN tb_Cargos_funcoes cf
			ON cf.id_cargo = c.id_cargo AND f.id_cc = cf.id_cc

IF @funcionarios = 1 BEGIN
	INSERT INTO #Log (nm_grupo, nr_ordem ,ds_log)
		SELECT 'Funcionários', 5, 
			   (CASE WHEN f.id_cc = 0
				THEN 'Centro de Custo ' + CONVERT(VARCHAR, f.id_cc_origem) + 
						' do Funcionário "' + f.nm_funcionario + 
						'" não cadastrado. Matricula ' + f.nr_matricula
				ELSE 'Cargo ' + CONVERT(VARCHAR, f.id_cargo) + 
						' do Funcionário "' + f.nm_funcionario + 
						'" não cadastrado. Matricula ' + f.nr_matricula
			   END) mensagem
		  FROM #Funcionarios f	
		 WHERE f.id_cc = 0 
			OR f.nm_cargo = ''

	-- ATUALIZAÇÃO
	UPDATE r
	   SET r.nm_recurso = f.nm_funcionario,
		   r.ds_rh_status = f.st_funcionario,	
		   r.ds_rh_cargo = f.nm_cargo,	
		   r.dt_entrada = f.dt_inicio,	
		   r.id_cc = f.id_cc,
		   r.id_funcao = f.id_funcao,
		   r.id_situacao = f.id_situacao,
		   r.ds_rh_regime_trabalho = f.ds_tipo,
		   r.ds_escala = f.ds_escala
	  FROM tb_recursos r
			INNER JOIN #Funcionarios f
				ON f.id_recurso = r.id_recurso
	 WHERE f.id_recurso > 0

	-- INCLUSÃO
	INSERT INTO TB_RECURSOS (cd_rl, nm_recurso, qt_dias_experiencia, dv_calculo_remover, 
			ds_rh_status, ds_rh_regime_trabalho, ds_escala, ds_rh_cargo, dt_entrada, 
			id_cc, id_funcao, id_situacao)
		SELECT f.nr_matricula, f.nm_funcionario, 
			   0 as qt_dias_experiencia, 0 as dv_calculo_remover,
			   f.st_funcionario, f.ds_tipo, f.ds_escala,
			   f.nm_cargo, f.dt_inicio, f.id_cc, 
			   f.id_funcao, f.id_situacao
		  FROM #Funcionarios f
		 WHERE f.id_recurso = 0
		   AND id_cc > 0 AND id_funcao > 0

	UPDATE f
	   SET f.id_recurso = r.id_recurso
	  FROM #Funcionarios f
			INNER JOIN tb_recursos r
				ON r.cd_rl = f.nr_matricula
	 WHERE f.id_recurso = 0
	END
/*******************************************************************************/


/*******************************************************************************/
/*** TRATAMENTO E IMPORTAÇÃO DE PONTOS *****************************************/
/*******************************************************************************/
IF @ponto = 1 BEGIN 
	INSERT INTO #Pontos (id_recurso_ponto, nr_matricula, id_tipo_verba, qt_horas,
						 dt_inicio, dt_fim, dt_referencia, id_recurso)
		SELECT 0, dbo.fc_Trim(ca.nr_matricula) nr_matricula, 
			   CONVERT(INT, dbo.fc_Trim(ca.id_tipo_verba)) id_tipo_verba, 
			   CONVERT(TIME, dbo.fc_Trim(ca.qt_horas)) qt_horas,
			   CONVERT(DATETIME, dbo.fc_Trim(ca.dt_inicio), 103) dt_inicio, 
			   CONVERT(DATETIME, dbo.fc_Trim(ca.dt_fim), 103) dt_fim,
			   CONVERT(DATE, dbo.fc_Trim(ca.dt_inicio), 103) dt_referencia,
			   ISNULL(f.id_recurso, 0) id_recurso
		  FROM [dbo].[tb_Carga_Apontamentos] ca
				LEFT JOIN #Funcionarios f
					ON ca.nr_matricula = f.nr_matricula

	UPDATE #Pontos 
	   SET dt_referencia = DATEADD(dd, -1, dt_referencia)
	 WHERE datepart(hour, dt_inicio) < 6

	UPDATE #Pontos 
	   SET dt_competencia = dateadd(dd, ((-1 * datepart(dd, dt_referencia)) + 1), dt_referencia),
		   qt_horas = convert(time, (dt_fim - dt_inicio))

	/*******************************************************************************/
	/*** TRATAMENTO DE PERIODOS ****************************************************/ 
	/*******************************************************************************/ 
	DECLARE c_Periodos CURSOR READ_ONLY FOR
		SELECT pt.dt_competencia
		  FROM (SELECT DISTINCT(dt_competencia) dt_competencia FROM #Pontos) pt
			LEFT JOIN tb_periodos p
				ON p.dt_competencia = pt.dt_competencia
		 WHERE p.id_periodo IS NULL
		  	
	OPEN c_Periodos
	FETCH NEXT FROM c_Periodos INTO @competencia

	WHILE (@@fetch_status <> -1) BEGIN
		IF (@@fetch_status <> -2) BEGIN
			EXEC sp_periodo_criar @competencia, @usuario, 
								  @periodo OUTPUT, @mensagem OUTPUT
			
			FETCH NEXT FROM c_Periodos INTO @competencia
			END
		END

	CLOSE c_Periodos
	DEALLOCATE c_Periodos

	UPDATE pt
	   SET pt.id_periodo = p.id_periodo
	  FROM #Pontos pt
			INNER JOIN tb_periodos p
				ON p.dt_competencia = pt.dt_competencia

	UPDATE pt
	   SET pt.id_periodo_recurso = pr.id_periodo_recurso
	  FROM #Pontos pt
			INNER JOIN tb_periodos_recursos pr
				ON pr.id_periodo = pt.id_periodo
				AND pr.id_recurso = pt.id_recurso
	 WHERE pt.id_recurso > 0

	INSERT INTO tb_periodos_recursos (id_periodo, id_recurso, qt_horas_trabalhadas,
			qt_horas_excecoes, qt_horas_transferidas, id_cc, id_funcao, dv_calculo_remover)
		SELECT p.id_periodo, p.id_recurso, 0, 0, 0, r.id_cc, r.id_funcao, r.dv_calculo_remover
		  FROM (SELECT DISTINCT pt.id_periodo, pt.id_recurso
				  FROM #Pontos pt
				 WHERE pt.id_recurso > 0
				   AND pt.id_periodo_recurso = 0) p
			INNER JOIN tb_Recursos r
				ON r.id_recurso = p.id_recurso

	UPDATE pt
	   SET pt.id_periodo_recurso = pr.id_periodo_recurso
	  FROM #Pontos pt
			INNER JOIN tb_periodos_recursos pr
				ON pr.id_periodo = pt.id_periodo
				AND pr.id_recurso = pt.id_recurso
	 WHERE pt.id_recurso > 0
	   AND pt.id_periodo_recurso = 0
	/*******************************************************************************/

	UPDATE pt
	   SET pt.id_recurso_ponto = p.id_recurso_pontoRH,
		   pt.dt_inicio_atual = p.dt_inicio,
		   pt.dt_fim_atual = p.dt_fim
	  FROM #Pontos pt
			INNER JOIN tb_Recursos_PontosRH p
				ON p.id_periodo_recurso = pt.id_periodo_recurso
			   AND p.dt_referencia = pt.dt_referencia
	 WHERE pt.id_periodo_recurso > 0

	UPDATE p
	   SET p.dt_inicio = pt.dt_inicio_atual,
		   p.dt_fim = pt.dt_fim_atual,
		   p.qt_horas = (CONVERT(DECIMAL(9,2), ((datepart(hour, pt.qt_horas) * 60) + datepart(minute, pt.qt_horas))) / 60)
	  FROM tb_Recursos_PontosRH p
			INNER JOIN #Pontos pt
				ON p.id_periodo_recurso = pt.id_periodo_recurso
			   AND p.dt_referencia = pt.dt_referencia
	 WHERE pt.id_recurso_ponto > 0
	   AND ((p.dt_inicio <> pt.dt_inicio_atual) OR (p.dt_fim <> pt.dt_fim_atual))

	INSERT INTO tb_Recursos_PontosRH (id_periodo_recurso, dt_referencia, qt_horas, 
									  dt_inicio, dt_fim, id_situacao)
		SELECT id_periodo_recurso, dt_referencia, 
			   (CONVERT(DECIMAL(9,2), ((datepart(hour, qt_horas) * 60) + datepart(minute, qt_horas))) / 60) horas,
			   dt_inicio, dt_fim, 1	
		  FROM #Pontos
		 WHERE id_periodo_recurso > 0
		   AND id_recurso_ponto = 0
		 order by id_periodo_recurso, dt_referencia

	INSERT INTO #Log (nm_grupo, nr_ordem ,ds_log)
		SELECT 'Pontos', 6, 
			   (CASE WHEN p.id_recurso = 0
				THEN 'Recurso ' + p.nr_matricula + 
						' no dia ' + CONVERT(VARCHAR, p.dt_referencia, 103) + 
						' não cadastrado.'
				ELSE CASE WHEN p.id_periodo = 0
						THEN 'Período do dia ' + CONVERT(VARCHAR, p.dt_referencia, 103) + 
								' não cadastrado.'
						ELSE 'Recurso ' + p.nr_matricula + 
								' não vinculado ao período do dia ' + CONVERT(VARCHAR, p.dt_referencia, 103) + 
								'. Informe o administrador do sistema.'
					   END
			   END) mensagem
		  FROM #Pontos p	
		 WHERE p.id_recurso = 0 
			OR p.id_periodo_recurso = 0
			OR p.id_periodo = 0
	END
/*******************************************************************************/

/*******************************************************************************/
/**** GERA EMAIL DE PROCESSAMENTO **********************************************/
/*******************************************************************************/
SET @EmailAssunto = 'LHH Importação ADP - Dia ' + CONVERT(VARCHAR, GETDATE(), 103)

SELECT @EmailDestinatarios = vl_parametro
  FROM tb_Parametros
 WHERE id_parametro = 5

IF LEN(@EmailDestinatarios) > 0 BEGIN
	SET @HtmlHeader = '<HTML><HEADER>
							<STYLE type="text/css">
							.h0 { color:white; font: 12px verdana; }
							.f0 { color:black; font: 12px verdana; }
							.f1 { color:black; font: 12px arial,verdana;}
							.f2 { color:red; font: 12px arial,verdana;}
							td { align-self:center; align-content:center; align-items:center; }
							</STYLE></HEADER>
							<BODY>
							<FONT class="f0">Prezado(s) Administrador(es)</FONT><BR><BR>
							<FONT class="f1">Processamento da Importação dos arquivos do RH finalizado com sucesso!</FONT><BR><BR>'

	IF EXISTS(SELECT 1 FROM #Log) BEGIN
		SET @HtmlHeader = @HtmlHeader + '<FONT class="f1">Verifique os itens abaixo que não puderam ser importados:</FONT><BR><BR>'

		SET @HtmlTable = '<TABLE border="1" cellpadding="3" cellspacing="0" style="border-color: #7A1E0A;">
							<TR class="h0" bgcolor="#7A1E0A"><TD align="center"><b>Origem</b></TD><TD align="center"><b>Descrição</b></TD></TR>'

		DECLARE c_Logs CURSOR READ_ONLY FOR
			SELECT nm_grupo, ds_log
			  FROM #Log
			 ORDER BY nr_ordem, ds_log
		  	
		OPEN c_Logs
		FETCH NEXT FROM c_Logs INTO @grupo, @log

		WHILE (@@fetch_status <> -1) BEGIN
			IF (@@fetch_status <> -2) BEGIN
				SET @HtmlTable = @HtmlTable + '<TR class="f1"><TD>' + @grupo + '</TD><TD>' + @log + '</TD></TR>'
			
				FETCH NEXT FROM c_Logs INTO @grupo, @log
				END
			END

		CLOSE c_Logs
		DEALLOCATE c_Logs

		SET @HtmlTable = @HtmlTable + '</TABLE>'
		END

	SET @HtmlBody   = @HtmlHeader + @HtmlTable + '</BODY></HTML>'

	EXEC MSDB.DBO.SP_SEND_DBMAIL 
			@RECIPIENTS = @EmailDestinatarios,
			@SUBJECT = @EmailAssunto,
			@BODY = @HtmlBody,
			@BODY_FORMAT = 'HTML',
			@ATTACH_QUERY_RESULT_AS_FILE = 0;
	END
/*******************************************************************************/

DROP TABLE #Cargos
DROP TABLE #CentroCusto
DROP TABLE #Verbas
DROP TABLE #Funcionarios
DROP TABLE #Log

END
GO
