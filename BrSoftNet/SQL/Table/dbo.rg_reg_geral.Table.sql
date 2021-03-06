USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_reg_geral]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_reg_geral](
	[cod_empr] [int] NOT NULL,
	[cod_rg] [int] IDENTITY(1,1) NOT NULL,
	[razao_social] [varchar](100) NOT NULL,
	[tipo_rg] [char](1) NOT NULL,
	[cod_status] [int] NOT NULL,
	[data_hora] [datetime] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
	[nome_fantasia] [varchar](20) NULL,
	[optante_simples] [char](1) NOT NULL,
 CONSTRAINT [PK__rg_reg_g__6E142E404B422AD5] PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_rg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_reg_geral]  WITH NOCHECK ADD  CONSTRAINT [FK__rg_reg_ge__cod_s__69C6B1F5] FOREIGN KEY([cod_status])
REFERENCES [dbo].[rg_status] ([cod_status])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_reg_geral] NOCHECK CONSTRAINT [FK__rg_reg_ge__cod_s__69C6B1F5]
GO
ALTER TABLE [dbo].[rg_reg_geral]  WITH NOCHECK ADD  CONSTRAINT [FK__rg_reg_ge__tipo___6ABAD62E] FOREIGN KEY([tipo_rg])
REFERENCES [dbo].[rg_tipo_rg] ([tipo_rg])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_reg_geral] NOCHECK CONSTRAINT [FK__rg_reg_ge__tipo___6ABAD62E]
GO
