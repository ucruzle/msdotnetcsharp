USE [BrErpSindicatoV04]
GO
SET IDENTITY_INSERT [dbo].[rg_status] ON 

INSERT [dbo].[rg_status] ([cod_status], [descr_status]) VALUES (1, N'Ativo1')
INSERT [dbo].[rg_status] ([cod_status], [descr_status]) VALUES (2, N'Inativo')
INSERT [dbo].[rg_status] ([cod_status], [descr_status]) VALUES (3, N'Suspenso')
SET IDENTITY_INSERT [dbo].[rg_status] OFF
