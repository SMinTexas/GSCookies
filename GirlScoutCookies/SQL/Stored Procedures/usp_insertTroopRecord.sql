USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopRecord]    Script Date: 12/26/2017 6:52:26 PM ******/
DROP PROCEDURE [dbo].[usp_insertTroopRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopRecord]    Script Date: 12/26/2017 6:52:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Inserts troop record to table Troop
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertTroopRecord]
(
	@intTroopNbr INT,
	@strCommunity NVARCHAR(50),
	@intRegionNbr INT,
	@strCouncil NVARCHAR(50),
	@intUserId INT,
	@dtmCreationDate DATETIME,
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [Troop_Id] FROM [dbo].[Troops] 
				   WHERE [Troop_Nbr] = @intTroopNbr
				   AND [Community] = @strCommunity
				   AND [Region_Nbr] = @intRegionNbr
				   AND [Council] = @strCouncil)
	BEGIN
		INSERT INTO [dbo].[Troops]
		([Troop_Nbr],
		 [Community],
		 [Region_Nbr],
		 [Council],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@intTroopNbr,
		 @strCommunity,
		 @intRegionNbr,
		 @strCouncil,
		 @intUserId,
		 @dtmCreationDate
		)
		SET @intReturn = 0
	END
	ELSE
		SET @intReturn = 90001

	RETURN @intReturn
END


GO


