USE [master]
GO
/****** Object:  Database [Kundregister]    Script Date: 2018-04-15 22:07:07 ******/
CREATE DATABASE [Kundregister]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kundregister', FILENAME = N'C:\Users\Administrator\Kundregister.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kundregister_log', FILENAME = N'C:\Users\Administrator\Kundregister_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Kundregister] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kundregister].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kundregister] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kundregister] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kundregister] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kundregister] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kundregister] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kundregister] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kundregister] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kundregister] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kundregister] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kundregister] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kundregister] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kundregister] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kundregister] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kundregister] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kundregister] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kundregister] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kundregister] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kundregister] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kundregister] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kundregister] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kundregister] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kundregister] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kundregister] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Kundregister] SET  MULTI_USER 
GO
ALTER DATABASE [Kundregister] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kundregister] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kundregister] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kundregister] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kundregister] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Kundregister] SET QUERY_STORE = OFF
GO
USE [Kundregister]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Kundregister]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2018-04-15 22:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Type] [varchar](50) NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustProd]    Script Date: 2018-04-15 22:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustProd](
	[ProductID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_CustProd] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phones]    Script Date: 2018-04-15 22:07:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phones](
	[PhoneId] [int] IDENTITY(1,1) NOT NULL,
	[HomePhone] [varchar](50) NULL,
	[MobilePhone] [varchar](50) NULL,
	[WorkingPhone] [varchar](50) NULL,
	[EmergencyContactPhone] [varchar](50) NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2018-04-15 22:07:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nchar](10) NULL,
	[ProductType] [nchar](10) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Jonas', N'Berg', N'berg@mail.cr', 1)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Eva', N'Johansson', N'wea@mail.se', 2)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Stig', N'Stig', N'Stig@stig.se', 3)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Erik', N'Olsson', N'hej@mail.com', 4)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Lolo', N'Peterström', N'Lolo@mail.se', 5)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Test', N'Testson', N'testEpost@post.se', 6)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Stin', N'Eroll', N'eroll@gmail.com', 7)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Andre', N'Malm', N'Andre@mailtoandre.se', 9)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Jens', N'Malm', N'Jensmalm873@gmail.com', 10)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'New', N'Lisa', N'Hemsberg', N'Lisa-Hemsberg@mail.se', 12)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'Potential', N'Lena', N'olsson', N'Lena.Olsson@gmail.com', 13)
INSERT [dbo].[Customer] ([Type], [Firstname], [Surname], [Email], [CustomerID]) VALUES (N'ijadw', N'Hej', N'mijhadwp', N'pijadw', 14)
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (1, 1)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (1, 2)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (2, 6)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (3, 1)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (3, 2)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (3, 3)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (3, 4)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (3, 5)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (3, 6)
INSERT [dbo].[CustProd] ([ProductID], [CustomerID]) VALUES (3, 7)
SET IDENTITY_INSERT [dbo].[Phones] ON 

INSERT [dbo].[Phones] ([PhoneId], [HomePhone], [MobilePhone], [WorkingPhone], [EmergencyContactPhone], [CustomerID]) VALUES (1, N'0526-10405', N'0709317237', N'', N'', 10)
INSERT [dbo].[Phones] ([PhoneId], [HomePhone], [MobilePhone], [WorkingPhone], [EmergencyContactPhone], [CustomerID]) VALUES (2, N'03123322', N'0123456', N'082145646', N'46456546', 1)
INSERT [dbo].[Phones] ([PhoneId], [HomePhone], [MobilePhone], [WorkingPhone], [EmergencyContactPhone], [CustomerID]) VALUES (3, N'0526-54164', N'0709541654', N'031684684', N'84698', 2)
INSERT [dbo].[Phones] ([PhoneId], [HomePhone], [MobilePhone], [WorkingPhone], [EmergencyContactPhone], [CustomerID]) VALUES (7, N'08-654644', N'0709704684', N'031546400', NULL, 3)
INSERT [dbo].[Phones] ([PhoneId], [HomePhone], [MobilePhone], [WorkingPhone], [EmergencyContactPhone], [CustomerID]) VALUES (8, N'041-564646', N'0746635414', N'041-654656', N'1654648', 4)
INSERT [dbo].[Phones] ([PhoneId], [HomePhone], [MobilePhone], [WorkingPhone], [EmergencyContactPhone], [CustomerID]) VALUES (9, N'08-684684', N'0735465464', N'031864684', N'6846846', 7)
INSERT [dbo].[Phones] ([PhoneId], [HomePhone], [MobilePhone], [WorkingPhone], [EmergencyContactPhone], [CustomerID]) VALUES (10, N'dpoajkwd', N'daiwjd', N'dapwojd', N'pojadww', 26)
SET IDENTITY_INSERT [dbo].[Phones] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductType]) VALUES (1, N'Hjul      ', N'Bildel    ')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductType]) VALUES (2, N'Football  ', N'Sports    ')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductType]) VALUES (3, N'iPhone    ', N'Phone     ')
SET IDENTITY_INSERT [dbo].[Product] OFF
ALTER TABLE [dbo].[CustProd]  WITH CHECK ADD  CONSTRAINT [FK_CustProd_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CustProd] CHECK CONSTRAINT [FK_CustProd_Customer]
GO
ALTER TABLE [dbo].[CustProd]  WITH CHECK ADD  CONSTRAINT [FK_CustProd_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[CustProd] CHECK CONSTRAINT [FK_CustProd_Product]
GO
USE [master]
GO
ALTER DATABASE [Kundregister] SET  READ_WRITE 
GO
