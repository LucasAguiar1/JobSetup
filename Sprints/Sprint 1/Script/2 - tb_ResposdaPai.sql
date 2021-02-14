use JobSetupPREPROD
GO

/****** Object:  Table [dbo].[tb_RespostaPai]    Script Date: 12/01/2021 08:22:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_RespostaPai](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPai] [int] NOT NULL,
	[id_tipoResposta] [int] NOT NULL,
	[valor] [nvarchar](max) NULL,
	[status] [nvarchar](10) NULL,
	[idUsuario] [nvarchar](10) NULL,
	[nomeUsuario] [nvarchar](max) NULL,
	[dataResposta] [datetime] NULL,
 CONSTRAINT [PK_tb_ResposdaPai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


