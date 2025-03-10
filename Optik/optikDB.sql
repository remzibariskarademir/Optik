USE [master]
GO
/****** Object:  Database [optikOkumaDB]    Script Date: 1.02.2023 16:22:07 ******/
CREATE DATABASE [optikOkumaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'optikOkumaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\optikOkumaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'optikOkumaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\optikOkumaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [optikOkumaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [optikOkumaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [optikOkumaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [optikOkumaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [optikOkumaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [optikOkumaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [optikOkumaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [optikOkumaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [optikOkumaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [optikOkumaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [optikOkumaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [optikOkumaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [optikOkumaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [optikOkumaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [optikOkumaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [optikOkumaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [optikOkumaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [optikOkumaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [optikOkumaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [optikOkumaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [optikOkumaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [optikOkumaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [optikOkumaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [optikOkumaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [optikOkumaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [optikOkumaDB] SET  MULTI_USER 
GO
ALTER DATABASE [optikOkumaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [optikOkumaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [optikOkumaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [optikOkumaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [optikOkumaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [optikOkumaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'optikOkumaDB', N'ON'
GO
ALTER DATABASE [optikOkumaDB] SET QUERY_STORE = OFF
GO
USE [optikOkumaDB]
GO
/****** Object:  Table [dbo].[booklettype]    Script Date: 1.02.2023 16:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booklettype](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[bookletname] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[department]    Script Date: 1.02.2023 16:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[depname] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 1.02.2023 16:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamTypes](
	[exTypeId] [int] IDENTITY(1,1) NOT NULL,
	[exType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[exTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 1.02.2023 16:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 1.02.2023 16:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[statusId] [int] IDENTITY(1,1) NOT NULL,
	[statusName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1.02.2023 16:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[surname] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](11) NULL,
	[statusId] [int] NOT NULL,
	[FirstActivition] [int] NOT NULL,
	[answer] [nvarchar](50) NULL,
	[question] [nvarchar](100) NULL,
	[active] [int] NULL,
 CONSTRAINT [PK__Users__C5B196621AC612D8] PRIMARY KEY CLUSTERED 
(
	[UId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[booklettype] ON 

INSERT [dbo].[booklettype] ([Id], [bookletname]) VALUES (1, N'A')
INSERT [dbo].[booklettype] ([Id], [bookletname]) VALUES (2, N'A B')
INSERT [dbo].[booklettype] ([Id], [bookletname]) VALUES (3, N'A B C')
INSERT [dbo].[booklettype] ([Id], [bookletname]) VALUES (4, N'A B C D')
SET IDENTITY_INSERT [dbo].[booklettype] OFF
GO
SET IDENTITY_INSERT [dbo].[department] ON 

INSERT [dbo].[department] ([Id], [depname]) VALUES (1, N'BİLGİSAYAR PROGRAMCILIĞI')
INSERT [dbo].[department] ([Id], [depname]) VALUES (2, N'ÇOCUK GELİŞİM')
INSERT [dbo].[department] ([Id], [depname]) VALUES (3, N'DIŞ TİCARET')
INSERT [dbo].[department] ([Id], [depname]) VALUES (4, N'ÖZEL GÜVENLİK VE KORUMA')
INSERT [dbo].[department] ([Id], [depname]) VALUES (5, N'MODA TASARIM')
INSERT [dbo].[department] ([Id], [depname]) VALUES (6, N'DERİ KONFEKSİYON')
INSERT [dbo].[department] ([Id], [depname]) VALUES (7, N'EMLAK YÖNETİM')
INSERT [dbo].[department] ([Id], [depname]) VALUES (8, N'PAZARLAMA')
INSERT [dbo].[department] ([Id], [depname]) VALUES (9, N'YEREL YÖNETİMLER')
SET IDENTITY_INSERT [dbo].[department] OFF
GO
SET IDENTITY_INSERT [dbo].[ExamTypes] ON 

INSERT [dbo].[ExamTypes] ([exTypeId], [exType]) VALUES (1, N'Vize')
INSERT [dbo].[ExamTypes] ([exTypeId], [exType]) VALUES (2, N'Final')
INSERT [dbo].[ExamTypes] ([exTypeId], [exType]) VALUES (3, N'Bütünleme')
INSERT [dbo].[ExamTypes] ([exTypeId], [exType]) VALUES (4, N'Muafiyet')
INSERT [dbo].[ExamTypes] ([exTypeId], [exType]) VALUES (5, N'Ek-Sınav')
SET IDENTITY_INSERT [dbo].[ExamTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [Question]) VALUES (1, N'En sevdiğiniz hayvan ?')
INSERT [dbo].[Question] ([Id], [Question]) VALUES (2, N'En sevdiğiniz şehir ?')
INSERT [dbo].[Question] ([Id], [Question]) VALUES (3, N'En sevdiğiniz isim ?')
INSERT [dbo].[Question] ([Id], [Question]) VALUES (4, N'En sevdiğiniz renk ?')
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([statusId], [statusName]) VALUES (1, N'Admin')
INSERT [dbo].[Status] ([statusId], [statusName]) VALUES (2, N'Kullanıcı')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (1, N'admin', N'admin', N'81dc9bdb52d04dc20036dbd8313ed055', N'admin', N'123456789', 1, 0, N'köpek', N'En sevdiğiniz renk', 1)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (2, N'kullanıcı', N'kullanıcı', N'81dc9bdb52d04dc20036dbd8313ed055', N'kullanıcı', N'123456789', 2, 0, N'köpek', N'En sevdiğiniz renk', 1)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (3, N'kullanıcı2', N'kullanıcı2', N'81dc9bdb52d04dc20036dbd8313ed055', N'kullanıcı2', N'123456789', 2, 1, N'köpek', N'En sevdiğiniz renk', 1)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (4, N'kullanıcı3', N'kullanıcı3', N'81dc9bdb52d04dc20036dbd8313ed055', N'kullanıcı3', N'123456789', 2, 0, N'köpek', N'En sevdiğiniz renk', 1)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (5, N'deneme', N'deneme', N'81dc9bdb52d04dc20036dbd8313ed055', N'deneme', N'123456789', 2, 1, N'köpek', N'En sevdiğiniz renk ?', 0)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (6, N'deneme2', N'deneme2', N'81dc9bdb52d04dc20036dbd8313ed055', N'deneme2', N'123456789', 2, 0, NULL, NULL, 1)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (10, N'deneme3', N'deneme3', N'81dc9bdb52d04dc20036dbd8313ed055', N'deneme3', N'123456789', 2, 1, NULL, NULL, 0)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (11, N'Ömer Faruk', N'Moz', N'81dc9bdb52d04dc20036dbd8313ed055', N'omerfarukmoz@hotmail.com', N'05422519973', 2, 1, N'8dc46002f01ad2025123ad7b3c492202', N'En sevdiğiniz hayvan ?', 0)
INSERT [dbo].[Users] ([UId], [name], [surname], [password], [email], [phone], [statusId], [FirstActivition], [answer], [question], [active]) VALUES (12, N'Merve Nur', N'Doğrul', N'81dc9bdb52d04dc20036dbd8313ed055', N'mervedogrul7@gmail.com', N'12345678901', 2, 1, N'9a9192f7d647d812542d95d9225bc167', N'En sevdiğiniz hayvan ?', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_statusId_Users] FOREIGN KEY([statusId])
REFERENCES [dbo].[Status] ([statusId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_statusId_Users]
GO
USE [master]
GO
ALTER DATABASE [optikOkumaDB] SET  READ_WRITE 
GO
