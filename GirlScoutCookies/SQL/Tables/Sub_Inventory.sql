USE [GSCookies]
GO

ALTER TABLE [dbo].[Sub_Inventory] DROP CONSTRAINT [sub_Ginv_FK]
GO

ALTER TABLE [dbo].[Sub_Inventory] DROP CONSTRAINT [sub_cookie_Binv_FK]
GO

ALTER TABLE [dbo].[Sub_Inventory] DROP CONSTRAINT [sub_Binv_FK]
GO

/****** Object:  Table [dbo].[Sub_Inventory]    Script Date: 1/22/2018 5:31:23 AM ******/
DROP TABLE [dbo].[Sub_Inventory]
GO

/****** Object:  Table [dbo].[Sub_Inventory]    Script Date: 1/22/2018 5:31:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sub_Inventory](
	[Sub_Inventory_Id] [int] IDENTITY(1,1) NOT NULL,
	[Booth_Id] [int] NULL,
	[Girl_Id] [int] NULL,
	[Cookie_Id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [sub_inventory_PK] PRIMARY KEY CLUSTERED 
(
	[Sub_Inventory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sub_Inventory]  WITH CHECK ADD  CONSTRAINT [sub_Binv_FK] FOREIGN KEY([Booth_Id])
REFERENCES [dbo].[Booths] ([Booth_Id])
GO

ALTER TABLE [dbo].[Sub_Inventory] CHECK CONSTRAINT [sub_Binv_FK]
GO

ALTER TABLE [dbo].[Sub_Inventory]  WITH CHECK ADD  CONSTRAINT [sub_cookie_Binv_FK] FOREIGN KEY([Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sub_Inventory] CHECK CONSTRAINT [sub_cookie_Binv_FK]
GO

ALTER TABLE [dbo].[Sub_Inventory]  WITH CHECK ADD  CONSTRAINT [sub_Ginv_FK] FOREIGN KEY([Girl_Id])
REFERENCES [dbo].[Girls] ([Girl_Id])
GO

ALTER TABLE [dbo].[Sub_Inventory] CHECK CONSTRAINT [sub_Ginv_FK]
GO


