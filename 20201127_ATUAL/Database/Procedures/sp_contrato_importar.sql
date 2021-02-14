
/*
select * from tb_Contratos order by 3
select * from tb_Contratos_itens order by 10
select * from tb_Contratos_importacao order by 10		4500778255
select * from tb_Contratos_Rateio_Funcoes order by 2
select * from #Importacao order by nr_contrato

select cd_Sap from tb_CentroCusto group by cd_Sap having count(1) > 1
select * from tb_CentroCusto where cd_sap in ('25SA001') order by cd_Sap
select * from tb_CentroCusto order by cd_cc

delete tb_contratos_funcoes
delete tb_contratos_itens
delete tb_contratos
delete tb_Contratos_importacao

-- exec sp_contrato_importar 3, 'TESTE.xlsx'
*/
CREATE PROCEDURE sp_contrato_importar
(
	@periodo	INT,
	@arquivo	VARCHAR(200)
)
AS BEGIN
SET NOCOUNT ON

DECLARE @conferido  bit = 0, 
		@situacao	int = 1,
		@situacaoPeriodo int = 0,
		@contrato	int = 0,
		@funcao		int = 0,
		@valor		numeric(18,2),
		@rateio		numeric(18,2),
		@diferenca	numeric(18,2),
		@inicio		datetime,
		@fim		datetime

DECLARE @linha		int = 0,
		@dsPeriodo	varchar(10) = '',
		@cc			int = 0,
		@ccExterno	varchar(30) = '',
		@pedido		varchar(500) = '',
		@documento	varchar(30) = '',
		@nrContrato	varchar(30) = '',
		@empresa	varchar(30) = '',
		@lancamento	datetime,
		@nrTotalEntrada	numeric(10,3) = 0,
		@vlTotalEntrada	numeric(18,2) = 0,
		@entrada	datetime,
		@validacao	varchar(500),
		@mensagens	int = 0

/******************************************************************************************/
/*** TABELAS TEMPORÁRIAS ******************************************************************/
/******************************************************************************************/
CREATE TABLE #Validacao (mensagem varchar(500) NOT NULL)

CREATE TABLE #Importacao 
(
	  nr_linha				int				NOT NULL
	, ds_periodo			varchar(10)		NOT NULL
	, id_cc					int				NOT NULL
	, cd_cc_externo			varchar(30)		NOT NULL
	, ds_texto_pedido		varchar(500)	NOT NULL
	, cd_documento_compra	varchar(30)		NOT NULL
	, nr_contrato			varchar(30)		NOT NULL
	, ds_empresa			varchar(30)		NOT NULL
	, dt_lancamento			datetime		NOT NULL
	, nr_total_entrada		numeric(10,3)	NOT NULL
	, vl_total_entrada		numeric(18,2)	NOT NULL
	, dt_entrada			datetime		NOT NULL
	, id_contrato			int				NULL
)

/******************************************************************************************/
/*** PROCESSAMENTO INICIAL DE IMPORTAÇÃO **************************************************/
/******************************************************************************************/
SELECT @inicio = dt_inicio, 
	   @fim = dt_fim,
	   @situacaoPeriodo = id_situacao
  FROM tb_periodos
 WHERE id_periodo = @periodo

IF @situacaoPeriodo <> 3 BEGIN
	INSERT INTO #Validacao (mensagem) VALUES ('Importação liberada apenas para períodos em Aberto!')
	END
ELSE BEGIN
	INSERT INTO #Importacao (nr_linha, ds_periodo, id_cc, cd_cc_externo, ds_texto_pedido, cd_documento_compra, nr_contrato, 
							 ds_empresa, dt_lancamento, nr_total_entrada, vl_total_entrada, dt_entrada)
		SELECT ci.nr_linha, ci.ds_periodo, isnull(cc.id_cc, 0) id_cc, ci.cd_cc_externo, ci.ds_texto_pedido, ci.nr_contrato, ci.cd_documento_compra, 
			   ci.ds_empresa, ci.dt_lancamento, ci.nr_total_entrada, ci.vl_total_entrada, ci.dt_entrada
		  FROM tb_Contratos_Importacao ci
				LEFT JOIN tb_CentroCusto cc
					ON ci.cd_cc_externo = cc.cd_sap
		 WHERE vl_total_entrada > 0   -- VALORES NEGATIVOS RETIRADOS DA IMPORTAÇÃO A PEDIDO DO USUÁRIO TIAGO WILSON RIBEIRO

	/******************************************************************************************/
	/*** VALIDAÇÃO DOS CAMPOS DE IMPORTAÇÃO ***************************************************/
	/******************************************************************************************/
	DECLARE c_Validacao CURSOR READ_ONLY FOR
		 SELECT nr_linha, ds_periodo, ISNULL(id_cc, 0), cd_cc_externo, ds_texto_pedido,
				cd_documento_compra, nr_contrato, ds_empresa, dt_lancamento,
				nr_total_entrada, vl_total_entrada, dt_entrada, ''
		   FROM #Importacao 
		  	
	OPEN c_Validacao
	FETCH NEXT FROM c_Validacao INTO @linha, @dsPeriodo, @cc, @ccExterno, @pedido,
									 @documento, @nrContrato, @empresa, @lancamento,
									 @nrTotalEntrada, @vlTotalEntrada, @entrada, @Validacao

	WHILE (@@fetch_status <> -1) BEGIN
		IF (@@fetch_status <> -2) BEGIN
			IF @cc = 0 BEGIN
				SET @Validacao = ', Código do Centro de Custo SAP ' + @ccExterno + ' não cadastrado'
				END	

			IF @nrTotalEntrada = 0 BEGIN
				SET @Validacao = @Validacao + ', Quantidade Total de Entrada deve ser maior que Zero'
				END	

			IF @vlTotalEntrada = 0 BEGIN
				SET @Validacao = @Validacao + ', Valor/MR deve ser maior que Zero'
				END	

			IF ((@lancamento < @inicio) OR (@lancamento > @fim)) BEGIN
				SET @Validacao = @Validacao + ', Data de lançamento deve estar no período'
				END

			IF ((@entrada < @inicio) OR (@entrada > @fim)) BEGIN
				SET @Validacao = @Validacao + ', Data de Entrada deve estar no período'
				END

			IF LEN(@Validacao) > 0 BEGIN
				SET @Validacao = 'Linha ' + CONVERT(varchar, @linha) + ' - Valores Inválidos - ' + SUBSTRING(@Validacao, 3, LEN(@Validacao));

				INSERT INTO #Validacao (mensagem)
					VALUES (@Validacao)
				END

			FETCH NEXT FROM c_Validacao INTO @linha, @dsPeriodo, @cc, @ccExterno, @pedido,
									 @documento, @nrContrato, @empresa, @lancamento,
									 @nrTotalEntrada, @vlTotalEntrada, @entrada, @validacao
			END
		END

	CLOSE c_Validacao
	DEALLOCATE c_Validacao

	/**********************************************************************************************/
	/*** VALIDAÇÃO SE ALGUM CONTRATO JÁ FORA IMPORTADO ANTES NO PERÍODO ***************************/
	/**********************************************************************************************/
	INSERT INTO #Validacao (mensagem)
		SELECT 'Contrato ' + c.nr_contrato + ' já importado no periodo' 
		  FROM tb_Contratos c WITH(NOLOCK)
				INNER JOIN 
					(SELECT DISTINCT nr_contrato FROM #Importacao) i
						ON c.nr_contrato = i.nr_contrato
		 WHERE c.id_periodo = @periodo
	END

SET @mensagens = (SELECT COUNT(1) FROM #Validacao)
/**********************************************************************************************/

/**********************************************************************************************/
/*** PROCESSAMENTO LIBERADO APENAS QUANDO NÃO TIVER NENHUM ERRO *******************************/
/**********************************************************************************************/
IF @mensagens = 0 BEGIN

	/******************************************************************************************/
	/*** GRAVAÇÃO DOS DADOS DE CONTRATO *******************************************************/
	/******************************************************************************************/
	INSERT INTO tb_Contratos (id_periodo, nr_contrato, dt_contrato, ds_contrato, vl_contrato,
							  dv_conferido, nm_arquivo_importacao, id_situacao)
			SELECT @periodo, nr_contrato, max(dt_entrada), MAX(ds_texto_pedido), SUM(vl_total_entrada), 
				   @conferido, @arquivo, @situacao
			  FROM #Importacao
			 GROUP BY nr_contrato
			 ORDER BY 2

	UPDATE i
	   SET id_contrato = c.id_contrato
	  FROM #Importacao I
			INNER JOIN tb_contratos c
				ON i.nr_contrato = c.nr_contrato
	 WHERE c.id_periodo = @periodo
	/******************************************************************************************/

	/******************************************************************************************/
	/*** GRAVAÇÃO DOS DADOS DOS ITENS DE CONTRATO *********************************************/
	/******************************************************************************************/
	INSERT INTO tb_contratos_itens (id_contrato, id_cc, cd_cc_externo, ds_texto_pedido, 
									cd_documento_compra, ds_empresa, dt_lancamento, 
									nr_total_entrada, vl_total_entrada, id_situacao)
							 SELECT id_contrato, id_cc, cd_cc_externo, ds_texto_pedido, 
									cd_documento_compra, ds_empresa, dt_lancamento, 
									nr_total_entrada, vl_total_entrada, @situacao
							   FROM #Importacao
	/******************************************************************************************/
					
	/******************************************************************************************/
	/*** GRAVAÇÃO DOS DADOS DE RATEIO DAS FUNÇÕES *********************************************/
	/******************************************************************************************/
	INSERT INTO tb_contratos_funcoes (id_contrato, id_funcao, vl_percentual, 
									  id_classificacao, vl_rateio, id_situacao)
				SELECT i.id_contrato, crf.id_funcao, crf.vl_percentual, crf.id_classificacao,
					   ((crf.vl_percentual * i.vl_total_entrada) / 100), @situacao
				  FROM (SELECT id_contrato, nr_contrato, sum(vl_total_entrada) vl_total_entrada
						  FROM #Importacao
						 GROUP BY id_contrato, nr_contrato) i
						  INNER JOIN tb_Contratos_Rateio_Funcoes crf
							ON i.nr_contrato = crf.nr_contrato
	/******************************************************************************************/


	/******************************************************************************************/
	/*** ARREDONDAMENTO DO RATEIO *************************************************************/
	/******************************************************************************************/
	DECLARE c_Rateio CURSOR READ_ONLY FOR
		SELECT a.id_contrato, a.vl_contrato, a.vl_rateio 
		  FROM (SELECT c.id_contrato, c.vl_contrato, sum(cf.vl_rateio) vl_rateio 
				  FROM tb_contratos c WITH(NOLOCK)
						INNER JOIN dbo.tb_Contratos_Funcoes cf WITH(NOLOCK)
							ON c.id_contrato = cf.id_contrato
				 WHERE c.id_periodo = @periodo
				 GROUP BY c.id_contrato, c.vl_contrato) a
 		  	
	OPEN c_Rateio
	FETCH NEXT FROM c_Rateio INTO @contrato, @valor, @rateio

	WHILE (@@fetch_status <> -1) BEGIN
		IF (@@fetch_status <> -2) BEGIN
			SET @diferenca = @valor - @rateio

			SELECT TOP 1 @funcao = id_contrato_funcao
			  FROM dbo.tb_Contratos_Funcoes WITH(NOLOCK)
			 WHERE id_contrato = @contrato
			 ORDER BY vl_rateio DESC

			UPDATE dbo.tb_Contratos_Funcoes
			   SET vl_rateio = vl_rateio + @diferenca
			 WHERE id_contrato_funcao = @funcao

			FETCH NEXT FROM c_Rateio INTO @contrato, @valor, @rateio
			END
		END

	CLOSE c_Rateio
	DEALLOCATE c_Rateio
	/******************************************************************************************/

	/******************************************************************************************/
	/*** MARCAR COMO CONFERIDOS OS CONTRATOS COM O RATEIO CADASTRADOS *************************/
	/******************************************************************************************/
	UPDATE tb_Contratos 
	   SET dv_conferido = 1 
	 WHERE id_contrato IN (
			SELECT a.id_contrato
			  FROM (SELECT c.id_contrato, c.vl_contrato, sum(cf.vl_rateio) vl_rateio 
					  FROM tb_contratos c WITH(NOLOCK)
							INNER JOIN dbo.tb_Contratos_Funcoes cf WITH(NOLOCK)
								ON c.id_contrato = cf.id_contrato
					 WHERE c.id_periodo = @periodo
					 GROUP BY c.id_contrato, c.vl_contrato) a
			  WHERE a.vl_contrato = a.vl_rateio)

	DECLARE c_Horas CURSOR READ_ONLY FOR
		SELECT id_contrato
		  FROM tb_contratos WITH(NOLOCK)
		 WHERE id_periodo = @periodo
		   AND dv_conferido = 1 
 		  	
	OPEN c_Horas
	FETCH NEXT FROM c_Horas INTO @contrato

	WHILE (@@fetch_status <> -1) BEGIN
		IF (@@fetch_status <> -2) BEGIN
			EXEC dbo.sp_contrato_rateio_calculo @contrato

			FETCH NEXT FROM c_Horas INTO @contrato
			END
		END

	CLOSE c_Horas
	DEALLOCATE c_Horas
	/******************************************************************************************/
	END

/******************************************************************************************/
/*** RETORNO DAS MENSAGENS DE VALIDAÇÃO ***************************************************/
/******************************************************************************************/
SELECT * FROM #Validacao

END
GO


