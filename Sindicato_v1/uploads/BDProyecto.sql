USE [RentaCar]
GO
/****** Object:  Table [dbo].[Tbl_Cliente]    Script Date: 11/26/2019 5:42:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Cliente](
	[IdCliente] [int] NOT NULL,
	[Identificacion] [int] NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Apellido1] [varchar](max) NOT NULL,
	[Apellido2] [varchar](max) NULL,
	[Direccion] [varchar](max) NULL,
	[Telefono] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdReserva] [int] NOT NULL,
	[IdVehiculo] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Reserva]    Script Date: 11/26/2019 5:42:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Reserva](
	[IdReserva] [int] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[TipoPago] [varchar](max) NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[FechaDevolucion] [datetime] NOT NULL,
	[Ciudad] [varchar](max) NULL,
	[Monto] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Tbl_Reserva] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario]    Script Date: 11/26/2019 5:42:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario](
	[IdUsuario] [int] NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[Contraseña] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Tbl_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Vehiculo]    Script Date: 11/26/2019 5:42:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Vehiculo](
	[IdVehiculo] [int] NOT NULL,
	[Placa] [varchar](max) NOT NULL,
	[Modelo] [varchar](max) NULL,
	[Marca] [varchar](max) NOT NULL,
	[Kilometraje] [varchar](max) NULL,
	[Color] [varchar](max) NULL,
	[Tipo] [varchar](max) NULL,
	[TipoCombustible] [varchar](max) NULL,
 CONSTRAINT [PK_Tbl_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Cliente_Tbl_Vehiculo] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Tbl_Vehiculo] ([IdVehiculo])
GO
ALTER TABLE [dbo].[Tbl_Cliente] CHECK CONSTRAINT [FK_Tbl_Cliente_Tbl_Vehiculo]
GO
