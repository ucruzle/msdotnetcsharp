USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_endereco]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_endereco](
	[cod_empr] [int] NOT NULL,
	[cod_rg] [int] NOT NULL,
	[endereco] [varchar](40) NOT NULL,
	[nro_endereco] [varchar](10) NOT NULL,
	[bairro] [varchar](30) NOT NULL,
	[complemento] [varchar](40) NULL,
	[cep] [int] NOT NULL,
	[cod_municipio] [int] NOT NULL,
	[cx_postal] [int] NULL,
	[home_page] [varchar](60) NULL,
	[e_mail] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_rg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_endereco]  WITH NOCHECK ADD  CONSTRAINT [FK__rg_endere__cod_m__1D4655FB] FOREIGN KEY([cod_municipio])
REFERENCES [dbo].[rg_municipio] ([cod_municipio])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_endereco] NOCHECK CONSTRAINT [FK__rg_endere__cod_m__1D4655FB]
GO
ALTER TABLE [dbo].[rg_endereco]  WITH NOCHECK ADD  CONSTRAINT [FK__rg_endereco__1E3A7A34] FOREIGN KEY([cod_empr], [cod_rg])
REFERENCES [dbo].[rg_reg_geral] ([cod_empr], [cod_rg])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_endereco] NOCHECK CONSTRAINT [FK__rg_endereco__1E3A7A34]
GO
