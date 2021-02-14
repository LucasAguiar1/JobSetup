
/*
DECLARE @mensagens	int
exec sp_fechamento_validar 2, @mensagens OUTPUT
select @mensagens
*/
CREATE PROCEDURE dbo.sp_fechamento_validar
( 
	@periodo	int,
	@mensagens	int OUTPUT
)
AS begin
SET NOCOUNT ON

DECLARE @diaBridge		numeric(7,5) = 0,
	    @pesoAjustado	numeric	(18,8) = 0,
		@inicio			date,
		@fim			date,
		@situacao		int = 0

SET @mensagens = 0


/**************************************************************************************/
CREATE TABLE #Validacao
(
nm_item		varchar(50)  not null,
ds_item		varchar(300) not null
)

/**************************************************************************************/
CREATE TABLE #Pontos
(
id_periodo_recurso	int	NOT NULL,
dt_referencia		date NOT NULL, 
qt_horas			numeric(5,2) NOT NULL 
)
CREATE NONCLUSTERED INDEX iPontos ON #Pontos (id_periodo_recurso);

/**************************************************************************************/
CREATE TABLE #Excecoes
(
id_periodo_recurso	int	NOT NULL,
id_recurso			int	NOT NULL, 
dt_referencia		date NOT NULL, 
qt_horas			numeric(5,2) NOT NULL 
)
CREATE NONCLUSTERED INDEX iExcecoes ON #Excecoes (id_periodo_recurso);

/**************************************************************************************/
CREATE TABLE #Transferencias
(
id_periodo_recurso	int	NOT NULL,
id_recurso			int	NOT NULL, 
dt_referencia		date NOT NULL, 
qt_horas			numeric(5,2) NOT NULL 
)
CREATE NONCLUSTERED INDEX iTransferencia ON #Transferencias (id_periodo_recurso);


/**************************************************************************************/
/*** CARGA DE DADOS PARA VALIDAÇÃO ****************************************************/
/**************************************************************************************/
INSERT INTO #Pontos (id_periodo_recurso, dt_referencia, qt_horas)
	SELECT pr.id_periodo_recurso, rp.dt_referencia, rp.qt_horas
	  FROM tb_Periodos_Recursos pr
			INNER JOIN tb_Recursos_PontosRH rp
				ON pr.id_periodo_recurso = rp.id_periodo_recurso
	 WHERE id_periodo = @periodo
	 	
INSERT INTO #Excecoes (id_periodo_recurso, id_recurso, dt_referencia, qt_horas)
	SELECT pr.id_periodo_recurso, pr.id_recurso, re.dt_referencia, re.qt_horas
	  FROM tb_Periodos_Recursos pr
			INNER JOIN tb_Recursos_Excecoes re
				ON pr.id_periodo_recurso = re.id_periodo_recurso
	 WHERE id_periodo = @periodo

INSERT INTO #Transferencias (id_periodo_recurso, id_recurso, dt_referencia, qt_horas)
	SELECT pr.id_periodo_recurso, pr.id_recurso, rt.dt_referencia, rt.qt_horas
	  FROM tb_Periodos_Recursos pr
			INNER JOIN tb_Recursos_Transferencias rt
				ON pr.id_periodo_recurso = rt.id_periodo_recurso
	 WHERE id_periodo = @periodo

/**************************************************************************************/
/*** VALIDAÇÕES DE PERIODO ************************************************************/
/**************************************************************************************/
SELECT @diaBridge = ISNULL(nr_dia_bridge, 0),
	   @pesoAjustado = ISNULL(vl_peso_ajustado, 0),
	   @inicio = dt_inicio,
	   @fim = dt_fim,
	   @situacao = id_situacao
  FROM tb_periodos 
 WHERE id_periodo = @periodo

IF @diaBridge = 0 BEGIN
	INSERT INTO #Validacao VALUES ('Periodo', 'Número de dias Bridgestone não configurado para o periodo')
	END

IF @pesoAjustado = 0 BEGIN
	INSERT INTO #Validacao VALUES ('Periodo', 'Peso ajustado não configurado para o periodo')
	END

IF @situacao = 5 BEGIN
	INSERT INTO #Validacao VALUES ('Periodo', 'Periodo já fechado, não pode ser fechado novamente')
	END

/**************************************************************************************/
/*** VALIDAÇÕES DE PONTO NO RH ********************************************************/
/**************************************************************************************/
INSERT INTO #Validacao
	SELECT 'Ponto RH', 
		   'Dia ' + CONVERT(VARCHAR, a.dt_referencia, 103) + ' não tem nenhum registro de ponto registrado'
	  FROM (SELECT c.dt_referencia, 
				   (SELECT COUNT(1) FROM #Pontos WHERE dt_referencia = c.dt_referencia) lancamentos
			  FROM tb_Calendarios c WITH(NOLOCK)
		     WHERE c.id_periodo = @periodo
			   AND c.id_ignorar_producao <> 1
			) a
     WHERE ISNULL(a.lancamentos, 0) = 0
	 ORDER BY a.dt_referencia


/**************************************************************************************/
/*** VALIDAÇÕES DE PESOS ARMAZENADOS **************************************************/
/**************************************************************************************/
INSERT INTO #Validacao
	SELECT 'Peso Armazenado', 
		   'Dia ' + CONVERT(VARCHAR, a.dt_referencia, 103) + ' não tem nenhum registro de peso armazenado'
	  FROM (SELECT c.dt_referencia, 
				   (SELECT COUNT(1) FROM TB_PESOS_ARMAZENADOS
				     WHERE dt_referencia = c.dt_referencia) pesos
			  FROM tb_Calendarios c
		     WHERE c.id_periodo = @periodo) a
     WHERE ISNULL(a.pesos, 0) = 0
	 ORDER BY a.dt_referencia

/**************************************************************************************/
/*** VALIDAÇÕES DE RECURSO ************************************************************/
/**************************************************************************************/
INSERT INTO #Validacao
	SELECT 'Recurso', 
		   (CASE WHEN ISNULL(p.qt_horas, 0) = 0
			THEN 'Recurso ' + r.nm_recurso + ' - ' + 
					(CASE WHEN a.qt_horas_exc > 0
						THEN (CASE WHEN a.qt_horas_trf > 0
								THEN 'Exceção e Transferência cadastradas (' + convert(varchar, a.qt_horas) + 'h)'
								ELSE 'Exceção cadastrada (' + convert(varchar, a.qt_horas) + 'h)'
							  END)
						ELSE 'Transferência cadastrada (' + convert(varchar, a.qt_horas) + 'h)'
					END) + ' para ' + CONVERT(VARCHAR, a.dt_referencia, 103) + ' sem ponto registrado'
			ELSE 'Recurso ' + r.nm_recurso + ' - ' + 
					(CASE WHEN a.qt_horas_exc > 0
						THEN (CASE WHEN a.qt_horas_trf > 0
								THEN 'Exceção e Transferência (' + convert(varchar, a.qt_horas) + '/' + convert(varchar, p.qt_horas) + 'h) ultrapassam '
								ELSE 'Exceção (' + convert(varchar, a.qt_horas) + '/' + convert(varchar, p.qt_horas) + 'h) ultrapassa'
							  END)
						ELSE 'Transferência (' + convert(varchar, a.qt_horas) + '/' + convert(varchar, p.qt_horas) + 'h) ultrapassa'
					END) + ' o registrado no ponto do dia ' + CONVERT(VARCHAR, a.dt_referencia, 103)
		   END) mensagem 
		   -- a.id_periodo_recurso, a.dt_referencia, a.qt_horas_exc,
		   -- a.qt_horas_trf, a.qt_horas, p.qt_horas qt_horas_ponto,
	  FROM (SELECT ISNULL(e.id_periodo_recurso, t.id_periodo_recurso) id_periodo_recurso,
				   ISNULL(e.id_recurso, t.id_recurso) id_recurso,
				   ISNULL(e.dt_referencia, t.dt_referencia) dt_referencia, 
				   ISNULL(e.qt_horas, 0) + ISNULL(t.qt_horas, 0) qt_horas,
				   ISNULL(e.qt_horas, 0) qt_horas_exc,
				   ISNULL(t.qt_horas, 0) qt_horas_trf
			  from #Excecoes e
					FULL OUTER JOIN #Transferencias t
				ON e.id_periodo_recurso = t.id_periodo_recurso
			   AND e.dt_referencia = t.dt_referencia) a
			INNER JOIN tb_recursos r
				ON r.id_recurso = a.id_recurso
			LEFT JOIN #Pontos p
				ON a.id_periodo_recurso = p.id_periodo_recurso
			   AND a.dt_referencia = p.dt_referencia
	 WHERE ISNULL(p.qt_horas, 0) < a.qt_horas

/**************************************************************************************/
/*** VALIDAÇÕES DE SERVIÇOS ***********************************************************/
/**************************************************************************************/
INSERT INTO #Validacao
	SELECT 'Serviços', 
		   'Contrato ' + nr_contrato + ' não conferido'
	  FROM tb_contratos c
     WHERE c.id_periodo = @periodo
       AND c.dv_conferido = 0
	 ORDER BY c.nr_contrato

/**************************************************************************************/
/*** RETORNO DA VALIDAÇÃO *************************************************************/
/**************************************************************************************/
SELECT nm_item tipo, ds_item descricao
 FROM #Validacao

SET @mensagens = (SELECT COUNT(1) FROM #Validacao)

DROP TABLE #Pontos
DROP TABLE #Excecoes
DROP TABLE #Transferencias
DROP TABLE #Validacao

END
GO

