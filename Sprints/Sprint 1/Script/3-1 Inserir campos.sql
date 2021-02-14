use JobSetupPREPROD
ALTER TABLE tb_RespostaFilho
ADD dataResposta datetime
GO
ALTER TABLE tb_RespostaFilho
ADD idUsuario NVARCHAR(50)
GO
ALTER TABLE tb_RespostaFilho
ADD nomeUsuario NVARCHAR(MAX)
GO
ALTER TABLE tb_RespostaPai
ALTER  COLUMN idUsuario nvarchar(50)
GO
ALTER TABLE tb_RespostaPai
ADD idPreenchimento bigint
GO
ALTER TABLE tb_RespostaFilho
ADD idPreenchimento bigint
GO

ALTER TABLE tb_RespostaPai
ADD idsAlternativa NVARCHAR(MAX)
GO
ALTER TABLE tb_RespostaFilho
ADD idsAlternativa NVARCHAR(MAX)
GO



