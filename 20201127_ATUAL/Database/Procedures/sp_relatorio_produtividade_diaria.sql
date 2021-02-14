
 -- exec sp_relatorio_produtividade_diaria 3
CREATE PROCEDURE sp_relatorio_produtividade_diaria
( 
	@periodo		int
) 
AS begin
SET NOCOUNT ON

DECLARE @periodoAnterior	int,
		@situacao			int,
		@competencia		date,
		@nr_horas_servico	numeric(9,2) = 0,
		@referencia			date,
		@horasPMH			numeric(18,2),
		@horasCMH			numeric(18,2),
		@pesoArmazenado		numeric(18,3),
		@ItemPPMH			numeric(9,2) = 0,
		@totalPPMH			numeric(18,2) = 0,
		@contadorPPMH		int = 0,
		@ItemPCMH			numeric(9,2) = 0,
		@TotalPCMH			numeric(18,2) = 0,
		@contadorPCMH		int = 0

SELECT @competencia = dateadd(month, -1, dt_competencia),
	   @situacao = id_situacao
  FROM tb_periodos WITH(NOLOCK)
 WHERE id_periodo = @periodo

SELECT @periodoAnterior = id_periodo
  FROM tb_periodos WITH(NOLOCK) 
 WHERE dt_competencia = @competencia

IF @situacao = 3 BEGIN
	EXEC dbo.sp_fechamento_processar @periodo, 1
	END

/**********************************************************************************/
/*** TABELA TEMPORÁRIA PARA TRATAMENTO DOS DADOS **********************************/
/**********************************************************************************/
CREATE TABLE #FechamentoCC
(
dt_referencia	date not null,
id_cc			int not null,
id_tipo			int not null,
qt_horas_tmh	numeric(9,2) not null,
qt_horas_pmh	numeric(9,2) not null,
qt_horas_cmh	numeric(9,2) not null
)

CREATE TABLE #Relatorio
(
dt_referencia	date not null,
id_cc			int not null,
cd_cc			varchar(50) not null,
nm_cc			varchar(100) not null,
id_tipo			int not null,
nm_tipo			varchar(50) not null,
qt_horas		numeric(18,2) not null,
nr_ordem		int null
)

CREATE TABLE #CentroCusto
(
id_cc			int not null,
cd_cc			varchar(50) not null,
nm_cc			varchar(100) not null,
id_tipo			int not null,
nm_tipo			varchar(50) not null,
nr_ordem		int not null
)

CREATE TABLE #PesoArmazenado
(
dt_referencia		date not null,
qt_peso_armazenado	numeric(18,2) not null
)

CREATE TABLE #Semana
(
id_dia	int not null,
nm_dia	varchar(3) not null
)
INSERT INTO #Semana VALUES (1, 'DOM')
INSERT INTO #Semana VALUES (2, 'SEG')
INSERT INTO #Semana VALUES (3, 'TER')
INSERT INTO #Semana VALUES (4, 'QUA')
INSERT INTO #Semana VALUES (5, 'QUI')
INSERT INTO #Semana VALUES (6, 'SEX')
INSERT INTO #Semana VALUES (7, 'SAB')

/**********************************************************************************/
/*** MÉDIA DE HORAS DE SERVIÇO POR DIA DO MÊS ANTERIOR  ***************************/
/**********************************************************************************/
SELECT @nr_horas_servico = SUM(ISNULL(ci.nr_horas_dia, 0))
  FROM tb_contratos_itens ci WITH(NOLOCK)
		INNER JOIN tb_contratos c WITH(NOLOCK)
			ON ci.id_contrato = c.id_contrato
 WHERE c.id_periodo = @periodoAnterior


/**********************************************************************************/
/*** RECUPERAÇÃO DOS DADOS DE FECHAMENTO POR CENTRO DE CUSTO PARA O PERIODO *******/
/**********************************************************************************/
INSERT INTO #FechamentoCC
	SELECT dt_referencia, id_cc, id_tipo, qt_horas_tmh, qt_horas_pmh, qt_horas_cmh
	  FROM tb_Fechamentos_CentroCusto_Diario
	 WHERE id_periodo = @periodo

/**********************************************************************************/
/*** PREPARAÇÃO DOS DADOS PARA GERAÇÃO DO RELATÓRIO *******************************/
/**********************************************************************************/
INSERT INTO #Relatorio
	SELECT fcc.dt_referencia, fcc.id_cc, 
		   cc.cd_cc, cc.nm_cc, fcc.id_tipo, 
		   t.nm_tipo, fcc.qt_horas_tmh, 1
	  from #FechamentoCC fcc
			INNER JOIN tb_centrocusto cc WITH(NOLOCK)
				ON cc.id_cc = fcc.id_cc
			INNER JOIN tb_tipos t WITH(NOLOCK)
				ON t.id_tipo = fcc.id_tipo

INSERT INTO #PesoArmazenado
	SELECT dt_referencia, (SUM(qt_peso_armazenado) / 1000) peso_armazenado	-- Mlbs
	  FROM tb_pesos_armazenados
	 WHERE dt_referencia IN (SELECT DISTINCT dt_referencia FROM #Relatorio)
	 GROUP BY dt_referencia

INSERT INTO #CentroCusto (id_cc, cd_cc, nm_cc, id_tipo, nm_tipo, nr_ordem)
	SELECT DISTINCT id_cc, cd_cc, nm_cc, id_tipo, nm_tipo, 0
	  FROM #Relatorio

INSERT INTO #CentroCusto VALUES (9000, 'Cont.', 'Serviços', 2, 'Serviços', 0)
INSERT INTO #CentroCusto VALUES (9001, 'Horas PMH', 'Horas PMH', 3, 'Cálculo', 3)
INSERT INTO #CentroCusto VALUES (9002, 'Horas CMH', 'Horas CMH', 3, 'Cálculo', 4)
INSERT INTO #CentroCusto VALUES (9003, 'Peso Armazenado', 'Peso Armazenado', 3, 'Cálculo', 5)
INSERT INTO #CentroCusto VALUES (9004, 'PPMH Diário', 'PPMH Diário', 3, 'Cálculo', 6)
INSERT INTO #CentroCusto VALUES (9005, 'PPMH Acum.', 'PPMH Acum.', 3, 'Cálculo', 7)
INSERT INTO #CentroCusto VALUES (9006, 'PCMH Diário', 'PCMH Diário', 3, 'Cálculo', 8)
INSERT INTO #CentroCusto VALUES (9007, 'PPMH Acum.', 'PPMH Acum.', 3, 'Cálculo', 9)


/**********************************************************************************/
/*** CALCULO E GERAÇÃO DOS CAMPOS DE VALORES DE PPMH/PCMH *************************/
/**********************************************************************************/
INSERT INTO #Relatorio
	SELECT DISTINCT dt_referencia, 9000, 'Cont.', 'Serviços', 
			2, 'Serviços', ISNULL(@nr_horas_servico, 0), 2
	  FROM #Relatorio

DECLARE c_Indicadores CURSOR READ_ONLY FOR
	SELECT dt_referencia, SUM(ISNULL(qt_horas_pmh, 0)), SUM(ISNULL(qt_horas_cmh, 0))
	  FROM #FechamentoCC
     GROUP BY dt_referencia
	 		  	
OPEN c_Indicadores
FETCH NEXT FROM c_Indicadores INTO @referencia, @horasPMH, @horasCMH

WHILE (@@fetch_status <> -1) BEGIN
	IF (@@fetch_status <> -2) BEGIN
		SET @horasCMH = ISNULL(@horasCMH, 0) + ISNULL(@nr_horas_servico, 0)

		INSERT INTO #Relatorio VALUES (@referencia, 9001, 'Horas PMH', 'Horas PMH', 3, 'Cálculo', @horasPMH, 3)

		INSERT INTO #Relatorio VALUES (@referencia, 9002, 'Horas CMH', 'Horas CMH', 3, 'Cálculo', @horasCMH, 4)

		SELECT @pesoArmazenado = qt_peso_armazenado
		  FROM #PesoArmazenado
		 WHERE dt_referencia = @referencia

		INSERT INTO #Relatorio VALUES (@referencia, 9003, 'Peso Armaz. Mlbs', 'Peso Armaz. Mlbs', 3, 'Cálculo', @pesoArmazenado, 5)

		IF @pesoArmazenado > 0 AND @horasPMH > 0 BEGIN
			SET @ItemPPMH = CONVERT(numeric(9,2), (@pesoArmazenado / @horasPMH))

			INSERT INTO #Relatorio VALUES (@referencia, 9004, 'PPMH Diário', 'PPMH Diário', 3, 'Cálculo', @ItemPPMH, 6)

			SET @TotalPPMH = @TotalPPMH + @ItemPPMH
			SET @contadorPPMH = @contadorPPMH + 1

			INSERT INTO #Relatorio VALUES (@referencia, 9005, 'PPMH Acum.', 'PPMH Acum.', 3, 'Cálculo', (@TotalPPMH / @contadorPPMH), 7)
			END

		IF @pesoArmazenado > 0 AND @horasCMH > 0 BEGIN
			SET @ItemPCMH = CONVERT(numeric(9,2), (@pesoArmazenado / @horasCMH))

			INSERT INTO #Relatorio VALUES (@referencia, 9006, 'PCMH Diário', 'PCMH Diário', 3, 'Cálculo', @ItemPCMH, 8)

			SET @TotalPCMH = @TotalPCMH + @ItemPCMH
			SET @contadorPCMH = @contadorPCMH + 1

			INSERT INTO #Relatorio VALUES (@referencia, 9007, 'PCMH Acum.', 'PCMH Acum.', 3, 'Cálculo', (@TotalPCMH / @contadorPCMH), 9)
			END

		FETCH NEXT FROM c_Indicadores INTO @referencia, @horasPMH, @horasCMH
		END
	END

CLOSE c_Indicadores
DEALLOCATE c_Indicadores


/**********************************************************************************/
/*** PREENCHIMENTO DOS DIAS COM VALORES ZERADOS ***********************************/
/**********************************************************************************/
INSERT INTO #Relatorio 
	SELECT a.dt_referencia, a.id_cc, a.cd_cc, a.nm_cc, a.id_tipo, a.nm_tipo, 0, 
			isnull(a.nr_ordem, isnull(r.nr_ordem, 1))
	  FROM (SELECT c.dt_referencia, cc.id_cc, cc.cd_cc, cc.nm_cc, 
					cc.id_tipo, cc.nm_tipo, cc.nr_ordem
			  FROM tb_calendarios c, #CentroCusto cc
			 WHERE id_periodo = @periodo) a
			LEFT JOIN #Relatorio r
				ON a.dt_referencia = r.dt_referencia AND a.id_cc = r.id_cc
	 WHERE r.id_cc IS NULL


/**********************************************************************************/
/*** RETORNO PARA GERAÇÃO DO RELATÓRIO ********************************************/
/**********************************************************************************/
SELECT s.nm_dia AS nm_dia, 
	   day(r.dt_referencia) id_dia,
	   r.id_cc, 
	   r.cd_cc, 
	   r.nm_cc, 
	   r.id_tipo, 
	   r.nm_tipo, 
	   r.qt_horas,
	   r.nr_ordem
  FROM #Relatorio r
		INNER JOIN #Semana s
			ON DATEPART(weekday, r.dt_referencia) = s.id_dia
 ORDER BY 2, 6, 9, 4

/**********************************************************************************/
DROP TABLE #FechamentoCC
DROP TABLE #Relatorio
DROP TABLE #CentroCusto
DROP TABLE #PesoArmazenado
DROP TABLE #Semana

END
GO

