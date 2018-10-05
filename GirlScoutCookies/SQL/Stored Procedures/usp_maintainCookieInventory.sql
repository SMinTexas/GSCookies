USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_maintainCookieInventory]    Script Date: 12/26/2017 6:54:24 PM ******/
DROP PROCEDURE [dbo].[usp_maintainCookieInventory]
GO

/****** Object:  StoredProcedure [dbo].[usp_maintainCookieInventory]    Script Date: 12/26/2017 6:54:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Steven Murray
-- Create Date: 26-December-2017
-- Description:	Inserts/updates cookie inventory table
--
-- Notes:
-- @intDirection:
--  1  : from another troop to the selected troop (add)
--  -1 : from the selected troop to another troop (subtract)
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_maintainCookieInventory]
	@intCookieId INT,
	@intDirection INT,
	@intQty INT,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intGirlId INT;
	DECLARE @intCurrentQty INT;
	DECLARE @intNewQty INT;
	DECLARE @intError INT;

	SET @intReturn = 0;

	IF EXISTS (
				SELECT [Inventory_Id]
				FROM [dbo].[Inventory]
				WHERE [Cookie_Id] = @intCookieId
			  )
	BEGIN
		SELECT @intCurrentQty = [Qty]
		FROM [dbo].[Inventory]
		WHERE [Cookie_Id] = @intCookieId;

		SET @intNewQty = @intCurrentQty + (@intQty * @intDirection);
		IF @intNewQty < 0
			SET @intNewQty = 0;

		UPDATE [dbo].[Inventory]
		SET [Qty] = @intNewQty
		WHERE [Cookie_Id] = @intCookieId;

		--SET @intError = @@ERROR;
		--IF @intError > 0 AND @intError < 90000
		--	SET @intReturn = 90001;
	END
	ELSE
	BEGIN
		SET @intNewQty = @intQty;

		INSERT INTO [dbo].[Inventory]
		([Cookie_Id],
		 [Qty]
		)
		VALUES
		(@intCookieId,
		 @intNewQty);

		 --SET @intError = @@ERROR;
		 --IF @intError > 0 AND @intError < 90000
			--SET @intReturn = 90002;
	END

	RETURN @intReturn;
END



GO


