USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateCustomerRecord]    Script Date: 12/26/2017 6:54:38 PM ******/
DROP PROCEDURE [dbo].[usp_updateCustomerRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_updateCustomerRecord]    Script Date: 12/26/2017 6:54:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Steven Murray
-- Create Date: December 15, 2017
-- Description:	Updates customer record 
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_updateCustomerRecord]
(
	@intCustomerId INT,
	@strFirstName NVARCHAR(20),
	@strLastName NVARCHAR(20),
	@strAddress NVARCHAR(100),
	@strCity NVARCHAR(20),
	@strState NVARCHAR(2),
	@intZIPCode INT,
	@strHomePhone NVARCHAR(14),
	@strCellPhone NVARCHAR(14),
	@strWorkPhone NVARCHAR(14),
	@strEMail NVARCHAR(100),
	@strNotes NVARCHAR(1000),
	@intUserId INT,
	@strUpdatedValues NVARCHAR(1000),
	@intReturn INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT [Customer_Id] FROM [dbo].[Customers] WHERE [Customer_Id] = @intCustomerId)
	BEGIN
		UPDATE [dbo].[Customers]
		SET [FirstName] = @strFirstName,
			[LastName] = @strLastName,
			[Address] = @strAddress,
			[City] = @strCity,
			[State] = @strState,
			[ZIP] = @intZipCode,
			[HomePhone] = @strHomePhone,
			[CellPhone] = @strCellPhone,
			[WorkPhone] = @strWorkPhone,
			[EMail] = @strEMail,
			[Notes] = @strNotes
		WHERE [Customer_Id] = @intCustomerId

		INSERT INTO [dbo].[rl_CustomerUpdates]
		([Customer_Id],
		 [RecordUpdatedBy],
		 [UpdateDate],
		 [UpdateValues]
		)
		VALUES
		(@intCustomerId,
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


