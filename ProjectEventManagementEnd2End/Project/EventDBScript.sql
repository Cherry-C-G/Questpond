USE [master]
GO
/****** Object:  Database [EventDB]    Script Date: 05/10/2016 09:59:49 ******/
CREATE DATABASE [EventDB] ON  PRIMARY 
( NAME = N'EventDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\EventDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EventDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\EventDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EventDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EventDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EventDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [EventDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [EventDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [EventDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [EventDB] SET ARITHABORT OFF
GO
ALTER DATABASE [EventDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [EventDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [EventDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [EventDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [EventDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [EventDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [EventDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [EventDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [EventDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [EventDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [EventDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [EventDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [EventDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [EventDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [EventDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [EventDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [EventDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [EventDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [EventDB] SET  READ_WRITE
GO
ALTER DATABASE [EventDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [EventDB] SET  MULTI_USER
GO
ALTER DATABASE [EventDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [EventDB] SET DB_CHAINING OFF
GO
USE [EventDB]
GO
/****** Object:  Table [dbo].[Venue]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venue](
	[VenueID] [int] IDENTITY(1,1) NOT NULL,
	[VenueName] [varchar](200) NULL,
	[VenueFilename] [varchar](200) NULL,
	[VenueFilePath] [varchar](200) NULL,
	[Createdby] [int] NULL,
	[Createdate] [datetime] NULL,
	[VenueCost] [int] NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[VenueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Venue] ON
INSERT [dbo].[Venue] ([VenueID], [VenueName], [VenueFilename], [VenueFilePath], [Createdby], [Createdate], [VenueCost]) VALUES (1, N'BeachVenue', N'The-Wedding-Co.weddingplz1.jpg', N'634db6a5-8077-40b9-a657-888ba19c89ec.jpg', 2, NULL, 50000)
INSERT [dbo].[Venue] ([VenueID], [VenueName], [VenueFilename], [VenueFilePath], [Createdby], [Createdate], [VenueCost]) VALUES (2, N'Garden Venue', N'SR-Event-Planners4.weddingplz.jpg', N'f4d32e45-18e5-4be7-a85e-387142b07f23.jpg', 2, NULL, 20000)
SET IDENTITY_INSERT [dbo].[Venue] OFF
/****** Object:  Table [dbo].[States]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[States](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](200) NULL,
	[CountryID] [int] NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (1, N'Andhra Pradesh', 1)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (2, N'Maharashtra', 1)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (3, N'Shanghai', 2)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (4, N'Beijing', 2)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (5, N'New Jersey', 3)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (6, N'Texas', 3)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (7, N'Sunderland', 4)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (8, N'Newport', 4)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (9, N'Berlin', 5)
INSERT [dbo].[States] ([StateID], [StateName], [CountryID]) VALUES (10, N'Hamburg', 5)
SET IDENTITY_INSERT [dbo].[States] OFF
/****** Object:  Table [dbo].[Roles]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Rolename] [varchar](100) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleID], [Rolename]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleID], [Rolename]) VALUES (2, N'Users')
INSERT [dbo].[Roles] ([RoleID], [Rolename]) VALUES (3, N'SuperAdmin')
INSERT [dbo].[Roles] ([RoleID], [Rolename]) VALUES (4, N'Anonymous ')
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[Registration]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[Country] [varchar](100) NULL,
	[Mobileno] [varchar](20) NULL,
	[EmailID] [varchar](100) NULL,
	[Username] [varchar](20) NULL,
	[Password] [varchar](100) NULL,
	[ConfirmPassword] [varchar](100) NULL,
	[Gender] [varchar](10) NULL,
	[Birthdate] [datetime] NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Registration] ON
INSERT [dbo].[Registration] ([ID], [Name], [Address], [City], [State], [Country], [Mobileno], [EmailID], [Username], [Password], [ConfirmPassword], [Gender], [Birthdate], [RoleID]) VALUES (1, N'Customer', N'Bandra', N'5', N'2', N'1', N'9888888888', N'saihacksoft@gmail.com', N'Customer', N'E10ADC3949BA59ABBE56E057F20F883E', N'E10ADC3949BA59ABBE56E057F20F883E', N'M', CAST(0x000081A200000000 AS DateTime), 2)
INSERT [dbo].[Registration] ([ID], [Name], [Address], [City], [State], [Country], [Mobileno], [EmailID], [Username], [Password], [ConfirmPassword], [Gender], [Birthdate], [RoleID]) VALUES (2, N'Admin', N'Bandra', N'5', N'2', N'1', N'9888888888', N'saihacksoft@gmail.com', N'Admin', N'E10ADC3949BA59ABBE56E057F20F883E', N'E10ADC3949BA59ABBE56E057F20F883E', N'M', CAST(0x000081A200000000 AS DateTime), 1)
INSERT [dbo].[Registration] ([ID], [Name], [Address], [City], [State], [Country], [Mobileno], [EmailID], [Username], [Password], [ConfirmPassword], [Gender], [Birthdate], [RoleID]) VALUES (3, N'SuperAdmin', N'Bandra', N'5', N'2', N'1', N'9888888888', N'saihacksoft@gmail.com', N'SuperAdmin', N'E10ADC3949BA59ABBE56E057F20F883E', N'E10ADC3949BA59ABBE56E057F20F883E', N'M', CAST(0x000081A200000000 AS DateTime), 3)
INSERT [dbo].[Registration] ([ID], [Name], [Address], [City], [State], [Country], [Mobileno], [EmailID], [Username], [Password], [ConfirmPassword], [Gender], [Birthdate], [RoleID]) VALUES (4, N'Newadmin', N'Bandra', N'2', N'1', N'1', N'9888888888', N'Newadmin@gmail.com', N'Newadmin', N'E10ADC3949BA59ABBE56E057F20F883E', N'E10ADC3949BA59ABBE56E057F20F883E', N'M', CAST(0x00007E0E00000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Registration] OFF
/****** Object:  Table [dbo].[Light]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Light](
	[LightID] [int] IDENTITY(1,1) NOT NULL,
	[LightType] [char](1) NULL,
	[LightName] [varchar](200) NULL,
	[LightFilename] [varchar](200) NULL,
	[LightFilePath] [varchar](200) NULL,
	[Createdby] [int] NULL,
	[Createdate] [datetime] NULL,
	[LightCost] [int] NULL,
 CONSTRAINT [PK_Light] PRIMARY KEY CLUSTERED 
(
	[LightID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Light] ON
INSERT [dbo].[Light] ([LightID], [LightType], [LightName], [LightFilename], [LightFilePath], [Createdby], [Createdate], [LightCost]) VALUES (1, N'1', N'String Lights', N'string-lights-wedding.jpg', N'0dfa03d5-2f9d-44f0-87ad-f07e0f0b7224.jpg', 2, NULL, 3000)
INSERT [dbo].[Light] ([LightID], [LightType], [LightName], [LightFilename], [LightFilePath], [Createdby], [Createdate], [LightCost]) VALUES (2, N'2', N'Acqualina outdoor Lights', N'Acqualina-outdoor-wedding-lighting-12.jpg', N'84a52172-2dae-43d3-ba8b-e6126ef7d248.jpg', 2, NULL, 5000)
SET IDENTITY_INSERT [dbo].[Light] OFF
/****** Object:  Table [dbo].[Food]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Food](
	[FoodID] [int] IDENTITY(1,1) NOT NULL,
	[FoodType] [char](1) NULL,
	[MealType] [char](1) NULL,
	[DishType] [int] NULL,
	[FoodName] [varchar](200) NULL,
	[FoodFilename] [varchar](200) NULL,
	[FoodFilePath] [varchar](200) NULL,
	[Createdby] [int] NULL,
	[Createdate] [datetime] NULL,
	[FoodCost] [int] NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON
INSERT [dbo].[Food] ([FoodID], [FoodType], [MealType], [DishType], [FoodName], [FoodFilename], [FoodFilePath], [Createdby], [Createdate], [FoodCost]) VALUES (1, N'1', N'1', 1, N'South India thali', N'south_indian_thali.jpg', N'ff3f984e-15fa-4c61-a143-7166c13bb6a0.jpg', 2, NULL, 250)
INSERT [dbo].[Food] ([FoodID], [FoodType], [MealType], [DishType], [FoodName], [FoodFilename], [FoodFilePath], [Createdby], [Createdate], [FoodCost]) VALUES (2, N'1', N'2', 2, N'North Indian Thali', N'maxim-s-cafe.jpg', N'8256d039-80b8-4710-b583-79d0998eb19d.jpg', 2, NULL, 250)
INSERT [dbo].[Food] ([FoodID], [FoodType], [MealType], [DishType], [FoodName], [FoodFilename], [FoodFilePath], [Createdby], [Createdate], [FoodCost]) VALUES (3, N'2', N'1', 1, N'Punjab Thali', N'o.jpg', N'c95a0e11-a554-4ec5-b270-7e752f2a7d98.jpg', 2, NULL, 300)
INSERT [dbo].[Food] ([FoodID], [FoodType], [MealType], [DishType], [FoodName], [FoodFilename], [FoodFilePath], [Createdby], [Createdate], [FoodCost]) VALUES (4, N'2', N'2', 1, N'Maharashtrian thali', N'a-thali-plate.jpg', N'b6b9b77b-daa4-4a48-bef8-3c7b5c1b132c.jpg', 2, NULL, 300)
SET IDENTITY_INSERT [dbo].[Food] OFF
/****** Object:  Table [dbo].[Flower]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flower](
	[FlowerID] [int] IDENTITY(1,1) NOT NULL,
	[FlowerName] [varchar](200) NULL,
	[FlowerFilename] [varchar](200) NULL,
	[FlowerFilePath] [varchar](200) NULL,
	[Createdby] [int] NULL,
	[Createdate] [datetime] NULL,
	[FlowerCost] [int] NULL,
 CONSTRAINT [PK_Flower] PRIMARY KEY CLUSTERED 
(
	[FlowerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Flower] ON
INSERT [dbo].[Flower] ([FlowerID], [FlowerName], [FlowerFilename], [FlowerFilePath], [Createdby], [Createdate], [FlowerCost]) VALUES (1, N'Orchids', N'Orchid.jpg', N'70f41879-909d-45a8-a6d9-dba7bb33f0d6.jpg', 2, NULL, 3000)
INSERT [dbo].[Flower] ([FlowerID], [FlowerName], [FlowerFilename], [FlowerFilePath], [Createdby], [Createdate], [FlowerCost]) VALUES (2, N'red wedding flower-bouquets', N'red-wedding-flower-bouquets-collection.jpg', N'cbd90318-99e7-45c2-bddb-3a3e2089208f.jpg', 2, NULL, 3000)
SET IDENTITY_INSERT [dbo].[Flower] OFF
/****** Object:  Table [dbo].[Event]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Event](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [varchar](50) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Event] ON
INSERT [dbo].[Event] ([EventID], [EventType], [Status]) VALUES (1, N'Marriage', N'1')
INSERT [dbo].[Event] ([EventID], [EventType], [Status]) VALUES (2, N'FamilyFunction', N'2')
INSERT [dbo].[Event] ([EventID], [EventType], [Status]) VALUES (3, N'Birthday Party', N'3')
INSERT [dbo].[Event] ([EventID], [EventType], [Status]) VALUES (4, N'anniversary', N'4')
INSERT [dbo].[Event] ([EventID], [EventType], [Status]) VALUES (5, N'FareWell Party', N'5')
INSERT [dbo].[Event] ([EventID], [EventType], [Status]) VALUES (6, N'College Event', N'6')
SET IDENTITY_INSERT [dbo].[Event] OFF
/****** Object:  Table [dbo].[Equipment]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentName] [varchar](200) NULL,
	[EquipmentFilename] [varchar](200) NULL,
	[EquipmentFilePath] [varchar](200) NULL,
	[Createdby] [int] NULL,
	[Createdate] [datetime] NULL,
	[EquipmentCost] [int] NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentFilename], [EquipmentFilePath], [Createdby], [Createdate], [EquipmentCost]) VALUES (1, N'DJ', N'2011-10-15 - Wedding - Brito-Lopez - Flip''s Setup - 640x512x256.jpg', N'c1bf21d9-361e-400b-b706-eb2067bd6576.jpg', 2, NULL, 5000)
INSERT [dbo].[Equipment] ([EquipmentID], [EquipmentName], [EquipmentFilename], [EquipmentFilePath], [Createdby], [Createdate], [EquipmentCost]) VALUES (2, N'Speakers and Mike', N'speaker.png', N'6671822f-4a69-4aa5-a75f-a279328cf334.png', 2, NULL, 2000)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
/****** Object:  Table [dbo].[Country]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON
INSERT [dbo].[Country] ([CountryID], [Name]) VALUES (1, N'India')
INSERT [dbo].[Country] ([CountryID], [Name]) VALUES (2, N'China')
INSERT [dbo].[Country] ([CountryID], [Name]) VALUES (3, N'USA')
INSERT [dbo].[Country] ([CountryID], [Name]) VALUES (4, N'UK')
INSERT [dbo].[Country] ([CountryID], [Name]) VALUES (5, N'Germany')
SET IDENTITY_INSERT [dbo].[Country] OFF
/****** Object:  Table [dbo].[City]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](200) NULL,
	[StateID] [int] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (1, N'Hyderabad', 1)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (2, N'Visakhapatnam', 1)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (3, N'Vijayawada', 1)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (4, N'Warangal', 1)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (5, N'Mumbai', 2)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (6, N'Pune', 2)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (7, N'Nagpur', 2)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (8, N'Thane', 2)
INSERT [dbo].[City] ([CityID], [CityName], [StateID]) VALUES (9, N'Nashik', 2)
SET IDENTITY_INSERT [dbo].[City] OFF
/****** Object:  Table [dbo].[BookingVenue]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingVenue](
	[BookingVenueID] [int] IDENTITY(1,1) NOT NULL,
	[VenueID] [int] NULL,
	[EventTypeID] [int] NULL,
	[GuestCount] [int] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[BookingID] [int] NULL,
 CONSTRAINT [PK_BookingVenue] PRIMARY KEY CLUSTERED 
(
	[BookingVenueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookingVenue] ON
INSERT [dbo].[BookingVenue] ([BookingVenueID], [VenueID], [EventTypeID], [GuestCount], [Createdby], [CreatedDate], [BookingID]) VALUES (1, 1, 1, 500, 1, CAST(0x0000A60200A29999 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BookingVenue] OFF
/****** Object:  Table [dbo].[BookingLight]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingLight](
	[BookLightID] [int] IDENTITY(1,1) NOT NULL,
	[LightType] [char](1) NULL,
	[LightIDSelected] [int] NULL,
	[BookingID] [int] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_BookingLight] PRIMARY KEY CLUSTERED 
(
	[BookLightID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BookingLight] ON
INSERT [dbo].[BookingLight] ([BookLightID], [LightType], [LightIDSelected], [BookingID], [Createdby], [CreatedDate]) VALUES (1, N'1', 1, 1, 1, CAST(0x0000A60200A2AD53 AS DateTime))
SET IDENTITY_INSERT [dbo].[BookingLight] OFF
/****** Object:  Table [dbo].[BookingFood]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingFood](
	[BookFoodID] [int] IDENTITY(1,1) NOT NULL,
	[FoodType] [char](1) NULL,
	[MealType] [char](1) NULL,
	[DishType] [int] NULL,
	[DishName] [int] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[BookingID] [int] NOT NULL,
 CONSTRAINT [PK_BookingFood] PRIMARY KEY CLUSTERED 
(
	[BookFoodID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BookingFood] ON
INSERT [dbo].[BookingFood] ([BookFoodID], [FoodType], [MealType], [DishType], [DishName], [Createdby], [CreatedDate], [BookingID]) VALUES (1, N'1', N'1', 1, 1, 1, CAST(0x0000A60200A2A753 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BookingFood] OFF
/****** Object:  Table [dbo].[BookingFlower]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingFlower](
	[BookingFlowerID] [int] IDENTITY(1,1) NOT NULL,
	[FlowerID] [int] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[BookingID] [int] NULL,
 CONSTRAINT [PK_BookingFlower] PRIMARY KEY CLUSTERED 
(
	[BookingFlowerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookingFlower] ON
INSERT [dbo].[BookingFlower] ([BookingFlowerID], [FlowerID], [Createdby], [CreatedDate], [BookingID]) VALUES (1, 1, 1, CAST(0x0000A60200A2B48A AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BookingFlower] OFF
/****** Object:  Table [dbo].[BookingEquipment]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingEquipment](
	[BookingEquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[BookingID] [int] NOT NULL,
 CONSTRAINT [PK_BookingEquipment] PRIMARY KEY CLUSTERED 
(
	[BookingEquipmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookingEquipment] ON
INSERT [dbo].[BookingEquipment] ([BookingEquipmentID], [EquipmentID], [Createdby], [CreatedDate], [BookingID]) VALUES (1, 1, 1, CAST(0x0000A60200A2A028 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BookingEquipment] OFF
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 05/10/2016 09:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[BookingNo] [varchar](50) NULL,
	[BookingDate] [date] NULL,
	[Createdby] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[BookingApproval] [char](1) NULL,
	[BookingApprovalDate] [datetime] NULL,
	[BookingCompletedFlag] [char](1) NULL,
 CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BookingDetails] ON
INSERT [dbo].[BookingDetails] ([BookingID], [BookingNo], [BookingDate], [Createdby], [CreatedDate], [BookingApproval], [BookingApprovalDate], [BookingCompletedFlag]) VALUES (1, N'BK-2016-1', CAST(0x613B0B00 AS Date), 1, CAST(0x0000A60200A29979 AS DateTime), N'P', NULL, N'C')
SET IDENTITY_INSERT [dbo].[BookingDetails] OFF
/****** Object:  Default [DF_Venue_Createdate]    Script Date: 05/10/2016 09:59:50 ******/
ALTER TABLE [dbo].[Venue] ADD  CONSTRAINT [DF_Venue_Createdate]  DEFAULT (getdate()) FOR [Createdate]
GO
/****** Object:  Default [DF_Light_Createdate]    Script Date: 05/10/2016 09:59:50 ******/
ALTER TABLE [dbo].[Light] ADD  CONSTRAINT [DF_Light_Createdate]  DEFAULT (getdate()) FOR [Createdate]
GO
/****** Object:  Default [DF_Food_Createdate]    Script Date: 05/10/2016 09:59:50 ******/
ALTER TABLE [dbo].[Food] ADD  CONSTRAINT [DF_Food_Createdate]  DEFAULT (getdate()) FOR [Createdate]
GO
/****** Object:  Default [DF_Flower_Createdate]    Script Date: 05/10/2016 09:59:50 ******/
ALTER TABLE [dbo].[Flower] ADD  CONSTRAINT [DF_Flower_Createdate]  DEFAULT (getdate()) FOR [Createdate]
GO
/****** Object:  Default [DF_Equipment_Createdate]    Script Date: 05/10/2016 09:59:50 ******/
ALTER TABLE [dbo].[Equipment] ADD  CONSTRAINT [DF_Equipment_Createdate]  DEFAULT (getdate()) FOR [Createdate]
GO
