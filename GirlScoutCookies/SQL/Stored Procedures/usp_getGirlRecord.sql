USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlRecord]    Script Date: 12/26/2017 6:49:23 PM ******/
DROP PROCEDURE [dbo].[usp_getGirlRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlRecord]    Script Date: 12/26/2017 6:49:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 15-November-2017
-- Description:	Gets girl record
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getGirlRecord]
(
	@intUserId INT,
	@intGirlId INT,
	@strFirstName NVARCHAR(20) OUTPUT,
	@strLastName NVARCHAR(20) OUTPUT,
	@dtmDOB DATETIME OUTPUT,
	@intLevelId INT OUTPUT,
	@strLevel NVARCHAR(25) OUTPUT,
	@intTroopId INT OUTPUT,
	@intTroopNumber INT OUTPUT,
	@strCommunity NVARCHAR(50) OUTPUT,
	@intRegionNumber INT OUTPUT,
	@strCouncil NVARCHAR(50) OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @strFirstName = g.[FirstName],
		   @strLastName = g.[LastName],
		   @dtmDOB = g.[DOB],
		   @intLevelId = g.[Level_Id],
		   @strLevel = l.[Level],
		   @intTroopId = g.[Troop_Id],
		   @intTroopNumber = t.[Troop_Nbr],
		   @strCommunity = t.[Community],
		   @intRegionNumber = t.[Region_Nbr],
		   @strCouncil = t.[Council]
	FROM [dbo].[Girls] g
	INNER JOIN [dbo].[rl_GirlRelation] r
		ON g.[Girl_Id] = r.[Girl_Id]
	INNER JOIN [dbo].[Troops] t
		ON g.[Troop_Id] = t.[Troop_Id]
	INNER JOIN [dbo].[lu_Levels] l
		ON g.[Level_Id] = l.[Level_Id]
	WHERE r.[User_Id] = @intUserId AND r.[Girl_Id] = @intGirlId
	AND g.[ArchiveDate] IS NULL

END
GO


