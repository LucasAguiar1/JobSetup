USE [JobSetupPREPROD]
GO

/****** Object:  Table [dbo].[tbl_Usuario]    Script Date: 21/01/2021 15:32:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nm_usuario] [varchar](50) NULL,
	[ds_login] [varchar](50) NULL,
	[ds_senha] [varchar](50) NULL,
	[id_permissao] [int] NULL,
	[id_status] [tinyint] NULL,
	[cd_rl] [varchar](15) NULL,
	[email] [varchar](100) NULL,
	[id_departamento] [int] NULL,
 CONSTRAINT [PK_tb_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tb_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_tb_Permissao_tb_Usuario] FOREIGN KEY([id_permissao])
REFERENCES [dbo].[tb_Permissao] ([id_permissao])
GO

ALTER TABLE [dbo].[tb_Usuario] CHECK CONSTRAINT [FK_tb_Permissao_tb_Usuario]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id da tabela' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_Usuario', @level2type=N'COLUMN',@level2name=N'id_usuario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permissao dado Operador/ Qualidade / Lider' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_Usuario', @level2type=N'COLUMN',@level2name=N'id_permissao'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Ativo / 2: Inativo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_Usuario', @level2type=N'COLUMN',@level2name=N'id_status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'codigo R.L.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_Usuario', @level2type=N'COLUMN',@level2name=N'cd_rl'
GO



