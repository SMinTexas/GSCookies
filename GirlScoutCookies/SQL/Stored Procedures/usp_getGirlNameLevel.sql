USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlNameLevel]    Script Date: 12/26/2017 6:49:18 PM ******/
DROP PROCEDURE [dbo].[usp_getGirlNameLevel]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlNameLevel]    Script Date: 12/26/2017 6:49:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 16-November-2017
-- Description:	Gets girl name and level for combo box
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getGirlNameLevel]
(
	@intUserId INT,
	@intGirlId INT,
	@strFirstName NVARCHAR(20) OUTPUT,
	@strLastName NVARCHAR(20) OUTPUT,
	@strLevel NVARCHAR(25) OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @strFirstName = g.[FirstName],
		   @strLastName = g.[LastName],
		   @strLevel = l.[Level]
	FROM [dbo].[Girls] g
	INNER JOIN [dbo].[rl_GirlRelation] r
		ON g.[Girl_Id] = r.[Girl_Id]
	INNER JOIN [dbo].[lu_Levels] l
		ON g.[Level_Id] = l.[Level_Id]
	WHERE r.[User_Id] = @intUserId AND r.[Girl_Id] = @intGirlId
	AND g.[ArchiveDate] IS NULL

END
GO


