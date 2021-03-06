USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ct_nivel_1]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ct_nivel_1](
	[cod_empr] [int] NOT NULL,
	[cod_plano_cont] [int] NOT NULL,
	[cod_nivel1] [int] NOT NULL,
	[descr_nivel1] [varchar](40) NOT NULL,
	[sequ_nivel1] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_plano_cont] ASC,
	[cod_nivel1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ct_nivel_1]  WITH CHECK ADD  CONSTRAINT [FK__ct_nivel___cod_e__4FD1D5C8] FOREIGN KEY([cod_empr])
REFERENCES [dbo].[ge_empresa] ([cod_empr])
GO
ALTER TABLE [dbo].[ct_nivel_1] CHECK CONSTRAINT [FK__ct_nivel___cod_e__4FD1D5C8]
GO
ALTER TABLE [dbo].[ct_nivel_1]  WITH CHECK ADD FOREIGN KEY([cod_plano_cont])
REFERENCES [dbo].[ct_plano_contabil] ([cod_plano_cont])
GO
