USE [master]
GO
/****** Object:  Database [[Norbit]]    Script Date: 12/17/2019 2:06:49 PM ******/
CREATE DATABASE [Norbit]
 CONTAINMENT = NONE

 COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER DATABASE [ShilinSupport] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShilinSupport].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Norbit] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Norbit] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Norbit] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Norbit] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Norbit] SET ARITHABORT OFF 
GO
ALTER DATABASE [Norbit] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Norbit] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Norbit] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Norbit] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Norbit] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Norbit] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Norbit] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Norbit] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Norbit] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Norbit] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Norbit] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Norbit] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Norbit] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Norbit] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Norbit] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Norbit] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Norbit] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Norbit] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Norbit] SET  MULTI_USER 
GO
ALTER DATABASE [Norbit] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Norbit] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Norbit] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Norbit] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Norbit] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Norbit] SET QUERY_STORE = OFF
GO
USE [Norbit]
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 12/17/2019 2:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assets](
	[AssetsID] [int] NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[AssetsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 12/17/2019 2:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] NOT NULL,
	[Login] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Phone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Function]    Script Date: 12/17/2019 2:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Function](
	[FunctionID] [int] NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED 
(
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 12/17/2019 2:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] NOT NULL,
	[Description] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClientsID] [int] NOT NULL,
	[WorkerID] [int] NOT NULL,
	[AssetsID] [int] NOT NULL,
	[TypeServiceID] [int] NOT NULL,
	[DateAdd] [date] NULL,
	[DateEnd] [date] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeService]    Script Date: 12/17/2019 2:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeService](
	[TypeServiceID] [int] NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_TypeService] PRIMARY KEY CLUSTERED 
(
	[TypeServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 12/17/2019 2:06:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[WorkerID] [int] NOT NULL,
	[Surname] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IdFunction] [int] NOT NULL,
	[Login] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[WorkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Assets] ([AssetsID], [Name]) VALUES (1, N'Новая')
INSERT [dbo].[Assets] ([AssetsID], [Name]) VALUES (2, N'Отложена')
INSERT [dbo].[Assets] ([AssetsID], [Name]) VALUES (3, N'В процессе')
INSERT [dbo].[Assets] ([AssetsID], [Name]) VALUES (4, N'Выполнена')
INSERT [dbo].[Assets] ([AssetsID], [Name]) VALUES (5, N'Отказано')
INSERT [dbo].[Client] ([ClientID], [Login], [Password], [Phone], [Email]) VALUES (1, N'Uliana', N'Uliana2000', N'8888888', N'Andrey')
INSERT [dbo].[Client] ([ClientID], [Login], [Password], [Phone], [Email]) VALUES (3, N'IVAN', N'IVAN2009', N'988888989', N'IVAN@1.ru')
INSERT [dbo].[Client] ([ClientID], [Login], [Password], [Phone], [Email]) VALUES (10, N'1', N'1', N'1', N'')
INSERT [dbo].[Client] ([ClientID], [Login], [Password], [Phone], [Email]) VALUES (11, N'wdwd', N'ada', N'wdad', N'awd')
INSERT [dbo].[Function] ([FunctionID], [Name]) VALUES (1, N'IT')
INSERT [dbo].[Function] ([FunctionID], [Name]) VALUES (2, N'Consultant')
INSERT [dbo].[Function] ([FunctionID], [Name]) VALUES (3, N'asdasdasd')
INSERT [dbo].[Project] ([ProjectID], [Description], [ClientsID], [WorkerID], [AssetsID], [TypeServiceID], [DateAdd], [DateEnd]) VALUES (1, N'1', 1, 1, 1, 1, CAST(N'2019-11-17' AS Date), CAST(N'2019-11-17' AS Date))
INSERT [dbo].[Project] ([ProjectID], [Description], [ClientsID], [WorkerID], [AssetsID], [TypeServiceID], [DateAdd], [DateEnd]) VALUES (2, N'132', 11, 2, 2, 1, CAST(N'2010-01-12' AS Date), CAST(N'2021-04-08' AS Date))
INSERT [dbo].[TypeService] ([TypeServiceID], [Name]) VALUES (1, N'Починка')
INSERT [dbo].[TypeService] ([TypeServiceID], [Name]) VALUES (2, N'Замена')
INSERT [dbo].[TypeService] ([TypeServiceID], [Name]) VALUES (3, N'Консультация')
INSERT [dbo].[Worker] ([WorkerID], [Surname], [Name], [IdFunction], [Login], [Password]) VALUES (1, N'Manohina', N'Uliana', 1, N'SA', N'SA')
INSERT [dbo].[Worker] ([WorkerID], [Surname], [Name], [IdFunction], [Login], [Password]) VALUES (2, N'Ivanov', N'Ivan', 2, N'SN', N'SN')
INSERT [dbo].[Worker] ([WorkerID], [Surname], [Name], [IdFunction], [Login], [Password]) VALUES (3, N'A', N'A', 1, N'A', N'A')
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Assets] FOREIGN KEY([AssetsID])
REFERENCES [dbo].[Assets] ([AssetsID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Assets]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Client] FOREIGN KEY([ClientsID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Client]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_TypeService] FOREIGN KEY([TypeServiceID])
REFERENCES [dbo].[TypeService] ([TypeServiceID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_TypeService]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Worker] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Worker]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Function] FOREIGN KEY([IdFunction])
REFERENCES [dbo].[Function] ([FunctionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Function]
GO
USE [master]
GO
ALTER DATABASE [Norbit] SET  READ_WRITE 
GO
