USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_addRegionNumber]    Script Date: 12/26/2017 6:45:39 PM ******/
DROP PROCEDURE [dbo].[usp_addRegionNumber]
GO

/****** Object:  StoredProcedure [dbo].[usp_addRegionNumber]    Script Date: 12/26/2017 6:45:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 14-November-2017
-- Description:	Inserts a region_id to lu_Region_Number
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_addRegionNumber]
(
	@intRegionId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [Region_Number] FROM [dbo].[lu_Region_Number] WHERE [Region_Number] = @intRegionId)
	BEGIN
		INSERT INTO [dbo].[lu_Region_Number]
		([Region_Number])
		VALUES
		(@intRegionId)
	END
END

GO


