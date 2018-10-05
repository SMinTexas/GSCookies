USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlCountPerUser]    Script Date: 12/26/2017 6:47:23 PM ******/
DROP PROCEDURE [dbo].[usp_getGirlCountPerUser]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlCountPerUser]    Script Date: 12/26/2017 6:47:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 15-November-2017
-- Description:	Counts the number of girls per user
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getGirlCountPerUser]
(
	@intUserId INT,
	@intGirlCount INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @intGirlCount = COUNT(g.[Girl_Id])
	FROM [dbo].[Girls] g
	INNER JOIN [dbo].[rl_GirlRelation] r
		ON g.[Girl_Id] = r.[Girl_Id]
	WHERE r.[User_Id] = @intUserId
	AND g.[ArchiveDate] IS NULL
END

GO


