USE [GSCookies]
GO

/****** Object:  Table [dbo].[rl_GirlRelation]    Script Date: 12/26/2017 4:58:26 PM ******/
DROP TABLE [dbo].[rl_GirlRelation]
GO

/****** Object:  Table [dbo].[rl_GirlRelation]    Script Date: 12/26/2017 4:58:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_GirlRelation](
	[Girl_Id] [int] NOT NULL,
	[User_Id] [int] NOT NULL,
 CONSTRAINT [girl_Grel_FK] FOREIGN KEY ([Girl_Id]) REFERENCES [dbo].[Girls],
 CONSTRAINT [user_Grel_FK] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users]
) ON [PRIMARY]

GO


