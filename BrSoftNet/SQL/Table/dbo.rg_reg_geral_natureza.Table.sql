USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_reg_geral_natureza]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_reg_geral_natureza](
	[cod_empr] [int] NOT NULL,
	[cod_rg] [int] NOT NULL,
	[cod_natureza] [int] NOT NULL,
	[cod_status_nat_rg] [int] NOT NULL,
	[data_hora] [datetime] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC,
	[cod_rg] ASC,
	[cod_natureza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_reg_geral_natureza]  WITH CHECK ADD FOREIGN KEY([cod_natureza])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_reg_geral_natureza]  WITH CHECK ADD  CONSTRAINT [FK__rg_reg_ge__cod_s__2C88998B] FOREIGN KEY([cod_status_nat_rg])
REFERENCES [dbo].[rg_status] ([cod_status])
GO
ALTER TABLE [dbo].[rg_reg_geral_natureza] CHECK CONSTRAINT [FK__rg_reg_ge__cod_s__2C88998B]
GO
ALTER TABLE [dbo].[rg_reg_geral_natureza]  WITH NOCHECK ADD  CONSTRAINT [FK__rg_reg_geral_nat__2E70E1FD] FOREIGN KEY([cod_empr], [cod_rg])
REFERENCES [dbo].[rg_reg_geral] ([cod_empr], [cod_rg])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_reg_geral_natureza] NOCHECK CONSTRAINT [FK__rg_reg_geral_nat__2E70E1FD]
GO
