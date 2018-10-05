USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getRecordIdByNameValue]    Script Date: 12/31/2017 1:19:39 PM ******/
DROP PROCEDURE [dbo].[usp_getRecordIdByNameValue]
GO

/****** Object:  StoredProcedure [dbo].[usp_getRecordIdByNameValue]    Script Date: 12/31/2017 1:19:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-December-2017
-- Description:	Gets the record Id based on a name value
-- Notes:
-- @intRecType:	1 - User
--				2 - Troop
--				3 - Girl
--				4 - Cookie
--				5 - Customer
--				6 - Order
--				7 - Sale
--				8 - Booth
--				9 - Deposit
--				10 - Roster (Member)
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getRecordIdByNameValue]
(
	@intRecType INT,
	@strName NVARCHAR(50),
	@blnArchived BIT,
	@intRecId INT OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	IF @intRecType = 1
	BEGIN
		IF @blnArchived = 1
		BEGIN
			SELECT @intRecId = [User_Id]
			FROM [dbo].[Users]
			WHERE [UserName] = @strName
			AND [ArchiveDate] IS NOT NULL
		END
		ELSE
		BEGIN
			SELECT @intRecId = [User_Id]
			FROM [dbo].[Users]
			WHERE [UserName] = @strName
			AND [ArchiveDate] IS NULL
		END
	END

	IF @intRecType = 2
	BEGIN
		IF @blnArchived = 1
		BEGIN
			SELECT @intRecId = [Troop_Id]
			FROM [dbo].[Troops]
			WHERE [Troop_Nbr] = CAST(@strName AS INT)
			AND [ArchiveDate] IS NOT NULL
		END
		ELSE
		BEGIN
			SELECT @intRecId = [Troop_Id]
			FROM [dbo].[Troops]
			WHERE [Troop_Nbr] = CAST(@strName AS INT)
			AND [ArchiveDate] IS NULL
		END
	END

	IF @intRecType = 3
	BEGIN
		IF @blnArchived = 1
		BEGIN
			SELECT @intRecId = [Girl_Id]
			FROM [dbo].[Girls]
			WHERE ([FirstName] + ' ' + [LastName]) = @strName
			AND [ArchiveDate] IS NOT NULL
		END
		ELSE
		BEGIN
			SELECT @intRecId = [Girl_Id]
			FROM [dbo].[Girls]
			WHERE ([FirstName] + ' ' + [LastName]) = @strName
			AND [ArchiveDate] IS NULL
		END
	END

	IF @intRecType = 4
	BEGIN
		IF @blnArchived = 1
		BEGIN
			SELECT @intRecId = [Cookie_Id]
			FROM [dbo].[Cookies]
			WHERE [Cookie_Name] = @strName
			AND [ArchiveDate] IS NOT NULL
		END
		ELSE
		BEGIN
			SELECT @intRecId = [Cookie_Id]
			FROM [dbo].[Cookies]
			WHERE [Cookie_Name] = @strName
			AND [ArchiveDate] IS NULL
		END
	END

	IF @intRecType = 5
	BEGIN
		IF @blnArchived = 1
		BEGIN
			SELECT @intRecId = [Customer_Id]
			FROM [dbo].[Customers]
			WHERE ([FirstName] + ' ' + [LastName]) = @strName
			AND [ArchiveDate] IS NOT NULL
		END
		ELSE
		BEGIN
			SELECT @intRecId = [Customer_Id]
			FROM [dbo].[Customers]
			WHERE ([FirstName] + ' ' + [LastName]) = @strName
			AND [ArchiveDate] IS NULL
		END
	END

	IF @intRecType = 10
	BEGIN
		IF @blnArchived = 1
		BEGIN
			SELECT @intRecID = [Roster_Id]
			FROM [dbo].[Troop_Roster]
			WHERE ([FirstName] + ' ' + [LastName]) = @strName
			AND [ArchiveDate] IS NOT NULL
		END
		ELSE
		BEGIN
			SELECT @intRecId = [Roster_Id]
			FROM [dbo].[Troop_Roster]
			WHERE ([FirstName] + ' ' + [LastName]) = @strName
			AND [ArchiveDate] IS NULL
		END
	END

	IF @intRecId IS NULL
		SET @intRecId = -1

	SELECT @intRecId

END




GO


