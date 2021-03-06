USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_usuario_processo]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_usuario_processo](
	[cod_empr] [int] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
	[cod_proc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[usuario] ASC,
	[cod_proc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ge_usuario_processo]  WITH CHECK ADD  CONSTRAINT [FK__ge_usuari__cod_e__67DE6983] FOREIGN KEY([cod_empr])
REFERENCES [dbo].[ge_empresa] ([cod_empr])
GO
ALTER TABLE [dbo].[ge_usuario_processo] CHECK CONSTRAINT [FK__ge_usuari__cod_e__67DE6983]
GO
ALTER TABLE [dbo].[ge_usuario_processo]  WITH CHECK ADD  CONSTRAINT [FK__ge_usuari__cod_p__66EA454A] FOREIGN KEY([cod_proc])
REFERENCES [dbo].[ge_processo] ([cod_proc])
GO
ALTER TABLE [dbo].[ge_usuario_processo] CHECK CONSTRAINT [FK__ge_usuari__cod_p__66EA454A]
GO
ALTER TABLE [dbo].[ge_usuario_processo]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[ge_usuario] ([usuario])
GO
