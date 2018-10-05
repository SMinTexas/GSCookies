-- script to populate the Girls table

DECLARE @strFirstName NVARCHAR(25);
DECLARE @strLastName NVARCHAR(25);
DECLARE @intLevelId INT;
DECLARE @intTroopId INT;
DECLARE @dtmDOB DATETIME;

SET @strFirstName = 'Danielle';
SET @strLastName = 'Murray';
SET @intLevelId = 4;
SET @intTroopId = 1;
SET @dtmDOB = CAST('2006-03-18' AS DATETIME)

INSERT INTO [dbo].[Girls]
([FirstName],[LastName],[Level_Id],[Troop_Id],[DOB],[RecAddedBy],[CreationDate])
VALUES
(@strFirstName,@strLastName,@intLevelId,@intTroopId,@dtmDOB,1,GETDATE())

INSERT INTO [dbo].[rl_GirlRelation]
([Girl_Id],[User_Id])
VALUES
(1,1)

