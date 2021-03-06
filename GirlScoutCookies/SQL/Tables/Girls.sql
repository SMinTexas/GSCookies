USE [GSCookies]
GO

/****** Object:  Table [dbo].[Girls]    Script Date: 12/26/2017 4:52:47 PM ******/
DROP TABLE [dbo].[Girls]
GO

/****** Object:  Table [dbo].[Girls]    Script Date: 12/26/2017 4:52:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Girls](
	[Girl_Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Level_Id] [int] NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[DOB] [datetime] NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [girl_PK] PRIMARY KEY CLUSTERED 
(
	[Girl_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


