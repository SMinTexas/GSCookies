USE [GSCookies]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 12/26/2017 7:12:20 PM ******/
DROP TABLE [dbo].[Orders]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 12/26/2017 7:12:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Order_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[Order_Type] [int] NOT NULL,
	[Order_Date] [datetime] NOT NULL,
	[RecAddedBy] [int] NOT NULL,
 CONSTRAINT [troop_order_FK] FOREIGN KEY ([Troop_Id]) REFERENCES [dbo].[Troops],
 CONSTRAINT [order_PK] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


