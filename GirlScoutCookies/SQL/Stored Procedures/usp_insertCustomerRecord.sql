USE [GSCookies]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertCustomerRecord]    Script Date: 12/26/2017 6:52:09 PM ******/
DROP PROCEDURE [dbo].[usp_insertCustomerRecord]
GO

/****** Object:  StoredProcedure [dbo].[usp_insertCustomerRecord]    Script Date: 12/26/2017 6:52:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Steven Murray
-- Create Date: 11-December-2017
-- Description:	Inserts customer record to table Customers
--
-- Revision History:
-- =============================================
CREATE PROCEDURE [dbo].[usp_insertCustomerRecord]
	-- Add the parameters for the stored procedure here
	@strFirstName NVARCHAR(20),
	@strLastName NVARCHAR(20),
	@strAddress NVARCHAR(50),
	@strCity NVARCHAR(20),
	@strState NVARCHAR(2),
	@intZIP INT,
	@strHome NVARCHAR(14),
	@strCell NVARCHAR(14),
	@strWork NVARCHAR(14),
	@strEMail NVARCHAR(100),
	@strNotes NVARCHAR(1000),
	@intUserId INT,
	@dtmCreationDate DateTime,
	@intReturn INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	-- General variables
	DECLARE @intCustomerId INT
	DECLARE @intError INT

	SET @intReturn = 0

	IF EXISTS (
				SELECT [Customer_Id] 
				FROM [dbo].[Customers]
				WHERE [FirstName] = @strFirstName
				AND [LastName] = @strLastName
			  )
	BEGIN
		SELECT @intCustomerId = [Customer_Id]
		FROM [dbo].[Customers]
		WHERE [FirstName] = @strFirstName
		AND [LastName] = @strLastName

		SET @intReturn = 90001
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Customers]
		([FirstName],
		 [LastName],
		 [Address],
		 [City],
		 [State],
		 [ZIP],
		 [HomePhone],
		 [CellPhone],
		 [WorkPhone],
		 [EMail],
		 [Notes],
		 [RecAddedBy],
		 [CreationDate]
		)
		VALUES
		(@strFirstName,
	     @strLastName,
		 @strAddress,
		 @strCity,
		 @strState,
		 @intZIP,
		 @strHome,
		 @strCell,
		 @strWork,
		 @strEMail,
		 @strNotes,
		 @intUserId,
		 @dtmCreationDate)

		 SET @intError = @@ERROR

		 IF @intError > 0 AND @intError < 90000
			SET @intReturn = 90001
	END

	RETURN @intReturn
END




GO


