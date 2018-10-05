USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getTroopId]    Script Date: 12/26/2017 6:51:00 PM ******/
DROP PROCEDURE [dbo].[usp_getTroopId]
GO

/****** Object:  StoredProcedure [dbo].[usp_getTroopId]    Script Date: 12/26/2017 6:51:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Gets a girl's troop_id

-- can be deleted 19-Dec-2017 SM
-- =============================================
CREATE PROCEDURE [dbo].[usp_getTroopId]
(
	@intGirlId INT,
	@intTroopId INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @intTroopId = [Troop_Id]
	FROM [dbo].[Girls]
	WHERE [Girl_Id] = @intGirlId
	AND [ArchiveDate] IS NULL

END

GO


