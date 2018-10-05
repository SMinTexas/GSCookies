USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getEMail]    Script Date: 12/26/2017 6:47:19 PM ******/
DROP PROCEDURE [dbo].[usp_getEMail]
GO

/****** Object:  StoredProcedure [dbo].[usp_getEMail]    Script Date: 12/26/2017 6:47:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 12-November-2017
-- Description:	Gets user E-Mail
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getEMail]
(
	@strUsername NVARCHAR(50),
	@strEMail NVARCHAR(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @strEMail = [EMail]
	FROM [dbo].[Users]
	WHERE [Username] = @strUsername

END

GO


