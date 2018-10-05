USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_OrderType]    Script Date: 12/28/2017 3:15:19 PM ******/
DROP TABLE [dbo].[lu_OrderType]
GO

/****** Object:  Table [dbo].[lu_OrderType]    Script Date: 12/28/2017 3:15:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_OrderType](
	[OrderType_Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_lu_OrderType] PRIMARY KEY CLUSTERED 
(
	[OrderType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


