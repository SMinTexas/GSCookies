USE [GSCookies]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 12/26/2017 5:00:09 PM ******/
DROP TABLE [dbo].[Users]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 12/26/2017 5:00:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Hint] [nvarchar](50) NOT NULL,
	[Relation] [nvarchar](12) NOT NULL,
	[Phone] [nvarchar](14) NOT NULL,
	[EMail] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[UserLevel] [nvarchar](5) NOT NULL,
	[RecAddedBy] [nvarchar](20) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [users_PK] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


