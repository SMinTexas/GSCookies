USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getPasswordHint]    Script Date: 12/26/2017 6:49:44 PM ******/
DROP PROCEDURE [dbo].[usp_getPasswordHint]
GO

/****** Object:  StoredProcedure [dbo].[usp_getPasswordHint]    Script Date: 12/26/2017 6:49:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Gets user password hint
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getPasswordHint]
(
	@strUsername NVARCHAR(50),
	@strHint NVARCHAR(50) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @strHint = [Hint]
	FROM [dbo].[Users]
	WHERE [Username] = @strUsername
	AND [ArchiveDate] IS NULL

END

GO


