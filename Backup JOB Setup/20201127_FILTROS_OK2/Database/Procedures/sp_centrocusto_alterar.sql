
/*
declare @retorno varchar(200)
exec sp_centrocusto_alterar 101, '1005', '56SC151', 4, 4, 'DIRETORIA TECNICA BUILDING I', '', 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_centrocusto_alterar
(
	@centrocusto	int,
	@codigo			varchar(20),
	@codigoSAP		varchar(20),
	@area			int,
	@tipo			int,
	@nome			varchar(150),
	@listaEmail		varchar(1000),
	@usuario		varchar(50),
	@mensagem		varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

DECLARE @log			varchar(500) = '',
		@valido			bit = 0,
		@codigoOld		varchar(20),
		@codigoSAPOld	varchar(20),
		@areaOld		int,
		@tipoOld		int,
		@nomeOld		varchar(150),
		@listaEmailOld	varchar(1000)

SET @mensagem = ''

SELECT @codigoOld = ISNULL(cd_cc, ''), 
       @codigoSAPOld = ISNULL(cd_sap, ''), 
	   @nomeOld = nm_cc, 
	   @listaEmailOld = ISNULL(ds_lista_email, ''),
	   @areaOld = id_area,
	   @tipoOld = id_tipo
  FROM tb_CentroCusto WITH(NOLOCK)
 WHERE id_cc = @centrocusto

IF (@codigo <> @codigoOld) OR (@codigoSAP <> @codigoSAPOld) 
		OR (@nome <> @nomeOld) OR (@area <> @areaOld) 
		OR (@tipo <> @tipoOld) OR (@listaEmail <> @listaEmailOld) BEGIN

	IF @codigo = '' BEGIN
		SET @mensagem = 'Código do Centro de Custo deve ser preenchido!'
		END
	ELSE BEGIN
		IF @codigoSAP = '' BEGIN
			SET @mensagem = 'Código SAP do Centro de Custo deve ser preenchido!'
			END
		ELSE BEGIN
			IF @nome = '' BEGIN
				SET @mensagem = 'Nome do Centro de Custo deve ser preenchido!'
				END
			ELSE BEGIN
				IF @area = 0 BEGIN
					SET @mensagem = 'Área do centro de custo deve ser selecionada!'
					END
				ELSE BEGIN
					IF @tipo = 0 BEGIN
						SET @mensagem = 'Tipo do centro de custo deve ser selecionada!'
						END
					ELSE BEGIN
						IF (@codigo <> @codigoOld) BEGIN
							IF EXISTS (SELECT 1 FROM tb_CentroCusto WITH(NOLOCK)
							            WHERE id_cc <> @centrocusto AND cd_cc = @codigo) BEGIN
								SET @mensagem = 'Código do Centro de Custo já utilizado por outro Centro de Custo!'
								END
							END

						IF (@nome <> @nomeOld) BEGIN
							IF EXISTS (SELECT 1 FROM tb_CentroCusto WITH(NOLOCK)
										WHERE id_cc <> @centrocusto AND nm_cc = @nome) BEGIN
								SET @mensagem = 'Nome do Centro de Custo já utilizado por outro Centro de Custo!'
								END
							END
						END
					END
				END
			END
		END

	IF LEN(@mensagem) = 0 BEGIN
		UPDATE tb_CentroCusto
		   SET cd_cc = @codigo,
			   cd_sap = @codigoSAP,
			   nm_cc = @nome,
			   ds_lista_email = @listaEmail,
			   id_area = @area,
			   id_tipo = @tipo
		 WHERE id_cc = @centrocusto

		IF (@codigo <> @codigoOld) 
			SET @log = 'cd_cc : { new: ' + @codigo + ', old: ' + @codigoOld + ' }, '

		IF (@codigoSAP <> @codigoSAPOld) 
			SET @log = @log + ' cd_sap: { new: ' + @codigoSAP + ', old: ' + @codigoSAPOld + ' }, '

		IF (@nome <> @nomeOld)
			SET @log = @log + ' nm_cc: { new: ' + @nome + ', old: ' + @nomeOld + ' }, '

		IF (@area <> @areaOld) 
			SET @log = @log + ' id_area: { new: ' + CONVERT(VARCHAR, @area) + ', old: ' + CONVERT(VARCHAR, @areaOld) + ' }, '

		IF (@tipo <> @tipoOld)
			SET @log = @log + ' id_tipo: { new: ' + CONVERT(VARCHAR, @tipo) + ', old: ' + CONVERT(VARCHAR, @tipoOld) + ' }, '

		IF (@listaEmail <> @listaEmailOld)
			SET @log = @log + ' ds_lista_email: { new: ' + @listaEmail + ', old: ' + @listaEmailOld + ' }'
		
		-- Gravação do Log de Processos
		EXEC dbo.sp_log_processo_incluir 'Centro_Custo', 'UPD', @centrocusto, @usuario, @log
		END
	END

END
GO




