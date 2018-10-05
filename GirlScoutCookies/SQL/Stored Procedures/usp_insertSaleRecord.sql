USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertSaleRecord]    Script Date: 1/6/2018 1:49:35 PM ******/
DROP PROCEDURE [dbo].[usp_insertSaleRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertSaleRecord]    Script Date: 1/6/2018 1:49:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Steven Murray
-- Create Date: 06-January-2018
-- Description:	Inserts cookie sales records to Sales
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertSaleRecord]
	@intSaleType INT,
	@intTroopId INT,
	@intSaleById INT,
	@intCustomerId INT,
	@intCookieId INT,
	@intQty INT,
	@intUserId INT,
	@dtmCreationDate DATETIME,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intRetVal INT;
	DECLARE @intError INT;

	IF @intSaleType = 1
	BEGIN
		SET @intReturn = 0;

		INSERT INTO [dbo].[Sales]
		([Sale_Type_Id],
		 [Troop_Id],
		 [SoldBy_Id],
		 [Customer_Id],
		 [Cookie_Id],
		 [Qty],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@intSaleType,
		 @intTroopId,
		 @intSaleById,
		 @intCustomerId,
		 @intCookieId,
		 @intQty,
		 @intUserId,
		 @dtmCreationDate
		)

		SET @intError = @@ERROR;
		IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90000;

		EXEC [dbo].[usp_maintainGirlInventory]
			@intSaleById,
			@intCookieId,
			-1,
			@intQty,
			@intRetVal
	END
	ELSE
	IF @intSaleType = 2
	BEGIN
		SET @intReturn = 0;

		INSERT INTO [dbo].[Sales]
		([Sale_Type_Id],
		 [Troop_Id],
		 [SoldBy_Id],
		 [Customer_Id],
		 [Cookie_Id],
		 [Qty],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@intSaleType,
		 @intTroopId,
		 @intSaleById,
		 NULL,
		 @intCookieId,
		 @intQty,
		 @intUserId,
		 @dtmCreationDate
		)

		SET @intError = @@ERROR;
		IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90001;

		EXEC [dbo].[usp_maintainBoothInventory]
			@intSaleById,
			@intCookieId,
			-1,
			@intQty,
			@intRetVal
	END

	RETURN @intReturn;
END






GO


