USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_Region_Number]    Script Date: 12/26/2017 4:55:58 PM ******/
DROP TABLE [dbo].[lu_Region_Number]
GO

/****** Object:  Table [dbo].[lu_Region_Number]    Script Date: 12/26/2017 4:55:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_Region_Number](
	[Region_Id] [int] IDENTITY(1,1) NOT NULL,
	[Region_Number] [int] NOT NULL,
 CONSTRAINT [PK_lu_Region_Number] PRIMARY KEY CLUSTERED 
(
	[Region_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


