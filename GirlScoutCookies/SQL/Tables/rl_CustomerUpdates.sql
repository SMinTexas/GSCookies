USE [GSCookies]
GO

/****** Object:  Table [dbo].[rl_CustomerUpdates]    Script Date: 12/26/2017 4:58:20 PM ******/
DROP TABLE [dbo].[rl_CustomerUpdates]
GO

/****** Object:  Table [dbo].[rl_CustomerUpdates]    Script Date: 12/26/2017 4:58:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_CustomerUpdates](
	[Customer_Id] [int] NOT NULL,
	[RecordUpdatedBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateValues] [nvarchar](1000) NOT NULL,
 CONSTRAINT [cust_update_FK] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customers]
) ON [PRIMARY]

GO


