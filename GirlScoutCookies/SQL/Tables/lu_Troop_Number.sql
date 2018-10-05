USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_Troop_Number]    Script Date: 12/26/2017 4:56:11 PM ******/
DROP TABLE [dbo].[lu_Troop_Number]
GO

/****** Object:  Table [dbo].[lu_Troop_Number]    Script Date: 12/26/2017 4:56:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_Troop_Number](
	[Troop_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Number] [int] NOT NULL,
 CONSTRAINT [PK_lu_Troop_Number] PRIMARY KEY CLUSTERED 
(
	[Troop_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


