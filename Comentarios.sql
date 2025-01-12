USE [BlogPostDB]
GO

/****** Object:  Table [dbo].[comentarios]    Script Date: 12/01/2025 3:09:31 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[comentarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contenido] [nvarchar](max) NULL,
	[Autor] [nvarchar](max) NULL,
	[BlogPostId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.comentarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[comentarios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.comentarios_dbo.BlogPosts_BlogPostId] FOREIGN KEY([BlogPostId])
REFERENCES [dbo].[BlogPosts] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[comentarios] CHECK CONSTRAINT [FK_dbo.comentarios_dbo.BlogPosts_BlogPostId]
GO


