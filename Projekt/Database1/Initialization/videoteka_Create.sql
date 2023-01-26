USE [master]
GO
/****** Object:  Database [videoteka]    Script Date: 26.01.2023 23:48:51 ******/
CREATE DATABASE [videoteka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'videoteka', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MB_LOCAL\MSSQL\DATA\videoteka.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'videoteka_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MB_LOCAL\MSSQL\DATA\videoteka_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[content]    Script Date: 26.01.2023 23:48:51 ******/
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
/****** Object:  Table [dbo].[contentrelation]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contentrelation](
	[contentid] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[rate] [smallint] NOT NULL,
	[progress] [int] NOT NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[contentid] ASC,
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contenttype]    Script Date: 26.01.2023 23:48:51 ******/
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
/****** Object:  Table [dbo].[genrerelation]    Script Date: 26.01.2023 23:48:51 ******/
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
/****** Object:  Table [dbo].[genres]    Script Date: 26.01.2023 23:48:51 ******/
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
/****** Object:  Table [dbo].[producer]    Script Date: 26.01.2023 23:48:51 ******/
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
/****** Object:  Table [dbo].[producerrelation]    Script Date: 26.01.2023 23:48:51 ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 26.01.2023 23:48:51 ******/
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
ALTER TABLE [dbo].[contentrelation] ADD  DEFAULT ((1)) FOR [status]
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
/****** Object:  StoredProcedure [dbo].[Get1contentidbyDesc]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get1contentidbyDesc]
AS
BEGIN
    SELECT id FROM content ORDER BY id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Get1idfromcontenttypebyDesc]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get1idfromcontenttypebyDesc]
AS
BEGIN
    SELECT id FROM contenttype ORDER BY id DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetContentTypeIDByName]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContentTypeIDByName] (@x nvarchar(255))
AS
BEGIN
    SELECT id FROM contenttype WHERE name = @x
END
GO
/****** Object:  StoredProcedure [dbo].[GetGenreIdByName]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGenreIdByName] (@name VARCHAR(255))
AS
BEGIN
    SELECT id FROM genres WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducerIDByName]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducerIDByName] (@name VARCHAR(255))
AS
BEGIN
    SELECT id FROM producer WHERE name=@name;
END

GO
/****** Object:  StoredProcedure [dbo].[InsertContent]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertContent]
    @x VARCHAR(255),
    @y INT,
    @z INT,
    @w VARCHAR(2000),
    @u VARCHAR(MAX)
AS
BEGIN
    INSERT INTO content (name, type, numberofepisodes, description, picture)
    VALUES (@x, @y, @z, @w, @u)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertContenttypeName]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertContenttypeName] (@name varchar(255))
AS
BEGIN
    INSERT INTO contenttype (name) values (@name);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertGenre]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertGenre] (@name varchar(255))
AS
BEGIN
    INSERT INTO genres (name) values (@name);
END;

GO
/****** Object:  StoredProcedure [dbo].[InsertGenrerelation]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertGenrerelation] (@contentid INT, @genreid INT)
AS
BEGIN
    INSERT INTO genrerelation (contentid, genreid)
    VALUES (@contentid, @genreid)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProducer]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProducer] (@name varchar(255))
AS
BEGIN
    INSERT INTO producer (name) values (@name);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertProducerrelation]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProducerrelation] (@contentid int, @producerid int)
AS
BEGIN
    INSERT INTO producerrelation (contentid,producerid) VALUES (@contentid, @producerid)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser] (@login varchar(255), @password varchar(255))
AS
BEGIN
    INSERT INTO users (login,password)
    VALUES (@login, @password)
END
GO
/****** Object:  StoredProcedure [dbo].[ListShow]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListShow]
AS
BEGIN
    SELECT content.id as 'id',
           content.name AS 'name',
           contenttype.name AS 'type',
           content.numberofepisodes AS 'episodes',
           table1.producers AS 'producer',
           table2.genres AS 'genre',
           content.picture AS 'picture'
    FROM content
    JOIN contenttype
    ON content.type = contenttype.id
    JOIN (SELECT producerrelation.contentid, 
                 STRING_AGG(producer.name, '; ') AS 'producers'
          FROM producerrelation
          JOIN producer
          ON producerrelation.producerid = producer.id
          GROUP BY producerrelation.contentid) AS table1
    ON table1.contentID = content.id
    JOIN (SELECT genrerelation.contentid,
                 STRING_AGG(genres.name, '; ') AS 'genres'
          FROM genrerelation
          JOIN genres
          ON genrerelation.genreid = genres.id
          GROUP BY genrerelation.contentid) AS table2
    ON table2.contentID = content.id
    ORDER BY content.name ASC;
END

GO
/****** Object:  StoredProcedure [dbo].[LoginCheck]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginCheck] (@login varchar(255), @password varchar(255))
AS
BEGIN
    SELECT ID, isadmin FROM users
    WHERE login = @login AND password = @password
END
GO
/****** Object:  StoredProcedure [dbo].[MyListShow]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MyListShow] (@user_id INT)
AS
BEGIN
    SELECT  content.id AS 'id',
            content.name AS 'name',
            contenttype.name AS 'type',
            table1.progress AS 'progress',
            contentrelation.rate AS 'score',
            content.picture AS 'picture'
    FROM content
    JOIN contenttype
    ON content.type = contenttype.id
    JOIN contentrelation
    ON content.id = contentrelation.contentid
    JOIN users
    ON contentrelation.userid = users.id
    JOIN (SELECT content.id AS 'id',
                users.id AS 'uid',
                CONCAT(contentrelation.progress,'/',content.numberofepisodes) AS 'progress'
         FROM content
         JOIN contentrelation
         ON content.id = contentrelation.contentid
         JOIN users
         ON users.ID = contentrelation.userid) AS table1
    ON table1.id = contentrelation.contentid 
    AND table1.uid = contentrelation.userid
    WHERE users.ID = @user_id;
END

GO
/****** Object:  StoredProcedure [dbo].[ShowList]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowList] (@content_id INT)
AS
BEGIN
    SELECT content.id AS 'id',
           content.name AS 'name',
           content.description AS 'description',
           table1.allscore AS 'allscore',
           content.numberofepisodes AS 'numberOfEpisodes',
           table2.genres AS 'genre',
           table3.producers AS 'producer',
           content.picture AS 'picture'
    FROM content
    JOIN (SELECT content.id AS 'id', AVG(ISNULL(contentrelation.rate, 0)) AS 'allscore'
          FROM content
          LEFT JOIN contentrelation ON content.id = contentrelation.contentid
          GROUP BY content.id) AS table1
    ON table1.id = content.id
    JOIN (SELECT genrerelation.contentid,
                 STRING_AGG(genres.name, '; ') AS 'genres'
          FROM genrerelation
          JOIN genres
          ON genrerelation.genreid = genres.id
          GROUP BY genrerelation.contentid) AS table2
    ON table2.contentID = content.id
    JOIN (SELECT producerrelation.contentid, 
                 STRING_AGG(producer.name, '; ') AS 'producers'
          FROM producerrelation
          JOIN producer
          ON producerrelation.producerid = producer.id
          GROUP BY producerrelation.contentid) AS table3
    ON table3.contentID = content.id
    WHERE content.id = @content_id;
END;

GO
/****** Object:  StoredProcedure [dbo].[ShowMyList]    Script Date: 26.01.2023 23:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowMyList] (@content_id INT, @user_id INT)
AS
BEGIN
    SELECT content.id AS 'id',
           content.name AS 'name',
           content.description AS 'description',
           table1.allscore AS 'allscore',
           content.numberofepisodes AS 'numberOfEpisodes',
           contentrelation.progress AS 'episodeProgress',
           contentrelation.rate AS 'score',
           table2.genres AS 'genre',
           table3.producers AS 'producer',
           contentrelation.status AS 'idAdded',
           content.picture AS 'picture'
    FROM content
    JOIN (SELECT content.id AS 'id', AVG(ISNULL(contentrelation.rate, 0)) AS 'allscore'
              FROM content
              LEFT JOIN contentrelation ON content.id = contentrelation.contentid
              GROUP BY content.id) AS table1
    ON table1.id = content.id
    JOIN (SELECT genrerelation.contentid,
                 STRING_AGG(genres.name, '; ') AS 'genres'
          FROM genrerelation
          JOIN genres
          ON genrerelation.genreid = genres.id
          GROUP BY genrerelation.contentid) AS table2
    ON table2.contentID = content.id
    JOIN (SELECT producerrelation.contentid, 
                 STRING_AGG(producer.name, '; ') AS 'producers'
          FROM producerrelation
          JOIN producer
          ON producerrelation.producerid = producer.id
          GROUP BY producerrelation.contentid) AS table3
    ON table3.contentID = content.id
    JOIN contentrelation
    ON contentrelation.contentid=content.id
    JOIN users
    ON users.ID=contentrelation.userid
    WHERE content.id = @content_id AND users.ID = @user_id
END;

GO
USE [master]
GO
ALTER DATABASE [videoteka] SET  READ_WRITE 
GO
