USE [GSCookies]
GO

/****** Object:  Table [dbo].[Booths]    Script Date: 12/26/2017 4:52:26 PM ******/
DROP TABLE [dbo].[Booths]
GO

/****** Object:  Table [dbo].[Booths]    Script Date: 12/26/2017 4:52:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booths](
	[Booth_Id] [int] IDENTITY(1,1) NOT NULL,
	[Booth_Date] [date] NOT NULL,
	[Booth_Time] [time](7) NOT NULL,
	[Booth_Location] [nvarchar](100) NOT NULL,
	[Booth_Parent_Primary] [int] NOT NULL,
	[Booth_Parent_Secondary] [int] NOT NULL,
	[Booth_Parent_Additional] [int] NULL,
	[Booth_Girl_First] [int] NOT NULL,
	[Booth_Girl_Second] [int] NOT NULL,
	[Booth_Girl_Third] [int] NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [booth_PK] PRIMARY KEY CLUSTERED 
(
	[Booth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


