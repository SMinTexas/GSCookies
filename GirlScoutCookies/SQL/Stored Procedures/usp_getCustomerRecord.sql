USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_getCustomerRecord]    Script Date: 12/26/2017 6:47:14 PM ******/
DROP PROCEDURE [dbo].[usp_getCustomerRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_getCustomerRecord]    Script Date: 12/26/2017 6:47:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Steven Murray
-- Create Date: 15-December-2017
-- Description:	Gets customer record
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_getCustomerRecord]
(
	@intRecId INT,
	@strFirstName NVARCHAR(20) OUTPUT,
	@strLastName NVARCHAR(20) OUTPUT,
	@strAddress NVARCHAR(50) OUTPUT,
	@strCity NVARCHAR(20) OUTPUT,
	@strState NVARCHAR(2) OUTPUT,
	@intZIPCode INT OUTPUT,
	@strHomePhone NVARCHAR(14) OUTPUT,
	@strCellPhone NVARCHAR(14) OUTPUT,
	@strWorkPhone NVARCHAR(14) OUTPUT,
	@strEMail NVARCHAR(100) OUTPUT,
	@strNotes NVARCHAR(1000) OUTPUT
) 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @strFirstName = [FirstName],
		   @strLastName = [LastName],
		   @strAddress = [Address],
		   @strCity = [City],
		   @strState = [State],
		   @intZIPCode = [ZIP],
		   @strHomePhone = [HomePhone],
		   @strCellPhone = [CellPhone],
		   @strWorkPhone = [WorkPhone],
		   @strEMail = [EMail],
		   @strNotes = [Notes]
	FROM [dbo].[Customers]
	WHERE [Customer_Id] = @intRecId
	AND [ArchiveDate] IS NULL

END

GO


