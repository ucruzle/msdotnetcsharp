USE [BrErpSindicatoV04]
GO
SET IDENTITY_INSERT [dbo].[ge_aplicacao] ON 

INSERT [dbo].[ge_aplicacao] ([cod_aplic], [descr_aplic], [sigla_aplic], [sequ_aplic], [ativa], [form_aplic]) VALUES (0, N'Genérico1', N'GN', 13, N'S', N'GenericoF1')
INSERT [dbo].[ge_aplicacao] ([cod_aplic], [descr_aplic], [sigla_aplic], [sequ_aplic], [ativa], [form_aplic]) VALUES (1, N'Gerenciador', N'GE', 1, N'S', N'GerenciadorF')
INSERT [dbo].[ge_aplicacao] ([cod_aplic], [descr_aplic], [sigla_aplic], [sequ_aplic], [ativa], [form_aplic]) VALUES (2, N'Registro Geral', N'RG', 2, N'S', N'MenRegGeralF')
INSERT [dbo].[ge_aplicacao] ([cod_aplic], [descr_aplic], [sigla_aplic], [sequ_aplic], [ativa], [form_aplic]) VALUES (4, N'Financeiro', N'FI', 4, N'N', N'MenFinanceiroF')
INSERT [dbo].[ge_aplicacao] ([cod_aplic], [descr_aplic], [sigla_aplic], [sequ_aplic], [ativa], [form_aplic]) VALUES (5, N'Contabilidade', N'CT', 5, N'S', N'MemContabilF')
INSERT [dbo].[ge_aplicacao] ([cod_aplic], [descr_aplic], [sigla_aplic], [sequ_aplic], [ativa], [form_aplic]) VALUES (6, N'Folha de Pagamento', N'FP', 6, N'S', N'MenFolhaPagtoF')
INSERT [dbo].[ge_aplicacao] ([cod_aplic], [descr_aplic], [sigla_aplic], [sequ_aplic], [ativa], [form_aplic]) VALUES (12, N'Fatura', N'FA', 12, N'S', N'MemFaturaF')
SET IDENTITY_INSERT [dbo].[ge_aplicacao] OFF
