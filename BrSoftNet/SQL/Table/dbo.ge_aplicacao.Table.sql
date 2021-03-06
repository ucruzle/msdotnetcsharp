USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_aplicacao]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_aplicacao](
	[cod_aplic] [int] IDENTITY(1,1) NOT NULL,
	[descr_aplic] [varchar](40) NOT NULL,
	[sigla_aplic] [char](2) NOT NULL,
	[sequ_aplic] [int] NOT NULL,
	[ativa] [char](1) NULL,
	[form_aplic] [varchar](30) NOT NULL,
 CONSTRAINT [PK__ge_aplic__CD6AA4FE1209AD79] PRIMARY KEY CLUSTERED 
(
	[cod_aplic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
