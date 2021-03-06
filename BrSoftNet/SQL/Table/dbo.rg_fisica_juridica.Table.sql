USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_fisica_juridica]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_fisica_juridica](
	[cod_empr] [int] NOT NULL,
	[cod_rg] [int] NOT NULL,
	[num_cpf] [int] NULL,
	[dig_cpf] [int] NULL,
	[num_rg] [varchar](20) NULL,
	[dig_rg] [varchar](2) NULL,
	[dt_emissao_rg] [datetime] NULL,
	[orgao_exp_rg] [varchar](10) NULL,
	[insc_municipal] [varchar](20) NULL,
	[cgc] [int] NULL,
	[filial_cgc] [int] NULL,
	[dig_cgc] [int] NULL,
	[insc_estadual] [varchar](20) NULL,
	[nro_banco] [int] NOT NULL,
	[nro_agencia] [int] NULL,
	[dig_agencia] [int] NULL,
	[nro_conta] [int] NULL,
	[dig_conta] [int] NULL,
	[cod_tipo_cta] [int] NOT NULL,
	[cei] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_rg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
