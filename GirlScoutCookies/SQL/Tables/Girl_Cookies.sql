USE [GSCookies]
GO

/****** Object:  Table [dbo].[Girl_Cookies]    Script Date: 12/26/2017 4:52:41 PM ******/
DROP TABLE [dbo].[Girl_Cookies]
GO

/****** Object:  Table [dbo].[Girl_Cookies]    Script Date: 12/26/2017 4:52:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Girl_Cookies](
	[Girl_Cookie_Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Detail_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[Cookie_Qty] [int] NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [girl_cookie_PK] PRIMARY KEY CLUSTERED 
(
	[Girl_Cookie_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


