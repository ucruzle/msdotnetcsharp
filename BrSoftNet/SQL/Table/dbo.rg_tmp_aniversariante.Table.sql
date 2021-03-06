USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_tmp_aniversariante]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_tmp_aniversariante](
	[usuario] [varchar](15) NOT NULL,
	[cod_rg] [int] NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[descr_empr] [varchar](100) NOT NULL,
	[dia_mes_inicial] [char](5) NOT NULL,
	[dia_mes_final] [char](5) NOT NULL,
	[dt_nascimento] [datetime] NOT NULL,
	[e_mail] [varchar](50) NOT NULL,
	[dia_aniv] [int] NOT NULL,
	[mes_aniv] [int] NOT NULL,
	[descr_mes_aniv] [varchar](10) NOT NULL,
	[telefone] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario] ASC,
	[cod_rg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
