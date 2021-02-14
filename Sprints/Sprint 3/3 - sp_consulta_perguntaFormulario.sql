USE [JobSetup]
GO

/****** Object:  Table [dbo].[tb_identificador]    Script Date: 10/02/2021 14:18:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_identificador](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPreenchimento] [int] NOT NULL,
	[identificadoLote] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_identificador] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


