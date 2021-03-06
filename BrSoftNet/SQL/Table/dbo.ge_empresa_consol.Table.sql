USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_empresa_consol]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_empresa_consol](
	[cod_empr_consol] [int] IDENTITY(1,1) NOT NULL,
	[descr_empr_consol] [varchar](100) NOT NULL,
	[ativa] [char](1) NOT NULL,
 CONSTRAINT [PK__ge_empre__6E416DBE1D7B6025] PRIMARY KEY CLUSTERED 
(
	[cod_empr_consol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
