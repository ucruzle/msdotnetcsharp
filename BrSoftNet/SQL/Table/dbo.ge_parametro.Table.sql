USE [BrErpSindicatoV04]
GO
/****** Object:  Table [dbo].[ge_parametro]    Script Date: 03/02/2015 10:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ge_parametro](
	[id_tabela] [int] IDENTITY(1,1) NOT NULL,
	[dir_logo_empresa] [varchar](100) NOT NULL,
	[dir_pgm_relatorio] [varchar](100) NOT NULL,
	[dir_relatorio] [varchar](100) NOT NULL,
	[dir_backup] [varchar](100) NOT NULL,
	[dir_script] [varchar](100) NOT NULL,
	[dir_importacao] [varchar](100) NOT NULL,
	[dir_exportacao_excel] [varchar](100) NOT NULL,
	[cod_tipo_proc_esp] [int] NOT NULL,
	[cod_tipo_proc_int] [int] NOT NULL,
	[mostra_form_menu] [char](1) NOT NULL,
	[dir_foto] [varchar](100) NOT NULL,
	[dir_servidor] [varchar](100) NOT NULL,
 CONSTRAINT [PK__ge_param__948CC03228ED12D1] PRIMARY KEY CLUSTERED 
(
	[id_tabela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ge_parametro]  WITH NOCHECK ADD  CONSTRAINT [FK__ge_parame__cod_t__5B78929E] FOREIGN KEY([cod_tipo_proc_int])
REFERENCES [dbo].[ge_tipo_processo] ([cod_tipo_proc])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ge_parametro] NOCHECK CONSTRAINT [FK__ge_parame__cod_t__5B78929E]
GO
ALTER TABLE [dbo].[ge_parametro]  WITH NOCHECK ADD  CONSTRAINT [FK__ge_parame__cod_t__5C6CB6D7] FOREIGN KEY([cod_tipo_proc_esp])
REFERENCES [dbo].[ge_tipo_processo] ([cod_tipo_proc])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ge_parametro] NOCHECK CONSTRAINT [FK__ge_parame__cod_t__5C6CB6D7]
GO
