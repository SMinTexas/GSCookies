USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_Choice]    Script Date: 12/26/2017 4:55:36 PM ******/
DROP TABLE [dbo].[lu_Choice]
GO

/****** Object:  Table [dbo].[lu_Choice]    Script Date: 12/26/2017 4:55:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_Choice](
	[Choice_Id] [int] IDENTITY(1,1) NOT NULL,
	[ChoiceDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lu_Choice] PRIMARY KEY CLUSTERED 
(
	[Choice_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


