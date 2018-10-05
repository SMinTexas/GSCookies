USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_maintainGirlInventory]    Script Date: 12/28/2017 2:52:24 PM ******/
DROP PROCEDURE [dbo].[usp_maintainGirlInventory]
GO

/****** Object:  StoredProcedure [dbo].[usp_maintainGirlInventory]    Script Date: 12/28/2017 2:52:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Steven Murray
-- Create Date: 28-December-2017
-- Description:	Inserts/updates girl inventory table
--
-- Notes:
-- @intDirection:
--  1  : from troop to the selected girl (add)
--  -1 : from the selected girl to troop (subtract)
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_maintainGirlInventory]
	@intGirlId INT,
	@intCookieId INT,
	@intDirection INT,
	@intQty INT,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intCurrentQty INT;
	DECLARE @intNewQty INT;
	DECLARE @intError INT;

	SET @intReturn = 0;

	IF EXISTS (
				SELECT [Girl_Inventory_Id]
				FROM [dbo].[Girl_Inventory]
				WHERE [Girl_Id] = @intGirlId
				AND [Cookie_Id] = @intCookieId
			  )
	BEGIN
		SELECT @intCurrentQty = [Qty]
		FROM [dbo].[Girl_Inventory]
		WHERE [Girl_Id] = @intGirlId 
		AND [Cookie_Id] = @intCookieId;

		SET @intNewQty = @intCurrentQty + (@intQty * @intDirection);
		IF @intNewQty < 0
			SET @intNewQty = 0;

		UPDATE [dbo].[Girl_Inventory]
		SET [Qty] = @intNewQty
		WHERE [Girl_Id] = @intGirlId
		AND [Cookie_Id] = @intCookieId;

	END
	ELSE
	BEGIN
		SET @intNewQty = @intQty;

		INSERT INTO [dbo].[Girl_Inventory]
		([Girl_Id],
		 [Cookie_Id],
		 [Qty]
		)
		VALUES
		(@intGirlId,
		 @intCookieId,
		 @intNewQty);

	END

	RETURN @intReturn;
END




GO


