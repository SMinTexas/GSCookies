USE [GSCookies]
GO

/****** Object:  Table [dbo].[Cookies]    Script Date: 12/26/2017 4:52:31 PM ******/
DROP TABLE [dbo].[Cookies]
GO

/****** Object:  Table [dbo].[Cookies]    Script Date: 12/26/2017 4:52:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cookies](
	[Cookie_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cookie_Name] [varchar](50) NOT NULL,
	[Cookie_Description] [nvarchar](500) NOT NULL,
	[CountPerContainer] [int] NULL,
	[NetWeightPerContainer] [float] NULL,
	[ServingSize] [int] NULL,
	[CaloriesPerServing] [int] NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [cookie_PK] PRIMARY KEY CLUSTERED 
(
	[Cookie_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


