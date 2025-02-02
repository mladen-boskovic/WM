USE [master]
GO
/****** Object:  Database [WMDB]    Script Date: 13-Mar-20 23:22:19 ******/
CREATE DATABASE [WMDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WMDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WMDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WMDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WMDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WMDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WMDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WMDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WMDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WMDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WMDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WMDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WMDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WMDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WMDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WMDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WMDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WMDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WMDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WMDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WMDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WMDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WMDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WMDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WMDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WMDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WMDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WMDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WMDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WMDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WMDB] SET  MULTI_USER 
GO
ALTER DATABASE [WMDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WMDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WMDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WMDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WMDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WMDB] SET QUERY_STORE = OFF
GO
USE [WMDB]
GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 13-Mar-20 23:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[CATEGORY_ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CATEGORY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MANUFACTURER]    Script Date: 13-Mar-20 23:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MANUFACTURER](
	[MANUFACTURER_ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MANUFACTURER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 13-Mar-20 23:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[PRODUCT_ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[DESCRIPTION] [nvarchar](250) NOT NULL,
	[PRICE] [decimal](10, 2) NOT NULL,
	[CATEGORY_ID] [int] NOT NULL,
	[MANUFACTURER_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PRODUCT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_SUPPLIER]    Script Date: 13-Mar-20 23:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_SUPPLIER](
	[PRODUCT_SUPPLIER_ID] [int] IDENTITY(1,1) NOT NULL,
	[PRODUCT_ID] [int] NOT NULL,
	[SUPPLIER_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PRODUCT_SUPPLIER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUPPLIER]    Script Date: 13-Mar-20 23:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUPPLIER](
	[SUPPLIER_ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SUPPLIER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CATEGORY] ON 

INSERT [dbo].[CATEGORY] ([CATEGORY_ID], [NAME]) VALUES (4, N'Category 1')
INSERT [dbo].[CATEGORY] ([CATEGORY_ID], [NAME]) VALUES (5, N'Category 2')
INSERT [dbo].[CATEGORY] ([CATEGORY_ID], [NAME]) VALUES (6, N'Category 3')
SET IDENTITY_INSERT [dbo].[CATEGORY] OFF
SET IDENTITY_INSERT [dbo].[MANUFACTURER] ON 

INSERT [dbo].[MANUFACTURER] ([MANUFACTURER_ID], [NAME]) VALUES (4, N'Manufacturer 1')
INSERT [dbo].[MANUFACTURER] ([MANUFACTURER_ID], [NAME]) VALUES (5, N'Manufacturer 2')
INSERT [dbo].[MANUFACTURER] ([MANUFACTURER_ID], [NAME]) VALUES (6, N'Manufacturer 3')
SET IDENTITY_INSERT [dbo].[MANUFACTURER] OFF
SET IDENTITY_INSERT [dbo].[PRODUCT] ON 

INSERT [dbo].[PRODUCT] ([PRODUCT_ID], [NAME], [DESCRIPTION], [PRICE], [CATEGORY_ID], [MANUFACTURER_ID]) VALUES (8, N'First product', N'a a a a a a', CAST(85.44 AS Decimal(10, 2)), 5, 4)
INSERT [dbo].[PRODUCT] ([PRODUCT_ID], [NAME], [DESCRIPTION], [PRICE], [CATEGORY_ID], [MANUFACTURER_ID]) VALUES (9, N'Second product', N'bbbbbbbbbbb', CAST(11.99 AS Decimal(10, 2)), 6, 6)
INSERT [dbo].[PRODUCT] ([PRODUCT_ID], [NAME], [DESCRIPTION], [PRICE], [CATEGORY_ID], [MANUFACTURER_ID]) VALUES (10, N'Third product', N'cccccccccccccc', CAST(55.55 AS Decimal(10, 2)), 4, 4)
SET IDENTITY_INSERT [dbo].[PRODUCT] OFF
SET IDENTITY_INSERT [dbo].[PRODUCT_SUPPLIER] ON 

INSERT [dbo].[PRODUCT_SUPPLIER] ([PRODUCT_SUPPLIER_ID], [PRODUCT_ID], [SUPPLIER_ID]) VALUES (23, 8, 4)
INSERT [dbo].[PRODUCT_SUPPLIER] ([PRODUCT_SUPPLIER_ID], [PRODUCT_ID], [SUPPLIER_ID]) VALUES (24, 8, 6)
INSERT [dbo].[PRODUCT_SUPPLIER] ([PRODUCT_SUPPLIER_ID], [PRODUCT_ID], [SUPPLIER_ID]) VALUES (28, 9, 4)
INSERT [dbo].[PRODUCT_SUPPLIER] ([PRODUCT_SUPPLIER_ID], [PRODUCT_ID], [SUPPLIER_ID]) VALUES (29, 9, 5)
INSERT [dbo].[PRODUCT_SUPPLIER] ([PRODUCT_SUPPLIER_ID], [PRODUCT_ID], [SUPPLIER_ID]) VALUES (30, 9, 6)
INSERT [dbo].[PRODUCT_SUPPLIER] ([PRODUCT_SUPPLIER_ID], [PRODUCT_ID], [SUPPLIER_ID]) VALUES (31, 10, 5)
SET IDENTITY_INSERT [dbo].[PRODUCT_SUPPLIER] OFF
SET IDENTITY_INSERT [dbo].[SUPPLIER] ON 

INSERT [dbo].[SUPPLIER] ([SUPPLIER_ID], [NAME]) VALUES (4, N'Supplier 1')
INSERT [dbo].[SUPPLIER] ([SUPPLIER_ID], [NAME]) VALUES (5, N'Supplier 2')
INSERT [dbo].[SUPPLIER] ([SUPPLIER_ID], [NAME]) VALUES (6, N'Supplier 3')
SET IDENTITY_INSERT [dbo].[SUPPLIER] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__CATEGORY__D9C1FA00FC443732]    Script Date: 13-Mar-20 23:22:20 ******/
ALTER TABLE [dbo].[CATEGORY] ADD UNIQUE NONCLUSTERED 
(
	[NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__MANUFACT__D9C1FA0091804C16]    Script Date: 13-Mar-20 23:22:20 ******/
ALTER TABLE [dbo].[MANUFACTURER] ADD UNIQUE NONCLUSTERED 
(
	[NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PRODUCT__D9C1FA005B08006E]    Script Date: 13-Mar-20 23:22:20 ******/
ALTER TABLE [dbo].[PRODUCT] ADD UNIQUE NONCLUSTERED 
(
	[NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UNIQUE_PRODUCT_SUPPLIER]    Script Date: 13-Mar-20 23:22:20 ******/
ALTER TABLE [dbo].[PRODUCT_SUPPLIER] ADD  CONSTRAINT [UNIQUE_PRODUCT_SUPPLIER] UNIQUE NONCLUSTERED 
(
	[PRODUCT_ID] ASC,
	[SUPPLIER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__SUPPLIER__D9C1FA0063763862]    Script Date: 13-Mar-20 23:22:20 ******/
ALTER TABLE [dbo].[SUPPLIER] ADD UNIQUE NONCLUSTERED 
(
	[NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD FOREIGN KEY([CATEGORY_ID])
REFERENCES [dbo].[CATEGORY] ([CATEGORY_ID])
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD FOREIGN KEY([MANUFACTURER_ID])
REFERENCES [dbo].[MANUFACTURER] ([MANUFACTURER_ID])
GO
ALTER TABLE [dbo].[PRODUCT_SUPPLIER]  WITH CHECK ADD FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[PRODUCT] ([PRODUCT_ID])
GO
ALTER TABLE [dbo].[PRODUCT_SUPPLIER]  WITH CHECK ADD FOREIGN KEY([SUPPLIER_ID])
REFERENCES [dbo].[SUPPLIER] ([SUPPLIER_ID])
GO
USE [master]
GO
ALTER DATABASE [WMDB] SET  READ_WRITE 
GO
