USE [GSCookies]
GO

/****** Object:  Table [dbo].[Troop_Parent_Roster]    Script Date: 12/26/2017 5:00:01 PM ******/
DROP TABLE [dbo].[Troop_Parent_Roster]
GO

/****** Object:  Table [dbo].[Troop_Parent_Roster]    Script Date: 12/26/2017 5:00:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Troop_Parent_Roster](
	[Parent_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](14) NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [troop_parent_roster_PK] PRIMARY KEY CLUSTERED 
(
	[Parent_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


