USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getTroopInfo]    Script Date: 12/26/2017 6:51:03 PM ******/
DROP PROCEDURE [dbo].[usp_getTroopInfo]
GO

/****** Object:  StoredProcedure [dbo].[usp_getTroopInfo]    Script Date: 12/26/2017 6:51:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Gets troop record
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getTroopInfo]
(
	@intTroopId INT,
	@intTroopNbr INT OUTPUT,
	@strCommunity NVARCHAR(50) OUTPUT,
	@intRegionNbr INT OUTPUT,
	@strCouncil NVARCHAR(50) OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @intTroopNbr = [Troop_Nbr],
		   @strCommunity = [Community],
		   @intRegionNbr = [Region_Nbr],
		   @strCouncil = [Council]
	FROM [dbo].[Troops]
	WHERE [Troop_Id] = @intTroopId
	AND [ArchiveDate] IS NULL

END

GO


