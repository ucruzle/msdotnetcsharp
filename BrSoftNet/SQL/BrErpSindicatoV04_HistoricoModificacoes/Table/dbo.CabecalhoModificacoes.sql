USE [BrErpSindicatoV04_HistoricoModificacoes]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CabecalhoModificacoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoRegistro] [int] NOT NULL,
	[NomeProcesso] [varchar](100) NOT NULL,
	[TipoModificacao] [char](1) NOT NULL,
	[Usuario] [char](20) NOT NULL,
	[Data] [date] NOT NULL,
	[Hora] [timestamp] NOT NULL,
	[StatusExecucao] [char](1) NOT NULL,
 CONSTRAINT [PK_CabecalhoModificacoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO