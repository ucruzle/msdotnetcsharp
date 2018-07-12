USE [BrErpSindicatoV04_HistoricoModificacoes]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LancamentoExcecoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCabecalhoModificacoes] [int] NOT NULL,
	[Formulario] [varchar](50) NOT NULL,
	[Tarefa] [varchar](50) NOT NULL,
	[FuncaoDisparador] [varchar](50) NOT NULL,
	[TipoExcecao] [char](30) NOT NULL,
	[MensagemExcecao] [varchar](max) NOT NULL,
 CONSTRAINT [PK_LancamentoExcecoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LancamentoExcecoes]  WITH CHECK ADD  CONSTRAINT [FK_CabecalhoModificacoes_LancamentoExcecoes] FOREIGN KEY([IdCabecalhoModificacoes])
REFERENCES [dbo].[CabecalhoModificacoes] ([Id])
GO

ALTER TABLE [dbo].[LancamentoExcecoes] CHECK CONSTRAINT [FK_CabecalhoModificacoes_LancamentoExcecoes]
GO