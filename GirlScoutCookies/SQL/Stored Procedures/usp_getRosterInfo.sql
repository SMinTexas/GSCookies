USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getTroopInfo]    Script Date: 12/31/2017 1:43:01 PM ******/
DROP PROCEDURE [dbo].[usp_getRosterInfo]
GO

/****** Object:  StoredProcedure [dbo].[usp_getTroopInfo]    Script Date: 12/31/2017 1:43:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 31-December-2017
-- Description:	Gets roster record
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getRosterInfo]
(
	@intRosterId INT,
	@intTroopId INT OUTPUT,
	@intMemberTypeId INT OUTPUT,
	@strFirstName NVARCHAR(20) OUTPUT,
	@strLastName NVARCHAR(20) OUTPUT,
	@strPhone NVARCHAR(14) OUTPUT,
	@strEMail NVARCHAR(100) OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @intTroopId = [Troop_Id],
		   @intMemberTypeId = [Member_Type_Id],
		   @strFirstName = [FirstName],
		   @strLastName = [LastName],
		   @strPhone = [Phone],
		   @strEMail = [EMail]
	FROM [dbo].[Troop_Roster]
	WHERE [Roster_Id] = @intRosterId
	AND [ArchiveDate] IS NULL

END

GO


