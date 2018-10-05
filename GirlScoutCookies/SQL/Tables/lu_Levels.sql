USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_Levels]    Script Date: 12/26/2017 4:55:49 PM ******/
DROP TABLE [dbo].[lu_Levels]
GO

/****** Object:  Table [dbo].[lu_Levels]    Script Date: 12/26/2017 4:55:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_Levels](
	[Level_Id] [int] IDENTITY(1,1) NOT NULL,
	[Level] [nvarchar](25) NOT NULL
) ON [PRIMARY]

GO


