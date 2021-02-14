
/*
declare @retorno varchar(200)
exec sp_centrocusto_categoria_alterar 86, '1|16.01;2|10.29;3|66.34;4|3.63;5|2.25;6|0.27;7|1.11;8|0.10', 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_centrocusto_categoria_alterar
(
	@centrocusto	int,
	@distribuicao	varchar(1000),
	@usuario		varchar(50),
	@mensagem		varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

SET @mensagem = ''

DECLARE @log			varchar(500) = '',
		@item			varchar(200) = '',
		@coluna			varchar(200) = '',
		@indice			int = 0,
		@centroCusto_categoria int,
		@categoria		int = 0,
		@percentual		numeric(5,2) = 0,
		@percentual_old	numeric(5,2) = 0

CREATE TABLE #Distribuicao
(
	id_centroCusto_categoria	int			 NOT NULL,
	id_categoria				int			 NOT NULL,
	pc_distribuicao				numeric(5,2) NOT NULL,
	pc_distribuicao_old			numeric(5,2) NOT NULL
)

/****************************************************************************************/
/*** FORMATA플O DOS DADOS DE ENTRADA ****************************************************/
/****************************************************************************************/
DECLARE c_Linhas CURSOR READ_ONLY FOR
	SELECT LTRIM(RTRIM(item)), 0, 0, 0 FROM dbo.fc_Split(@distribuicao, ';')
OPEN c_Linhas
FETCH NEXT FROM c_Linhas 
	INTO @item, @categoria, @percentual, @indice

WHILE (@@fetch_status <> -1) BEGIN
	IF (@@fetch_status <> -2) BEGIN
		IF LEN(@item) > 0 BEGIN
			DECLARE c_Colunas CURSOR READ_ONLY FOR
				SELECT LTRIM(RTRIM(item)) FROM dbo.fc_Split(@item, '|')
			OPEN c_Colunas
			FETCH NEXT FROM c_Colunas 
				INTO @coluna

			WHILE (@@fetch_status <> -1) BEGIN
				IF (@@fetch_status <> -2) BEGIN
					IF @indice = 0
						SET @categoria = CONVERT(INT, @coluna)
					ELSE
						SET @percentual = CONVERT(NUMERIC(5,2), @coluna)

					SET @indice = @indice + 1
					FETCH NEXT FROM c_Colunas 
						INTO @coluna
					END
				END

			CLOSE c_Colunas
			DEALLOCATE c_Colunas
			END

			INSERT INTO #Distribuicao VALUES (0, @categoria, @percentual, 0)
		FETCH NEXT FROM c_Linhas 
			INTO @item, @categoria, @percentual, @indice
		END
	END

CLOSE c_Linhas
DEALLOCATE c_Linhas

/****************************************************************************************/
/*** RECUPERA플O DOS DADOS CADASTRADOS NO SISTEMA ***************************************/
/****************************************************************************************/
UPDATE d
   SET d.pc_distribuicao_old = ccc.pc_distribuicao,
	   d.id_centroCusto_categoria = ccc.id_centroCusto_categoria
  FROM #Distribuicao d
		inner join tb_centrocusto_categorias ccc
			ON ccc.id_categoria = d.id_categoria
			AND ccc.id_cc = @centrocusto

/****************************************************************************************/
/*** ATUALIZA플O DAS CATEGORIAS QUE SOFRERAM MODIFICA합ES *******************************/
/****************************************************************************************/
DECLARE c_Final CURSOR READ_ONLY FOR
	SELECT id_centroCusto_categoria, id_categoria, 
	       pc_distribuicao, pc_distribuicao_old 
	  FROM #Distribuicao 
	 WHERE pc_distribuicao_old <> pc_distribuicao

OPEN c_Final
FETCH NEXT FROM c_Final 
	INTO @centroCusto_categoria, @categoria, @percentual, @percentual_old

WHILE (@@fetch_status <> -1) BEGIN
	IF (@@fetch_status <> -2) BEGIN
		IF @centroCusto_categoria > 0 BEGIN	
			UPDATE tb_centrocusto_categorias 
			   SET pc_distribuicao = @percentual
			 WHERE id_centroCusto_categoria = @centroCusto_categoria

			SET @log = 'centroCusto_categoria: ' + CONVERT(VARCHAR, @centroCusto_categoria) + 
						', pc_distribuicao: { new: ' + CONVERT(VARCHAR, @percentual) + ', old: ' + CONVERT(VARCHAR, @percentual_old) + ' } '

			EXEC dbo.sp_log_processo_incluir 'CentroCusto_Categoria', 'UPD', @centrocusto, @usuario, @log
			END
		ELSE BEGIN
			INSERT INTO tb_centrocusto_categorias VALUES (@centrocusto, @categoria, @percentual)
			SET @centroCusto_categoria = @@IDENTITY

			SET @log = 'centroCusto_categoria: ' + CONVERT(VARCHAR, @centroCusto_categoria) + 
						', pc_distribuicao: { new: ' + CONVERT(VARCHAR, @percentual) + ', old: 0 } '

			EXEC dbo.sp_log_processo_incluir 'CentroCusto_Categoria', 'INS', @centrocusto, @usuario, @log
			END

		FETCH NEXT FROM c_Final 
			INTO @centroCusto_categoria, @categoria, @percentual, @percentual_old
		END
	END

CLOSE c_Final
DEALLOCATE c_Final

DROP TABLE #Distribuicao

END
GO




