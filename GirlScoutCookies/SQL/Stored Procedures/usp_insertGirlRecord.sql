USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertGirlRecord]    Script Date: 12/26/2017 6:52:13 PM ******/
DROP PROCEDURE [dbo].[usp_insertGirlRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertGirlRecord]    Script Date: 12/26/2017 6:52:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Inserts girl record to table Girls
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertGirlRecord]
	-- Add the parameters for the stored procedure here
	@strFirstName NVARCHAR(50),
	@strLastName NVARCHAR(50),
	@dtmDOB DATETIME,
	@intLevelId INT,
	@intTroopId INT,
	@intUserId INT,
	@dtmCreationDate DateTime,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intGirlId INT
	DECLARE @intError INT

	SET @intReturn = 0

	IF EXISTS (
				SELECT [Girl_Id] 
				FROM [dbo].[Girls]
				WHERE [FirstName] = @strFirstName AND [LastName] = @strLastName
			  )
	BEGIN
		SELECT @intGirlId = [Girl_Id]
		FROM [dbo].[Girls]
		WHERE [FirstName] = @strFirstName AND [LastName] = @strLastName
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Girls]
		([FirstName],
		 [LastName],
		 [Level_Id],
		 [Troop_Id],
		 [DOB],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@strFirstName,
		 @strLastName,
		 @intLevelId,
		 @intTroopId,
		 @dtmDOB,
		 @intUserId,
		 @dtmCreationDate)

		 SET @intError = @@ERROR
		 IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90001
	END

	IF @intGirlId IS NULL
		SELECT @intGirlId = [Girl_Id]
		FROM [dbo].[Girls]
		WHERE [FirstName] = @strFirstName AND [LastName] = @strLastName
		
	IF @intReturn = 0
	BEGIN
		INSERT INTO [dbo].[rl_GirlRelation]
		([Girl_Id],
		 [User_Id]
		)
		VALUES
		(@intGirlId,
		 @intUserId
		)

		SET @intError = @@ERROR
		IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90001
	END

	RETURN @intReturn
END


GO


