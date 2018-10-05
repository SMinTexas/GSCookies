USE [GSCookies]
GO

ALTER TABLE [dbo].[rl_CookieUpdates] DROP CONSTRAINT [cookie_update_FK]
GO

/****** Object:  Table [dbo].[rl_CookieUpdates]    Script Date: 12/30/2017 1:54:21 PM ******/
DROP TABLE [dbo].[rl_CookieUpdates]
GO

/****** Object:  Table [dbo].[rl_CookieUpdates]    Script Date: 12/30/2017 1:54:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_CookieUpdates](
	[Cookie_Id] [int] NOT NULL,
	[RecordUpdatedBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateValues] [nvarchar](1000) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[rl_CookieUpdates]  WITH CHECK ADD  CONSTRAINT [cookie_update_FK] FOREIGN KEY([Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[rl_CookieUpdates] CHECK CONSTRAINT [cookie_update_FK]
GO


