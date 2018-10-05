USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertBoothRecord]    Script Date: 12/30/2017 10:10:06 AM ******/
DROP PROCEDURE [dbo].[usp_insertBoothRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertBoothRecord]    Script Date: 12/30/2017 10:10:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Steven Murray
-- Create Date: 30-December-2017
-- Description:	Inserts booth record to table Booths
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertBoothRecord]
	@dtmBoothDate DATETIME,
	@dtmBoothTime TIME,
	@strBoothLocation NVARCHAR(100),
	@intParentPrimary INT,
	@intParentSecondary INT,
	@intParentAdditional INT = 0,
	@intGirlFirst INT,
	@intGirlSecond INT,
	@intGirlThird INT = 0,
	@intUserId INT,
	@dtmCreationDate DateTime,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intBoothId INT
	DECLARE @intError INT

	SET @intReturn = 0

	IF EXISTS (
				SELECT [Booth_Id]
				FROM [dbo].[Booths]
				WHERE [Booth_Date] = @dtmBoothDate
				AND [Booth_Time] = @dtmBoothTime
				AND [Booth_Location] = @strBoothLocation
			  )
	BEGIN
		SELECT @intBoothId = [Booth_Id]
		FROM [dbo].[Booths]
		WHERE [Booth_Date] = @dtmBoothDate
		AND [Booth_Time] = @dtmBoothTime
		AND [Booth_Location] = @strBoothLocation

		SET @intReturn = 90001
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Booths]
		([Booth_Date],
		 [Booth_Time],
		 [Booth_Location],
		 [Booth_Parent_Primary],
		 [Booth_Parent_Secondary],
		 [Booth_Parent_Additional],
		 [Booth_Girl_First],
		 [Booth_Girl_Second],
		 [Booth_Girl_Third],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@dtmBoothDate,
		 @dtmBoothTime,
		 @strBoothLocation,
		 @intParentPrimary,
		 @intParentSecondary,
		 @intParentAdditional,
		 @intGirlFirst,
		 @intGirlSecond,
		 @intGirlThird,
		 @intUserId,
		 @dtmCreationDate)

		 SET @intError = @@ERROR

		 IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90002
	END

	RETURN @intReturn
END




GO


