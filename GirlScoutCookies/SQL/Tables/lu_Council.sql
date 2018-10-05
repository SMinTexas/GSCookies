USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_Council]    Script Date: 12/26/2017 4:55:45 PM ******/
DROP TABLE [dbo].[lu_Council]
GO

/****** Object:  Table [dbo].[lu_Council]    Script Date: 12/26/2017 4:55:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_Council](
	[Council_Id] [int] IDENTITY(1,1) NOT NULL,
	[Council] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lu_Council] PRIMARY KEY CLUSTERED 
(
	[Council_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


