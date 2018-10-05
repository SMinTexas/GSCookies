USE [GSCookies]
GO

/****** Object:  Table [dbo].[Order_Details]    Script Date: 12/26/2017 7:14:57 PM ******/
DROP TABLE [dbo].[Order_Details]
GO

/****** Object:  Table [dbo].[Order_Details]    Script Date: 12/26/2017 7:14:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_Details](
	[Order_Detail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[Order_Qty] [int] NOT NULL,
 CONSTRAINT [order_OD_FK] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders],
 CONSTRAINT [cookie_OD_FK] FOREIGN KEY ([Cookie_Id]) REFERENCES [dbo].[Cookies],
 CONSTRAINT [order_detail_PK] PRIMARY KEY CLUSTERED 
(
	[Order_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


