USE [GSCookies]
GO

/****** Object:  Table [dbo].[rl_TroopToTroop]    Script Date: 12/26/2017 4:58:31 PM ******/
DROP TABLE [dbo].[rl_TroopToTroop]
GO

/****** Object:  Table [dbo].[rl_TroopToTroop]    Script Date: 12/26/2017 4:58:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_TroopToTroop](
	[Cookie_Id] [int] NOT NULL,
	[FromTroop] [int] NOT NULL,
	[ToTroop] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[TransferDate] [datetime] NOT NULL,
	[RecAddedBy] [int] NOT NULL
	) ON [PRIMARY]
GO


