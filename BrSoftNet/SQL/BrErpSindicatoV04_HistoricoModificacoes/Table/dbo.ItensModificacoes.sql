USE [BrErpSindicatoV04_HistoricoModificacoes]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ItensModificacoes](
	[IdCabecalhoModificacoes] [int] NOT NULL,
	[IdItem] [int] IDENTITY(1,1) NOT NULL,
	[NomeTabela] [varchar](30) NOT NULL,
	[NomeCampo] [varchar](30) NOT NULL,
	[ValorAntigo] [varchar](max) NOT NULL,
	[ValorNovo] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ItensModificacoes] PRIMARY KEY CLUSTERED 
(
	[IdCabecalhoModificacoes] ASC,
	[IdItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ItensModificacoes]  WITH CHECK ADD  CONSTRAINT [FK_CabecalhoModificacoes_ItensModificacoes] FOREIGN KEY([IdCabecalhoModificacoes])
REFERENCES [dbo].[CabecalhoModificacoes] ([Id])
GO

ALTER TABLE [dbo].[ItensModificacoes] CHECK CONSTRAINT [FK_CabecalhoModificacoes_ItensModificacoes]
GO