USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_archiveRecord]    Script Date: 12/26/2017 6:46:56 PM ******/
DROP PROCEDURE [dbo].[usp_archiveRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_archiveRecord]    Script Date: 12/26/2017 6:46:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Steven Murray
-- Create Date: 9-December-2017
-- Description:	Updates a record by setting an archival date
-- Notes:
-- @intRecType:	1 - User
--				2 - Troop
--				3 - Girl
--				4 - Cookie
--				5 - Customer
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_archiveRecord]
(
	@intRecType INT,
	@intRecId INT,
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF @intRecType = 1
	BEGIN
		IF EXISTS(SELECT [User_Id] FROM [dbo].[Users] WHERE [User_Id] = @intRecID)
		BEGIN
			UPDATE [Users]
			SET [ArchiveDate] = GETDATE()
			WHERE [User_Id] = @intRecId
			AND [ArchiveDate] IS NULL
		
			SET @intReturn = 0
		END
		ELSE
			SET @intReturn = 90001
	END

	IF @intRecType = 2
	BEGIN
		IF EXISTS(SELECT [Troop_Nbr] FROM [dbo].[Troops] WHERE [Troop_Id] = @intRecID)
		BEGIN
			UPDATE [Troops]
			SET [ArchiveDate] = GETDATE()
			WHERE [Troop_Id] = @intRecId
			AND [ArchiveDate] IS NULL
		
			SET @intReturn = 0
		END
		ELSE
			SET @intReturn = 90001
	END

	IF @intRecType = 3
	BEGIN
		IF EXISTS(SELECT [Girl_Id] FROM [dbo].[Girls] WHERE [Girl_Id] = @intRecID)
		BEGIN
			UPDATE [Girls]
			SET [ArchiveDate] = GETDATE()
			WHERE [Girl_Id] = @intRecId
			AND [ArchiveDate] IS NULL
		
			SET @intReturn = 0
		END
		ELSE
			SET @intReturn = 90001
	END

	IF @intRecType = 4
	BEGIN
		IF EXISTS(SELECT [Cookie_Id] FROM [dbo].[Cookies] WHERE [Cookie_Id] = @intRecID)
		BEGIN
			UPDATE [Cookies]
			SET [ArchiveDate] = GETDATE()
			WHERE [Cookie_Id] = @intRecId
			AND [ArchiveDate] IS NULL
		
			SET @intReturn = 0
		END
		ELSE
			SET @intReturn = 90001
	END

	IF @intRecType = 5
	BEGIN
		IF EXISTS(SELECT [Customer_Id] FROM [dbo].[Customers] WHERE [Customer_Id] = @intRecID)
		BEGIN
			UPDATE [Customers]
			SET [ArchiveDate] = GETDATE()
			WHERE [Customer_Id] = @intRecId
			AND [ArchiveDate] IS NULL
		
			SET @intReturn = 0
		END
		ELSE
			SET @intReturn = 90001
	END

	RETURN @intReturn;
END






GO


