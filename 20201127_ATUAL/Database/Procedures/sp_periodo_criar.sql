/*
DECLARE @periodo INT, @mensagem	varchar(200)
exec sp_periodo_criar '2019-08-01', 'radm', @periodo OUTPUT, @mensagem OUTPUT
SELECT @periodo, @mensagem
*/
CREATE PROCEDURE dbo.sp_periodo_criar
( 
	@competencia	DATE, 
	@usuario		VARCHAR(50),
	@periodo		INT			 OUTPUT,
	@mensagem		VARCHAR(200) OUTPUT
) 
AS begin
SET NOCOUNT ON

DECLARE @inicio		DATE,
		@fim		DATE,
		@situacao	INT = 3

SET @mensagem = ''

IF NOT EXISTS (SELECT 1 FROM tb_periodos 
			    WHERE dt_competencia = @competencia) BEGIN
	SET @inicio = @competencia
	SET @fim = DATEADD(MM, 1, DATEADD(DD, -1, @inicio))

	INSERT INTO tb_periodos (dt_competencia, dt_inicio, dt_fim,  
							 nr_dia_bridge, vl_peso_ajustado, id_situacao)
					 VALUES (@competencia, @inicio, @fim, 0, 0, @situacao)

	SET @periodo = @@IDENTITY

	WHILE @inicio <= @fim BEGIN
		INSERT INTO tb_calendarios VALUES (@inicio, 0, null, null, null, 0, @periodo, 1); 

		SET @inicio = DATEADD(dd, 1, @inicio)
		END

	EXEC dbo.sp_log_processo_incluir 'Periodos', 'INS', @periodo, @usuario, ''
	END
ELSE BEGIN
	SET @mensagem = 'Periodo já cadastrado!'	
	END

END
GO

