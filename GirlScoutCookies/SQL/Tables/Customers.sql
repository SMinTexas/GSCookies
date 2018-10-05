USE [GSCookies]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 12/26/2017 4:52:37 PM ******/
DROP TABLE [dbo].[Customers]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 12/26/2017 4:52:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](2) NULL,
	[ZIP] [int] NULL,
	[HomePhone] [nvarchar](14) NULL,
	[CellPhone] [nvarchar](14) NULL,
	[WorkPhone] [nvarchar](14) NULL,
	[EMail] [nvarchar](100) NULL,
	[Notes] [nvarchar](1000) NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [customer_PK] PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


