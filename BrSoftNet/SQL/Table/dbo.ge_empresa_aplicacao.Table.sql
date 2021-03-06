USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_empresa_aplicacao]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ge_empresa_aplicacao](
	[cod_empr] [int] NOT NULL,
	[cod_aplic] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_aplic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ge_empresa_aplicacao]  WITH CHECK ADD  CONSTRAINT [FK__ge_empres__cod_a__56B3DD81] FOREIGN KEY([cod_aplic])
REFERENCES [dbo].[ge_aplicacao] ([cod_aplic])
GO
ALTER TABLE [dbo].[ge_empresa_aplicacao] CHECK CONSTRAINT [FK__ge_empres__cod_a__56B3DD81]
GO
ALTER TABLE [dbo].[ge_empresa_aplicacao]  WITH CHECK ADD  CONSTRAINT [FK__ge_empres__cod_e__57A801BA] FOREIGN KEY([cod_empr])
REFERENCES [dbo].[ge_empresa] ([cod_empr])
GO
ALTER TABLE [dbo].[ge_empresa_aplicacao] CHECK CONSTRAINT [FK__ge_empres__cod_e__57A801BA]
GO
