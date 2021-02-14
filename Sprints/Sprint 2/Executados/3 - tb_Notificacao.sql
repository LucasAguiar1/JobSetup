USE [JobSetupPREPROD]
GO

/****** Object:  Table [dbo].[tb_Notificacao]    Script Date: 19/01/2021 14:59:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_Notificacao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_formulario] [int] NOT NULL,
	[id_lider] [nvarchar](max) NULL,
	[notificacao] [nvarchar](max) NULL,
	[observacaoLider] [nvarchar](max) NULL,
	[dataNotificacao] [datetime] NULL,
	[dataLeitura] [datetime] NULL,
	[dataObsLider] [datetime] NULL,
	[id_nomeOperador] [nvarchar](max) NULL,
	[id_usuario] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Notificacao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


