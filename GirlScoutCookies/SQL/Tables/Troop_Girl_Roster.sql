USE [GSCookies]
GO

/****** Object:  Table [dbo].[Troop_Girl_Roster]    Script Date: 12/26/2017 4:59:57 PM ******/
DROP TABLE [dbo].[Troop_Girl_Roster]
GO

/****** Object:  Table [dbo].[Troop_Girl_Roster]    Script Date: 12/26/2017 4:59:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Troop_Girl_Roster](
	[Troop_Girl_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [troop_girl_roster_PK] PRIMARY KEY CLUSTERED 
(
	[Troop_Girl_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


