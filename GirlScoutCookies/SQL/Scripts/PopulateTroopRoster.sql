-- script to populate the table Troop_Roster

DECLARE @intTroopId INT;
DECLARE @intMemberTypeID INT;
DECLARE @strFirstName NVARCHAR(20);
DECLARE @strLastName NVARCHAR(20);
DECLARE @strPhone NVARCHAR(14);
DECLARE @strEMail NVARCHAR(100);

SET @intTroopID = 1

--Girls
SET @intMemberTypeID = 1;
SET @strFirstName = 'Danielle';
SET @strLastName = 'Murray';
SET @strPhone = '(713) 585-1929';
SET @strEMail = 'danielle.06.murray@comcast.net';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())

SET @strFirstName = 'Abby';
SET @strLastName = 'Merrell';
SET @strPhone = '(555) 555-5555';
SET @strEMail = 'a@m.com';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())

SET @strFirstName = 'Fallon';
SET @strLastName = 'Wilson';
SET @strPhone = '(555) 555-5555';
SET @strEMail = 'f@w.com';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())

--Leaders
SET @intMemberTypeID = 2;
SET @strFirstName = 'Rhonda';
SET @strLastName = 'Murray';
SET @strPhone = '(832) 289-0766';
SET @strEMail = 'rhondasmurray@gmail.com';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())

SET @strFirstName = 'Kirsty';
SET @strLastName = 'Merrell';
SET @strPhone = '(555) 555-5555';
SET @strEMail = 'k@m.com';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())

--Volunteers

SET @intMemberTypeID = 3;
SET @strFirstName = 'Steven';
SET @strLastName = 'Murray';
SET @strPhone = '(281) 974-9844';
SET @strEMail = 'tstevenm@gmail.com';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())

SET @strFirstName = 'Brad';
SET @strLastName = 'Merrell';
SET @strPhone = '(555) 555-5555';
SET @strEMail = 'b@m.com';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())

SET @strFirstName = 'Amanda';
SET @strLastName = 'Naumann';
SET @strPhone = '(555) 555-5555';
SET @strEMail = 'a@n.com';

INSERT INTO [dbo].[Troop_Roster]
([Troop_Id],[Member_Type_Id],[FirstName],[LastName],[Phone],[EMail],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@intMemberTypeID,@strFirstName,@strLastName,@strPhone,@strEMail,1,GETDATE())
