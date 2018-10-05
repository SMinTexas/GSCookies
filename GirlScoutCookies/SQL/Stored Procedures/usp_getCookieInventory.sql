USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getCookieInventory]    Script Date: 1/6/2018 12:04:13 PM ******/
DROP PROCEDURE [dbo].[usp_getCookieInventory]
GO

/****** Object:  StoredProcedure [dbo].[usp_getCookieInventory]    Script Date: 1/6/2018 12:04:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Steven Murray
-- Create Date: 06-January-2018
-- Description:	Gets cookie inventory by cookie
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getCookieInventory]
(
	@intSaleType INT,
	@intCounter INT,
	@intID INT,
	@strCookieName NVARCHAR(50) OUTPUT,
	@intQty INT OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	IF @intSaleType = 1
	BEGIN
		SELECT TOP 1 @strCookieName = c.[Cookie_Name],
					 @intQty = i.[Qty]
		FROM [dbo].[Girl_Inventory] i
		INNER JOIN [dbo].[Cookies] c
		ON i.[Cookie_Id] = c.[Cookie_Id]
		WHERE c.[ArchiveDate] IS NULL
		AND i.[Girl_Id] = @intID
		AND c.[Cookie_Id] > @intCounter
	END
	ELSE
	IF @intSaleType = 2
	BEGIN
		SELECT TOP 1 @strCookieName = c.[Cookie_Name],
					 @intQty = i.[Qty]
		FROM [dbo].[Booth_Inventory] i
		INNER JOIN [dbo].[Cookies] c
		ON i.[Cookie_Id] = c.[Cookie_Id]
		WHERE c.[ArchiveDate] IS NULL
		AND i.[Booth_Id] = @intID
		AND c.[Cookie_Id] > @intCounter
	END

END


GO


