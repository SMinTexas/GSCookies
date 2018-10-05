-- script to populate the Orders | Order_Details | Inventory tables

DECLARE @intCount INT = 9;
DECLARE @intCounter INT = 0;

DECLARE @intTroopId INT = 1;
DECLARE @intOrderType INT = 1;
DECLARE @dtmOrderDate DATETIME = CAST('2018-01-04' AS DATETIME);

WHILE @intCounter < @intCount
BEGIN
	INSERT INTO [dbo].[Orders]
	([Troop_Id],[Order_Type],[Order_Date],[RecAddedBy])
	VALUES
	(@intTroopId,@intOrderType,@dtmOrderDate,1)
	SET @intCounter = @intCounter + 1;
END

DECLARE @intOrderId INT = 1;
DECLARE @intCookieId INT = 1;
DECLARE @intQty INT = 400;

SET @intCounter = 0;

WHILE @intCounter < @intCount
BEGIN
	INSERT INTO [dbo].[Order_Details]
	([Order_Id],[Cookie_Id],[Order_Qty])
	VALUES
	(@intOrderId,@intCookieId,@intQty)

	INSERT INTO [dbo].[Inventory]
	([Troop_Id],[Cookie_Id],[Qty])
	VALUES
	(@intTroopId,@intCookieId,@intQty)

	SET @intCounter = @intCounter + 1;
	SET @intOrderId = @intOrderId + 1;
	SET @intCookieId = @intCookieId + 1;
END

