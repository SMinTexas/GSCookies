USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlId]    Script Date: 12/26/2017 6:47:27 PM ******/
DROP PROCEDURE [dbo].[usp_getGirlId]
GO

/****** Object:  StoredProcedure [dbo].[usp_getGirlId]    Script Date: 12/26/2017 6:47:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 15-November-2017
-- Description:	Gets girl_id
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getGirlId]
(
	@intUserId INT,
	@intGirlCount INT,
	@intIterator INT,
	@intGirlId INT OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intTempGirlId INT;

	IF @intGirlCount = 1
	BEGIN
		SELECT @intGirlId = g.[Girl_Id]
		FROM [dbo].[Girls] g
		INNER JOIN [dbo].[rl_GirlRelation] r
			ON g.[Girl_Id] = r.[Girl_Id]
		WHERE r.[User_Id] = @intUserId
		AND g.[ArchiveDate] IS NULL
	END

	IF @intGirlCount > 1
	BEGIN
		SELECT TOP 1 @intGirlId = g.[Girl_Id]
		FROM [dbo].[Girls] g
		INNER JOIN [dbo].[rl_GirlRelation] r
			ON g.[Girl_Id] = r.[Girl_Id]
		WHERE r.[User_Id] = @intUserId
		AND g.[ArchiveDate] IS NULL
		AND r.[Girl_Id] > @intIterator
	END

	RETURN @intGirlId;

END
GO


