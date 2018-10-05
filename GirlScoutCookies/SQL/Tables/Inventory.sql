USE [GSCookies]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 12/26/2017 7:12:08 PM ******/
DROP TABLE [dbo].[Inventory]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 12/26/2017 7:12:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventory](
	[Inventory_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [cookie_inv_FK] FOREIGN KEY ([Cookie_Id]) REFERENCES [dbo].[Cookies],
 CONSTRAINT [inventory_PK] PRIMARY KEY CLUSTERED 
(
	[Inventory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


