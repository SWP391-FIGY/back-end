USE [master]
GO
/****** Object:  Database [BirdFarmDB]    Script Date: 11/5/2023 1:53:35 AM ******/
CREATE DATABASE [BirdFarmDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BirdFarmDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BirdFarmDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BirdFarmDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BirdFarmDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BirdFarmDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BirdFarmDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BirdFarmDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BirdFarmDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BirdFarmDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BirdFarmDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BirdFarmDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BirdFarmDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BirdFarmDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BirdFarmDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BirdFarmDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BirdFarmDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BirdFarmDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BirdFarmDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BirdFarmDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BirdFarmDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BirdFarmDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BirdFarmDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BirdFarmDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BirdFarmDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BirdFarmDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BirdFarmDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BirdFarmDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BirdFarmDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BirdFarmDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BirdFarmDB] SET  MULTI_USER 
GO
ALTER DATABASE [BirdFarmDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BirdFarmDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BirdFarmDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BirdFarmDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BirdFarmDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BirdFarmDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BirdFarmDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [BirdFarmDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BirdFarmDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/5/2023 1:53:35 AM ******/
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
/****** Object:  Table [dbo].[Bird]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bird](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SpeciesId] [int] NOT NULL,
	[CageID] [int] NOT NULL,
	[DoB] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[BirdStatus] [int] NOT NULL,
	[BirdImageUrl] [nvarchar](max) NOT NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Bird] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cage]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Size] [nvarchar](max) NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[Area] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[CageStatus] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_Cage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedingPlan]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedingPlan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MealMenuID] [int] NOT NULL,
	[BirdID] [int] NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[FeedingStatus] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FeedingPlan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NutritionalIngredients] [nvarchar](max) NOT NULL,
	[StorageCondition] [nvarchar](max) NULL,
	[Unit] [nvarchar](max) NOT NULL,
	[StandardPrice] [float] NOT NULL,
	[SafetyThreshold] [int] NOT NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryLog]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FoodId] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Quantity] [float] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_InventoryLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BirdID] [int] NULL,
	[CageID] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealMenu]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](max) NOT NULL,
	[SpeciesID] [int] NOT NULL,
	[DaysBeforeFeeding] [int] NULL,
	[Size] [nvarchar](max) NOT NULL,
	[BirdStatus] [int] NOT NULL,
	[MenuStatus] [int] NOT NULL,
	[NutritionalIngredients] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MealMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuDetail]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MealMenuID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [PK_MenuDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatorID] [int] NOT NULL,
	[PurchaseRequestID] [int] NULL,
	[SupplierID] [int] NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrderDetail]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[NetPrice] [int] NOT NULL,
	[DeliverDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PurchaseOrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseRequest]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseRequest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatorID] [int] NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_PurchaseRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseRequestDetail]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseRequestDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseRequestID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_PurchaseRequestDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Species]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Species](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[Size] [nvarchar](max) NOT NULL,
	[Voice] [nvarchar](max) NULL,
	[ImageLink] [nvarchar](max) NULL,
	[LifeExpectancy] [int] NOT NULL,
	[Habitat] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Species] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BirdID] [int] NULL,
	[CageID] [int] NULL,
	[StaffID] [int] NULL,
	[TaskName] [nvarchar](max) NOT NULL,
	[DateTime] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/5/2023 1:53:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[FirebaseID] [nvarchar](max) NULL,
	[Role] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231104181817_FixMenuForeignKey', N'7.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231104184341_FixMenuDetailQuantity', N'7.0.13')
GO
SET IDENTITY_INSERT [dbo].[Bird] ON 

INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (1, 1, 1, N'11/2/2022', N'Trống', N'có mào đỏ pha trắng. ', 2, N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Red-whiskered_bulbul_by_Creepanta_11.jpg/420px-Red-whiskered_bulbul_by_Creepanta_11.jpg', CAST(N'2023-11-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (2, 1, 1, N'11/3/2022', N'Mái', N'', 2, N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Red-whiskered_bulbul_by_Creepanta_11.jpg/420px-Red-whiskered_bulbul_by_Creepanta_11.jpg', CAST(N'2023-11-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (3, 2, 2, N'11/4/2022', N'Trống', N'Sức khỏe yếu. Cần chăm sóc kỹ hơn', 5, N'https://cdn.eva.vn/upload/3-2021/images/2021-09-30/image3-1632998835-30-width650height460.jpg', CAST(N'2023-11-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (4, 2, 3, N'11/5/2022', N'Mái', N'Bị nhiễm lạnh. 41 ngày tuổi', 4, N'https://cdn.eva.vn/upload/3-2021/images/2021-09-30/image3-1632998835-30-width650height460.jpg', CAST(N'2023-11-06T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (5, 3, 2, N'11/6/2022', N'Trống', N'', 1, N'https://lh3.googleusercontent.com/x2qa9iwXtlPBwn3_s0Of700Z45jLsv3y_qHdrfsHTbEJbKGaQFlCIgMp7BsVeHNDY_t1Y3FZyTk44hwXnY9ZTymKEGOe8dMiBsEyM3X_jFZN11XQX2yw4OC_a8ef_8mlPk5jD0Gn', CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (6, 3, 2, N'11/7/2022', N'Mái', N'', 1, N'https://lh3.googleusercontent.com/x2qa9iwXtlPBwn3_s0Of700Z45jLsv3y_qHdrfsHTbEJbKGaQFlCIgMp7BsVeHNDY_t1Y3FZyTk44hwXnY9ZTymKEGOe8dMiBsEyM3X_jFZN11XQX2yw4OC_a8ef_8mlPk5jD0Gn', CAST(N'2023-11-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (7, 4, 9, N'11/8/2022', N'Trống', N'Bị thương ở chân', 3, N'https://cdn.eva.vn/upload/4-2021/images/2021-10-01/image1-1633053449-421-width600height450.jpg', CAST(N'2023-11-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (8, 4, 3, N'11/9/2022', N'Mái', N'', 1, N'https://cdn.eva.vn/upload/4-2021/images/2021-10-01/image1-1633053449-421-width600height450.jpg', CAST(N'2023-11-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (9, 1, 3, N'11/10/2022', N'Trống', N'', 1, N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Red-whiskered_bulbul_by_Creepanta_11.jpg/420px-Red-whiskered_bulbul_by_Creepanta_11.jpg', CAST(N'2023-11-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (10, 1, 3, N'11/11/2022', N'Mái', N'', 1, N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Red-whiskered_bulbul_by_Creepanta_11.jpg/420px-Red-whiskered_bulbul_by_Creepanta_11.jpg', CAST(N'2023-11-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (11, 2, 3, N'11/12/2022', N'Trống', N'', 1, N'https://cdn.eva.vn/upload/3-2021/images/2021-09-30/image3-1632998835-30-width650height460.jpg', CAST(N'2023-11-13T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (12, 2, 3, N'11/13/2022', N'Mái', N'', 1, N'https://cdn.eva.vn/upload/3-2021/images/2021-09-30/image3-1632998835-30-width650height460.jpg', CAST(N'2023-11-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (13, 2, 4, N'11/14/2022', N'Trống', N'Hủy', 6, N'https://cdn.eva.vn/upload/3-2021/images/2021-09-30/image3-1632998835-30-width650height460.jpg', CAST(N'2023-11-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (14, 3, 5, N'11/15/2022', N'Mái', N'', 1, N'https://lh3.googleusercontent.com/x2qa9iwXtlPBwn3_s0Of700Z45jLsv3y_qHdrfsHTbEJbKGaQFlCIgMp7BsVeHNDY_t1Y3FZyTk44hwXnY9ZTymKEGOe8dMiBsEyM3X_jFZN11XQX2yw4OC_a8ef_8mlPk5jD0Gn', CAST(N'2023-11-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (15, 4, 4, N'11/16/2022', N'Trống', N'', 1, N'https://cdn.eva.vn/upload/4-2021/images/2021-10-01/image1-1633053449-421-width600height450.jpg', CAST(N'2023-11-17T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (16, 4, 4, N'11/17/2022', N'Mái', N'', 1, N'https://cdn.eva.vn/upload/4-2021/images/2021-10-01/image1-1633053449-421-width600height450.jpg', CAST(N'2023-11-18T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (17, 2, 4, N'11/18/2022', N'Trống', N'', 1, N'https://cdn.eva.vn/upload/3-2021/images/2021-09-30/image3-1632998835-30-width650height460.jpg', CAST(N'2023-11-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bird] ([ID], [SpeciesId], [CageID], [DoB], [Gender], [Description], [BirdStatus], [BirdImageUrl], [LastModifyDate]) VALUES (18, 1, 4, N'11/19/2022', N'Mái', N'', 1, N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Red-whiskered_bulbul_by_Creepanta_11.jpg/420px-Red-whiskered_bulbul_by_Creepanta_11.jpg', CAST(N'2023-11-20T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Bird] OFF
GO
SET IDENTITY_INSERT [dbo].[Cage] ON 

INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (1, N'50x30x40', N'Wood', N'C', N'Small', 1, 2)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (2, N'50x30x50', N'Wood', N'B', N'Small', 1, 2)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (3, N'200X 100X200', N'Blue', N'A', N'Large - fixed barn ', 1, 20)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (4, N'200X 100X200', N'Blue', N'A', N'Large - fixed barn ', 1, 20)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (5, N'R22X 50', N'Green', N'B', N'Small - Round', 1, 2)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (6, N'R22X 50', N'Green', N'B', N'Small - Round', 2, 2)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (7, N'100x50x60', N'Wood', N'B', N'Medium ', 3, 5)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (8, N'R22X 50', N'Yellow', N'B', N'Small - Round', 4, 2)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (9, N'R11X 38', N'wood', N'D', N'Small - Round', 1, 1)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (10, N'R11X 38', N'wood', N'D', N'Small - Round', 1, 1)
INSERT [dbo].[Cage] ([ID], [Size], [Color], [Area], [Type], [CageStatus], [Capacity]) VALUES (11, N'200X 100X200', N'Blue', N'A', N'Large - fixed barn ', 1, 20)
SET IDENTITY_INSERT [dbo].[Cage] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedingPlan] ON 

INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (1, 1, 1, CAST(N'2023-11-01T11:00:00.0000000' AS DateTime2), N'Fed', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (2, 2, 2, CAST(N'2023-11-01T11:00:00.0000000' AS DateTime2), N'Fed', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (3, 3, 3, CAST(N'2023-11-01T11:00:00.0000000' AS DateTime2), N'Other', N'Đã bán')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (4, 3, 4, CAST(N'2023-11-01T11:00:00.0000000' AS DateTime2), N'Other', N'Dead')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (5, 3, 11, CAST(N'2023-11-01T11:00:00.0000000' AS DateTime2), N'Fed', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (6, 3, 12, CAST(N'2023-11-01T11:00:00.0000000' AS DateTime2), N'Fed', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (7, 1, 1, CAST(N'2023-11-02T10:00:00.0000000' AS DateTime2), N'Overdue', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (8, 2, 2, CAST(N'2023-11-02T10:00:00.0000000' AS DateTime2), N'Overdue', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (9, 3, 11, CAST(N'2023-11-02T11:00:00.0000000' AS DateTime2), N'Ongoing', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (10, 3, 12, CAST(N'2023-11-02T11:00:00.0000000' AS DateTime2), N'Ongoing', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (11, 1, 1, CAST(N'2023-11-03T11:00:00.0000000' AS DateTime2), N'Upcoming', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (12, 2, 2, CAST(N'2023-11-03T11:00:00.0000000' AS DateTime2), N'Upcoming', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (13, 3, 11, CAST(N'2023-11-03T11:00:00.0000000' AS DateTime2), N'Upcoming', N'')
INSERT [dbo].[FeedingPlan] ([ID], [MealMenuID], [BirdID], [DateTime], [FeedingStatus], [Description]) VALUES (14, 3, 12, CAST(N'2023-11-03T11:00:00.0000000' AS DateTime2), N'Upcoming', N'')
SET IDENTITY_INSERT [dbo].[FeedingPlan] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (1, N'Cám cho chào mào thay lông', N'Protein: 45%', N'Normal', N'kg', 250000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (2, N'Cám cho chào mào lên lửa', N'Protein: 70% ', N'Normal', N'kg', 350000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (3, N'Đậu phộng', N'Chất béo 35%', N'Normal', N'kg', 70000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (4, N'Cam', N'vitamic C 20%', N'Air Conditional', N'kg', 30000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (5, N'Đu đủ', N' beta-carotene cao', N'Air Conditional', N'kg', 25000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (6, N'Mướp khía', N'', N'Normal', N'kg', 15000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (7, N'Cà chua', N'', N'Air Conditional', N'kg', 45000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (8, N'Cà rốt ', N' beta-carotene cao', N'Normal', N'kg', 40000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (9, N'Trái Gất', N' beta-carotene cao', N'Normal', N'kg', 32000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (10, N'Cám chim ', N'', N'Normal', N'kg', 100000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (11, N'Ngũ cốc', N'', N'Normal', N'kg', 50000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (12, N'Cào cào ', N'', N'Normal - in cage', N'each', 120000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (13, N'Châu Chấu', N'', N'Normal - in cage', N'each', 150000, 50)
INSERT [dbo].[Food] ([ID], [Name], [NutritionalIngredients], [StorageCondition], [Unit], [StandardPrice], [SafetyThreshold]) VALUES (14, N'Trứng kiến', N'', N'Normal', N'kg', 120000, 50)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (1, 1, 11, CAST(N'2022-11-02T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (2, 2, 11, CAST(N'2022-11-03T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (3, 3, 11, CAST(N'2022-11-04T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (4, 4, 11, CAST(N'2022-11-05T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (5, 5, 11, CAST(N'2022-11-06T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (6, 6, 11, CAST(N'2022-11-07T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (7, 7, 11, CAST(N'2022-11-08T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (8, 8, 11, CAST(N'2022-11-09T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (9, 9, 11, CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (10, 10, 11, CAST(N'2022-11-11T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (11, 11, 11, CAST(N'2022-11-12T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (12, 12, 11, CAST(N'2022-11-13T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (13, 13, 11, CAST(N'2022-11-14T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (14, 13, 11, CAST(N'2022-11-14T00:00:00.0000000' AS DateTime2), N'Cancel')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (15, 14, 11, CAST(N'2022-11-15T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (16, 15, 11, CAST(N'2022-11-16T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (17, 16, 11, CAST(N'2022-11-17T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (18, 17, 11, CAST(N'2022-11-18T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (19, 18, 11, CAST(N'2022-11-19T00:00:00.0000000' AS DateTime2), N'')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (20, 1, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (21, 2, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (22, 3, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (23, 4, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (24, 5, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (25, 6, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (26, 7, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (27, 8, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (28, 9, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (29, 10, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (30, 11, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (31, 12, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (32, 14, 3, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (33, 15, 4, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (34, 16, 4, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (35, 17, 4, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (36, 18, 4, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), N'Chuyển lồng')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (37, 1, 1, CAST(N'2023-10-26T00:00:00.0000000' AS DateTime2), N'Chuyển lồng do thay lông')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (38, 2, 1, CAST(N'2023-10-26T00:00:00.0000000' AS DateTime2), N'Chuyển lồng do thay lông')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (39, 7, 9, CAST(N'2023-10-31T00:00:00.0000000' AS DateTime2), N'Chuyển lồng do bị thương')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (40, 5, 2, CAST(N'2023-10-31T00:00:00.0000000' AS DateTime2), N'Chuyển lồng ')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (41, 6, 2, CAST(N'2023-10-31T00:00:00.0000000' AS DateTime2), N'Chuyển lồng ')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (42, 3, 3, CAST(N'2023-11-01T00:00:00.0000000' AS DateTime2), N'Sold')
INSERT [dbo].[Log] ([ID], [BirdID], [CageID], [Date], [Description]) VALUES (43, 4, 3, CAST(N'2023-11-01T00:00:00.0000000' AS DateTime2), N'Dead')
SET IDENTITY_INSERT [dbo].[Log] OFF
GO
SET IDENTITY_INSERT [dbo].[MealMenu] ON 

INSERT [dbo].[MealMenu] ([ID], [MenuName], [SpeciesID], [DaysBeforeFeeding], [Size], [BirdStatus], [MenuStatus], [NutritionalIngredients]) VALUES (1, N'Meal cho chào mào thay lông', 1, 60, N'10 -20cm', 2, 1, N'Protetin: 45% - Vitamin C 20%- Kích thích mọc lông 2%')
INSERT [dbo].[MealMenu] ([ID], [MenuName], [SpeciesID], [DaysBeforeFeeding], [Size], [BirdStatus], [MenuStatus], [NutritionalIngredients]) VALUES (2, N'Meal cho chào mào lên lửa', 1, 60, N'10 -20cm', 2, 1, N'Protetin: 60% - Vitamin C 10%- Kích thích mọc lông 2% -  beta-carotene 10%')
INSERT [dbo].[MealMenu] ([ID], [MenuName], [SpeciesID], [DaysBeforeFeeding], [Size], [BirdStatus], [MenuStatus], [NutritionalIngredients]) VALUES (3, N'Meal cho chim họa mi', 2, 30, N'10cm', 1, 1, N'Protein: 50% - Xơ: 20% - Vitamin A, B, K, B5: 10% - ')
INSERT [dbo].[MealMenu] ([ID], [MenuName], [SpeciesID], [DaysBeforeFeeding], [Size], [BirdStatus], [MenuStatus], [NutritionalIngredients]) VALUES (4, N'Meal cho chim họa mi', 2, 31, N'10cm', 1, 2, N'Protein: 50% - Xơ: 20% - Vitamin A, B, K, B5: 10% - ')
INSERT [dbo].[MealMenu] ([ID], [MenuName], [SpeciesID], [DaysBeforeFeeding], [Size], [BirdStatus], [MenuStatus], [NutritionalIngredients]) VALUES (5, N'Meal cho chim họa mi', 2, 32, N'10cm', 1, 3, N'Protein: 50% - Xơ: 20% - Vitamin A, B, K, B5: 10% - ')
SET IDENTITY_INSERT [dbo].[MealMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuDetail] ON 

INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (1, 1, 1, 0.01)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (2, 1, 3, 0.005)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (3, 1, 4, 0.063)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (4, 1, 6, 0.05)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (5, 2, 2, 0.01)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (6, 2, 5, 0.08)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (7, 2, 3, 0.005)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (8, 2, 9, 0.035)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (9, 3, 10, 0.01)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (10, 3, 11, 0.08)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (11, 3, 13, 1)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (12, 4, 10, 0.01)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (13, 4, 11, 0.08)
INSERT [dbo].[MenuDetail] ([ID], [MealMenuID], [FoodID], [Quantity]) VALUES (14, 4, 12, 1)
SET IDENTITY_INSERT [dbo].[MenuDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Species] ON 

INSERT [dbo].[Species] ([ID], [Name], [Color], [Size], [Voice], [ImageLink], [LifeExpectancy], [Habitat]) VALUES (1, N'Chào mào', N'phần trên màu nâu và phần dưới màu trắng với hai bên sườn bóng và một cái cựa sẫm màu chạy trên bầu ngực ngang vai. Nó có mào đen nhọn cao, mặt đỏ và đường viền đen mỏng. Đuôi dài và có màu nâu với các đầu lông màu trắng, nhưng vùng lỗ thông hơi có màu đỏ. Con non thiếu mảng đỏ phía sau mắt và vùng lỗ thông hơi có màu cam đỏ', N'20 cm ', N'https://youtu.be/dTNCezi54ag', N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Red-whiskered_bulbul_by_Creepanta_11.jpg/420px-Red-whiskered_bulbul_by_Creepanta_11.jpg', 11, N'Đây là loài chim sống ở những khu vực có cây cối rậm rạp, đất nước thoáng đãng hơn với những bụi rậm và đất trồng trọt.')
INSERT [dbo].[Species] ([ID], [Name], [Color], [Size], [Voice], [ImageLink], [LifeExpectancy], [Habitat]) VALUES (2, N'Họa Mi', N'phần lônh ngắn phủ toàn thân có màu nâu đậm. Lông ở phần đầu và cổ có dạng vân kẻ màu đen, phần bụng có màu nâu nhạt hơn', N'21- 25cm (49-75g)', N'https://youtu.be/oRHcP8lYaL0', N'https://cdn.eva.vn/upload/3-2021/images/2021-09-30/image3-1632998835-30-width650height460.jpg', 17, N'Khi sống trong môi trường tự nhiên, chim Họa Mi thường kiếm ăn từ các lớp lá theo từng cặp hoặc bầy đàn. chim Họa Mi thường sinh sản vào tầm tháng 6 – 7 Âm lịch. Tổ của chim Họa Mi thường làm từ lá tre, cỏ và rễ cây. Vào mùa sinh sản chim Họa Mi thường đẻ từ 2 – 5 trứng và ấp trong vòng 13 – 16 ngày, sau đó chim bố, chim mẹ sẽ kiếm ăn nuôi con. ')
INSERT [dbo].[Species] ([ID], [Name], [Color], [Size], [Voice], [ImageLink], [LifeExpectancy], [Habitat]) VALUES (3, N'Vẹt Yến Phụng', N'màu xanh lục và vàng với các mảng màu đen, hình vỏ sò ở gáy, lưng và cánh. ', N'18cm (30-40kg)', N'https://youtu.be/88-LGgj1GBQ', N'https://lh3.googleusercontent.com/x2qa9iwXtlPBwn3_s0Of700Z45jLsv3y_qHdrfsHTbEJbKGaQFlCIgMp7BsVeHNDY_t1Y3FZyTk44hwXnY9ZTymKEGOe8dMiBsEyM3X_jFZN11XQX2yw4OC_a8ef_8mlPk5jD0Gn', 8, N'Khi ở ngoài tự nhiên, Yến Phụng thường sống theo cặp và rất gắn bó với nhau. Chúng gần như đẻ quanh năm và nhiều nhất vào mùa hè. Thường loài chim này sẽ làm tổ bằng cách khoét thân cây.')
INSERT [dbo].[Species] ([ID], [Name], [Color], [Size], [Voice], [ImageLink], [LifeExpectancy], [Habitat]) VALUES (4, N'Vành Khuyên', N'Mỏ vàng. Lông chim màu xanh hoặc vàng ', N'10cm', N'https://youtu.be/vwYrsyHWEJM', N'https://cdn.eva.vn/upload/4-2021/images/2021-10-01/image1-1633053449-421-width600height450.jpg', 7, N'Thích sống nơi có khí hậu ấm áp như Châu Phi, Nam Á, Úc và Đông Nam Á')
SET IDENTITY_INSERT [dbo].[Species] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (1, NULL, 1, 1, N'Cho ăn', N'11/1/2023  11:00:00 AM', N'', N'Done')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (2, NULL, 2, 3, N'Cho ăn', N'11/1/2023  11:00:00 AM', N'Chim bị bán và đã chết 1 con', N'Overdue')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (3, NULL, 3, 3, N'Cho ăn', N'11/1/2023  11:00:00 AM', N'', N'Done')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (4, 7, 9, 3, N'Thay băng', N'11/1/2023  11:00:00 AM', N'', N'Done')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (5, NULL, 1, 1, N'Cho ăn', N'11/1/2023  10:00:00 AM', N'', N'Overdue')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (6, NULL, 3, 4, N'Cho ăn', N'11/2/2023  11:00:00 AM', N'', N'Ongoing')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (7, NULL, 1, 4, N'Vệ sinh lồng', N'11/2/2023  10:00:00 AM', N'', N'Overdue')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (8, NULL, 3, 4, N'Vệ sinh lồng', N'11/2/2023  11:00:00 AM', N'', N'Done')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (9, NULL, 1, 1, N'Cho ăn', N'11/3/2023  11:00:00 AM', N'', N'Upcoming')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (10, NULL, 3, 3, N'Cho ăn', N'11/3/2023  11:00:00 AM', N'', N'Upcoming')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (11, NULL, 4, 4, N'Cho ăn', N'11/3/2023  11:00:00 AM', N'', N'Not Assign')
INSERT [dbo].[Task] ([ID], [BirdID], [CageID], [StaffID], [TaskName], [DateTime], [Description], [Status]) VALUES (12, NULL, 4, 1, N'Vệ sinh lồng', N'11/3/2023  11:00:00 AM', N'', N'Not Assign')
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name], [Email], [Password], [PhoneNumber], [FirebaseID], [Role], [Status]) VALUES (1, N'User 1', N'email1@gmail.com', N'', N'', N'', 1, 1)
INSERT [dbo].[User] ([ID], [Name], [Email], [Password], [PhoneNumber], [FirebaseID], [Role], [Status]) VALUES (2, N'User 2', N'email2@gmail.com', N'', N'', N'', 1, 1)
INSERT [dbo].[User] ([ID], [Name], [Email], [Password], [PhoneNumber], [FirebaseID], [Role], [Status]) VALUES (3, N'User 3', N'email3@gmail.com', N'', N'', N'', 2, 1)
INSERT [dbo].[User] ([ID], [Name], [Email], [Password], [PhoneNumber], [FirebaseID], [Role], [Status]) VALUES (4, N'User 4', N'email4@gmail.com', N'', N'', N'', 3, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [IX_Bird_CageID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Bird_CageID] ON [dbo].[Bird]
(
	[CageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bird_SpeciesId]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Bird_SpeciesId] ON [dbo].[Bird]
(
	[SpeciesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FeedingPlan_BirdID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingPlan_BirdID] ON [dbo].[FeedingPlan]
(
	[BirdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FeedingPlan_MealMenuID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingPlan_MealMenuID] ON [dbo].[FeedingPlan]
(
	[MealMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InventoryLog_FoodId]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_InventoryLog_FoodId] ON [dbo].[InventoryLog]
(
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Log_BirdID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Log_BirdID] ON [dbo].[Log]
(
	[BirdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Log_CageID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Log_CageID] ON [dbo].[Log]
(
	[CageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MealMenu_SpeciesID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_MealMenu_SpeciesID] ON [dbo].[MealMenu]
(
	[SpeciesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuDetail_FoodID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_MenuDetail_FoodID] ON [dbo].[MenuDetail]
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuDetail_MealMenuID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_MenuDetail_MealMenuID] ON [dbo].[MenuDetail]
(
	[MealMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrder_CreatorID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_CreatorID] ON [dbo].[PurchaseOrder]
(
	[CreatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrder_PurchaseRequestID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_PurchaseRequestID] ON [dbo].[PurchaseOrder]
(
	[PurchaseRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrder_SupplierID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_SupplierID] ON [dbo].[PurchaseOrder]
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrderDetail_FoodID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrderDetail_FoodID] ON [dbo].[PurchaseOrderDetail]
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrderDetail_PurchaseOrderID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrderDetail_PurchaseOrderID] ON [dbo].[PurchaseOrderDetail]
(
	[PurchaseOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseRequest_CreatorID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseRequest_CreatorID] ON [dbo].[PurchaseRequest]
(
	[CreatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseRequestDetail_FoodID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseRequestDetail_FoodID] ON [dbo].[PurchaseRequestDetail]
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseRequestDetail_PurchaseRequestID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseRequestDetail_PurchaseRequestID] ON [dbo].[PurchaseRequestDetail]
(
	[PurchaseRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Task_BirdID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Task_BirdID] ON [dbo].[Task]
(
	[BirdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Task_CageID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Task_CageID] ON [dbo].[Task]
(
	[CageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Task_StaffID]    Script Date: 11/5/2023 1:53:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Task_StaffID] ON [dbo].[Task]
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bird]  WITH CHECK ADD  CONSTRAINT [FK_Bird_Cage_CageID] FOREIGN KEY([CageID])
REFERENCES [dbo].[Cage] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bird] CHECK CONSTRAINT [FK_Bird_Cage_CageID]
GO
ALTER TABLE [dbo].[Bird]  WITH CHECK ADD  CONSTRAINT [FK_Bird_Species_SpeciesId] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[Species] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bird] CHECK CONSTRAINT [FK_Bird_Species_SpeciesId]
GO
ALTER TABLE [dbo].[FeedingPlan]  WITH CHECK ADD  CONSTRAINT [FK_FeedingPlan_Bird_BirdID] FOREIGN KEY([BirdID])
REFERENCES [dbo].[Bird] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedingPlan] CHECK CONSTRAINT [FK_FeedingPlan_Bird_BirdID]
GO
ALTER TABLE [dbo].[FeedingPlan]  WITH CHECK ADD  CONSTRAINT [FK_FeedingPlan_MealMenu_MealMenuID] FOREIGN KEY([MealMenuID])
REFERENCES [dbo].[MealMenu] ([ID])
GO
ALTER TABLE [dbo].[FeedingPlan] CHECK CONSTRAINT [FK_FeedingPlan_MealMenu_MealMenuID]
GO
ALTER TABLE [dbo].[InventoryLog]  WITH CHECK ADD  CONSTRAINT [FK_InventoryLog_Food_FoodId] FOREIGN KEY([FoodId])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[InventoryLog] CHECK CONSTRAINT [FK_InventoryLog_Food_FoodId]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_Bird_BirdID] FOREIGN KEY([BirdID])
REFERENCES [dbo].[Bird] ([ID])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_Bird_BirdID]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_Cage_CageID] FOREIGN KEY([CageID])
REFERENCES [dbo].[Cage] ([ID])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_Cage_CageID]
GO
ALTER TABLE [dbo].[MealMenu]  WITH CHECK ADD  CONSTRAINT [FK_MealMenu_Species_SpeciesID] FOREIGN KEY([SpeciesID])
REFERENCES [dbo].[Species] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MealMenu] CHECK CONSTRAINT [FK_MealMenu_Species_SpeciesID]
GO
ALTER TABLE [dbo].[MenuDetail]  WITH CHECK ADD  CONSTRAINT [FK_MenuDetail_Food_FoodID] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuDetail] CHECK CONSTRAINT [FK_MenuDetail_Food_FoodID]
GO
ALTER TABLE [dbo].[MenuDetail]  WITH CHECK ADD  CONSTRAINT [FK_MenuDetail_MealMenu_MealMenuID] FOREIGN KEY([MealMenuID])
REFERENCES [dbo].[MealMenu] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuDetail] CHECK CONSTRAINT [FK_MenuDetail_MealMenu_MealMenuID]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_PurchaseRequest_PurchaseRequestID] FOREIGN KEY([PurchaseRequestID])
REFERENCES [dbo].[PurchaseRequest] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_PurchaseRequest_PurchaseRequestID]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Supplier_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Supplier_SupplierID]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_User_CreatorID] FOREIGN KEY([CreatorID])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_User_CreatorID]
GO
ALTER TABLE [dbo].[PurchaseOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetail_Food_FoodID] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrderDetail] CHECK CONSTRAINT [FK_PurchaseOrderDetail_Food_FoodID]
GO
ALTER TABLE [dbo].[PurchaseOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetail_PurchaseOrder_PurchaseOrderID] FOREIGN KEY([PurchaseOrderID])
REFERENCES [dbo].[PurchaseOrder] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrderDetail] CHECK CONSTRAINT [FK_PurchaseOrderDetail_PurchaseOrder_PurchaseOrderID]
GO
ALTER TABLE [dbo].[PurchaseRequest]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseRequest_User_CreatorID] FOREIGN KEY([CreatorID])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseRequest] CHECK CONSTRAINT [FK_PurchaseRequest_User_CreatorID]
GO
ALTER TABLE [dbo].[PurchaseRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseRequestDetail_Food_FoodID] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseRequestDetail] CHECK CONSTRAINT [FK_PurchaseRequestDetail_Food_FoodID]
GO
ALTER TABLE [dbo].[PurchaseRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseRequestDetail_PurchaseRequest_PurchaseRequestID] FOREIGN KEY([PurchaseRequestID])
REFERENCES [dbo].[PurchaseRequest] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseRequestDetail] CHECK CONSTRAINT [FK_PurchaseRequestDetail_PurchaseRequest_PurchaseRequestID]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Bird_BirdID] FOREIGN KEY([BirdID])
REFERENCES [dbo].[Bird] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Bird_BirdID]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Cage_CageID] FOREIGN KEY([CageID])
REFERENCES [dbo].[Cage] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Cage_CageID]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User_StaffID] FOREIGN KEY([StaffID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User_StaffID]
GO
USE [master]
GO
ALTER DATABASE [BirdFarmDB] SET  READ_WRITE 
GO
