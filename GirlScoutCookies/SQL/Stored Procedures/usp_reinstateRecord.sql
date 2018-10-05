USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_reinstateRecord]    Script Date: 12/26/2017 6:54:33 PM ******/
DROP PROCEDURE [dbo].[usp_reinstateRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_reinstateRecord]    Script Date: 12/26/2017 6:54:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Steven Murray
-- Create Date: December 13, 2017
-- Description:	Updates a record by clearing an archival date
-- Notes:
-- @intRecType:	1 - User
--				2 - Troop
--				3 - Girl
--				4 - Cookie
--				5 - Customer
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_reinstateRecord]
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
			SET [ArchiveDate] = NULL
			WHERE [User_Id] = @intRecId
			AND [ArchiveDate] IS NOT NULL
		
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
			SET [ArchiveDate] = NULL
			WHERE [Troop_Id] = @intRecId
			AND [ArchiveDate] IS NOT NULL
		
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
			SET [ArchiveDate] = NULL
			WHERE [Girl_Id] = @intRecId
			AND [ArchiveDate] IS NOT NULL
		
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
			SET [ArchiveDate] = NULL
			WHERE [Cookie_Id] = @intRecId
			AND [ArchiveDate] IS NOT NULL
		
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
			SET [ArchiveDate] = NULL
			WHERE [Customer_Id] = @intRecId
			AND [ArchiveDate] IS NOT NULL
		
			SET @intReturn = 0
		END
		ELSE
			SET @intReturn = 90001
	END

	RETURN @intReturn;
END






GO


