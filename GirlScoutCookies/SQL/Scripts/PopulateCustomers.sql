-- script to populate the Customers table

DECLARE @strFirstName NVARCHAR(20);
DECLARE @strLastName NVARCHAR(20);
DECLARE @strAddress NVARCHAR(50);
DECLARE @strCity NVARCHAR(20);
DECLARE @strState NVARCHAR(2);
DECLARE @intZip INT;
DECLARE @strHome NVARCHAR(14);
DECLARE @strCell NVARCHAR(14);
DECLARE @strWork NVARCHAR(14);
DECLARE @strEMail NVARCHAR(100);
DECLARE @strNotes NVARCHAR(1000);

SET @strFirstName = 'Tom';
SET @strLastName = 'Murray';
SET @strAddress = '450 North Rivershire #33A';
SET @strCity = 'Conroe';
SET @strState = 'TX';
SET @intZip = 77304;
SET @strHome = '(936) 494-2016';
SET @strEMail = 'temurray@consolidated.net';
SET @strNotes = 'This is Pops!  He likes Caramel deLites and Peanut Butter Patties.  Last year he also seemed to really like the S''Mores';

INSERT INTO [dbo].[Customers]
([FirstName],[LastName],[Address],[City],[State],[ZIP],[HomePhone],[CellPhone],[WorkPhone],[EMail],[Notes],[RecAddedBy],[CreationDate])
VALUES
(@strFirstName,@strLastName,@strAddress,@strCity,@strState,@intZip,@strHome,NULL,NULL,@strEMail,@strNotes,1,GETDATE())
