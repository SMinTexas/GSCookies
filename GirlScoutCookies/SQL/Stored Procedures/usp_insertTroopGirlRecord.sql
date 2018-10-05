USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopGirlRecord]    Script Date: 12/26/2017 6:52:18 PM ******/
DROP PROCEDURE [dbo].[usp_insertTroopGirlRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopGirlRecord]    Script Date: 12/26/2017 6:52:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Steven Murray
-- Create Date: 20-December-2017
-- Description:	Inserts girl record to table Troop_Girl_Roster
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertTroopGirlRecord]
(
	@intTroopId INT,
	@strFirstName NVARCHAR(20),
	@strLastName NVARCHAR(20),
	@intUserId INT,
	@dtmCreationDate DATETIME,
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [Troop_Girl_Id] FROM [dbo].[Troop_Girl_Roster] 
				   WHERE [FirstName] = @strFirstName
				   AND [LastName] = @strLastName)
	BEGIN
		INSERT INTO [dbo].[Troop_Girl_Roster]
		([Troop_Id],
		 [FirstName],
		 [LastName],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@intTroopId,
		 @strFirstName,
		 @strLastName,
		 @intUserId,
		 @dtmCreationDate
		)
		SET @intReturn = 0
	END
	ELSE
		SET @intReturn = 90001

	RETURN @intReturn
END



GO


