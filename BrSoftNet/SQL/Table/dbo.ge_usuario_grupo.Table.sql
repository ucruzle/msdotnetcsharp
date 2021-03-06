USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_usuario_grupo]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_usuario_grupo](
	[cod_empr] [int] NOT NULL,
	[cod_grupo] [int] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_grupo] ASC,
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ge_usuario_grupo]  WITH CHECK ADD  CONSTRAINT [FK__ge_usuari__cod_e__65F62111] FOREIGN KEY([cod_empr])
REFERENCES [dbo].[ge_empresa] ([cod_empr])
GO
ALTER TABLE [dbo].[ge_usuario_grupo] CHECK CONSTRAINT [FK__ge_usuari__cod_e__65F62111]
GO
ALTER TABLE [dbo].[ge_usuario_grupo]  WITH CHECK ADD FOREIGN KEY([cod_grupo])
REFERENCES [dbo].[ge_grupo] ([cod_grupo])
GO
ALTER TABLE [dbo].[ge_usuario_grupo]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[ge_usuario] ([usuario])
GO
