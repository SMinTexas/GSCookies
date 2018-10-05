-- script to populate the Booths table

DECLARE @intTroopId INT = 1;
DECLARE @dtmBoothDate DATETIME = CAST('2018-01-05' AS DATETIME);
DECLARE @dtmBoothTime TIME(0) = CAST('10:00:00' AS TIME(0));
DECLARE @strLocation NVARCHAR(100) = 'Kroger Bayhill/GP';
DECLARE @intPrimary INT = 4;
DECLARE @intSecondary INT = 5;
DECLARE @intAdditional INT = 6;
DECLARE @intFirst INT = 1;
DECLARE @intSecond INT = 2;
DECLARE @intThird INT = 3;

INSERT INTO [dbo].[Booths]
([Troop_Id],[Booth_Date],[Booth_Time],[Booth_Location],[Booth_Parent_Primary],[Booth_Parent_Secondary],[Booth_Parent_Additional],[Booth_Girl_First],[Booth_Girl_Second],[Booth_Girl_Third],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@dtmBoothDate,@dtmBoothTime,@strLocation,@intPrimary,@intSecondary,@intAdditional,@intFirst,@intSecond,@intThird,1,GETDATE())

SET @dtmBoothTime = CAST('12:00:00' AS TIME(0));

INSERT INTO [dbo].[Booths]
([Troop_Id],[Booth_Date],[Booth_Time],[Booth_Location],[Booth_Parent_Primary],[Booth_Parent_Secondary],[Booth_Parent_Additional],[Booth_Girl_First],[Booth_Girl_Second],[Booth_Girl_Third],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@dtmBoothDate,@dtmBoothTime,@strLocation,@intPrimary,@intSecondary,NULL,@intFirst,@intSecond,NULL,1,GETDATE())

SET @dtmBoothTime = CAST('14:00:00' AS TIME(0))

INSERT INTO [dbo].[Booths]
([Troop_Id],[Booth_Date],[Booth_Time],[Booth_Location],[Booth_Parent_Primary],[Booth_Parent_Secondary],[Booth_Parent_Additional],[Booth_Girl_First],[Booth_Girl_Second],[Booth_Girl_Third],[RecAddedBy],[CreationDate])
VALUES
(@intTroopId,@dtmBoothDate,@dtmBoothTime,@strLocation,@intPrimary,@intSecondary,NULL,@intFirst,@intSecond,NULL,1,GETDATE())