USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getUserId]    Script Date: 12/26/2017 6:51:07 PM ******/
DROP PROCEDURE [dbo].[usp_getUserId]
GO

/****** Object:  StoredProcedure [dbo].[usp_getUserId]    Script Date: 12/26/2017 6:51:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Gets the UserId for a selected user
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getUserId]
(
	@strUsername NVARCHAR(50),
	@strPassword NVARCHAR(50),
	@intUserId INT OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @intUserId = [User_Id]
	FROM [dbo].[Users]
	WHERE [UserName] = @strUserName AND [Password] = @strPassword
	AND [ArchiveDate] IS NULL

	IF @intUserId IS NULL
		SET @intUserId = -1

	SELECT @intUserId

END

GO


