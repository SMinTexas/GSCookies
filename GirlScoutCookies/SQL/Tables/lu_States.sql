USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_States]    Script Date: 12/26/2017 4:56:02 PM ******/
DROP TABLE [dbo].[lu_States]
GO

/****** Object:  Table [dbo].[lu_States]    Script Date: 12/26/2017 4:56:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_States](
	[State_Id] [int] IDENTITY(1,1) NOT NULL,
	[State_Abbr] [nvarchar](2) NOT NULL,
	[State_Name] [nvarchar](14) NOT NULL,
 CONSTRAINT [PK_lu_States] PRIMARY KEY CLUSTERED 
(
	[State_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


