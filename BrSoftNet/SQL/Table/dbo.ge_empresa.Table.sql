USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_empresa]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_empresa](
	[cod_empr] [int] IDENTITY(1,1) NOT NULL,
	[descr_empr] [varchar](100) NOT NULL,
	[descr_empr_red] [varchar](20) NOT NULL,
	[cod_empr_consol] [int] NOT NULL,
	[ativa] [char](1) NOT NULL,
	[cod_rg] [int] NOT NULL,
	[host] [varchar](40) NULL,
	[port] [int] NULL,
	[username] [varchar](40) NULL,
	[senha] [varchar](40) NULL,
	[e_mail] [varchar](40) NULL,
	[endereco_banco] [varchar](100) NULL,
	[versao] [varchar](20) NOT NULL,
 CONSTRAINT [PK__ge_empre__E7A591EA15DA3E5D] PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
