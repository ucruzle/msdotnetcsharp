USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_tipo_processo]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_tipo_processo](
	[cod_tipo_proc] [int] NOT NULL,
	[descr_tipo_proc] [varchar](30) NOT NULL,
	[sequ_tipo_proc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_tipo_proc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
