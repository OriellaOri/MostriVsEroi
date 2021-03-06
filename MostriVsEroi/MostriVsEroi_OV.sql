USE [master]
GO
/****** Object:  Database [MostriVsEroi]    Script Date: 18/06/2021 09:05:03 ******/
CREATE DATABASE [MostriVsEroi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MostriVsEroi', FILENAME = N'C:\Users\Utente\MostriVsEroi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MostriVsEroi_log', FILENAME = N'C:\Users\Utente\MostriVsEroi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MostriVsEroi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MostriVsEroi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ARITHABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MostriVsEroi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MostriVsEroi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MostriVsEroi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET  MULTI_USER 
GO
ALTER DATABASE [MostriVsEroi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MostriVsEroi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MostriVsEroi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MostriVsEroi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MostriVsEroi] SET QUERY_STORE = OFF
GO
USE [MostriVsEroi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MostriVsEroi]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategorieEroi]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorieEroi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livelli]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livelli](
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
 CONSTRAINT [PK_Livelli_1] PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArmiEroi]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArmiEroi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Danno] [int] NOT NULL,
	[IdCategoriaEroe] [int] NOT NULL,
 CONSTRAINT [PK_Armi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroi]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[IdCategoriaEroe] [int] NOT NULL,
	[IdLivello] [int] NOT NULL,
	[PuntiEsperienza] [int] NOT NULL,
	[IdUtente] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
 CONSTRAINT [PK_Eroi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UtentiConEroi]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UtentiConEroi]
AS
SELECT        TOP (100) PERCENT dbo.Utenti.Username, dbo.Utenti.IsAdmin, dbo.Eroi.Nome AS Eroe, dbo.CategorieEroi.Nome AS Categoria, dbo.Livelli.Livello, dbo.Livelli.PuntiVita, dbo.ArmiEroi.Nome AS Arma, dbo.ArmiEroi.Danno, 
                         dbo.Eroi.PuntiEsperienza AS Esperienza
FROM            dbo.Utenti LEFT OUTER JOIN
                         dbo.Eroi ON dbo.Utenti.Id = dbo.Eroi.IdUtente LEFT OUTER JOIN
                         dbo.CategorieEroi ON dbo.Eroi.IdCategoriaEroe = dbo.CategorieEroi.Id LEFT OUTER JOIN
                         dbo.Livelli ON dbo.Eroi.IdLivello = dbo.Livelli.Livello LEFT OUTER JOIN
                         dbo.ArmiEroi ON dbo.Eroi.IdArma = dbo.ArmiEroi.Id AND dbo.CategorieEroi.Id = dbo.ArmiEroi.IdCategoriaEroe
ORDER BY dbo.Utenti.Username
GO
/****** Object:  Table [dbo].[CategorieMostri]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorieMostri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CategorieMostri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArmiMostri]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArmiMostri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Danno] [int] NOT NULL,
	[IdCategoriaMostro] [int] NOT NULL,
 CONSTRAINT [PK_ArmiMostri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostri]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[IdLivello] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[IdCategoriaMostri] [int] NOT NULL,
 CONSTRAINT [PK_Mostri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ListaMostri]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ListaMostri]
AS
SELECT        dbo.Mostri.Nome, dbo.CategorieMostri.Nome AS Categoria, dbo.Livelli.Livello, dbo.Livelli.PuntiVita, dbo.ArmiMostri.Nome AS Arma, dbo.ArmiMostri.Danno
FROM            dbo.Mostri INNER JOIN
                         dbo.Livelli ON dbo.Mostri.IdLivello = dbo.Livelli.Livello INNER JOIN
                         dbo.CategorieMostri ON dbo.Mostri.IdCategoriaMostri = dbo.CategorieMostri.Id INNER JOIN
                         dbo.ArmiMostri ON dbo.Mostri.IdArma = dbo.ArmiMostri.Id AND dbo.CategorieMostri.Id = dbo.ArmiMostri.IdCategoriaMostro
GO
/****** Object:  View [dbo].[ArmiPerCategoriaEroe]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArmiPerCategoriaEroe]
AS
SELECT        dbo.ArmiEroi.Id, dbo.ArmiEroi.Nome, dbo.ArmiEroi.Danno, dbo.CategorieEroi.Nome AS CategoriaEroe
FROM            dbo.ArmiEroi INNER JOIN
                         dbo.CategorieEroi ON dbo.ArmiEroi.IdCategoriaEroe = dbo.CategorieEroi.Id
GO
/****** Object:  View [dbo].[ArmiPerCategoriaMostro]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArmiPerCategoriaMostro]
AS
SELECT        dbo.ArmiMostri.Id, dbo.ArmiMostri.Nome, dbo.ArmiMostri.Danno, dbo.CategorieMostri.Nome AS CategoriaMostro
FROM            dbo.ArmiMostri INNER JOIN
                         dbo.CategorieMostri ON dbo.ArmiMostri.IdCategoriaMostro = dbo.CategorieMostri.Id
GO
/****** Object:  View [dbo].[EroiTop10]    Script Date: 18/06/2021 09:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EroiTop10]
AS
SELECT        TOP (10) Eroe, Categoria, Livello, Esperienza, Username
FROM            dbo.UtentiConEroi
ORDER BY Livello DESC, Esperienza DESC
GO
SET IDENTITY_INSERT [dbo].[ArmiEroi] ON 

INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (1, N'Alabarda', 15, 1)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (2, N'Ascia', 5, 1)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (3, N'Mazza', 5, 1)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (4, N'Spada', 10, 1)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (5, N'Spadone', 15, 1)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (6, N'Arco e Freccia', 8, 2)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (7, N'Bacchetta', 5, 2)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (8, N'Bastone Magico', 10, 2)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (9, N'Onda D''Urto', 15, 2)
INSERT [dbo].[ArmiEroi] ([Id], [Nome], [Danno], [IdCategoriaEroe]) VALUES (10, N'Pugnale', 5, 2)
SET IDENTITY_INSERT [dbo].[ArmiEroi] OFF
GO
SET IDENTITY_INSERT [dbo].[ArmiMostri] ON 

INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (1, N'Discorso Noioso', 4, 1)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (2, N'Farneticazione', 7, 1)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (3, N'Imprecazione', 5, 1)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (4, N'Magia Nera', 3, 1)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (5, N'Arco', 7, 2)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (6, N'Clava', 5, 2)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (7, N'Spada Rotta', 3, 2)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (8, N'Mazza Chiodata', 10, 2)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (9, N'Alabarda del Drago', 30, 3)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (10, N'Divinazione', 15, 3)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (11, N'Fulmine', 10, 3)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (12, N'Fulmine Celeste', 15, 3)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (13, N'Tempesta', 6, 3)
INSERT [dbo].[ArmiMostri] ([Id], [Nome], [Danno], [IdCategoriaMostro]) VALUES (14, N'Tempesta Oscura', 15, 3)
SET IDENTITY_INSERT [dbo].[ArmiMostri] OFF
GO
SET IDENTITY_INSERT [dbo].[CategorieEroi] ON 

INSERT [dbo].[CategorieEroi] ([Id], [Nome]) VALUES (1, N'Guerriero')
INSERT [dbo].[CategorieEroi] ([Id], [Nome]) VALUES (2, N'Mago')
SET IDENTITY_INSERT [dbo].[CategorieEroi] OFF
GO
SET IDENTITY_INSERT [dbo].[CategorieMostri] ON 

INSERT [dbo].[CategorieMostri] ([Id], [Nome]) VALUES (1, N'Cultista')
INSERT [dbo].[CategorieMostri] ([Id], [Nome]) VALUES (2, N'Orco')
INSERT [dbo].[CategorieMostri] ([Id], [Nome]) VALUES (3, N'Signore Del Male')
SET IDENTITY_INSERT [dbo].[CategorieMostri] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroi] ON 

INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (2, N'Ermione', 2, 3, 40, 1, 9)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (3, N'Angel', 1, 4, 0, 2, 2)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (6, N'Ron', 2, 2, 0, 2, 7)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (8, N'Arya', 1, 1, 0, 6, 4)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (9, N'Pollock', 2, 2, 31, 5, 8)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (10, N'Maddy00', 1, 1, 0, 7, 2)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (1007, N'Mun', 2, 5, 0, 3, 8)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (1008, N'GattoPardo', 1, 2, 0, 4, 3)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (1009, N'Rick', 1, 5, 123, 4, 1)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (1010, N'Morty', 2, 3, 50, 4, 10)
INSERT [dbo].[Eroi] ([Id], [Nome], [IdCategoriaEroe], [IdLivello], [PuntiEsperienza], [IdUtente], [IdArma]) VALUES (1011, N'Beth', 1, 4, 91, 4, 5)
SET IDENTITY_INSERT [dbo].[Eroi] OFF
GO
INSERT [dbo].[Livelli] ([Livello], [PuntiVita]) VALUES (1, 20)
INSERT [dbo].[Livelli] ([Livello], [PuntiVita]) VALUES (2, 40)
INSERT [dbo].[Livelli] ([Livello], [PuntiVita]) VALUES (3, 60)
INSERT [dbo].[Livelli] ([Livello], [PuntiVita]) VALUES (4, 80)
INSERT [dbo].[Livelli] ([Livello], [PuntiVita]) VALUES (5, 100)
GO
SET IDENTITY_INSERT [dbo].[Mostri] ON 

INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (1, N'Ronny', 1, 3, 1)
INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (2, N'Bella Trix', 2, 11, 3)
INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (3, N'Renato', 3, 5, 2)
INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (4, N'Malfoy', 4, 14, 3)
INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (5, N'Asterix', 5, 8, 2)
INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (6, N'Pavone', 1, 7, 2)
INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (7, N'Sole', 5, 11, 3)
INSERT [dbo].[Mostri] ([Id], [Nome], [IdLivello], [IdArma], [IdCategoriaMostri]) VALUES (8, N'Ursula', 1, 7, 2)
SET IDENTITY_INSERT [dbo].[Mostri] OFF
GO
SET IDENTITY_INSERT [dbo].[Utenti] ON 

INSERT [dbo].[Utenti] ([Id], [Username], [Password], [IsAdmin]) VALUES (1, N'OriellaOri', N'123', 1)
INSERT [dbo].[Utenti] ([Id], [Username], [Password], [IsAdmin]) VALUES (2, N'Gabriel', N'123', 0)
INSERT [dbo].[Utenti] ([Id], [Username], [Password], [IsAdmin]) VALUES (3, N'Lindet', N'123', 1)
INSERT [dbo].[Utenti] ([Id], [Username], [Password], [IsAdmin]) VALUES (4, N'Test', N'test', 1)
INSERT [dbo].[Utenti] ([Id], [Username], [Password], [IsAdmin]) VALUES (5, N'IlNox', N'pass', 0)
INSERT [dbo].[Utenti] ([Id], [Username], [Password], [IsAdmin]) VALUES (6, N'Ari21', N'123', 0)
INSERT [dbo].[Utenti] ([Id], [Username], [Password], [IsAdmin]) VALUES (7, N'Maddy', N'qwerty', 0)
SET IDENTITY_INSERT [dbo].[Utenti] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UtenteENomeEroeNONsiRipetono]    Script Date: 18/06/2021 09:05:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UtenteENomeEroeNONsiRipetono] ON [dbo].[Eroi]
(
	[IdUtente] ASC,
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Eroi] ADD  CONSTRAINT [DF_Eroi_IdLivello]  DEFAULT ((1)) FOR [IdLivello]
GO
ALTER TABLE [dbo].[Eroi] ADD  CONSTRAINT [DF_Eroi_PuntiEsperienza]  DEFAULT ((0)) FOR [PuntiEsperienza]
GO
ALTER TABLE [dbo].[Utenti] ADD  CONSTRAINT [DF_Utenti_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[ArmiEroi]  WITH CHECK ADD  CONSTRAINT [FK_ArmiEroi_CategorieEroi] FOREIGN KEY([IdCategoriaEroe])
REFERENCES [dbo].[CategorieEroi] ([Id])
GO
ALTER TABLE [dbo].[ArmiEroi] CHECK CONSTRAINT [FK_ArmiEroi_CategorieEroi]
GO
ALTER TABLE [dbo].[ArmiMostri]  WITH CHECK ADD  CONSTRAINT [FK_ArmiMostri_CategorieMostri] FOREIGN KEY([IdCategoriaMostro])
REFERENCES [dbo].[CategorieMostri] ([Id])
GO
ALTER TABLE [dbo].[ArmiMostri] CHECK CONSTRAINT [FK_ArmiMostri_CategorieMostri]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_ArmiEroi] FOREIGN KEY([IdArma])
REFERENCES [dbo].[ArmiEroi] ([Id])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_ArmiEroi]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_CategorieEroi] FOREIGN KEY([IdCategoriaEroe])
REFERENCES [dbo].[CategorieEroi] ([Id])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_CategorieEroi]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Livelli1] FOREIGN KEY([IdLivello])
REFERENCES [dbo].[Livelli] ([Livello])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Livelli1]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Utenti] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utenti] ([Id])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Utenti]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_ArmiMostri] FOREIGN KEY([IdArma])
REFERENCES [dbo].[ArmiMostri] ([Id])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_ArmiMostri]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_CategorieMostri] FOREIGN KEY([IdCategoriaMostri])
REFERENCES [dbo].[CategorieMostri] ([Id])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_CategorieMostri]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_Livelli1] FOREIGN KEY([IdLivello])
REFERENCES [dbo].[Livelli] ([Livello])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_Livelli1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[34] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ArmiEroi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CategorieEroi"
            Begin Extent = 
               Top = 56
               Left = 310
               Bottom = 152
               Right = 480
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiPerCategoriaEroe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiPerCategoriaEroe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ArmiMostri"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CategorieMostri"
            Begin Extent = 
               Top = 56
               Left = 324
               Bottom = 152
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 915
         Width = 1500
         Width = 1020
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiPerCategoriaMostro'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiPerCategoriaMostro'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UtentiConEroi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiTop10'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiTop10'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[16] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Mostri_1"
            Begin Extent = 
               Top = 143
               Left = 28
               Bottom = 273
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Livelli"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 102
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CategorieMostri"
            Begin Extent = 
               Top = 232
               Left = 600
               Bottom = 328
               Right = 770
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArmiMostri"
            Begin Extent = 
               Top = 113
               Left = 379
               Bottom = 243
               Right = 567
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ListaMostri'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ListaMostri'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ListaMostri'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Utenti"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Eroi"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CategorieEroi"
            Begin Extent = 
               Top = 6
               Left = 457
               Bottom = 102
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Livelli"
            Begin Extent = 
               Top = 151
               Left = 509
               Bottom = 247
               Right = 679
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArmiEroi"
            Begin Extent = 
               Top = 89
               Left = 773
               Bottom = 219
               Right = 946
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtentiConEroi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtentiConEroi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtentiConEroi'
GO
USE [master]
GO
ALTER DATABASE [MostriVsEroi] SET  READ_WRITE 
GO
