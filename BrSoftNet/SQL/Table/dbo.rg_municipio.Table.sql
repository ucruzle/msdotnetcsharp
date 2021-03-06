USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_municipio]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_municipio](
	[cod_municipio] [int] IDENTITY(1,1) NOT NULL,
	[municipio] [varchar](40) NOT NULL,
	[sigla_estado] [char](2) NOT NULL,
 CONSTRAINT [PK__rg_munic__5E09AC2700AA174D] PRIMARY KEY CLUSTERED 
(
	[cod_municipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_municipio]  WITH CHECK ADD  CONSTRAINT [FK__rg_munici__sigla__22FF2F51] FOREIGN KEY([sigla_estado])
REFERENCES [dbo].[rg_estado] ([sigla_estado])
GO
ALTER TABLE [dbo].[rg_municipio] CHECK CONSTRAINT [FK__rg_munici__sigla__22FF2F51]
GO
