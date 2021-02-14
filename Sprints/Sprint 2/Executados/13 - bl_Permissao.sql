USE [JobSetupPREPROD]
GO

/****** Object:  Table [dbo].[tbl_Permissao]    Script Date: 21/01/2021 15:28:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_Permissao](
	[id_permissao] [int] IDENTITY(1,1) NOT NULL,
	[ds_permissao] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Permissao] PRIMARY KEY CLUSTERED 
(
	[id_permissao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


