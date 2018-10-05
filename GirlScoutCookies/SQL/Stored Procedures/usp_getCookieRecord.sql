USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getCookieRecord]    Script Date: 1/10/2018 8:53:12 AM ******/
DROP PROCEDURE [dbo].[usp_getCookieRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_getCookieRecord]    Script Date: 1/10/2018 8:53:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Steven Murray
-- Create Date: 22-December-2017
-- Description:	Gets cookie record
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getCookieRecord]
(
	@intCounter INT,
	@intCookieId INT OUTPUT,
	@strCookieName NVARCHAR(50) OUTPUT,
	@strCookieDesc NVARCHAR(500) OUTPUT,
	@fltPrice FLOAT OUTPUT,
	@intCount INT OUTPUT,
	@fltWeight FLOAT OUTPUT,
	@intServing INT OUTPUT,
	@intCalories INT OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 @intCookieId = [Cookie_Id],
				 @strCookieName = [Cookie_Name],
				 @strCookieDesc = [Cookie_Description],
				 @fltPrice = [Cookie_Price],
				 @intCount = [CountPerContainer],
			     @fltWeight = [NetWeightPerContainer],
				 @intServing = [ServingSize],
				 @intCalories = [CaloriesPerServing]
	FROM [dbo].[Cookies]
	WHERE [ArchiveDate] IS NULL
	AND [Cookie_Id] > @intCounter

END

GO


