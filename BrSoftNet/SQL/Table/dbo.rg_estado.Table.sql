USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_estado]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_estado](
	[sigla_estado] [char](2) NOT NULL,
	[descr_estado] [varchar](30) NOT NULL,
	[sigla_regiao] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sigla_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_estado]  WITH CHECK ADD FOREIGN KEY([sigla_regiao])
REFERENCES [dbo].[rg_regiao] ([sigla_regiao])
GO
