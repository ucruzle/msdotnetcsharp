USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_regiao]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_regiao](
	[sigla_regiao] [char](2) NOT NULL,
	[descr_regiao] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sigla_regiao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
