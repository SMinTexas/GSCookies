-- script to populate lu_Member_Type and lu_Sale_Type

DECLARE @strMember NVARCHAR(16);
DECLARE @strSale NVARCHAR(8);

SET @strMember = 'Girl';
INSERT INTO [dbo].[lu_Member_Type]
([Member_Type])
VALUES
(@strMember)

SET @strMember = 'Parent Leader';
INSERT INTO [dbo].[lu_Member_Type]
([Member_Type])
VALUES
(@strMember)

SET @strMember = 'Parent Volunteer';
INSERT INTO [dbo].[lu_Member_Type]
([Member_Type])
VALUES
(@strMember)

SET @strSale = 'Customer';
INSERT INTO [dbo].[lu_Sale_Type]
([Sale_Type])
VALUES
(@strSale)

SET @strSale = 'Booth';
INSERT INTO [dbo].[lu_Sale_Type]
([Sale_Type])
VALUES
(@strSale)