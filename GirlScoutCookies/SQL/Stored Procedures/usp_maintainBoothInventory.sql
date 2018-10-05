USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_maintainBoothInventory]    Script Date: 1/5/2018 9:59:13 AM ******/
DROP PROCEDURE [dbo].[usp_maintainBoothInventory]
GO

/****** Object:  StoredProcedure [dbo].[usp_maintainBoothInventory]    Script Date: 1/5/2018 9:59:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Steven Murray
-- Create Date: 05-January-2018
-- Description:	Inserts/updates booth inventory table
--
-- Notes:
-- @intDirection:
--  1  : from troop to the selected booth (add)
--  -1 : from the selected booth to troop (subtract)
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_maintainBoothInventory]
	@intBoothId INT,
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
				SELECT [Booth_Inventory_Id]
				FROM [dbo].[Booth_Inventory]
				WHERE [Booth_Id] = @intBoothId
				AND [Cookie_Id] = @intCookieId
			  )
	BEGIN
		SELECT @intCurrentQty = [Qty]
		FROM [dbo].[Booth_Inventory]
		WHERE [Booth_Id] = @intBoothId 
		AND [Cookie_Id] = @intCookieId;

		SET @intNewQty = @intCurrentQty + (@intQty * @intDirection);
		IF @intNewQty < 0
			SET @intNewQty = 0;

		UPDATE [dbo].[Booth_Inventory]
		SET [Qty] = @intNewQty
		WHERE [Booth_Id] = @intBoothId
		AND [Cookie_Id] = @intCookieId;

	END
	ELSE
	BEGIN
		SET @intNewQty = @intQty;

		INSERT INTO [dbo].[Booth_Inventory]
		([Booth_Id],
		 [Cookie_Id],
		 [Qty]
		)
		VALUES
		(@intBoothId,
		 @intCookieId,
		 @intNewQty);

	END

	RETURN @intReturn;
END





GO


