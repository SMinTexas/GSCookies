USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_promoteGirl]    Script Date: 12/26/2017 6:54:27 PM ******/
DROP PROCEDURE [dbo].[usp_promoteGirl]
GO

/****** Object:  StoredProcedure [dbo].[usp_promoteGirl]    Script Date: 12/26/2017 6:54:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Steven Murray
-- Create Date: December 8, 2017
-- Description:	Promotes a girl from one level to the next
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_promoteGirl]
(
	@intGirlId INT,
	@strNewLevel VARCHAR(25) OUTPUT,
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	-- Extra variables
	DECLARE @intCurrentLevelId INT;
	DECLARE @intNewLevelId INT;
	DECLARE @intMaxLevelId INT;

	IF EXISTS (SELECT [Girl_Id] FROM [dbo].[Girls] WHERE [Girl_Id] = @intGirlId)
	BEGIN
		SELECT @intCurrentLevelId = [Level_Id]
		FROM [dbo].[Girls]
		WHERE [Girl_Id] = @intGirlId
		AND [ArchiveDate] IS NULL
	END

	SELECT @intMaxLevelId = MAX([Level_Id])
	FROM [dbo].[lu_Levels]

	SET @intNewLevelId = @intCurrentLevelId + 1

	SELECT @strNewLevel = [Level]
	FROM [dbo].[lu_Levels]
	WHERE [Level_Id] = @intNewLevelId

	IF EXISTS (SELECT [Girl_Id] FROM [dbo].[Girls] WHERE [Girl_Id] = @intGirlId)
	BEGIN
		IF @intNewLevelId <= @intMaxLevelId
		BEGIN
			UPDATE [Girls]
			SET [Level_Id] = @intNewLevelId
			WHERE [Girl_Id] = @intGirlId
			AND [ArchiveDate] IS NULL

			SET @intReturn = 0;
		END
		ELSE IF @intNewLevelId > @intMaxLevelId
		BEGIN
			SET @strNewLevel = 'Out of the program';
			SET @intReturn = 90000;
		END
	END
	ELSE
		SET @intReturn = 90001;

	RETURN @intReturn;
END




GO


