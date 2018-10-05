USE [GSCookies]
GO

/****** Object:  Table [dbo].[Troops]    Script Date: 12/26/2017 5:00:05 PM ******/
DROP TABLE [dbo].[Troops]
GO

/****** Object:  Table [dbo].[Troops]    Script Date: 12/26/2017 5:00:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Troops](
	[Troop_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Nbr] [int] NOT NULL,
	[Community] [nvarchar](50) NOT NULL,
	[Region_Nbr] [int] NOT NULL,
	[Council] [nvarchar](50) NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [PK_Troop] PRIMARY KEY CLUSTERED 
(
	[Troop_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


