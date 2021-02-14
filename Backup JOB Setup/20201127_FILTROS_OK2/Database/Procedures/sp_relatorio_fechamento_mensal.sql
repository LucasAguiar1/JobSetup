
-- exec sp_relatorio_fechamento_mensal 2019
CREATE PROCEDURE dbo.sp_relatorio_fechamento_mensal
( 
	@ano		int
) 
AS begin
SET NOCOUNT ON

DECLARE @inicio			DATE,
		@fim			DATE,
		@categoria		VARCHAR(50),
		@mes			INT	= 0,
		@mes_base		INT	= 0,
		@horasTMH		NUMERIC(9,2) = 0,
		@horasPMH		NUMERIC(9,2) = 0,
		@horasCMH		NUMERIC(9,2) = 0,
		@pesoAjustado	NUMERIC(18,3) = 0,
		@ppmh			NUMERIC(18,2) = 0,
		@pcmh			NUMERIC(18,2) = 0,
		@ptmh			NUMERIC(18,2) = 0,
		@ordem			INT = 1,
		@ordemCMH		INT = 5000,
		@ordemTMH		INT = 10000,
		@ordemCateg		INT = 0,
		@diasBridge		NUMERIC(7, 5) = 0,
		@tipo			VARCHAR(10)	= '',
		@tipoId			INT = 0,
		@subTipo		INT = 0,
		@descricao		VARCHAR(50)

DECLARE @horasTotalTMH	NUMERIC(9,2) = 0,
		@horasTotalPMH	NUMERIC(9,2) = 0,
		@horasTotalCMH	NUMERIC(9,2) = 0,
		@pesoTotal		NUMERIC(18,3) = 0

SET @inicio = CONVERT(DATE, (CONVERT(VARCHAR, @ano) + '-01-01'))
SET @fim = CONVERT(DATE, (CONVERT(VARCHAR, @ano) + '-12-31'))

CREATE TABLE #Categoria
(
id_categoria		INT				NOT NULL,
id_periodo			INT				NOT NULL,
nr_mes				INT				NOT NULL,
qt_horas_tmh		NUMERIC(9,2)	NOT NULL,
qt_horas_pmh		NUMERIC(9,2)	NOT NULL,
qt_horas_cmh		NUMERIC(9,2)	NOT NULL,
qt_peso_ajustado	NUMERIC(18,3)	NOT NULL
)

CREATE TABLE #Mes
(
nr_mes	INT	NOT NULL,
ds_mes	CHAR(3) NOT NULL
)
INSERT INTO #Mes VALUES (1, 'JAN')
INSERT INTO #Mes VALUES (2, 'FEV')
INSERT INTO #Mes VALUES (3, 'MAR')
INSERT INTO #Mes VALUES (4, 'ABR')
INSERT INTO #Mes VALUES (5, 'MAI')
INSERT INTO #Mes VALUES (6, 'JUN')
INSERT INTO #Mes VALUES (7, 'JUL')
INSERT INTO #Mes VALUES (8, 'AGO')
INSERT INTO #Mes VALUES (9, 'SET')
INSERT INTO #Mes VALUES (10, 'OUT')
INSERT INTO #Mes VALUES (11, 'NOV')
INSERT INTO #Mes VALUES (12, 'DEZ')

CREATE TABLE #Saida
(
nm_tipo				VARCHAR(10)		NOT NULL,
nm_categoria		VARCHAR(50)		NOT NULL,
nm_descricao		VARCHAR(50)		NOT NULL,
nr_mes				INT				NOT NULL,
qt_base				NUMERIC(18,2)	NOT NULL,
nr_ordem			INT				NOT NULL,
id_tipo				INT				NOT NULL,
id_sub_tipo			INT				NOT NULL,
nr_ordem_categ		INT				NOT NULL
)

CREATE TABLE #Periodo
(
id_periodo			INT				NOT NULL, 
dt_competencia		DATE			NOT NULL, 
nr_dia_bridge		NUMERIC(7, 5)	NOT NULL 
)

INSERT INTO #Periodo
	SELECT id_periodo, dt_competencia, nr_dia_bridge
	  FROM tb_periodos WITH(NOLOCK)
	 WHERE dt_competencia BETWEEN @inicio AND @fim
	   AND id_situacao = 5

/************************************************************************/
/*** Leitura dos dados de Categoria *************************************/
/************************************************************************/
INSERT INTO #Categoria (id_categoria, id_periodo, nr_mes, 
						qt_horas_tmh, qt_horas_pmh, qt_horas_cmh, qt_peso_ajustado)
	SELECT a.id_categoria, a.id_periodo, MONTH(a.dt_competencia), 
		   a.qt_horas_tmh, a.qt_horas_pmh, a.qt_horas_cmh, fcm.qt_peso_ajustado
	  FROM (SELECT ccc.id_categoria, p.id_periodo, p.dt_competencia, sum(ccc.qt_horas_tmh) qt_horas_tmh, 
				   sum(ccc.qt_horas_pmh) qt_horas_pmh, sum(ccc.qt_horas_cmh) qt_horas_cmh
			  FROM dbo.tb_Fechamentos_CentroCusto_Mensal_Categoria ccc WITH(NOLOCK)
					INNER JOIN #Periodo p
						ON ccc.id_periodo = p.id_periodo
			 GROUP BY ccc.id_categoria, p.id_periodo, p.dt_competencia) a
				INNER JOIN tb_Fechamentos_Categoria_Mensal fcm
					ON a.id_periodo = fcm.id_periodo
				   AND a.id_categoria = fcm.id_categoria

/************************************************************************/
/*** Cursor para tratar os dados das categorias no formato do relatório */
/************************************************************************/
DECLARE c_Processamento CURSOR READ_ONLY FOR
	SELECT ctg.nm_categoria, c.nr_mes, c.qt_horas_tmh, c.qt_horas_pmh, 
		   c.qt_horas_cmh, c.qt_peso_ajustado, p.nr_dia_bridge, ctg.nr_ordem
	  FROM #Categoria c
			INNER JOIN tb_Categorias ctg
				ON c.id_categoria = ctg.id_categoria
			INNER JOIN #Periodo p
				ON c.id_periodo = p.id_periodo
	 UNION
	 SELECT '', 13, 0, 0, 0, 0, 0, 0
	 ORDER BY c.nr_mes, ctg.nr_ordem, ctg.nm_categoria

OPEN c_Processamento
FETCH NEXT FROM c_Processamento 
	INTO @categoria, @mes, @horasTMH, @horasPMH, @horasCMH, @pesoAjustado, @diasBridge, @ordemCateg

WHILE (@@fetch_status <> -1) BEGIN
	IF (@@fetch_status <> -2) BEGIN
		IF @mes_base <> @mes BEGIN
			IF @mes_base > 0 BEGIN
				/************************************************************************/
				/*** Tratamento do RESUMO de PPMH ***************************************/
				/************************************************************************/
				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PPMH', 'PPMH GERAL', 'Peso (MLbs)', @mes_base, @pesoTotal, @ordem, 1, 1, 100)
				SET @ordem = @ordem + 1
		
				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PPMH', 'PPMH GERAL', 'Horas', @mes_base, @horasTotalPMH, @ordem, 1, 2, 100)
				SET @ordem = @ordem + 1
		
				IF @pesoTotal > 0 AND @horasTotalPMH > 0
					SET @ppmh = @pesoTotal / @horasTotalPMH
				ELSE
					SET @ppmh = 0
				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PPMH', 'PPMH GERAL', 'PPMH', @mes_base, @ppmh, @ordem, 1, 3, 100)
				SET @ordem = @ordem + 1

				/************************************************************************/
				/*** Tratamento do RESUMO de PCMH ***************************************/
				/************************************************************************/
				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PCMH', 'PCMH GERAL', 'Peso (MLbs)', @mes_base, @pesoTotal, @ordemCMH, 2, 1, 100)
				SET @ordemCMH = @ordemCMH + 1

				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PCMH', 'PCMH GERAL', 'Horas', @mes_base, @horasTotalCMH, @ordemCMH, 2, 2, 100)	
				SET @ordemCMH = @ordemCMH + 1
			
				IF @pesoTotal > 0 AND @horasTotalCMH > 0
					SET @pcmh = @pesoTotal / @horasTotalCMH
				ELSE
					SET @pcmh = 0
				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PCMH', 'PCMH GERAL', 'PCMH', @mes_base, @pcmh, @ordemCMH, 2, 3, 100)					
				SET @ordemCMH = @ordemCMH + 1

				/************************************************************************/
				/*** Tratamento do RESUMO de PTMH ***************************************/
				/************************************************************************/
				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PTMH', 'PTMH GERAL', 'Peso (MLbs)', @mes_base, @pesoTotal, @ordemTMH, 3, 1, 100)
				SET @ordemTMH = @ordemTMH + 1

				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PTMH', 'PTMH GERAL', 'Horas', @mes_base, @horasTotalTMH, @ordemTMH, 3, 2, 100)	
				SET @ordemTMH = @ordemTMH + 1
			
				IF @pesoTotal > 0 AND @horasTotalTMH > 0
					SET @ptmh = @pesoTotal / @horasTotalTMH
				ELSE
					SET @ptmh = 0
				INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
					VALUES ('PTMH', 'PTMH GERAL', 'PTMH', @mes_base, @ptmh, @ordemTMH, 3, 3, 100)					
				SET @ordemTMH = @ordemTMH + 1

				SET @pesoTotal = 0
				SET @horasTotalTMH = 0
				SET @horasTotalPMH = 0
				SET @horasTotalCMH = 0
				END

				IF @mes < 13 BEGIN
					INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
						VALUES ('', 'Dias', 'Bridgestone', @mes, @diasBridge, @ordem, 0, 0, 0)
					SET @ordem = @ordem + 1
					END
			END

		IF @mes < 13 BEGIN
			/************************************************************************/
			/*** Tratamento dos REGISTROS de PPMH ***********************************/
			/************************************************************************/
			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PPMH', @categoria, 'Peso (MLbs)', @mes, @pesoAjustado, @ordem, 1, 1, @ordemCateg)
			SET @ordem = @ordem + 1
			SET @pesoTotal = @pesoTotal + @pesoAjustado
		
			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PPMH', @categoria, 'Horas', @mes, @horasPMH, @ordem, 1, 2, @ordemCateg)
			SET @ordem = @ordem + 1
			SET @horasTotalPMH = @horasTotalPMH + @horasPMH
		
			IF @pesoAjustado > 0 AND @horasPMH > 0
				SET @ppmh = @pesoAjustado / @horasPMH
			ELSE
				SET @ppmh = 0
			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PPMH', @categoria, 'PPMH', @mes, @ppmh, @ordem, 1, 3, @ordemCateg)
			SET @ordem = @ordem + 1

			/************************************************************************/
			/*** Tratamento dos REGISTROS de PCMH ***********************************/
			/************************************************************************/
			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PCMH', @categoria, 'Peso (MLbs)', @mes, @pesoAjustado, @ordemCMH, 2, 1, @ordemCateg)
			SET @ordemCMH = @ordemCMH + 1

			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PCMH', @categoria, 'Horas', @mes, @horasCMH, @ordemCMH, 2, 2, @ordemCateg)	
			SET @ordemCMH = @ordemCMH + 1
			SET @horasTotalCMH = @horasTotalCMH + @horasCMH

			IF @pesoAjustado > 0 AND @horasCMH > 0
				SET @pcmh = @pesoAjustado / @horasCMH
			ELSE
				SET @pcmh = 0
			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PCMH', @categoria, 'PCMH', @mes, @pcmh, @ordemCMH, 2, 3, @ordemCateg)					
			SET @ordemCMH = @ordemCMH + 1

			/************************************************************************/
			/*** Tratamento dos REGISTROS de PTMH ***********************************/
			/************************************************************************/
			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PTMH', @categoria, 'Peso (MLbs)', @mes, @pesoAjustado, @ordemTMH, 3, 1, @ordemCateg)
			SET @ordemTMH = @ordemTMH + 1

			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PTMH', @categoria, 'Horas', @mes, @horasTMH, @ordemTMH, 3, 2, @ordemCateg)	
			SET @ordemTMH = @ordemTMH + 1
			SET @horasTotalTMH = @horasTotalTMH + @horasTMH

			IF @pesoAjustado > 0 AND @horasTMH > 0
				SET @ptmh = @pesoAjustado / @horasTMH
			ELSE
				SET @ptmh = 0
			INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
				VALUES ('PTMH', @categoria, 'PTMH', @mes, @ptmh, @ordemTMH, 3, 3, @ordemCateg)					
			SET @ordemTMH = @ordemTMH + 1
			END 

		SET @mes_base = @mes	

		FETCH NEXT FROM c_Processamento 
			INTO @categoria, @mes, @horasTMH, @horasPMH, @horasCMH, @pesoAjustado, @diasBridge, @ordemCateg
		END
	END

CLOSE c_Processamento
DEALLOCATE c_Processamento


/************************************************************************/
/*** Inclusão de Valores Zerados ****************************************/
/************************************************************************/
DECLARE c_ValoresZerados CURSOR READ_ONLY FORWARD_ONLY FOR
	SELECT DISTINCT s.nm_tipo, s.nm_categoria, s.nm_descricao, 
					s.nr_ordem_categ, s.id_tipo, s.id_sub_tipo
	  FROM #Saida s
	 WHERE s.nr_ordem_categ > 0 AND s.nr_ordem_categ <> 100

OPEN c_ValoresZerados
FETCH NEXT FROM c_ValoresZerados 
	INTO @tipo, @categoria, @descricao, @ordemCateg, @tipoId, @subTipo

WHILE (@@fetch_status <> -1) BEGIN
	IF (@@fetch_status <> -2) BEGIN
		DECLARE c_Periodos CURSOR READ_ONLY FORWARD_ONLY FOR
			SELECT MONTH(dt_competencia) nr_mes FROM #Periodo ORDER BY 1

		OPEN c_Periodos
		FETCH NEXT FROM c_Periodos 
			INTO @mes

		WHILE (@@fetch_status <> -1) BEGIN
			IF (@@fetch_status <> -2) BEGIN
				IF NOT EXISTS (SELECT 1 FROM #Saida 
								WHERE nr_mes = @mes AND nm_tipo = @tipo
								  AND nm_categoria = @categoria AND id_sub_tipo = @subTipo
								  AND nr_ordem_categ = @ordemCateg) BEGIN
					INSERT INTO #Saida (nm_tipo, nm_categoria, nm_descricao, nr_mes, qt_base, nr_ordem, id_tipo, id_sub_tipo, nr_ordem_categ)
						VALUES (@tipo, @categoria, @descricao, @mes, 0, 0, @tipoId, @subTipo, @ordemCateg)	
					END

				FETCH NEXT FROM c_Periodos 
					INTO @mes
				END
			END

		CLOSE c_Periodos
		DEALLOCATE c_Periodos

		FETCH NEXT FROM c_ValoresZerados 
			INTO @tipo, @categoria, @descricao, @ordemCateg, @tipoId, @subTipo
		END
	END

CLOSE c_ValoresZerados
DEALLOCATE c_ValoresZerados

/************************************************************************/
/*** Dados de retorno para geração do relatório *************************/
/************************************************************************/
SELECT s.nm_tipo, s.nm_categoria, s.nm_descricao, s.nr_mes, m.ds_mes,
	   s.qt_base, s.nr_ordem, s.id_tipo, s.id_sub_tipo, s.nr_ordem_categ	
  FROM #Saida s
		INNER JOIN #Mes m
			ON s.nr_mes = m.nr_mes
 ORDER BY s.nr_mes, s.id_tipo, s.nr_ordem_categ, s.nr_ordem, s.id_sub_tipo


/************************************************************************/
/*** Exclusão das Tabelas Temporárias ***********************************/
/************************************************************************/
DROP TABLE #Categoria
DROP TABLE #Saida
DROP TABLE #Periodo
DROP TABLE #Mes

END
GO
