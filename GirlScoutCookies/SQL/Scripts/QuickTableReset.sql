-- Run this only when needing to do a quick re-build of the existing table structures

-- Table Drops
USE [GSCookies]
GO


DROP TABLE [dbo].[rl_CookieTransfer]
GO
DROP TABLE [dbo].[Sub_Inventory]
GO
DROP TABLE [dbo].[Inventory]
GO
DROP TABLE [dbo].[Order_Details]
GO
DROP TABLE [dbo].[Orders]
GO
DROP TABLE [dbo].[rl_CustomerUpdates]
GO
DROP TABLE [dbo].[rl_CookieUpdates]
GO
DROP TABLE [dbo].[rl_GirlRelation]
GO
DROP TABLE [dbo].[Sales]
GO
DROP TABLE [dbo].[lu_Sale_Type]
GO
DROP TABLE [dbo].[Booth_Sales_Details]
GO
DROP TABLE [dbo].[Booths]
GO
DROP TABLE [dbo].[Customers]
GO
DROP TABLE [dbo].[Cookies]
GO
DROP TABLE [dbo].[Girls]
GO
DROP TABLE [dbo].[Troop_Roster]
GO
DROP TABLE [dbo].[Troops]
GO
DROP TABLE [dbo].[lu_Member_Type]
GO
DROP TABLE [dbo].[Users]
GO

-- Table Create
USE [GSCookies]
GO

-- * Users
/****** Object:  Table [dbo].[Users]    Script Date: 12/26/2017 5:00:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Hint] [nvarchar](50) NOT NULL,
	[Relation] [nvarchar](12) NOT NULL,
	[Phone] [nvarchar](14) NOT NULL,
	[EMail] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[UserLevel] [nvarchar](5) NOT NULL,
	[RecAddedBy] [nvarchar](20) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [users_PK] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * Troops
/****** Object:  Table [dbo].[Troops]    Script Date: 12/26/2017 5:00:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Troops](
	[Troop_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Nbr] [int] NOT NULL,
	[Community] [nvarchar](50) NOT NULL,
	[Region_Nbr] [int] NOT NULL,
	[Council] [nvarchar](50) NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [PK_Troop] PRIMARY KEY CLUSTERED 
(
	[Troop_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * lu_Member_Type
/****** Object:  Table [dbo].[lu_Member_Type]    Script Date: 12/31/2017 6:06:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_Member_Type](
	[Member_Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[Member_Type] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_lu_Member_Type] PRIMARY KEY CLUSTERED 
(
	[Member_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * Troop_Roster
/****** Object:  Table [dbo].[Troop_Roster]    Script Date: 12/31/2017 6:07:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Troop_Roster](
	[Roster_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[Member_Type_Id] [int] NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](14) NOT NULL,
	[EMail] [nvarchar](100) NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [roster_PK] PRIMARY KEY CLUSTERED 
(
	[Roster_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Troop_Roster]  WITH CHECK ADD  CONSTRAINT [roster_member_FK] FOREIGN KEY([Member_Type_Id])
REFERENCES [dbo].[lu_Member_Type] ([Member_Type_Id])
GO

ALTER TABLE [dbo].[Troop_Roster] CHECK CONSTRAINT [roster_member_FK]
GO

ALTER TABLE [dbo].[Troop_Roster]  WITH CHECK ADD  CONSTRAINT [roster_troop_FK] FOREIGN KEY([Troop_Id])
REFERENCES [dbo].[Troops] ([Troop_Id])
GO

ALTER TABLE [dbo].[Troop_Roster] CHECK CONSTRAINT [roster_troop_FK]
GO

-- * Girls
/****** Object:  Table [dbo].[Girls]    Script Date: 12/26/2017 4:52:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Girls](
	[Girl_Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Level_Id] [int] NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[DOB] [datetime] NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [girl_PK] PRIMARY KEY CLUSTERED 
(
	[Girl_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * Cookies
/****** Object:  Table [dbo].[Cookies]    Script Date: 12/26/2017 4:52:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cookies](
	[Cookie_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cookie_Name] [varchar](50) NOT NULL,
	[Cookie_Description] [nvarchar](500) NOT NULL,
	[Cookie_Price] [float] NOT NULL,
	[CountPerContainer] [int] NULL,
	[NetWeightPerContainer] [float] NULL,
	[ServingSize] [int] NULL,
	[CaloriesPerServing] [int] NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [cookie_PK] PRIMARY KEY CLUSTERED 
(
	[Cookie_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-- * Customers
/****** Object:  Table [dbo].[Customers]    Script Date: 12/26/2017 4:52:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](2) NULL,
	[ZIP] [int] NULL,
	[HomePhone] [nvarchar](14) NULL,
	[CellPhone] [nvarchar](14) NULL,
	[WorkPhone] [nvarchar](14) NULL,
	[EMail] [nvarchar](100) NULL,
	[Notes] [nvarchar](1000) NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [customer_PK] PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * Booths
/****** Object:  Table [dbo].[Booths]    Script Date: 1/3/2018 10:23:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booths](
	[Booth_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[Booth_Date] [date] NOT NULL,
	[Booth_Time] [time](0) NOT NULL,
	[Booth_Location] [nvarchar](100) NOT NULL,
	[Booth_Parent_Primary] [int] NOT NULL,
	[Booth_Parent_Secondary] [int] NOT NULL,
	[Booth_Parent_Additional] [int] NULL,
	[Booth_Girl_First] [int] NOT NULL,
	[Booth_Girl_Second] [int] NOT NULL,
	[Booth_Girl_Third] [int] NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [booth_PK] PRIMARY KEY CLUSTERED 
(
	[Booth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Booths]  WITH CHECK ADD  CONSTRAINT [booth_troop_FK] FOREIGN KEY([Troop_Id])
REFERENCES [dbo].[Troops] ([Troop_Id])
GO

ALTER TABLE [dbo].[Booths] CHECK CONSTRAINT [booth_troop_FK]
GO

-- * Booth_Sales_Details
/****** Object:  Table [dbo].[Booth_Sales_Details]    Script Date: 1/22/2018 7:53:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booth_Sales_Details](
	[Booth_Sales_Details_Id] [int] IDENTITY(1,1) NOT NULL,
	[Booth_Id] [int] NULL,
	[Girl_First_Id] [int] NOT NULL,
	[Girl_First_Split] [int] NOT NULL,
	[Girl_Second_Id] [int] NOT NULL,
	[Girl_Second_Split] [int] NOT NULL,
	[Girl_Third_Id] [int] NULL,
	[Girl_Third_Split] [int] NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [booth_sales_PK] PRIMARY KEY CLUSTERED 
(
	[Booth_Sales_Details_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Booth_Sales_Details]  WITH CHECK ADD  CONSTRAINT [first_girl_FK] FOREIGN KEY([Girl_First_Id])
REFERENCES [dbo].[Girls] ([Girl_Id])
GO

ALTER TABLE [dbo].[Booth_Sales_Details] CHECK CONSTRAINT [first_girl_FK]
GO

ALTER TABLE [dbo].[Booth_Sales_Details]  WITH CHECK ADD  CONSTRAINT [sales_details_booth_FK] FOREIGN KEY([Booth_Id])
REFERENCES [dbo].[Booths] ([Booth_Id])
GO

ALTER TABLE [dbo].[Booth_Sales_Details] CHECK CONSTRAINT [sales_details_booth_FK]
GO

ALTER TABLE [dbo].[Booth_Sales_Details]  WITH CHECK ADD  CONSTRAINT [second_girl_FK] FOREIGN KEY([Girl_Second_Id])
REFERENCES [dbo].[Girls] ([Girl_Id])
GO

ALTER TABLE [dbo].[Booth_Sales_Details] CHECK CONSTRAINT [second_girl_FK]
GO

ALTER TABLE [dbo].[Booth_Sales_Details]  WITH CHECK ADD  CONSTRAINT [third_girl_FK] FOREIGN KEY([Girl_Third_Id])
REFERENCES [dbo].[Girls] ([Girl_Id])
GO

ALTER TABLE [dbo].[Booth_Sales_Details] CHECK CONSTRAINT [third_girl_FK]
GO

-- * lu_Sale_Type
/****** Object:  Table [dbo].[lu_Sale_Type]    Script Date: 1/6/2018 1:16:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[lu_Sale_Type](
	[Sale_Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Type] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_lu_Sale_Type] PRIMARY KEY CLUSTERED 
(
	[Sale_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * Sales
/****** Object:  Table [dbo].[Sales]    Script Date: 1/6/2018 1:17:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sales](
	[Sales_Id] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Type_Id] [int] NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[Booth_Id] [int] NULL,
	[Girl_Id] [int] NULL,
	[Customer_Id] [int] NULL,
	[First_Cookie_Id] [int] NULL,
	[First_Cookie_Qty] [int] NULL,
	[Second_Cookie_Id] [int] NULL,
	[Second_Cookie_Qty] [int] NULL,
	[Third_Cookie_Id] [int] NULL,
	[Third_Cookie_Qty] [int] NULL,
	[Fourth_Cookie_Id] [int] NULL,
	[Fourth_Cookie_Qty] [int] NULL,
	[Fifth_Cookie_Id] [int] NULL,
	[Fifth_Cookie_Qty] [int] NULL,
	[Sixth_Cookie_Id] [int] NULL,
	[Sixth_Cookie_Qty] [int] NULL,
	[Seventh_Cookie_Id] [int] NULL,
	[Seventh_Cookie_Qty] [int] NULL,
	[Eighth_Cookie_Id] [int] NULL,
	[Eighth_Cookie_Qty] [int] NULL,
	[Ninth_Cookie_Id] [int] NULL,
	[Ninth_Cookie_Qty] [int] NULL,
	[Paid] [bit] NOT NULL,
	[Cash] [float] NULL,
	[Check] [float] NULL,
	[CC] [float] NULL,
	[Donation] [float] NULL,
	[TotalSale] [float] NULL,
	[RecAddedBy] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ArchiveDate] [datetime] NULL,
 CONSTRAINT [sales_PK] PRIMARY KEY CLUSTERED 
(
	[Sales_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_troop_FK] FOREIGN KEY([Troop_Id])
REFERENCES [dbo].[Troops] ([Troop_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_troop_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sale_type_FK] FOREIGN KEY([Sale_Type_Id])
REFERENCES [dbo].[lu_Sale_Type] ([Sale_Type_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sale_type_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sale_booth_FK] FOREIGN KEY([Booth_Id])
REFERENCES [dbo].[Booths] ([Booth_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sale_booth_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sale_girl_FK] FOREIGN KEY([Girl_Id])
REFERENCES [dbo].[Girls] ([Girl_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sale_girl_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_customer_FK] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customers] ([Customer_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_customer_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie1_FK] FOREIGN KEY([First_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie1_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie2_FK] FOREIGN KEY([Second_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie2_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie3_FK] FOREIGN KEY([Third_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie3_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie4_FK] FOREIGN KEY([Fourth_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie4_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie5_FK] FOREIGN KEY([Fifth_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie5_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie6_FK] FOREIGN KEY([Sixth_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie6_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie7_FK] FOREIGN KEY([Seventh_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie7_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie8_FK] FOREIGN KEY([Eighth_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie8_FK]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [sales_cookie9_FK] FOREIGN KEY([Ninth_Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [sales_cookie9_FK]
GO

-- * rl_GirlRelation
/****** Object:  Table [dbo].[rl_GirlRelation]    Script Date: 12/26/2017 4:58:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_GirlRelation](
	[Girl_Id] [int] NOT NULL,
	[User_Id] [int] NOT NULL,
 CONSTRAINT [girl_Grel_FK] FOREIGN KEY ([Girl_Id]) REFERENCES [dbo].[Girls],
 CONSTRAINT [user_Grel_FK] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users]
) ON [PRIMARY]

GO

-- * rl_CookieUpdates
/****** Object:  Table [dbo].[rl_CookieUpdates]    Script Date: 12/30/2017 1:54:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_CookieUpdates](
	[Cookie_Id] [int] NOT NULL,
	[RecordUpdatedBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateValues] [nvarchar](1000) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[rl_CookieUpdates]  WITH CHECK ADD  CONSTRAINT [cookie_update_FK] FOREIGN KEY([Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[rl_CookieUpdates] CHECK CONSTRAINT [cookie_update_FK]
GO

-- * rl_CustomerUpdates
/****** Object:  Table [dbo].[rl_CustomerUpdates]    Script Date: 12/30/2017 1:55:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_CustomerUpdates](
	[Customer_Id] [int] NOT NULL,
	[RecordUpdatedBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateValues] [nvarchar](1000) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[rl_CustomerUpdates]  WITH CHECK ADD  CONSTRAINT [cust_update_FK] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customers] ([Customer_Id])
GO

ALTER TABLE [dbo].[rl_CustomerUpdates] CHECK CONSTRAINT [cust_update_FK]
GO

-- * Orders
/****** Object:  Table [dbo].[Orders]    Script Date: 12/26/2017 7:12:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Order_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[Order_Type] [int] NOT NULL,
	[Order_Date] [datetime] NOT NULL,
	[RecAddedBy] [int] NOT NULL,
 CONSTRAINT [troop_order_FK] FOREIGN KEY ([Troop_Id]) REFERENCES [dbo].[Troops],
 CONSTRAINT [order_PK] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * Order_Details
/****** Object:  Table [dbo].[Order_Details]    Script Date: 12/26/2017 7:14:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_Details](
	[Order_Detail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[Order_Qty] [int] NOT NULL,
 CONSTRAINT [order_OD_FK] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders],
 CONSTRAINT [cookie_OD_FK] FOREIGN KEY ([Cookie_Id]) REFERENCES [dbo].[Cookies],
 CONSTRAINT [order_detail_PK] PRIMARY KEY CLUSTERED 
(
	[Order_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- * Inventory
/****** Object:  Table [dbo].[Inventory]    Script Date: 12/26/2017 7:12:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventory](
	[Inventory_Id] [int] IDENTITY(1,1) NOT NULL,
	[Troop_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [cookie_inv_FK] FOREIGN KEY ([Cookie_Id]) REFERENCES [dbo].[Cookies],
 CONSTRAINT [inventory_PK] PRIMARY KEY CLUSTERED 
(
	[Inventory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [inv_troop_FK] FOREIGN KEY([Troop_Id])
REFERENCES [dbo].[Troops] ([Troop_Id])
GO

ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [inv_troop_FK]
GO

-- * Sub_Inventory
/****** Object:  Table [dbo].[Sub_Inventory]    Script Date: 1/22/2018 5:31:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sub_Inventory](
	[Sub_Inventory_Id] [int] IDENTITY(1,1) NOT NULL,
	[Booth_Id] [int] NULL,
	[Girl_Id] [int] NULL,
	[Cookie_Id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [sub_inventory_PK] PRIMARY KEY CLUSTERED 
(
	[Sub_Inventory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sub_Inventory]  WITH CHECK ADD  CONSTRAINT [sub_Binv_FK] FOREIGN KEY([Booth_Id])
REFERENCES [dbo].[Booths] ([Booth_Id])
GO

ALTER TABLE [dbo].[Sub_Inventory] CHECK CONSTRAINT [sub_Binv_FK]
GO

ALTER TABLE [dbo].[Sub_Inventory]  WITH CHECK ADD  CONSTRAINT [sub_cookie_Binv_FK] FOREIGN KEY([Cookie_Id])
REFERENCES [dbo].[Cookies] ([Cookie_Id])
GO

ALTER TABLE [dbo].[Sub_Inventory] CHECK CONSTRAINT [sub_cookie_Binv_FK]
GO

ALTER TABLE [dbo].[Sub_Inventory]  WITH CHECK ADD  CONSTRAINT [sub_Ginv_FK] FOREIGN KEY([Girl_Id])
REFERENCES [dbo].[Girls] ([Girl_Id])
GO

ALTER TABLE [dbo].[Sub_Inventory] CHECK CONSTRAINT [sub_Ginv_FK]
GO

-- * rl_CookieTransfer
/****** Object:  Table [dbo].[rl_CookieTransfer]    Script Date: 12/27/2017 8:14:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rl_CookieTransfer](
	[OrderType_Id] [int] NOT NULL,
	[Cookie_Id] [int] NOT NULL,
	[From] [int] NOT NULL,
	[To] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[TransferDate] [datetime] NOT NULL,
	[RecAddedBy] [int] NOT NULL,
	CONSTRAINT [transfer_FK] FOREIGN KEY ([OrderType_Id]) REFERENCES [dbo].[lu_OrderType],
	CONSTRAINT [cookie_trans_FK] FOREIGN KEY ([Cookie_Id]) REFERENCES [dbo].[Cookies]
) ON [PRIMARY]

GO
























































