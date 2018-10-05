USE [GSCookies]
GO

/****** Object:  Table [dbo].[Girl_Inventory]    Script Date: 12/28/2017 9:47:18 AM ******/
DROP TABLE [dbo].[Girl_Inventory]
GO

/****** Object:  Table [dbo].[Girl_Inventory]    Script Date: 12/28/2017 9:47:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Girl_Inventory](
	[Girl_Inventory_Id] [int] IDENTITY(1,1) NOT NULL,
	[Girl_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [girl_Ginv_FK] FOREIGN KEY ([Girl_Id]) REFERENCES [dbo].[Girls],
 CONSTRAINT [cookie_Ginv_FK] FOREIGN KEY ([Cookie_Id]) REFERENCES [dbo].[Cookies],
 CONSTRAINT [girl_inventory_PK] PRIMARY KEY CLUSTERED 
(
	[Girl_Inventory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


