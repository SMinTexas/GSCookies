USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopParentRecord]    Script Date: 12/26/2017 6:52:22 PM ******/
DROP PROCEDURE [dbo].[usp_insertTroopParentRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertTroopParentRecord]    Script Date: 12/26/2017 6:52:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Steven Murray
-- Create Date: 20-December-2017
-- Description:	Inserts parent record to table Troop_Parent_Roster
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertTroopParentRecord]
(
	@intTroopId INT,
	@strFirstName NVARCHAR(20),
	@strLastName NVARCHAR(20),
	@strPhone NVARCHAR(14),
	@intUserId INT,
	@dtmCreationDate DATETIME,
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [Parent_Id] FROM [dbo].[Troop_Parent_Roster] 
				   WHERE [FirstName] = @strFirstName
				   AND [LastName] = @strLastName)
	BEGIN
		INSERT INTO [dbo].[Troop_Parent_Roster]
		([Troop_Id],
		 [FirstName],
		 [LastName],
		 [Phone],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@intTroopId,
		 @strFirstName,
		 @strLastName,
		 @strPhone,
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


