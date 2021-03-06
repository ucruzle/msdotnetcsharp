USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_tipo_rg]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_tipo_rg](
	[tipo_rg] [char](1) NOT NULL,
	[descr_tipo_rg] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tipo_rg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
