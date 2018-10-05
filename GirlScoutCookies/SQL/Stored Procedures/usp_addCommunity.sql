USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_addCommunity]    Script Date: 12/26/2017 6:45:25 PM ******/
DROP PROCEDURE [dbo].[usp_addCommunity]
GO

/****** Object:  StoredProcedure [dbo].[usp_addCommunity]    Script Date: 12/26/2017 6:45:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 14-November-2017
-- Description:	Inserts a community value to lu_Community
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_addCommunity]
(
	@strCommunity NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [Community] FROM [dbo].[lu_Community] WHERE [Community] = @strCommunity)
	BEGIN
		INSERT INTO [dbo].[lu_Community]
		([Community])
		VALUES
		(@strCommunity)
	END
END

GO


