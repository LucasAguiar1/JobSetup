use JobSetupPREPROD
GO

/****** Object:  Table [dbo].[tb_Preenchimento]    Script Date: 13/01/2021 14:33:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_Preenchimento](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_formulario] [int] NOT NULL,
 CONSTRAINT [PK_tb_Preenchimento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


