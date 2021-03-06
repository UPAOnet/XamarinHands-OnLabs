
USE [BDEventoXamarin]
GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 29/06/2016 10:46:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo](
	[equipo_id] [int] IDENTITY(1,1) NOT NULL,
	[equipo_nombre] [nvarchar](50) NOT NULL,
	[equipo_fundacion] [date] NOT NULL,
	[equipo_entrenador] [nvarchar](40) NOT NULL,
	[equipo_estadio] [nvarchar](50) NOT NULL,
	[equipo_copas] [int] NOT NULL,
 CONSTRAINT [PK_Equipo] PRIMARY KEY CLUSTERED 
(
	[equipo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Jugador]    Script Date: 29/06/2016 10:46:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugador](
	[jugador_id] [int] IDENTITY(1,1) NOT NULL,
	[equipo_id] [int] NOT NULL,
	[jugador_nombre] [nvarchar](50) NOT NULL,
	[jugador_foto] [nvarchar](100) NULL,
	[jugador_fecha] [date] NULL,
	[jugador_equipo] [nvarchar](35) NOT NULL,
	[jugador_posicion] [nvarchar](35) NOT NULL,
	[jugador_edad] [int] NOT NULL,
	[jugador_goles] [int] NULL,
	[jugador_division] [nvarchar](40) NULL,
	[jugador_numero] [int] NULL,
 CONSTRAINT [PK_Jugador] PRIMARY KEY CLUSTERED 
(
	[jugador_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Equipo] ON 

INSERT [dbo].[Equipo] ([equipo_id], [equipo_nombre], [equipo_fundacion], [equipo_entrenador], [equipo_estadio], [equipo_copas]) VALUES (1, N'Selección Peruana', CAST(N'1935-06-15' AS Date), N'Ricardo Gareca', N'Estado Nacional del Perú', 8)
SET IDENTITY_INSERT [dbo].[Equipo] OFF
SET IDENTITY_INSERT [dbo].[Jugador] ON 

INSERT [dbo].[Jugador] ([jugador_id], [equipo_id], [jugador_nombre], [jugador_foto], [jugador_fecha], [jugador_equipo], [jugador_posicion], [jugador_edad], [jugador_goles], [jugador_division], [jugador_numero]) VALUES (1, 1, N'Paolo Guerrero', N'http://thumb.resfu.com/img_data/players/medium/21388.jpg?size=150x&ext=png&lossy=1&1', CAST(N'1982-12-31' AS Date), N'Flamengo', N'Delantero', 32, 28, N'Primera', 9)
INSERT [dbo].[Jugador] ([jugador_id], [equipo_id], [jugador_nombre], [jugador_foto], [jugador_fecha], [jugador_equipo], [jugador_posicion], [jugador_edad], [jugador_goles], [jugador_division], [jugador_numero]) VALUES (2, 1, N'Pedro Gallese', N'http://thumb.resfu.com/img_data/players/medium/241393.jpg?size=60x&ext=png&lossy=1&1', CAST(N'1990-02-23' AS Date), N'Morelia', N'Arquero', 26, 0, N'Primera', 1)
SET IDENTITY_INSERT [dbo].[Jugador] OFF
ALTER TABLE [dbo].[Jugador]  WITH CHECK ADD  CONSTRAINT [FK_Jugador_Equipo] FOREIGN KEY([equipo_id])
REFERENCES [dbo].[Equipo] ([equipo_id])
GO
ALTER TABLE [dbo].[Jugador] CHECK CONSTRAINT [FK_Jugador_Equipo]
GO
