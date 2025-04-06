USE [SGTCC]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 06/04/2025 18:18:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Senha] [nvarchar](255) NOT NULL,
	[Papel] [int] NOT NULL,
	[IdImagem] [int] NULL,
	[UltimoAcesso] [datetime] NULL,
	[CriadoEm] [datetime] NOT NULL,
	[EditadoEm] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdImagem])
REFERENCES [dbo].[Arquivo] ([Id])
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Arquivo_IdImagem] FOREIGN KEY([IdImagem])
REFERENCES [dbo].[Arquivo] ([Id])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Arquivo_IdImagem]
GO

