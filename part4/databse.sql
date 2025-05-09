USE [master]
GO
/****** Object:  Database [GroceryDb]    Script Date: 08/04/2025 22:18:36 ******/
CREATE DATABASE [GroceryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GroceryDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GroceryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GroceryDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GroceryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GroceryDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GroceryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GroceryDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GroceryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GroceryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GroceryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GroceryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GroceryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GroceryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GroceryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GroceryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GroceryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GroceryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GroceryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GroceryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GroceryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GroceryDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GroceryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GroceryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GroceryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GroceryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GroceryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GroceryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GroceryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GroceryDb] SET RECOVERY FULL 
GO
ALTER DATABASE [GroceryDb] SET  MULTI_USER 
GO
ALTER DATABASE [GroceryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GroceryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GroceryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GroceryDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GroceryDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GroceryDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GroceryDb', N'ON'
GO
ALTER DATABASE [GroceryDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [GroceryDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GroceryDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/04/2025 22:18:36 ******/
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
/****** Object:  Table [dbo].[Grocers]    Script Date: 08/04/2025 22:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grocers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phon] [nvarchar](max) NOT NULL,
	[Maile] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Grocers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 08/04/2025 22:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[QuantityOrder] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 08/04/2025 22:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[minQuantityOrder] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 08/04/2025 22:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[RepresentativeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250404112108_order', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250404131038_getOrder', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250404134432_noPrudectOrder', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250408170827_last', N'7.0.0')
GO
SET IDENTITY_INSERT [dbo].[Grocers] ON 

INSERT [dbo].[Grocers] ([Id], [Name], [Phon], [Maile], [Address]) VALUES (2, N'manager', N'0547730604', N'lmichal2024@gmail.com', N'petach-tikva')
SET IDENTITY_INSERT [dbo].[Grocers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (3, CAST(N'2025-04-04T16:48:25.4891093' AS DateTime2), 1, 2, 4, 1)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (4, CAST(N'2025-04-04T17:07:41.8980615' AS DateTime2), 1, 2, 2, 2)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (5, CAST(N'2025-04-04T17:31:02.8776845' AS DateTime2), 1, 2, 4, 1)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (6, CAST(N'2025-04-04T17:31:04.8145290' AS DateTime2), 1, 2, 2, 2)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (7, CAST(N'2025-04-04T17:31:43.4384090' AS DateTime2), 2, 0, 5, 3)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (8, CAST(N'2025-04-05T21:17:46.9581961' AS DateTime2), 2, 0, 5, 3)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (9, CAST(N'2025-04-05T21:17:50.4508301' AS DateTime2), 1, 1, 2, 2)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (10, CAST(N'2025-04-05T21:17:53.2201869' AS DateTime2), 1, 0, 4, 1)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (11, CAST(N'2025-04-05T21:17:56.3936265' AS DateTime2), 2, 0, 5, 3)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (12, CAST(N'2025-04-05T22:26:21.5376102' AS DateTime2), 1, 0, 9, 1)
INSERT [dbo].[Orders] ([Id], [Date], [SupplierId], [Status], [QuantityOrder], [ProductId]) VALUES (13, CAST(N'2025-04-05T22:30:42.0150911' AS DateTime2), 1, 0, 16, 2)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [ProductPrice], [minQuantityOrder], [SupplierId]) VALUES (1, N'בננה', 3, 4, 1)
INSERT [dbo].[Products] ([Id], [ProductName], [ProductPrice], [minQuantityOrder], [SupplierId]) VALUES (2, N'שוקולד', 2, 2, 1)
INSERT [dbo].[Products] ([Id], [ProductName], [ProductPrice], [minQuantityOrder], [SupplierId]) VALUES (3, N'חלב', 7, 5, 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([Id], [CompanyName], [Phone], [RepresentativeName]) VALUES (1, N'טרה', N'0583230290', N'מיכל')
INSERT [dbo].[Suppliers] ([Id], [CompanyName], [Phone], [RepresentativeName]) VALUES (2, N'תנובה', N'6582024525', N'יעל')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
/****** Object:  Index [IX_Orders_ProductId]    Script Date: 08/04/2025 22:18:37 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_ProductId] ON [dbo].[Orders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_SupplierId]    Script Date: 08/04/2025 22:18:37 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_SupplierId] ON [dbo].[Orders]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SupplierId]    Script Date: 08/04/2025 22:18:37 ******/
CREATE NONCLUSTERED INDEX [IX_Products_SupplierId] ON [dbo].[Products]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Suppliers_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Suppliers_SupplierId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers_SupplierId]
GO
USE [master]
GO
ALTER DATABASE [GroceryDb] SET  READ_WRITE 
GO
