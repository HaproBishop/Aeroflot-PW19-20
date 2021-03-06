USE [master]
GO
/****** Object:  Database [Aeroflot]    Script Date: 20.04.2022 21:18:02 ******/
CREATE DATABASE [Aeroflot]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Aeroflot', FILENAME = N'W:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Aeroflot.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Aeroflot_log', FILENAME = N'W:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Aeroflot_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Aeroflot] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Aeroflot].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Aeroflot] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Aeroflot] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Aeroflot] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Aeroflot] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Aeroflot] SET ARITHABORT OFF 
GO
ALTER DATABASE [Aeroflot] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Aeroflot] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Aeroflot] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Aeroflot] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Aeroflot] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Aeroflot] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Aeroflot] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Aeroflot] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Aeroflot] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Aeroflot] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Aeroflot] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Aeroflot] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Aeroflot] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Aeroflot] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Aeroflot] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Aeroflot] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Aeroflot] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Aeroflot] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Aeroflot] SET  MULTI_USER 
GO
ALTER DATABASE [Aeroflot] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Aeroflot] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Aeroflot] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Aeroflot] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Aeroflot] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Aeroflot] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Aeroflot] SET QUERY_STORE = OFF
GO
USE [Aeroflot]
GO
/****** Object:  Table [dbo].[Races]    Script Date: 20.04.2022 21:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Races](
	[RaceID] [int] NOT NULL,
	[ArrivePlace] [nvarchar](50) NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[ArriveTime] [time](7) NOT NULL,
	[FreePlaceCount] [int] NOT NULL,
	[AirplaneKind] [nvarchar](50) NOT NULL,
	[AirplaneCapacity] [int] NOT NULL,
 CONSTRAINT [PK_Races] PRIMARY KEY CLUSTERED 
(
	[RaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (1, N'Москва', CAST(N'12:00:00' AS Time), CAST(N'20:00:00' AS Time), 4, N'Региональные', 75)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (2, N'Москва', CAST(N'10:00:00' AS Time), CAST(N'18:00:00' AS Time), 1, N'Региональные', 60)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (3, N'Лондон', CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), 12, N'Широкофюзеляжный ', 400)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (4, N'Лондон', CAST(N'12:00:00' AS Time), CAST(N'00:00:00' AS Time), 9, N'Широкофюзеляжный ', 390)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (5, N'Нью-Йорк', CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time), 2, N'Широкофюзеляжный ', 410)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (6, N'Нью-Йорк', CAST(N'02:00:00' AS Time), CAST(N'12:00:00' AS Time), 12, N'Широкофюзеляжный ', 415)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (7, N'Бразилиа', CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time), 9, N'Широкофюзеляжный ', 400)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (8, N'Канберра', CAST(N'00:00:00' AS Time), CAST(N'01:00:00' AS Time), 6, N'Широкофюзеляжный ', 390)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (9, N'Оттава', CAST(N'02:00:00' AS Time), CAST(N'00:00:00' AS Time), 5, N'Широкофюзеляжный ', 420)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (10, N'Оттава', CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time), 32, N'Широкофюзеляжный ', 400)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (11, N'Вашингтон', CAST(N'02:00:00' AS Time), CAST(N'01:00:00' AS Time), 2, N'Широкофюзеляжный ', 390)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (12, N'Вашингтон', CAST(N'03:00:00' AS Time), CAST(N'04:00:00' AS Time), 1, N'Широкофюзеляжный ', 403)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (13, N'Москва', CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), 4, N'Широкофюзеляжный ', 410)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (14, N'Токио', CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), 3, N'Широкофюзеляжный ', 405)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (15, N'Пекин', CAST(N'11:00:00' AS Time), CAST(N'11:00:00' AS Time), 2, N'Широкофюзеляжный ', 410)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (16, N'Пекин', CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), 12, N'Широкофюзеляжный ', 400)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (17, N'Самара', CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time), 13, N'Региональные', 60)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (18, N'Нижний Новгород', CAST(N'01:00:00' AS Time), CAST(N'00:00:00' AS Time), 12, N'Региональные', 75)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (19, N'Пенза', CAST(N'00:00:00' AS Time), CAST(N'02:00:00' AS Time), 4, N'Региональные', 78)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (20, N'Ульяновск', CAST(N'03:00:00' AS Time), CAST(N'00:00:00' AS Time), 14, N'Региональные', 72)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (21, N'Казань', CAST(N'04:00:00' AS Time), CAST(N'02:00:00' AS Time), 16, N'Региональные', 68)
INSERT [dbo].[Races] ([RaceID], [ArrivePlace], [DepartureTime], [ArriveTime], [FreePlaceCount], [AirplaneKind], [AirplaneCapacity]) VALUES (22, N'Чебоксары', CAST(N'12:00:00' AS Time), CAST(N'04:00:00' AS Time), 12, N'Региональные', 50)
GO
USE [master]
GO
ALTER DATABASE [Aeroflot] SET  READ_WRITE 
GO
