USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ct_plano_contabil]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ct_plano_contabil](
	[cod_plano_cont] [int] NOT NULL,
	[descr_plano_cont] [varchar](40) NOT NULL,
	[qtde_nivel] [int] NOT NULL,
	[descr_nivel1] [varchar](40) NOT NULL,
	[descr_nivel2] [varchar](40) NOT NULL,
	[descr_nivel3] [varchar](40) NOT NULL,
	[descr_nivel4] [varchar](40) NOT NULL,
	[descr_nivel5] [varchar](40) NOT NULL,
	[descr_nivel6] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_plano_cont] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
