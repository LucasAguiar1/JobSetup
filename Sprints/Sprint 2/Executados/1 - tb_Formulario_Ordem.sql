USE [JobSetupPREPROD]
GO

/****** Object:  Table [dbo].[tb_Formulario_Ordem]    Script Date: 16/01/2021 08:36:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_Formulario_Ordem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_formulario] [int] NOT NULL,
	[id_formulario_filho] [int] NOT NULL,
	[dataRegistro] [datetime] NOT NULL,
	[idUsuarioAlt] [nvarchar](max) NULL,
	[idUsuario] [nvarchar](max) NOT NULL,
	[dataRegistroAlt] [datetime] NULL,
	[tipo] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_tb_Formulario_Ordem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


