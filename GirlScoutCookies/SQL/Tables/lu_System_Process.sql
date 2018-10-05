USE [GSCookies]
GO

/****** Object:  Table [dbo].[lu_System_Process]    Script Date: 12/26/2017 4:56:06 PM ******/
DROP TABLE [dbo].[lu_System_Process]
GO

/****** Object:  Table [dbo].[lu_System_Process]    Script Date: 12/26/2017 4:56:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_System_Process](
	[Process_Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcessDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lu_System_Process] PRIMARY KEY CLUSTERED 
(
	[Process_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


