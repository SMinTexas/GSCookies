-- script to load the Troops table

DECLARE @intTroopNumber INT
DECLARE @strCommunity NVARCHAR(50)
DECLARE @intRegionNumber INT
DECLARE @strCouncil NVARCHAR(50)

SET @intTroopNumber = 17051
SET @strCommunity = 'Island Creek'
SET @intRegionNumber = 9
SET @strCouncil = 'San Jacinto'

INSERT INTO [dbo].[Troops]
([Troop_Nbr],[Community],[Region_Nbr],[Council],[RecAddedBy],[CreationDate])
VALUES
(@intTroopNumber,@strCommunity,@intRegionNumber,@strCouncil,1,GETDATE())