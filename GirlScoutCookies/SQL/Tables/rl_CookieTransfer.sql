USE [GSCookies]
GO

/****** Object:  Table [dbo].[rl_CookieTransfer]    Script Date: 12/27/2017 8:14:25 AM ******/
DROP TABLE [dbo].[rl_CookieTransfer]
GO

/****** Object:  Table [dbo].[rl_CookieTransfer]    Script Date: 12/27/2017 8:14:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_CookieTransfer](
	[OrderType_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[From] [int] NOT NULL,
	[To] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[TransferDate] [datetime] NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	CONSTRAINT [transfer_FK] FOREIGN KEY ([OrderType_Id]) REFERENCES [dbo].[lu_OrderType],
	CONSTRAINT [cookie_trans_FK] FOREIGN KEY ([Cookie_Id]) REFERENCES [dbo].[Cookies]
) ON [PRIMARY]

GO


