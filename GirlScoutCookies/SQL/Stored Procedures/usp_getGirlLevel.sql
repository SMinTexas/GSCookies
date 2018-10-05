USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlLevel]    Script Date: 12/26/2017 6:49:14 PM ******/
DROP PROCEDURE [dbo].[usp_getGirlLevel]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlLevel]    Script Date: 12/26/2017 6:49:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Steven Murray
-- Create Date: 8-December-2017
-- Description:	Gets a girl's current level
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getGirlLevel]
(
	@intGirlId INT,
	@strLevel NVARCHAR(25) OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @strLevel = l.[Level]
	FROM [dbo].[lu_Levels] l
	INNER JOIN [dbo].[Girls] g
	ON l.[Level_Id] = g.[Level_Id]
	WHERE g.[Girl_Id] = @intGirlId
	AND g.[ArchiveDate] IS NULL

END

GO


