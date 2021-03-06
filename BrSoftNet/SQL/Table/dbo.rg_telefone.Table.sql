USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_telefone]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_telefone](
	[cod_empr] [int] NOT NULL,
	[cod_rg] [int] NOT NULL,
	[seq_tel] [int] NOT NULL,
	[cod_tipo_fone] [int] NOT NULL,
	[ddd_fone] [char](4) NULL,
	[numero_fone] [varchar](12) NULL,
	[contato] [varchar](30) NULL,
	[e_mail] [varchar](60) NULL,
	[principal] [char](1) NULL,
 CONSTRAINT [PK__rg_telef__30E9FB5F13BCEBC1] PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_rg] ASC,
	[seq_tel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_telefone]  WITH NOCHECK ADD  CONSTRAINT [FK__rg_telefo__cod_t__2F650636] FOREIGN KEY([cod_tipo_fone])
REFERENCES [dbo].[rg_tipo_fone] ([cod_tipo_fone])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_telefone] NOCHECK CONSTRAINT [FK__rg_telefo__cod_t__2F650636]
GO
ALTER TABLE [dbo].[rg_telefone]  WITH NOCHECK ADD  CONSTRAINT [FK__rg_telefone__30592A6F] FOREIGN KEY([cod_empr], [cod_rg])
REFERENCES [dbo].[rg_reg_geral] ([cod_empr], [cod_rg])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_telefone] NOCHECK CONSTRAINT [FK__rg_telefone__30592A6F]
GO
