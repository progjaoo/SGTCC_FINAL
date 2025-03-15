USE [SGTCC]
GO

/****** Object:  Table [dbo].[UserActivationTokens]    Script Date: 15/03/2025 10:27:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [nvarchar](255) NOT NULL,
	[Expiration] [datetime] NOT NULL,
	[Type] [nchar](20) NOT NULL,
 CONSTRAINT [PK_UserToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserToken]  WITH CHECK ADD  CONSTRAINT [FK_UserToken_Usuario] FOREIGN KEY([UserId])
REFERENCES [dbo].[Usuario] ([Id])
GO

ALTER TABLE [dbo].[UserToken] CHECK CONSTRAINT [FK_UserToken_Usuario]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserActivationTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [nvarchar](500) NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserActivationTokens]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO


