USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_processo]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_processo](
	[cod_proc] [int] IDENTITY(1,1) NOT NULL,
	[descr_proc] [varchar](40) NOT NULL,
	[cod_tipo_proc] [int] NOT NULL,
	[cod_aplic] [int] NOT NULL,
	[ativo] [char](1) NOT NULL,
	[form] [varchar](30) NOT NULL,
	[sequ_proc] [int] NOT NULL,
 CONSTRAINT [PK__ge_proce__B776EC702CBDA3B5] PRIMARY KEY CLUSTERED 
(
	[cod_proc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ge_processo]  WITH CHECK ADD  CONSTRAINT [FK__ge_proces__cod_a__5D60DB10] FOREIGN KEY([cod_aplic])
REFERENCES [dbo].[ge_aplicacao] ([cod_aplic])
GO
ALTER TABLE [dbo].[ge_processo] CHECK CONSTRAINT [FK__ge_proces__cod_a__5D60DB10]
GO
ALTER TABLE [dbo].[ge_processo]  WITH CHECK ADD  CONSTRAINT [FK__ge_proces__cod_t__5E54FF49] FOREIGN KEY([cod_tipo_proc])
REFERENCES [dbo].[ge_tipo_processo] ([cod_tipo_proc])
GO
ALTER TABLE [dbo].[ge_processo] CHECK CONSTRAINT [FK__ge_proces__cod_t__5E54FF49]
GO
