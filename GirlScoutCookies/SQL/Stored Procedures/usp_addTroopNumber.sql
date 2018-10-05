USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_addTroopNumber]    Script Date: 12/26/2017 6:45:43 PM ******/
DROP PROCEDURE [dbo].[usp_addTroopNumber]
GO

/****** Object:  StoredProcedure [dbo].[usp_addTroopNumber]    Script Date: 12/26/2017 6:45:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Steven Murray
-- Create Date: 14-November-2017
-- Description:	Inserts a troop_id to lu_Troop_Number
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_addTroopNumber]
(
	@intTroopId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT [Troop_Number] FROM [dbo].[lu_Troop_Number] WHERE [Troop_Number] = @intTroopId)
	BEGIN
		INSERT INTO [dbo].[lu_Troop_Number]
		([Troop_Number])
		VALUES
		(@intTroopId)
	END
END

GO


