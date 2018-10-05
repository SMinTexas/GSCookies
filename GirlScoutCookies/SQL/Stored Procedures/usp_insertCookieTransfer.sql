USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertCookieTransfer]    Script Date: 12/29/2017 9:02:38 AM ******/
DROP PROCEDURE [dbo].[usp_insertCookieTransfer]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertCookieTransfer]    Script Date: 12/29/2017 9:02:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Steven Murray
-- Create Date: 26-December-2017
-- Description:	Inserts cookie transfer
--
-- Notes:
-- Transfer_Type =
-- 3 : Troop-to-troop transfer
-- 4 : Troop-to-girl transfer
-- 5 : Girl-to-troop transfer
-- 6 : Troop-to-booth transfer
-- 7 : Booth-to-troop transfer
--
-- @intDirection:
--  1  : from troop/girl/booth to the selected troop (add)
--  -1 : from the selected troop/girl/booth to another troop (subtract)
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertCookieTransfer]
	@intTransferType INT,
	@dtmTransferDate DATETIME,
	@intCookieId INT,
	@intQty INT,
	@intFromDirection INT, 
	@intToDirection INT,
	@intFrom INT,
	@intTo INT,
	@intUserId INT,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intRetVal INT;
	DECLARE @intError INT;
	DECLARE @intFromTroopId INT;
	DECLARE @intToTroopId INT;

	IF @intTransferType = 3
	BEGIN
		SET @intReturn = 0;

		IF EXISTS (SELECT [Troop_Id]
				   FROM [dbo].[Troops]
				   WHERE [Troop_Nbr] = @intFrom)
		BEGIN
			SELECT @intFromTroopId = [Troop_Id]
			FROM [dbo].[Troops]
			WHERE [Troop_Nbr] = @intFrom

			EXEC [dbo].[usp_maintainCookieInventory]
				@intCookieId,
				@intFromDirection,
				@intQty,
				@intRetVal;
		END

		IF EXISTS (SELECT [Troop_Id]
				   FROM [dbo].[Troops]
				   WHERE [Troop_Nbr] = @intTo)
		BEGIN
			SELECT @intToTroopId = [Troop_Id]
			FROM [dbo].[Troops]
			WHERE [Troop_Nbr] = @intTo

			EXEC [dbo].[usp_maintainCookieInventory]
				@intCookieId,
				@intToDirection,
				@intQty,
				@intRetVal;
		END

		INSERT INTO [dbo].[rl_CookieTransfer]
		([OrderType_Id],
		 [Cookie_Id],
		 [From],
		 [To],
		 [Qty],
		 [TransferDate],
		 [RecAddedBy]
		)
		VALUES
		(@intTransferType,
		 @intCookieId,
		 @intFrom,
		 @intTo,
		 @intQty,
		 @dtmTransferDate,
		 @intUserId
		)

		SET @intError = @@ERROR;
		IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90001;
	END

	IF @intTransferType = 4
	BEGIN
		SET @intReturn = 0

		EXEC [dbo].[usp_maintainCookieInventory]
			@intCookieId,
			@intFromDirection,
			@intQty,
			@intRetVal;

		EXEC [dbo].[usp_maintainGirlInventory]
			@intTo,
			@intCookieId,
			@intToDirection,
			@intQty,
			@intRetVal;

		INSERT INTO [dbo].[rl_CookieTransfer]
		([OrderType_Id],
		 [Cookie_Id],
		 [From],
		 [To],
		 [Qty],
		 [TransferDate],
		 [RecAddedBy]
		)
		VALUES
		(@intTransferType,
		 @intCookieId,
		 @intFrom,
		 @intTo,
		 @intQty,
		 @dtmTransferDate,
		 @intUserId
		)

		SET @intError = @@ERROR
		IF @intError > 0 AND @intError < 90000
			SET @intError = 90002;

	END

	IF @intTransferType = 5
	BEGIN
		SET @intReturn = 0

		EXEC [dbo].[usp_maintainCookieInventory]
			@intCookieId,
			@intToDirection,
			@intQty,
			@intRetVal;

		EXEC [dbo].[usp_maintainGirlInventory]
			@intFrom,
			@intCookieId,
			@intFromDirection,
			@intQty,
			@intRetVal;

		INSERT INTO [dbo].[rl_CookieTransfer]
		([OrderType_Id],
		 [Cookie_Id],
		 [From],
		 [To],
		 [Qty],
		 [TransferDate],
		 [RecAddedBy]
		)
		VALUES
		(@intTransferType,
		 @intCookieId,
		 @intFrom,
		 @intTo,
		 @intQty,
		 @dtmTransferDate,
		 @intUserId
		)

		SET @intError = @@ERROR
		IF @intError > 0 AND @intError < 90000
			SET @intError = 90002;

	END

	IF @intTransferType = 6
	BEGIN
		SET @intReturn = 0

		EXEC [dbo].[usp_maintainCookieInventory]
			@intCookieId,
			@intFromDirection,
			@intQty,
			@intRetVal;

		--EXEC [dbo].[usp_maintainGirlInventory]
		--	@intTo,
		--	@intCookieId,
		--	@intToDirection,
		--	@intQty,
		--	@intRetVal;

		INSERT INTO [dbo].[rl_CookieTransfer]
		([OrderType_Id],
		 [Cookie_Id],
		 [From],
		 [To],
		 [Qty],
		 [TransferDate],
		 [RecAddedBy]
		)
		VALUES
		(@intTransferType,
		 @intCookieId,
		 @intFrom,
		 @intTo,
		 @intQty,
		 @dtmTransferDate,
		 @intUserId
		)

		SET @intError = @@ERROR
		IF @intError > 0 AND @intError < 90000
			SET @intError = 90002;

	END

	IF @intTransferType = 7
	BEGIN
		SET @intReturn = 0

		EXEC [dbo].[usp_maintainCookieInventory]
			@intCookieId,
			@intToDirection,
			@intQty,
			@intRetVal;

		--EXEC [dbo].[usp_maintainGirlInventory]
		--	@intFrom,
		--	@intCookieId,
		--	@intFromDirection,
		--	@intQty,
		--	@intRetVal;

		INSERT INTO [dbo].[rl_CookieTransfer]
		([OrderType_Id],
		 [Cookie_Id],
		 [From],
		 [To],
		 [Qty],
		 [TransferDate],
		 [RecAddedBy]
		)
		VALUES
		(@intTransferType,
		 @intCookieId,
		 @intFrom,
		 @intTo,
		 @intQty,
		 @dtmTransferDate,
		 @intUserId
		)

		SET @intError = @@ERROR
		IF @intError > 0 AND @intError < 90000
			SET @intError = 90002;

	END
	RETURN @intReturn;
END






GO


