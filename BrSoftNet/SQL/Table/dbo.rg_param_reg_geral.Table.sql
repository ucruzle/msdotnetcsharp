USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_param_reg_geral]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_param_reg_geral](
	[cod_empr] [int] NOT NULL,
	[cod_nat_func] [int] NOT NULL,
	[cod_nat_func_lider] [int] NOT NULL,
	[cod_nat_cliente] [int] NOT NULL,
	[cod_nat_fornec] [int] NOT NULL,
	[cod_nat_banco] [int] NOT NULL,
	[cod_status_ativo] [int] NOT NULL,
	[cod_status_inativo] [int] NOT NULL,
	[permite_cgc_cpf_zerado] [char](1) NOT NULL,
	[cod_nat_tomadora] [int] NOT NULL,
	[cod_nat_resp] [int] NOT NULL,
	[permite_cgc_cpf_duplic] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_empr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD FOREIGN KEY([cod_nat_resp])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD FOREIGN KEY([cod_nat_tomadora])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD FOREIGN KEY([cod_nat_func_lider])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD FOREIGN KEY([cod_nat_fornec])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD FOREIGN KEY([cod_nat_banco])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD FOREIGN KEY([cod_nat_cliente])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD FOREIGN KEY([cod_nat_func])
REFERENCES [dbo].[rg_natureza] ([cod_natureza])
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD  CONSTRAINT [FK__rg_param___cod_s__2AA05119] FOREIGN KEY([cod_status_inativo])
REFERENCES [dbo].[rg_status] ([cod_status])
GO
ALTER TABLE [dbo].[rg_param_reg_geral] CHECK CONSTRAINT [FK__rg_param___cod_s__2AA05119]
GO
ALTER TABLE [dbo].[rg_param_reg_geral]  WITH CHECK ADD  CONSTRAINT [FK__rg_param___cod_s__2B947552] FOREIGN KEY([cod_status_ativo])
REFERENCES [dbo].[rg_status] ([cod_status])
GO
ALTER TABLE [dbo].[rg_param_reg_geral] CHECK CONSTRAINT [FK__rg_param___cod_s__2B947552]
GO
