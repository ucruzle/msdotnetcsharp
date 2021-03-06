USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_grupo_processo]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ge_grupo_processo](
	[cod_empr] [int] NOT NULL,
	[cod_grupo] [int] NOT NULL,
	[cod_proc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_grupo] ASC,
	[cod_proc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ge_grupo_processo]  WITH CHECK ADD  CONSTRAINT [FK__ge_grupo___cod_e__59904A2C] FOREIGN KEY([cod_empr])
REFERENCES [dbo].[ge_empresa] ([cod_empr])
GO
ALTER TABLE [dbo].[ge_grupo_processo] CHECK CONSTRAINT [FK__ge_grupo___cod_e__59904A2C]
GO
ALTER TABLE [dbo].[ge_grupo_processo]  WITH CHECK ADD FOREIGN KEY([cod_grupo])
REFERENCES [dbo].[ge_grupo] ([cod_grupo])
GO
ALTER TABLE [dbo].[ge_grupo_processo]  WITH CHECK ADD  CONSTRAINT [FK__ge_grupo___cod_p__589C25F3] FOREIGN KEY([cod_proc])
REFERENCES [dbo].[ge_processo] ([cod_proc])
GO
ALTER TABLE [dbo].[ge_grupo_processo] CHECK CONSTRAINT [FK__ge_grupo___cod_p__589C25F3]
GO
