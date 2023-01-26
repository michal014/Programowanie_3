﻿USE [master]
GO
/****** Object:  Database [videoteka]    Script Date: 25.01.2023 17:37:09 ******/
CREATE DATABASE [videoteka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'videoteka', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MB_LOCAL\MSSQL\DATA\videoteka.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'videoteka_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MB_LOCAL\MSSQL\DATA\videoteka_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [videoteka] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [videoteka].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [videoteka] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [videoteka] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [videoteka] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [videoteka] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [videoteka] SET ARITHABORT OFF 
GO
ALTER DATABASE [videoteka] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [videoteka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [videoteka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [videoteka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [videoteka] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [videoteka] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [videoteka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [videoteka] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [videoteka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [videoteka] SET  ENABLE_BROKER 
GO
ALTER DATABASE [videoteka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [videoteka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [videoteka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [videoteka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [videoteka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [videoteka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [videoteka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [videoteka] SET RECOVERY FULL 
GO
ALTER DATABASE [videoteka] SET  MULTI_USER 
GO
ALTER DATABASE [videoteka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [videoteka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [videoteka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [videoteka] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [videoteka] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [videoteka] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'videoteka', N'ON'
GO
ALTER DATABASE [videoteka] SET QUERY_STORE = OFF
GO
USE [videoteka]
GO
/****** Object:  Table [dbo].[content]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[content](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[type] [int] NULL,
	[numberofepisodes] [int] NOT NULL,
	[description] [varchar](2000) NULL,
	[picture] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contentrelation]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contentrelation](
	[contentid] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[rate] [smallint] NOT NULL,
	[progress] [int] NOT NULL,
	[status] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[contentid] ASC,
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contenttype]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contenttype](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genrerelation]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genrerelation](
	[contentid] [int] NOT NULL,
	[genreid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[contentid] ASC,
	[genreid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genres]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genres](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producer]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producerrelation]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producerrelation](
	[contentid] [int] NOT NULL,
	[producerid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[contentid] ASC,
	[producerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 25.01.2023 17:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[isadmin] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[content] ADD  DEFAULT (NULL) FOR [picture]
GO
ALTER TABLE [dbo].[contentrelation] ADD  DEFAULT ((0)) FOR [rate]
GO
ALTER TABLE [dbo].[contentrelation] ADD  DEFAULT ((0)) FOR [progress]
GO
ALTER TABLE [dbo].[contentrelation] ADD  DEFAULT ('w') FOR [status]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [new_always_no_admin]  DEFAULT ((0)) FOR [isadmin]
GO
ALTER TABLE [dbo].[content]  WITH CHECK ADD  CONSTRAINT [fk_content_contenttype] FOREIGN KEY([type])
REFERENCES [dbo].[contenttype] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[content] CHECK CONSTRAINT [fk_content_contenttype]
GO
ALTER TABLE [dbo].[contentrelation]  WITH CHECK ADD FOREIGN KEY([contentid])
REFERENCES [dbo].[content] ([id])
GO
ALTER TABLE [dbo].[contentrelation]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[users] ([ID])
GO
ALTER TABLE [dbo].[genrerelation]  WITH CHECK ADD FOREIGN KEY([contentid])
REFERENCES [dbo].[content] ([id])
GO
ALTER TABLE [dbo].[genrerelation]  WITH CHECK ADD FOREIGN KEY([genreid])
REFERENCES [dbo].[genres] ([id])
GO
ALTER TABLE [dbo].[producerrelation]  WITH CHECK ADD FOREIGN KEY([contentid])
REFERENCES [dbo].[content] ([id])
GO
ALTER TABLE [dbo].[producerrelation]  WITH CHECK ADD FOREIGN KEY([producerid])
REFERENCES [dbo].[producer] ([id])
GO
USE [master]
GO
ALTER DATABASE [videoteka] SET  READ_WRITE 
GO