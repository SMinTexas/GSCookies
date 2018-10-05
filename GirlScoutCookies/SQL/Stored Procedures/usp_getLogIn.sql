USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getLogIn]    Script Date: 12/26/2017 6:49:30 PM ******/
DROP PROCEDURE [dbo].[usp_getLogIn]
GO

/****** Object:  StoredProcedure [dbo].[usp_getLogIn]    Script Date: 12/26/2017 6:49:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Gets user login record
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getLogIn]
(
	@strUsername NVARCHAR(50),
	@strPassword NVARCHAR(50),
	@strFirstName NVARCHAR(20) OUTPUT,
	@strLastName NVARCHAR(20) OUTPUT,
	@intUserId INT OUTPUT,
	@strRelation NVARCHAR(10) OUTPUT,
	@strPhone NVARCHAR(14) OUTPUT,
	@strEMail NVARCHAR(100) OUTPUT,
	@strUserLevel NVARCHAR(5) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @strFirstName = [FirstName],
		   @strLastName = [LastName],
		   @intUserId = [User_Id],
		   @strRelation = [Relation],
		   @strPhone = [Phone],
		   @strEMail = [EMail],
		   @strUserLevel = [UserLevel]
	FROM [dbo].[Users]
	WHERE [Username] = @strUserName AND [Password] = @strPassword
	AND [ArchiveDate] IS NULL

END

GO


