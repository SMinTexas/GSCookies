USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateGirlRecord]    Script Date: 12/26/2017 6:54:42 PM ******/
DROP PROCEDURE [dbo].[usp_updateGirlRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateGirlRecord]    Script Date: 12/26/2017 6:54:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Steven Murray
-- Create Date: December 7, 2017
-- Description:	Updates girl record through promotion from one level to the next
--
-- Revision History:  can be deleted 19-Dec-2017 SM
-- =============================================
CREATE PROCEDURE [dbo].[usp_updateGirlRecord]
(
	@intGirlId INT,
	@intLevelId INT,
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT [Girl_Id] FROM [dbo].[Girls] WHERE [Girl_Id] = @intGirlId)
	BEGIN
		UPDATE [Girls]
		SET [Level_Id] = @intLevelId
		WHERE [Girl_Id] = @intGirlId
		AND [ArchiveDate] IS NULL

		SET @intReturn = 0;
	END
	ELSE
		SET @intReturn = 90001;

	RETURN @intReturn;
END




GO


