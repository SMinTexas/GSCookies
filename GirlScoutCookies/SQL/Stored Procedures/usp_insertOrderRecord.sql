USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertOrderRecord]    Script Date: 12/26/2017 7:04:56 PM ******/
DROP PROCEDURE [dbo].[usp_insertOrderRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertOrderRecord]    Script Date: 12/26/2017 7:04:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Steven Murray
-- Create Date: 26-December-2017
-- Description:	Inserts cookie order records to Orders, Order_Details and Inventory tables
--
-- Notes:
-- OrderType =
-- 1 : Initial
-- 2 : Resupply
-- 3 : Troop-to-troop order
-- 4 : Troop-to-girl order
-- 5 : Girl-to-troop order
-- 6 : Troop-to-booth order
-- 7 : Booth-to-girl order
--
-- @intDirection:
--  1  : from another troop to the selected troop (add)
--  -1 : from the selected troop to another troop (subtract)
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertOrderRecord]
	@intOrderType INT,
	@dtmOrderDate DATETIME,
	@intTroopId INT,
	@intCookieId INT,
	@intQty INT,
	@intDirection INT, 
	@intGirlId INT,
	@intBoothId INT,
	@intUserId INT,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intOrderId INT;
	DECLARE @intRetVal INT;
	DECLARE @intError INT;

	IF @intOrderType IN (1,2)
	BEGIN
		SET @intReturn = 0;

		INSERT INTO [dbo].[Orders]
		([Order_Type],
		 [Order_Date], 
		 [Troop_Id],
		 [RecAddedBy]
		)
		VALUES
		(@intOrderType,
		 @dtmOrderDate,
		 @intTroopId,
		 @intUserId
		);

		SET @intOrderId = SCOPE_IDENTITY();

		SET @intError = @@ERROR;
		IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90000;

		INSERT INTO [dbo].[Order_Details]
		([Order_Id],
		 [Cookie_Id],
		 [Order_Qty]
		)
		VALUES
		(@intOrderId,
		 @intCookieId,
		 @intQty
		);

		SET @intError = @@ERROR;
		IF @intError > 0 AND @intError < 90000
			SET @intError = 90001;

		EXEC [dbo].[usp_maintainCookieInventory]
			@intCookieId,
			@intDirection,
			@intQty,
			@intRetVal;

	END

	RETURN @intReturn;
END





GO


