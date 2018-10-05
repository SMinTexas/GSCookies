USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_addCouncil]    Script Date: 12/26/2017 6:45:35 PM ******/
DROP PROCEDURE [dbo].[usp_addCouncil]
GO

/****** Object:  StoredProcedure [dbo].[usp_addCouncil]    Script Date: 12/26/2017 6:45:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 14-November-2017
-- Description:	Inserts a council value to lu_Council
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_addCouncil]
(
	@strCouncil NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [Council] FROM [dbo].[lu_Council] WHERE [Council] = @strCouncil)
	BEGIN
		INSERT INTO [dbo].[lu_Council]
		([Council])
		VALUES
		(@strCouncil)
	END
END

GO


