USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateRosterRecord]    Script Date: 12/31/2017 1:23:26 PM ******/
DROP PROCEDURE [dbo].[usp_updateRosterRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateRosterRecord]    Script Date: 12/31/2017 1:23:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Steven Murray
-- Create Date: December 31, 2017
-- Description:	Updates roster record 
--
-- Revision History:  
-- =============================================
CREATE PROCEDURE [dbo].[usp_updateRosterRecord]
(
	@intRosterId INT,
	@intTroopId INT,
	@intMemberTypeId INT,
	@strFirstName NVARCHAR(20),
	@strLastName NVARCHAR(20),
	@strPhone NVARCHAR(14),
	@strEMail NVARCHAR(100),
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT [Roster_Id] 
			   FROM [dbo].[Troop_Roster] 
			   WHERE [Roster_Id] = @intRosterId)
	BEGIN
		UPDATE [Troop_Roster]
		SET [Troop_Id] = @intTroopId,
			[Member_Type_Id] = @intMemberTypeId,
			[FirstName] = @strFirstName,
			[LastName] = @strLastName,
			[Phone] = @strPhone,
			[EMail] = @strEMail
		WHERE [Roster_Id] = @intRosterId
		AND [ArchiveDate] IS NULL

		SET @intReturn = 0;
	END
	ELSE
		SET @intReturn = 90001;

	RETURN @intReturn;
END





GO


