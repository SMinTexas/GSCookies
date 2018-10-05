USE [GSCookies]
GO

ALTER TABLE [dbo].[Booth_Inventory] DROP CONSTRAINT [cookie_Binv_FK]
GO

ALTER TABLE [dbo].[Booth_Inventory] DROP CONSTRAINT [booth_Binv_FK]
GO

/****** Object:  Table [dbo].[Booth_Inventory]    Script Date: 12/29/2017 9:08:54 AM ******/
DROP TABLE [dbo].[Booth_Inventory]
GO

/****** Object:  Table [dbo].[Booth_Inventory]    Script Date: 12/29/2017 9:08:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booth_Inventory](
	[Booth_Inventory_Id] [int] IDENTITY(1,1) NOT NULL,
	[Booth_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [booth_inventory_PK] PRIMARY KEY CLUSTERED 
(
	[Booth_Inventory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Booth_Inventory]  WITH CHECK ADD  CONSTRAINT [booth_Binv_FK] FOREIGN KEY([Booth_Id])
REFERENCES [dbo].[Booths] ([Booth_Id])
GO

ALTER TABLE [dbo].[Booth_Inventory] CHECK CONSTRAINT [booth_Binv_FK]
GO

ALTER TABLE [dbo].[Booth_Inventory]  WITH CHECK ADD  CONSTRAINT [cookie_Binv_FK] FOREIGN KEY([Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Booth_Inventory] CHECK CONSTRAINT [cookie_Binv_FK]
GO


