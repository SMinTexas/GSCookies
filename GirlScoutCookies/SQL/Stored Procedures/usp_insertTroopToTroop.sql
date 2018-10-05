USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopToTroop]    Script Date: 12/26/2017 6:52:31 PM ******/
DROP PROCEDURE [dbo].[usp_insertTroopToTroop]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopToTroop]    Script Date: 12/26/2017 6:52:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Steven Murray
-- Create Date: 26-December-2017
-- Description:	Inserts troop-to-troop transfer
--
-- Notes:
-- OrderType =
-- 3 : Troop-to-troop order
--
-- @intDirection:
--  1  : from another troop to the selected troop (add)
--  -1 : from the selected troop to another troop (subtract)
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertTroopToTroop]
	@intOrderType INT,
	@dtmOrderDate DATETIME,
	@intTroopId INT,
	@intCookieId INT,
	@intQty INT,
	@intDirection INT, 
	@intFromTroop INT,
	@intToTroop INT,
	@intUserId INT,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intRetVal INT;
	DECLARE @intError INT;

	IF @intOrderType = 3
	BEGIN
		SET @intReturn = 0;

		EXEC [dbo].[usp_maintainCookieInventory]
			@intCookieId,
			@intDirection,
			@intQty,
			@intRetVal;

		INSERT INTO [dbo].[rl_TroopToTroop]
		([Cookie_Id],
		 [FromTroop],
		 [ToTroop],
		 [Qty]
		)
		VALUES
		(@intCookieId,
		 @intFromTroop,
		 @intToTroop,
		 @intQty
		)

		SET @intError = @@ERROR;
		IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90001;
	END

	RETURN @intReturn;
END




GO


