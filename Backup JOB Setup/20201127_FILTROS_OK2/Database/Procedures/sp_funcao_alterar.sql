
/*
declare @retorno varchar(200)
exec sp_funcao_alterar 1, '101', 'Líder', 4, 50, 0, 0, 1, 'radm', @retorno output
select @retorno
*/
CREATE PROCEDURE sp_funcao_alterar
(
	@funcao			int,
	@codigo			varchar(50),
	@nome			varchar(150),
	@classificacao	int,
	@servico		numeric(7,2),
	@contabiliza	bit,
	@pmh			bit,
	@cmh			bit,
	@usuario		varchar(50),
	@mensagem		varchar(200) OUTPUT
)
AS BEGIN
SET NOCOUNT ON

DECLARE @log			varchar(500) = '',
		@codigoOld		varchar(50),
		@nomeOld		varchar(150),
		@classificacaoOld int,
		@servicoOld		numeric(7,2),
		@contabilizaOld	bit,
		@pmhOld			bit,
		@cmhOld			bit

SET @mensagem = ''

SELECT @codigoOld = ISNULL(cd_operacao, ''), 
       @nomeOld = ISNULL(nm_funcao, ''), 
	   @classificacaoOld = id_classificacao, 
	   @pmhOld = ISNULL(dv_participa_pmh, 0),
	   @cmhOld = ISNULL(dv_participa_cmh, 0),
	   @contabilizaOld = ISNULL(dv_contabiliza_separado, 0),
	   @servicoOld = ISNULL(vl_hora_servico, 0)
  FROM tb_Funcoes WITH(NOLOCK)
 WHERE id_funcao = @funcao

IF (@codigo <> @codigoOld) OR (@nome <> @nomeOld) 
		OR (@classificacao <> @classificacaoOld) OR (@pmh <> @pmhOld) 
		OR (@contabiliza <> @contabilizaOld) OR (@cmh <> @cmhOld)
		OR (@servico <> @servicoOld) BEGIN

	IF @codigo = '' BEGIN
		SET @mensagem = 'Código da Função deve ser preenchido!'
		END
	ELSE BEGIN
		IF @nome = '' BEGIN
			SET @mensagem = 'O Nome da Função deve ser preenchido!'
			END
		ELSE BEGIN
			IF @classificacao = 0 BEGIN
				SET @mensagem = 'A classificação deve ser selecionada!'
				END
			ELSE BEGIN
				IF (@codigo <> @codigoOld) BEGIN
					IF EXISTS (SELECT 1 FROM tb_Funcoes WITH(NOLOCK)
							    WHERE id_funcao <> @funcao AND cd_operacao = @codigo AND id_situacao = 1) BEGIN
						SET @mensagem = 'Código da Função já utilizado por outra Função!'
						END
					END

				IF (@nome <> @nomeOld) BEGIN
					IF EXISTS (SELECT 1 FROM tb_Funcoes WITH(NOLOCK)
							    WHERE id_funcao <> @funcao AND nm_funcao = @nome AND id_situacao = 1) BEGIN
						SET @mensagem = 'Nome da Função já utilizado por outra Função!'
						END
					END
				END
			END
		END

	IF LEN(@mensagem) = 0 BEGIN
		UPDATE tb_Funcoes
		   SET cd_operacao = @codigo,
			   nm_funcao = @nome,
			   id_classificacao = @classificacao,
			   dv_participa_pmh = @pmh,
			   dv_participa_cmh = @cmh,
			   dv_contabiliza_separado = @contabiliza,
			   vl_hora_servico = @servico
		 WHERE id_funcao = @funcao

		IF (@codigo <> @codigoOld) 
			SET @log = 'cd_cc : { new: ' + @codigo + ', old: ' + @codigoOld + ' }, '

		IF (@nome <> @nomeOld) 
			SET @log = @log + ' cd_sap: { new: ' + @nome + ', old: ' + @nomeOld + ' }, '

		IF (@classificacao <> @classificacaoOld) 
			SET @log = @log + ' id_classificacao: { new: ' + CONVERT(VARCHAR, @classificacao) + ', old: ' + CONVERT(VARCHAR, @classificacaoOld) + ' }, '

		IF (@classificacao <> @classificacaoOld) 
			SET @log = @log + ' id_classificacao: { new: ' + CONVERT(VARCHAR, @classificacao) + ', old: ' + CONVERT(VARCHAR, @classificacaoOld) + ' }, '

		IF (@servico <> @servicoOld)
			SET @log = @log + ' vl_hora_servico: { new: ' + CONVERT(VARCHAR, @servico) + ', old: ' + CONVERT(VARCHAR, @servicoOld) + ' }, '

		IF (@pmh <> @pmhOld)
			SET @log = @log + ' dv_participa_pmh: { new: ' + CONVERT(VARCHAR, @pmh) + ', old: ' + CONVERT(VARCHAR, @pmhOld) + ' }, '

		IF (@cmh <> @cmhOld)
			SET @log = @log + ' dv_participa_pmh: { new: ' + CONVERT(VARCHAR, @cmh) + ', old: ' + CONVERT(VARCHAR, @cmhOld) + ' }, '

		IF (@contabiliza <> @contabilizaOld)
			SET @log = @log + ' dv_contabiliza_separado: { new: ' + CONVERT(VARCHAR, @contabiliza) + ', old: ' + CONVERT(VARCHAR, @contabilizaOld) + ' }, '
					
		-- Gravação do Log de Processos
		EXEC dbo.sp_log_processo_incluir 'FUNÇÃO', 'UPD', @funcao, @usuario, @log
		END
	END
END
GO




