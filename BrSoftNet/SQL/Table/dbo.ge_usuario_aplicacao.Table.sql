USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_usuario_aplicacao]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_usuario_aplicacao](
	[cod_empr] [int] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
	[cod_aplic] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[usuario] ASC,
	[cod_aplic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ge_usuario_aplicacao]  WITH CHECK ADD  CONSTRAINT [FK__ge_usuari__cod_a__61316BF4] FOREIGN KEY([cod_aplic])
REFERENCES [dbo].[ge_aplicacao] ([cod_aplic])
GO
ALTER TABLE [dbo].[ge_usuario_aplicacao] CHECK CONSTRAINT [FK__ge_usuari__cod_a__61316BF4]
GO
ALTER TABLE [dbo].[ge_usuario_aplicacao]  WITH CHECK ADD  CONSTRAINT [FK__ge_usuari__cod_e__6319B466] FOREIGN KEY([cod_empr])
REFERENCES [dbo].[ge_empresa] ([cod_empr])
GO
ALTER TABLE [dbo].[ge_usuario_aplicacao] CHECK CONSTRAINT [FK__ge_usuari__cod_e__6319B466]
GO
ALTER TABLE [dbo].[ge_usuario_aplicacao]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[ge_usuario] ([usuario])
GO
