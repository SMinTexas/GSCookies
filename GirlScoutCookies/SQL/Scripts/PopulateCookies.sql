-- script to load the cookies table

DECLARE @strCookieName NVARCHAR(50)
DECLARE @strCookieDescription NVARCHAR(500)
DECLARE @fltPrice FLOAT
DECLARE @intCountPerContainer INT
DECLARE @fltNetWeightPerContainer FLOAT
DECLARE @intServingSize INT
DECLARE @intCaloriesPerServing INT
DECLARE @intUserId INT
DECLARE @dtmCreationDate DATETIME
DECLARE @dtmArchiveDate DATETIME

SET @fltPrice = 4.0

--Thanks-A-Lot
SET @strCookieName = 'Thanks-A-Lot'
SET @strCookieDescription = 'Shortbread cookies dipped in rich fudge and topped with an embossed thank you message in one of five languages.'
SET @intCountPerContainer = 16
SET @fltNetWeightPerContainer = 8.5
SET @intServingSize = 2
SET @intCaloriesPerServing = 150
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)

--Girl Scout S'Mores
SET @strCookieName = 'Girl Scout S''More'
SET @strCookieDescription = 'Crispy graham cookie double dipped in yummy creme icing and finished with a scrumptuous chocolately coating.'
SET @intCountPerContainer = 15
SET @fltNetWeightPerContainer = 9.5
SET @intServingSize = 2
SET @intCaloriesPerServing = 180
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)

--Lemonades
SET @strCookieName = 'Lemonade'
SET @strCookieDescription = 'Savory slices of shortbread with a refreshingly tangy lemon flavored icing.'
SET @intCountPerContainer = 16
SET @fltNetWeightPerContainer = 8.5
SET @intServingSize = 2
SET @intCaloriesPerServing = 150
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)

--Shortbreads
SET @strCookieName = 'Shortbread'
SET @strCookieDescription = 'Traditional shortbread cookies.'
SET @intCountPerContainer = 40
SET @fltNetWeightPerContainer = 9.0
SET @intServingSize = 4
SET @intCaloriesPerServing = 120
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)

--Thin Mints
SET @strCookieName = 'Thin Mint'
SET @strCookieDescription = 'Crispy chocolate wafers dipped in a mint chocolatey coating.'
SET @intCountPerContainer = 32
SET @fltNetWeightPerContainer = 9.0
SET @intServingSize = 4
SET @intCaloriesPerServing = 160
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)

--Peanut Butter Patties
SET @strCookieName = 'Peanut Butter Pattie'
SET @strCookieDescription = 'Crispy vanilla cookies layered with peanut butter and covered with a chocolaty coating.'
SET @intCountPerContainer = 15
SET @fltNetWeightPerContainer = 6.5
SET @intServingSize = 2
SET @intCaloriesPerServing = 130
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)

--Caramel deLites
SET @strCookieName = 'Caramel deLite'
SET @strCookieDescription = 'Vanilla cookies topped with caramel, sprinkled with toasted coconut, and laced with chocolaty stripes.'
SET @intCountPerContainer = 15
SET @fltNetWeightPerContainer = 7.0
SET @intServingSize = 2
SET @intCaloriesPerServing = 130
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)

--Peanut Butter Sandwiches
SET @strCookieName = 'Peanut Butter Sandwich'
SET @strCookieDescription = 'Crisp and crunchy oatmeal cookies with creamy peanut butter filling.'
SET @intCountPerContainer = 20
SET @fltNetWeightPerContainer = 8.0
SET @intServingSize = 3
SET @intCaloriesPerServing = 170
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)
--Trios
SET @strCookieName = 'Trios'
SET @strCookieDescription = 'Chocolate Chips nestled in a gluten free peanut butter oatmeal cookie.'
SET @fltPrice = 5.0
SET @intCountPerContainer = 12
SET @fltNetWeightPerContainer = 5.0
SET @intServingSize = 3
SET @intCaloriesPerServing = 170
SET @intUserId = 1
SET @dtmCreationDate = GETDATE()
INSERT INTO [dbo].[Cookies]
(
 [Cookie_Name],
 [Cookie_Description],
 [Cookie_Price],
 [CountPerContainer],
 [NetWeightPerContainer],
 [ServingSize],
 [CaloriesPerServing],
 [RecAddedBy],
 [CreationDate],
 [ArchiveDate]
)
VALUES
(
 @strCookieName,
 @strCookieDescription,
 @fltPrice,
 @intCountPerContainer,
 @fltNetWeightPerContainer,
 @intServingSize,
 @intCaloriesPerServing,
 @intUserId,
 @dtmCreationDate,
 NULL
)