USE [kres]
GO
/****** Object:  Table [dbo].[cinsiyet]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cinsiyet](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_cinsiyet] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ders]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ders](
	[d_id] [int] IDENTITY(1,1) NOT NULL,
	[d_adi] [nvarchar](50) NULL,
	[d_aciklama] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donem]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donem](
	[do_id] [int] IDENTITY(1,1) NOT NULL,
	[do_donem] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[duyuru]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[duyuru](
	[dy_id] [int] IDENTITY(1,1) NOT NULL,
	[dy_baslik] [nvarchar](50) NULL,
	[dy_tarih] [nvarchar](50) NULL,
	[dy_donem] [nvarchar](50) NULL,
	[dy_icerik] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[etkinlik]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[etkinlik](
	[e_id] [int] IDENTITY(1,1) NOT NULL,
	[e_baslik] [nvarchar](50) NULL,
	[e_tarih] [nvarchar](50) NULL,
	[e_donem] [nvarchar](50) NULL,
	[e_icerik] [varchar](2500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[muhasebe]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[muhasebe](
	[m_id] [int] IDENTITY(1,1) NOT NULL,
	[m_gelirgider] [nvarchar](50) NULL,
	[m_tarih] [nvarchar](50) NULL,
	[m_tutar] [nvarchar](50) NULL,
	[m_gidert] [nvarchar](50) NULL,
	[m_odemet] [nvarchar](50) NULL,
	[m_donem] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ogrenci]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ogrenci](
	[o_id] [int] IDENTITY(1,1) NOT NULL,
	[o_adsoyad] [nvarchar](50) NULL,
	[o_tc] [nvarchar](50) NULL,
	[o_cinsiyet] [nvarchar](50) NULL,
	[o_sinif] [nvarchar](50) NULL,
	[o_donem] [nvarchar](50) NULL,
	[o_kayittarihi] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ogretmen]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ogretmen](
	[og_id] [int] IDENTITY(1,1) NOT NULL,
	[og_adisoyadi] [nvarchar](50) NULL,
	[og_tc] [nvarchar](50) NULL,
	[og_telno] [nvarchar](50) NULL,
	[og_adres] [nvarchar](50) NULL,
	[og_kadi] [nvarchar](50) NULL,
	[og_sifre] [nvarchar](50) NULL,
	[og_maas] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sinif]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sinif](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_sinif] [nvarchar](50) NULL,
	[s_donem] [nvarchar](50) NULL,
	[s_ogretmen] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[veli]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[veli](
	[v_id] [int] IDENTITY(1,1) NOT NULL,
	[v_adisoyadi] [nvarchar](50) NULL,
	[v_ogadsoyad] [nvarchar](50) NULL,
	[v_telno] [nvarchar](50) NULL,
	[v_adres] [nvarchar](50) NULL,
	[v_kadi] [nvarchar](50) NULL,
	[v_sifre] [nvarchar](50) NULL,
	[v_email] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[yemek]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[yemek](
	[ye_id] [int] IDENTITY(1,1) NOT NULL,
	[ye_donem] [nvarchar](50) NULL,
	[ye_tur1] [nvarchar](50) NULL,
	[ye_tur2] [nvarchar](50) NULL,
	[ye_tarih] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[yonetici]    Script Date: 5.07.2022 09:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[yonetici](
	[y_id] [int] IDENTITY(1,1) NOT NULL,
	[y_kadi] [nchar](30) NULL,
	[y_sifre] [nchar](30) NULL,
 CONSTRAINT [PK_yonetici] PRIMARY KEY CLUSTERED 
(
	[y_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
