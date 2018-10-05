USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertCookieRecord]    Script Date: 1/10/2018 8:54:24 AM ******/
DROP PROCEDURE [dbo].[usp_insertCookieRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertCookieRecord]    Script Date: 1/10/2018 8:54:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Steven Murray
-- Create Date: 11-December-2017
-- Description:	Inserts cookie record to table Cookies
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertCookieRecord]
	@strCookieName NVARCHAR(50),
	@strDescription NVARCHAR(500),
	@fltPrice FLOAT = 0.0,
	@intCount INT = 0,
	@fltWeight FLOAT = 0.0,
	@intServing INT = 0,
	@intCalories INT = 0,
	@intUserId INT,
	@dtmCreationDate DateTime,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intCookieId INT
	DECLARE @intError INT

	SET @intReturn = 0

	IF EXISTS (
				SELECT [Cookie_Id] 
				FROM [dbo].[Cookies]
				WHERE [Cookie_Name] = @strCookieName
			  )
	BEGIN
		SELECT @intCookieId = [Cookie_Id]
		FROM [dbo].[Cookies]
		WHERE [Cookie_Name] = @strCookieName

		SET @intReturn = 90001
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Cookies]
		([Cookie_Name],
		 [Cookie_Description],
		 [Cookie_Price],
		 [CountPerContainer],
		 [NetWeightPerContainer],
		 [ServingSize],
		 [CaloriesPerServing],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@strCookieName,
		 @strDescription,
		 @fltPrice,
		 @intCount,
		 @fltWeight,
		 @intServing,
		 @intCalories,
		 @intUserId,
		 @dtmCreationDate)

		 SET @intError = @@ERROR

		 IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90001
	END

	RETURN @intReturn
END



GO


