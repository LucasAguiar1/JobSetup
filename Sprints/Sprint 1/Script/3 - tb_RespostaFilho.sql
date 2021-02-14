use JobSetupPREPROD
GO

/****** Object:  Table [dbo].[tb_RespostaFilho]    Script Date: 12/01/2021 14:59:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_RespostaFilho](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFilho] [int] NOT NULL,
	[id_tipoResposta] [int] NOT NULL,
	[valor] [nvarchar](max) NULL,
	[idPai] [int] NOT NULL,
 CONSTRAINT [PK_tb_RespostaFilho] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


