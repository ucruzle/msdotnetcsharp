USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_tmp_valor_det]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_tmp_valor_det](
	[usuario] [char](15) NOT NULL,
	[codigo] [int] NOT NULL,
	[valor] [numeric](15, 2) NOT NULL,
	[perc_valor] [numeric](15, 2) NOT NULL,
	[status] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario] ASC,
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ge_tmp_valor_det]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[ge_tmp_valor] ([usuario])
GO
