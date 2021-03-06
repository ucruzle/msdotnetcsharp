USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_usuario]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_usuario](
	[usuario] [varchar](15) NOT NULL,
	[nome] [varchar](40) NOT NULL,
	[cod_empr] [int] NOT NULL,
	[cod_rg] [int] NOT NULL,
	[status_dba] [char](1) NOT NULL,
	[dt_cadastro] [datetime] NOT NULL,
	[senha] [varchar](40) NOT NULL,
	[ramal] [char](15) NOT NULL,
	[ativo] [char](1) NOT NULL,
	[usuario_incl] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ge_usuario]  WITH NOCHECK ADD  CONSTRAINT [FK__ge_usuario__603D47BB] FOREIGN KEY([cod_empr], [cod_rg])
REFERENCES [dbo].[rg_reg_geral] ([cod_empr], [cod_rg])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ge_usuario] NOCHECK CONSTRAINT [FK__ge_usuario__603D47BB]
GO
