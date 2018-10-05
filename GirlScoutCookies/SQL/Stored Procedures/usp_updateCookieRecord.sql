USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateCookieRecord]    Script Date: 1/10/2018 8:56:10 AM ******/
DROP PROCEDURE [dbo].[usp_updateCookieRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateCookieRecord]    Script Date: 1/10/2018 8:56:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		Steven Murray
-- Create Date: December 30, 2017
-- Description:	Updates cookie record 
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_updateCookieRecord]
(
	@intRecordType INT,
	@intCookieId INT,
	@strCookieName NVARCHAR(50),
	@strDescription NVARCHAR(500),
	@fltPrice FLOAT,
	@intCountPerContainer INT,
	@fltNetWeight FLOAT,
	@intServing INT,
	@intCalories INT,
	@intUserId INT,
	@strUpdatedValues NVARCHAR(1000),
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT [Cookie_Id] FROM [dbo].[Cookies] WHERE [Cookie_Id] = @intCookieId)
	BEGIN
		UPDATE [dbo].[Cookies]
		SET [Cookie_Name] = @strCookieName,
			[Cookie_Description] = @strDescription,
			[Cookie_Price] = @fltPrice,
			[CountPerContainer] = @intCountPerContainer,
			[NetWeightPerContainer] = @fltNetWeight,
			[ServingSize] = @intServing,
			[CaloriesPerServing] = @intCalories
		WHERE [Cookie_Id] = @intCookieId

		INSERT INTO [dbo].[rl_RecordUpdates]
		([RecordType_Id],
		 [Record_Id],
		 [RecordUpdatedBy],
		 [UpdateDate],
		 [UpdateValues]
		)
		VALUES
		(@intRecordType,
		 @intCookieId,
		 @intUserId,
		 GETDATE(),
		 @strUpdatedValues
		)

		SET @intReturn = 0;
	END
	ELSE
		SET @intReturn = 90001;

	RETURN @intReturn;
END







GO


