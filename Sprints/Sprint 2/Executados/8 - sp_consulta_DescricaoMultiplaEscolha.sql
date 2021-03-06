USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_DescricaoMultiplaEscolha]    Script Date: 16/01/2021 18:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE [dbo].[sp_consulta_DescricaoMultiplaEscolha]
	@id INT = NULL
AS
BEGIN
	IF(@id IS NULL)

	BEGIN
	select 
		D.id,
		D.nome,
		D.status,
		D.id_TipoResposta,
		D.tipo,
		D.idUsuario,
		D.dataRegistro 
	 from tb_DescricaoMultiplaEscolha D
	 where D.id IN (SELECT  MAX(T.[ID])  FROM tb_DescricaoMultiplaEscolha T  GROUP BY T.nome)
	 END 
	 ELSE
	 BEGIN
	 select 
		D.id,
		D.nome,
		D.status,
		D.id_TipoResposta,
		D.tipo,
		D.idUsuario,
		D.dataRegistro 
	 from tb_DescricaoMultiplaEscolha D
		WHERE D.id_TipoResposta = @id
	 END
END;
