USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[rg_log_reg_geral]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rg_log_reg_geral](
	[IdEmpresa] [int] NOT NULL,
	[IdRg] [int] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
	[datahora] [datetime] NOT NULL,
	[acoes] [char](1) NOT NULL,
	[status] [char](1) NOT NULL,
	[logid] [uniqueidentifier] NOT NULL,
	[aplicacao] [varchar](50) NULL,
	[metodos] [varchar](150) NULL,
	[disparador] [varchar](250) NULL,
	[cadeiaexc] [varchar](500) NULL,
	[linkaux] [varchar](400) NULL,
	[infochaves] [varchar](500) NULL,
	[descricao] [varchar](300) NULL,
	[mensagem] [varchar](500) NULL,
 CONSTRAINT [PK_rg_log_reg_geral] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC,
	[IdRg] ASC,
	[usuario] ASC,
	[datahora] ASC,
	[acoes] ASC,
	[status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[rg_log_reg_geral]  WITH NOCHECK ADD  CONSTRAINT [FK_rg_log_acoes] FOREIGN KEY([acoes])
REFERENCES [dbo].[rg_log_acoes] ([acoes])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_log_reg_geral] NOCHECK CONSTRAINT [FK_rg_log_acoes]
GO
ALTER TABLE [dbo].[rg_log_reg_geral]  WITH NOCHECK ADD  CONSTRAINT [FK_rg_log_status] FOREIGN KEY([status])
REFERENCES [dbo].[rg_log_status] ([Status])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[rg_log_reg_geral] NOCHECK CONSTRAINT [FK_rg_log_status]
GO
