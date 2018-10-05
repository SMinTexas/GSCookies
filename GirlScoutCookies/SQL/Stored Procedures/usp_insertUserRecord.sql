USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertUserRecord]    Script Date: 12/26/2017 6:52:36 PM ******/
DROP PROCEDURE [dbo].[usp_insertUserRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertUserRecord]    Script Date: 12/26/2017 6:52:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Inserts user record to table Users
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertUserRecord]
(
	@strUsername NVARCHAR(50),
	@strPassword NVARCHAR(50),
	@strHint NVARCHAR(50),
	@strRelation NVARCHAR(10),
	@strPhone NVARCHAR(14),
	@strEMail NVARCHAR(100),
	@strFirstName NVARCHAR(20),
	@strLastName NVARCHAR(20),
	@strUserLevel NVARCHAR(5),
	@dtmCreationDate DATETIME,
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [User_Id]
				   FROM [dbo].[Users]
				   WHERE [UserName] = @strUsername
				   AND [Password] = @strPassword
				   AND [Hint] = @strHint
				   AND [Relation] = @strRelation
				   AND [Phone] = @strPhone
				   AND [EMail] = @strEMail
				   AND [FirstName] = @strFirstName
				   AND [LastName] = @strLastName
				   AND [UserLevel] = @strUserLevel)
	BEGIN
		INSERT INTO [dbo].[Users]
		([UserName],
		 [Password],
		 [Hint],
		 [Relation],
		 [Phone],
		 [EMail],
		 [FirstName],
		 [LastName],
		 [UserLevel],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@strUsername,
		 @strPassword,
		 @strHint,
		 @strRelation,
		 @strPhone,
		 @strEMail,
		 @strFirstName,
		 @strLastName,
		 @strUserLevel,
		 'SYSTEM',
		 @dtmCreationDate
		)

		SET @intReturn = 0
	END
	ELSE
		SET @intReturn = 90001

	RETURN @intReturn
END


GO


