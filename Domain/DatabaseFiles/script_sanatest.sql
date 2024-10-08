USE [sanawebshopdb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[OrderDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](max) NULL,
	[ProductName] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/09/2024 10:33:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[Role] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240912181108_initial', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240917231901_AddCustomerRelation', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'Electronics')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'Fashion')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (3, N'Home & Garden')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (4, N'Health & Beauty')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (5, N'Sports & Outdoors')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (6, N'Toys & Games')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (7, N'Automotive')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (8, N'Books')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (9, N'Music & Movies')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (10, N'Groceries')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (11, N'Pet Supplies')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (12, N'Office Supplies')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (13, N'Baby Products')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (14, N'Jewelry & Watches')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (15, N'Footwear')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [Name], [Email], [Address], [UserId]) VALUES (1, N'demo customer', N'democustomer@demo.com', N'12 st av 123', 2)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (1, 1, 1, 1, CAST(799.99 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (2, 1, 2, 1, CAST(1299.50 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (3, 2, 1, 2, CAST(799.99 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (4, 2, 2, 1, CAST(1299.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CustomerId], [Description], [OrderDate]) VALUES (1, 1, N'some description', CAST(N'2024-09-19T03:09:09.2470000' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [Description], [OrderDate]) VALUES (2, 1, N'some description', CAST(N'2024-09-19T03:17:24.8760000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (1, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (2, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (3, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (4, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (5, 1)
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (1, N'ELEC001', N'Smartphone XYZ', CAST(799.99 AS Decimal(18, 2)), 50, N'https://example.com/images/smartphone.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (2, N'ELEC002', N'4K TV ABC', CAST(1299.50 AS Decimal(18, 2)), 30, N'https://example.com/images/tv.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (3, N'ELEC003', N'Wireless Headphones', CAST(199.99 AS Decimal(18, 2)), 100, N'https://example.com/images/headphones.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (4, N'ELEC004', N'Laptop Pro 15"', CAST(1599.00 AS Decimal(18, 2)), 25, N'https://example.com/images/laptop.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (5, N'ELEC005', N'Bluetooth Speaker', CAST(49.99 AS Decimal(18, 2)), 150, N'https://example.com/images/speaker.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (6, N'FASH001', N'Mens Leather Jacket', CAST(89.99 AS Decimal(18, 2)), 60, N'https://example.com/images/leather_jacket.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (7, N'FASH002', N'Womens Summer Dress', CAST(39.99 AS Decimal(18, 2)), 80, N'https://example.com/images/summer_dress.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (8, N'FASH003', N'Designer Sunglasses', CAST(149.99 AS Decimal(18, 2)), 40, N'https://example.com/images/sunglasses.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (9, N'FASH004', N'Sports Shoes', CAST(59.99 AS Decimal(18, 2)), 70, N'https://example.com/images/sport_shoes.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (10, N'FASH005', N'Handbag Classic', CAST(120.00 AS Decimal(18, 2)), 25, N'https://example.com/images/handbag.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (11, N'HOME001', N'Garden Chair Set', CAST(299.99 AS Decimal(18, 2)), 15, N'https://example.com/images/garden_chairs.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (12, N'HOME002', N'LED Desk Lamp', CAST(25.99 AS Decimal(18, 2)), 120, N'https://example.com/images/desk_lamp.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (13, N'HOME003', N'Vacuum Cleaner Pro', CAST(149.99 AS Decimal(18, 2)), 40, N'https://example.com/images/vacuum_cleaner.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (14, N'HOME004', N'Wooden Coffee Table', CAST(89.99 AS Decimal(18, 2)), 30, N'https://example.com/images/coffee_table.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (15, N'HOME005', N'Queen Size Mattress', CAST(499.99 AS Decimal(18, 2)), 10, N'https://example.com/images/mattress.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (16, N'HEAL001', N'Anti-aging Cream', CAST(49.99 AS Decimal(18, 2)), 80, N'https://example.com/images/anti_aging_cream.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (17, N'HEAL002', N'Electric Toothbrush', CAST(39.99 AS Decimal(18, 2)), 60, N'https://example.com/images/toothbrush.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (18, N'HEAL003', N'Hair Straightener', CAST(29.99 AS Decimal(18, 2)), 40, N'https://example.com/images/hair_straightener.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (19, N'HEAL004', N'Vitamin C Serum', CAST(19.99 AS Decimal(18, 2)), 100, N'https://example.com/images/vitamin_c_serum.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (20, N'HEAL005', N'Organic Shampoo', CAST(15.99 AS Decimal(18, 2)), 150, N'https://example.com/images/shampoo.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (21, N'SPRT001', N'Mountain Bike X100', CAST(499.99 AS Decimal(18, 2)), 20, N'https://example.com/images/mountain_bike.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (22, N'SPRT002', N'Tennis Racket Pro', CAST(79.99 AS Decimal(18, 2)), 50, N'https://example.com/images/tennis_racket.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (23, N'SPRT003', N'Yoga Mat Deluxe', CAST(29.99 AS Decimal(18, 2)), 100, N'https://example.com/images/yoga_mat.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (24, N'SPRT004', N'Camping Tent 4-Person', CAST(199.99 AS Decimal(18, 2)), 25, N'https://example.com/images/camping_tent.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (25, N'SPRT005', N'Running Shoes', CAST(99.99 AS Decimal(18, 2)), 60, N'https://example.com/images/running_shoes.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (26, N'TOYS001', N'Action Figure Hero', CAST(24.99 AS Decimal(18, 2)), 100, N'https://example.com/images/action_figure.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (27, N'TOYS002', N'Board Game Family Fun', CAST(34.99 AS Decimal(18, 2)), 40, N'https://example.com/images/board_game.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (28, N'TOYS003', N'Dollhouse Set', CAST(59.99 AS Decimal(18, 2)), 20, N'https://example.com/images/dollhouse.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (29, N'TOYS004', N'Remote Control Car', CAST(44.99 AS Decimal(18, 2)), 50, N'https://example.com/images/rc_car.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (30, N'TOYS005', N'Puzzle 1000 Pieces', CAST(19.99 AS Decimal(18, 2)), 120, N'https://example.com/images/puzzle.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (31, N'AUTO001', N'Car Tire All-Season', CAST(89.99 AS Decimal(18, 2)), 200, N'https://example.com/images/car_tire.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (32, N'AUTO002', N'Car Battery 12V', CAST(129.99 AS Decimal(18, 2)), 50, N'https://example.com/images/car_battery.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (33, N'AUTO003', N'Windshield Wiper Blades', CAST(19.99 AS Decimal(18, 2)), 150, N'https://example.com/images/wipers.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (34, N'AUTO004', N'LED Headlights', CAST(49.99 AS Decimal(18, 2)), 60, N'https://example.com/images/headlights.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (35, N'AUTO005', N'Car Air Freshener', CAST(5.99 AS Decimal(18, 2)), 300, N'https://example.com/images/air_freshener.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (36, N'BOOK001', N'Bestselling Novel XYZ', CAST(14.99 AS Decimal(18, 2)), 100, N'https://example.com/images/novel.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (37, N'BOOK002', N'Classic Rock Vinyl', CAST(29.99 AS Decimal(18, 2)), 30, N'https://example.com/images/vinyl.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (38, N'BOOK003', N'Blockbuster Movie DVD', CAST(9.99 AS Decimal(18, 2)), 80, N'https://example.com/images/dvd.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (39, N'BOOK004', N'Pop Music CD', CAST(12.99 AS Decimal(18, 2)), 50, N'https://example.com/images/cd.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (40, N'BOOK005', N'Cookbook Masterchef', CAST(24.99 AS Decimal(18, 2)), 60, N'https://example.com/images/cookbook.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (41, N'GROC001', N'Organic Almonds', CAST(15.99 AS Decimal(18, 2)), 120, N'https://example.com/images/almonds.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (42, N'GROC002', N'Pasta Italian', CAST(3.99 AS Decimal(18, 2)), 200, N'https://example.com/images/pasta.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (43, N'GROC003', N'Olive Oil Extra Virgin', CAST(12.99 AS Decimal(18, 2)), 150, N'https://example.com/images/olive_oil.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (44, N'GROC004', N'Coffee Beans Premium', CAST(19.99 AS Decimal(18, 2)), 80, N'https://example.com/images/coffee.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [ProductCode], [ProductName], [Price], [Stock], [ImageUrl], [Description]) VALUES (45, N'GROC005', N'Green Tea 100 Bags', CAST(7.99 AS Decimal(18, 2)), 100, N'https://example.com/images/tea.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [PasswordSalt], [Role]) VALUES (1, N'Harold', 0x1D09487278ECCC25B3E505D663B19C8F4E591A3D27FD25E67FFC605B5B118799E230F963D52694F09095A4520C567E92ED96C7C514FD7C82A6B107B91962A09A, 0xDB46D9B229B523C43D825A854E12E9CE72A9FB14D14A3A540A1DF15A276B94D1481621010195D605DFA96C2377631DCE97AAEF74F35421A553F032756DB908240A45C45304AB8231F97EC1F54C1C40F9A25E2B300A20E92D20808B33755795E45370A5D1DC04A2CA0B49D6A33BF0554FF72B8814892BDC0ED7FBE8F786E1BFB3, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [PasswordSalt], [Role]) VALUES (2, N'userdemo', 0xC630860A8363429E4AD4D86729633416878574B9819D8151B3A808F4B1F9C8378273FF04002D27F96625BBC6DD0B648B7D47F4EF3EF25FBB277CEAA02A840F00, 0x34A6DEB50A61D03365736E8066F83F135EE45B7D3F6BA7F20E84ED7F973056005D5066767673E8DB0C560425790B1DB39321B4DC1DE663CD68A41B656C1FB9FE35BD266136344F1FB34BF2B8B8B499A5172CE846403EA02C9FA254852711888F62C5EE78397810EEF81CB422BE081C23D6F94416DCE4F6B7A7A2E356BA19D472, N'Customer')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Customers_UserId]    Script Date: 18/09/2024 10:33:40 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Customers_UserId] ON [dbo].[Customers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 18/09/2024 10:33:40 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 18/09/2024 10:33:40 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_CustomerId]    Script Date: 18/09/2024 10:33:40 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CustomerId] ON [dbo].[Orders]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCategories_CategoryId]    Script Date: 18/09/2024 10:33:40 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategories_CategoryId] ON [dbo].[ProductCategories]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users_UserId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Products_ProductId]
GO
