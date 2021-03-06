USE [SII_DB]
GO
/****** Object:  Table [dbo].[Tbl_Acta]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Acta](
	[id_Acta] [int] IDENTITY(1,1) NOT NULL,
	[tipo_Acta] [varchar](50) NOT NULL,
	[fecha_Cre] [date] NOT NULL,
	[ubicacion] [varchar](300) NOT NULL,
 CONSTRAINT [t_acta_pk] PRIMARY KEY CLUSTERED 
(
	[id_Acta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Acta_Usuario]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Acta_Usuario](
	[id_A_U] [int] IDENTITY(1,1) NOT NULL,
	[id_Acta] [int] NOT NULL,
	[id_Usuario] [int] NOT NULL,
 CONSTRAINT [t_ac_usu_pk] PRIMARY KEY CLUSTERED 
(
	[id_A_U] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Agremiado]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Agremiado](
	[id_Agremiado] [int] IDENTITY(1,1) NOT NULL,
	[id_Usuario] [int] NOT NULL,
	[profesion] [varchar](150) NOT NULL,
	[colegio_Profesional] [varchar](150) NOT NULL,
	[puesto] [varchar](50) NOT NULL,
	[afiliado] [int] NOT NULL,
	[grado_Academico] [varchar](50) NOT NULL,
	[id_LugarTrabajo] [int] NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_agremiado1_pk] PRIMARY KEY CLUSTERED 
(
	[id_Agremiado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Bit_Ingreso]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Bit_Ingreso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [bigint] NULL,
	[hora] [datetime] NULL,
	[rol] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Compania]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Compania](
	[id_Compania] [int] IDENTITY(1,1) NOT NULL,
	[razon_Social] [varchar](100) NOT NULL,
	[cedula_Juridica] [int] NOT NULL,
	[nom_Compania] [varchar](100) NOT NULL,
	[direccion] [varchar](200) NOT NULL,
	[telefono] [int] NOT NULL,
	[correo_Electronico] [varchar](80) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_compania_pk] PRIMARY KEY CLUSTERED 
(
	[id_Compania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Deduccion]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Deduccion](
	[id_Deduccion] [int] IDENTITY(1,1) NOT NULL,
	[fecha_Deduccion] [date] NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
	[id_Agremiado] [int] NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_deduccion_pk] PRIMARY KEY CLUSTERED 
(
	[id_Deduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Departamento]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Departamento](
	[id_Departamento] [int] IDENTITY(1,1) NOT NULL,
	[departamento] [varchar](80) NOT NULL,
	[id_Compania] [int] NOT NULL,
	[ubicacion] [varchar](50) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_departamento_pk] PRIMARY KEY CLUSTERED 
(
	[id_Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Empleado]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Empleado](
	[id_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[cargo] [varchar](80) NOT NULL,
	[superior_Inmediato] [varchar](100) NOT NULL,
	[id_LugarTrabajo] [int] NOT NULL,
	[id_Usuario] [int] NOT NULL,
	[estado] [int] NOT NULL,
	[total_Vacaciones] [int] NULL,
	[cant_AusenciasJustificadas] [int] NULL,
	[cant_AusenciasInjustificadas] [int] NULL,
	[vac_Utilizadas] [int] NULL,
	[vac_Restantes] [int] NULL,
 CONSTRAINT [t_empleado_pk] PRIMARY KEY CLUSTERED 
(
	[id_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_EstadoCivil]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_EstadoCivil](
	[id_ECivil] [int] IDENTITY(1,1) NOT NULL,
	[estado_Civil] [varchar](50) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_ecivil_pk] PRIMARY KEY CLUSTERED 
(
	[id_ECivil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Gestion]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Gestion](
	[id_Gestion] [int] IDENTITY(1,1) NOT NULL,
	[motivo] [varchar](150) NULL,
	[fecha_Inicio] [date] NULL,
	[fecha_Fin] [date] NULL,
	[id_Empleado] [int] NOT NULL,
	[id_TipoGestion] [int] NOT NULL,
	[estado] [int] NOT NULL,
	[fecha_Ausencia] [date] NULL,
 CONSTRAINT [t_gestion_pk] PRIMARY KEY CLUSTERED 
(
	[id_Gestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Pais]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Pais](
	[id_Pais] [int] IDENTITY(1,1) NOT NULL,
	[country_code] [varchar](2) NOT NULL,
	[country_name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Persona]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Persona](
	[id_Persona] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [bigint] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[primer_Apellido] [varchar](50) NOT NULL,
	[segundo_Apellido] [varchar](50) NOT NULL,
	[genero] [varchar](50) NOT NULL,
	[nacionalidad] [int] NOT NULL,
	[id_ECivil] [int] NOT NULL,
	[fecha_Nac] [date] NOT NULL,
	[fecha_Reg] [date] NOT NULL,
	[telefono] [int] NOT NULL,
	[direccion] [varchar](200) NOT NULL,
	[correo_Electronico] [varchar](100) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_Persona_pk] PRIMARY KEY CLUSTERED 
(
	[id_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Rol]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Rol](
	[id_Rol] [int] IDENTITY(1,1) NOT NULL,
	[tipo_Rol] [varchar](50) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_rol_pk] PRIMARY KEY CLUSTERED 
(
	[id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_TipoGestion]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TipoGestion](
	[id_TipoGestion] [int] IDENTITY(1,1) NOT NULL,
	[tipo_Gestion] [varchar](50) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_tgestion_pk] PRIMARY KEY CLUSTERED 
(
	[id_TipoGestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_TipoUsuario]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TipoUsuario](
	[id_TipoUsu] [int] IDENTITY(1,1) NOT NULL,
	[tipo_Usuario] [varchar](50) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [t_usuario_pk] PRIMARY KEY CLUSTERED 
(
	[id_TipoUsu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario]    Script Date: 10/12/2019 13:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario](
	[id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_Persona] [int] NOT NULL,
	[contrasenia] [varchar](1000) NULL,
	[id_Rol] [int] NOT NULL,
	[id_TipoUsu] [int] NOT NULL,
	[estado] [int] NOT NULL,
	[token_recovery] [varchar](200) NULL,
 CONSTRAINT [t_usuario3_pk] PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Agremiado] ON 

INSERT [dbo].[Tbl_Agremiado] ([id_Agremiado], [id_Usuario], [profesion], [colegio_Profesional], [puesto], [afiliado], [grado_Academico], [id_LugarTrabajo], [estado]) VALUES (1, 1036, N'Doctor', N'Colegio Flores', N'Enfermera', 0, N'Bachillerato', 1, 1)
INSERT [dbo].[Tbl_Agremiado] ([id_Agremiado], [id_Usuario], [profesion], [colegio_Profesional], [puesto], [afiliado], [grado_Academico], [id_LugarTrabajo], [estado]) VALUES (2, 1038, N'Secretaria', N'San José', N'Secretaria', 0, N'Primaria', 1, 1)
INSERT [dbo].[Tbl_Agremiado] ([id_Agremiado], [id_Usuario], [profesion], [colegio_Profesional], [puesto], [afiliado], [grado_Academico], [id_LugarTrabajo], [estado]) VALUES (3, 1039, N'Ingeniera Eléctrica', N'Santa Clara', N'Ingeniera Eléctrica', 0, N'Superior', 1, 1)
INSERT [dbo].[Tbl_Agremiado] ([id_Agremiado], [id_Usuario], [profesion], [colegio_Profesional], [puesto], [afiliado], [grado_Academico], [id_LugarTrabajo], [estado]) VALUES (4, 1040, N'Administración de empresas', N'San Pedro', N'Gerencia', 0, N'Superior', 27, 1)
INSERT [dbo].[Tbl_Agremiado] ([id_Agremiado], [id_Usuario], [profesion], [colegio_Profesional], [puesto], [afiliado], [grado_Academico], [id_LugarTrabajo], [estado]) VALUES (5, 1041, N'Electricista', N'San Ignacio', N'Departamento Electricidad', 0, N'Superior', 26, 1)
INSERT [dbo].[Tbl_Agremiado] ([id_Agremiado], [id_Usuario], [profesion], [colegio_Profesional], [puesto], [afiliado], [grado_Academico], [id_LugarTrabajo], [estado]) VALUES (6, 1042, N'Mecánico', N'Maria Auxiliadora', N'Mecanico', 0, N'Superior', 26, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Agremiado] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Compania] ON 

INSERT [dbo].[Tbl_Compania] ([id_Compania], [razon_Social], [cedula_Juridica], [nom_Compania], [direccion], [telefono], [correo_Electronico], [estado]) VALUES (1, N'NA', 1234567891, N'ICE', N'N/A', 22306020, N'ice@ice.com', 3)
INSERT [dbo].[Tbl_Compania] ([id_Compania], [razon_Social], [cedula_Juridica], [nom_Compania], [direccion], [telefono], [correo_Electronico], [estado]) VALUES (2, N'NA', 1234567892, N'RACSA', N'NA', 24308220, N'racsa@racsa.com', 3)
INSERT [dbo].[Tbl_Compania] ([id_Compania], [razon_Social], [cedula_Juridica], [nom_Compania], [direccion], [telefono], [correo_Electronico], [estado]) VALUES (3, N'NA', 1234567893, N'CNFL', N'N/A', 24401010, N'cnfl@cnfl.com', 3)
SET IDENTITY_INSERT [dbo].[Tbl_Compania] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Deduccion] ON 

INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1004, CAST(N'2019-12-08' AS Date), CAST(92600 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1005, CAST(N'2019-12-08' AS Date), CAST(40200 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1006, CAST(N'2019-12-09' AS Date), CAST(92600 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1007, CAST(N'2019-12-09' AS Date), CAST(40200 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1008, CAST(N'2019-12-09' AS Date), CAST(37500 AS Decimal(18, 0)), 3, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1009, CAST(N'2019-12-09' AS Date), CAST(40200 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1010, CAST(N'2019-12-09' AS Date), CAST(85250 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1011, CAST(N'2019-12-10' AS Date), CAST(92600 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1012, CAST(N'2019-12-10' AS Date), CAST(40200 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1013, CAST(N'2019-12-10' AS Date), CAST(37500 AS Decimal(18, 0)), 3, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1014, CAST(N'2019-12-10' AS Date), CAST(40200 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Tbl_Deduccion] ([id_Deduccion], [fecha_Deduccion], [monto], [id_Agremiado], [estado]) VALUES (1015, CAST(N'2019-12-10' AS Date), CAST(85250 AS Decimal(18, 0)), 5, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Deduccion] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Departamento] ON 

INSERT [dbo].[Tbl_Departamento] ([id_Departamento], [departamento], [id_Compania], [ubicacion], [estado]) VALUES (1, N'Cooperativa', 3, N'Limón', 1)
INSERT [dbo].[Tbl_Departamento] ([id_Departamento], [departamento], [id_Compania], [ubicacion], [estado]) VALUES (26, N'Ventas', 2, N'Alajuela', 1)
INSERT [dbo].[Tbl_Departamento] ([id_Departamento], [departamento], [id_Compania], [ubicacion], [estado]) VALUES (27, N'Gerencia', 3, N'Heredia', 1)
INSERT [dbo].[Tbl_Departamento] ([id_Departamento], [departamento], [id_Compania], [ubicacion], [estado]) VALUES (28, N'Ventas', 2, N'Guanacaste', 1)
SET IDENTITY_INSERT [dbo].[Tbl_Departamento] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Empleado] ON 

INSERT [dbo].[Tbl_Empleado] ([id_Empleado], [cargo], [superior_Inmediato], [id_LugarTrabajo], [id_Usuario], [estado], [total_Vacaciones], [cant_AusenciasJustificadas], [cant_AusenciasInjustificadas], [vac_Utilizadas], [vac_Restantes]) VALUES (1027, N'Administrador', N'NA', 1, 1034, 1, 0, 0, 0, 0, 0)
INSERT [dbo].[Tbl_Empleado] ([id_Empleado], [cargo], [superior_Inmediato], [id_LugarTrabajo], [id_Usuario], [estado], [total_Vacaciones], [cant_AusenciasJustificadas], [cant_AusenciasInjustificadas], [vac_Utilizadas], [vac_Restantes]) VALUES (1028, N'Deducciones', N'Carlos Arias', 1, 1035, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_Empleado] ([id_Empleado], [cargo], [superior_Inmediato], [id_LugarTrabajo], [id_Usuario], [estado], [total_Vacaciones], [cant_AusenciasJustificadas], [cant_AusenciasInjustificadas], [vac_Utilizadas], [vac_Restantes]) VALUES (1029, N'CARGO', N'Marco', 27, 1037, 1, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_Empleado] OFF
SET IDENTITY_INSERT [dbo].[Tbl_EstadoCivil] ON 

INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (1, N'SOLTERO/A', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (2, N'COMPROMETIDO/A', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (3, N'EN RELACION', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (4, N'CASADO/A', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (5, N'UNION LIBRE', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (6, N'SEPARADO/A', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (7, N'DIVORCIADO/A', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (8, N'VIUDO/A', 3)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (18, N'NUEVO ESTADO ', 1)
INSERT [dbo].[Tbl_EstadoCivil] ([id_ECivil], [estado_Civil], [estado]) VALUES (19, N'NUEVO ESTADOO', 1)
SET IDENTITY_INSERT [dbo].[Tbl_EstadoCivil] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Pais] ON 

INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (1, N'AF', N'Afghanistan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (2, N'AL', N'Albania')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (3, N'DZ', N'Algeria')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (4, N'DS', N'American Samoa')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (5, N'AD', N'Andorra')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (6, N'AO', N'Angola')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (7, N'AI', N'Anguilla')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (8, N'AQ', N'Antarctica')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (9, N'AG', N'Antigua and Barbuda')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (10, N'AR', N'Argentina')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (11, N'AM', N'Armenia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (12, N'AW', N'Aruba')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (13, N'AU', N'Australia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (14, N'AT', N'Austria')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (15, N'AZ', N'Azerbaijan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (16, N'BS', N'Bahamas')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (17, N'BH', N'Bahrain')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (18, N'BD', N'Bangladesh')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (19, N'BB', N'Barbados')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (20, N'BY', N'Belarus')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (21, N'BE', N'Belgium')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (22, N'BZ', N'Belize')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (23, N'BJ', N'Benin')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (24, N'BM', N'Bermuda')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (25, N'BT', N'Bhutan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (26, N'BO', N'Bolivia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (27, N'BA', N'Bosnia and Herzegovina')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (28, N'BW', N'Botswana')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (29, N'BV', N'Bouvet Island')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (30, N'BR', N'Brazil')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (31, N'IO', N'British Indian Ocean Territory')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (32, N'BN', N'Brunei Darussalam')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (33, N'BG', N'Bulgaria')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (34, N'BF', N'Burkina Faso')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (35, N'BI', N'Burundi')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (36, N'KH', N'Cambodia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (37, N'CM', N'Cameroon')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (38, N'CA', N'Canada')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (39, N'CV', N'Cape Verde')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (40, N'KY', N'Cayman Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (41, N'CF', N'Central African Republic')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (42, N'TD', N'Chad')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (43, N'CL', N'Chile')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (44, N'CN', N'China')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (45, N'CX', N'Christmas Island')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (46, N'CC', N'Cocos (Keeling) Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (47, N'CO', N'Colombia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (48, N'KM', N'Comoros')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (49, N'CD', N'Democratic Republic of the Congo')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (50, N'CG', N'Republic of Congo')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (51, N'CK', N'Cook Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (52, N'CR', N'Costa Rica')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (53, N'HR', N'Croatia (Hrvatska)')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (54, N'CU', N'Cuba')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (55, N'CY', N'Cyprus')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (56, N'CZ', N'Czech Republic')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (57, N'DK', N'Denmark')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (58, N'DJ', N'Djibouti')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (59, N'DM', N'Dominica')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (60, N'DO', N'Dominican Republic')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (61, N'TP', N'East Timor')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (62, N'EC', N'Ecuador')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (63, N'EG', N'Egypt')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (64, N'SV', N'El Salvador')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (65, N'GQ', N'Equatorial Guinea')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (66, N'ER', N'Eritrea')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (67, N'EE', N'Estonia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (68, N'ET', N'Ethiopia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (69, N'FK', N'Falkland Islands (Malvinas)')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (70, N'FO', N'Faroe Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (71, N'FJ', N'Fiji')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (72, N'FI', N'Finland')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (73, N'FR', N'France')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (74, N'FX', N'France, Metropolitan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (75, N'GF', N'French Guiana')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (76, N'PF', N'French Polynesia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (77, N'TF', N'French Southern Territories')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (78, N'GA', N'Gabon')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (79, N'GM', N'Gambia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (80, N'GE', N'Georgia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (81, N'DE', N'Germany')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (82, N'GH', N'Ghana')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (83, N'GI', N'Gibraltar')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (84, N'GK', N'Guernsey')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (85, N'GR', N'Greece')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (86, N'GL', N'Greenland')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (87, N'GD', N'Grenada')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (88, N'GP', N'Guadeloupe')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (89, N'GU', N'Guam')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (90, N'GT', N'Guatemala')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (91, N'GN', N'Guinea')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (92, N'GW', N'Guinea-Bissau')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (93, N'GY', N'Guyana')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (94, N'HT', N'Haiti')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (95, N'HM', N'Heard and Mc Donald Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (96, N'HN', N'Honduras')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (97, N'HK', N'Hong Kong')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (98, N'HU', N'Hungary')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (99, N'IS', N'Iceland')
GO
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (100, N'IN', N'India')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (101, N'IM', N'Isle of Man')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (102, N'ID', N'Indonesia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (103, N'IR', N'Iran (Islamic Republic of)')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (104, N'IQ', N'Iraq')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (105, N'IE', N'Ireland')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (106, N'IL', N'Israel')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (107, N'IT', N'Italy')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (108, N'CI', N'Ivory Coast')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (109, N'JE', N'Jersey')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (110, N'JM', N'Jamaica')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (111, N'JP', N'Japan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (112, N'JO', N'Jordan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (113, N'KZ', N'Kazakhstan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (114, N'KE', N'Kenya')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (115, N'KI', N'Kiribati')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (116, N'KP', N'Korea, Democratic People''s Republic of')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (117, N'KR', N'Korea, Republic of')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (118, N'XK', N'Kosovo')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (119, N'KW', N'Kuwait')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (120, N'KG', N'Kyrgyzstan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (121, N'LA', N'Lao People''s Democratic Republic')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (122, N'LV', N'Latvia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (123, N'LB', N'Lebanon')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (124, N'LS', N'Lesotho')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (125, N'LR', N'Liberia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (126, N'LY', N'Libyan Arab Jamahiriya')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (127, N'LI', N'Liechtenstein')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (128, N'LT', N'Lithuania')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (129, N'LU', N'Luxembourg')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (130, N'MO', N'Macau')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (131, N'MK', N'North Macedonia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (132, N'MG', N'Madagascar')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (133, N'MW', N'Malawi')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (134, N'MY', N'Malaysia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (135, N'MV', N'Maldives')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (136, N'ML', N'Mali')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (137, N'MT', N'Malta')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (138, N'MH', N'Marshall Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (139, N'MQ', N'Martinique')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (140, N'MR', N'Mauritania')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (141, N'MU', N'Mauritius')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (142, N'TY', N'Mayotte')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (143, N'MX', N'Mexico')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (144, N'FM', N'Micronesia, Federated States of')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (145, N'MD', N'Moldova, Republic of')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (146, N'MC', N'Monaco')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (147, N'MN', N'Mongolia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (148, N'ME', N'Montenegro')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (149, N'MS', N'Montserrat')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (150, N'MA', N'Morocco')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (151, N'MZ', N'Mozambique')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (152, N'MM', N'Myanmar')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (153, N'NA', N'Namibia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (154, N'NR', N'Nauru')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (155, N'NP', N'Nepal')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (156, N'NL', N'Netherlands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (157, N'AN', N'Netherlands Antilles')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (158, N'NC', N'New Caledonia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (159, N'NZ', N'New Zealand')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (160, N'NI', N'Nicaragua')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (161, N'NE', N'Niger')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (162, N'NG', N'Nigeria')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (163, N'NU', N'Niue')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (164, N'NF', N'Norfolk Island')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (165, N'MP', N'Northern Mariana Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (166, N'NO', N'Norway')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (167, N'OM', N'Oman')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (168, N'PK', N'Pakistan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (169, N'PW', N'Palau')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (170, N'PS', N'Palestine')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (171, N'PA', N'Panama')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (172, N'PG', N'Papua New Guinea')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (173, N'PY', N'Paraguay')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (174, N'PE', N'Peru')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (175, N'PH', N'Philippines')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (176, N'PN', N'Pitcairn')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (177, N'PL', N'Poland')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (178, N'PT', N'Portugal')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (179, N'PR', N'Puerto Rico')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (180, N'QA', N'Qatar')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (181, N'RE', N'Reunion')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (182, N'RO', N'Romania')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (183, N'RU', N'Russian Federation')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (184, N'RW', N'Rwanda')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (185, N'KN', N'Saint Kitts and Nevis')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (186, N'LC', N'Saint Lucia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (187, N'VC', N'Saint Vincent and the Grenadines')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (188, N'WS', N'Samoa')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (189, N'SM', N'San Marino')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (190, N'ST', N'Sao Tome and Principe')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (191, N'SA', N'Saudi Arabia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (192, N'SN', N'Senegal')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (193, N'RS', N'Serbia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (194, N'SC', N'Seychelles')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (195, N'SL', N'Sierra Leone')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (196, N'SG', N'Singapore')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (197, N'SK', N'Slovakia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (198, N'SI', N'Slovenia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (199, N'SB', N'Solomon Islands')
GO
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (200, N'SO', N'Somalia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (201, N'ZA', N'South Africa')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (202, N'GS', N'South Georgia South Sandwich Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (203, N'SS', N'South Sudan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (204, N'ES', N'Spain')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (205, N'LK', N'Sri Lanka')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (206, N'SH', N'St. Helena')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (207, N'PM', N'St. Pierre and Miquelon')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (208, N'SD', N'Sudan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (209, N'SR', N'Suriname')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (210, N'SJ', N'Svalbard and Jan Mayen Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (211, N'SZ', N'Swaziland')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (212, N'SE', N'Sweden')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (213, N'CH', N'Switzerland')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (214, N'SY', N'Syrian Arab Republic')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (215, N'TW', N'Taiwan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (216, N'TJ', N'Tajikistan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (217, N'TZ', N'Tanzania, United Republic of')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (218, N'TH', N'Thailand')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (219, N'TG', N'Togo')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (220, N'TK', N'Tokelau')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (221, N'TO', N'Tonga')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (222, N'TT', N'Trinidad and Tobago')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (223, N'TN', N'Tunisia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (224, N'TR', N'Turkey')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (225, N'TM', N'Turkmenistan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (226, N'TC', N'Turks and Caicos Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (227, N'TV', N'Tuvalu')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (228, N'UG', N'Uganda')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (229, N'UA', N'Ukraine')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (230, N'AE', N'United Arab Emirates')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (231, N'GB', N'United Kingdom')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (232, N'US', N'United States')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (233, N'UM', N'United States minor outlying islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (234, N'UY', N'Uruguay')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (235, N'UZ', N'Uzbekistan')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (236, N'VU', N'Vanuatu')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (237, N'VA', N'Vatican City State')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (238, N'VE', N'Venezuela')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (239, N'VN', N'Vietnam')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (240, N'VG', N'Virgin Islands (British)')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (241, N'VI', N'Virgin Islands (U.S.)')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (242, N'WF', N'Wallis and Futuna Islands')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (243, N'EH', N'Western Sahara')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (244, N'YE', N'Yemen')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (245, N'ZM', N'Zambia')
INSERT [dbo].[Tbl_Pais] ([id_Pais], [country_code], [country_name]) VALUES (246, N'ZW', N'Zimbabwe')
SET IDENTITY_INSERT [dbo].[Tbl_Pais] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Persona] ON 

INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1090, 123456789, N'Admin', N'Admin', N'Admin', N'Masculino', 52, 1, CAST(N'2019-12-21' AS Date), CAST(N'2019-12-10' AS Date), 72038256, N'Alajuela, 124', N'marioelr1998@gmail.com', 1)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1091, 700690869, N'Martha', N'Castro', N'Perez', N'Femenino', 52, 1, CAST(N'1992-02-05' AS Date), CAST(N'2019-12-07' AS Date), 87336082, N'Alajuela, 124', N'marioelr1998@gmail.com', 1)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1092, 207840912, N'Mario', N'López', N'Román', N'Masculino', 52, 1, CAST(N'1998-10-10' AS Date), CAST(N'2019-12-07' AS Date), 72038256, N'Alajuela', N'marioelr1998@gmail.com', 1)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1093, 155809879421, N'Pedro', N'Castro', N'Arias', N'Masculino', 54, 18, CAST(N'1970-02-07' AS Date), CAST(N'2019-12-08' AS Date), 60206915, N'Alajuela', N'mario@gmail.com', 1)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1094, 112800672, N'Argery', N'Solano', N'Román', N'Femenino', 52, 3, CAST(N'1986-05-06' AS Date), CAST(N'2019-12-08' AS Date), 60102356, N'Alajuela, 124', N'mario@gmail.com', 1)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1095, 107270950, N'Nelly', N'Bustamante', N'Marin', N'Femenino', 52, 1, CAST(N'1986-12-11' AS Date), CAST(N'2019-12-09' AS Date), 89562310, N'San Jose, 123', N'nelly@gmail.com', 2)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1096, 107320032, N'Jorge Luis', N'Sancho', N'Chavez', N'Masculino', 52, 2, CAST(N'1970-02-01' AS Date), CAST(N'2019-12-09' AS Date), 75568920, N'Pavas, San José', N'jorge@gmail.com', 2)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1097, 204380935, N'Humberto Antonio', N'Alpizar', N'Alfaro', N'Masculino', 52, 3, CAST(N'1980-12-02' AS Date), CAST(N'2019-12-09' AS Date), 24562389, N'Alajuela, 124', N'humberto@gmail.com', 2)
INSERT [dbo].[Tbl_Persona] ([id_Persona], [cedula], [nombre], [primer_Apellido], [segundo_Apellido], [genero], [nacionalidad], [id_ECivil], [fecha_Nac], [fecha_Reg], [telefono], [direccion], [correo_Electronico], [estado]) VALUES (1098, 155809879422, N'Mario José', N'López', N'Arias', N'Masculino', 160, 4, CAST(N'1970-01-27' AS Date), CAST(N'2019-12-09' AS Date), 60772052, N'Alajuela, 124', N'mario@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[Tbl_Persona] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Rol] ON 

INSERT [dbo].[Tbl_Rol] ([id_Rol], [tipo_Rol], [estado]) VALUES (1, N'ADMINISTRADOR', 3)
INSERT [dbo].[Tbl_Rol] ([id_Rol], [tipo_Rol], [estado]) VALUES (2, N'GESTOR DEDUCCIONES', 3)
INSERT [dbo].[Tbl_Rol] ([id_Rol], [tipo_Rol], [estado]) VALUES (4, N'USUARIO GENERAL', 3)
INSERT [dbo].[Tbl_Rol] ([id_Rol], [tipo_Rol], [estado]) VALUES (8, N'NUEVO ROL', 1)
INSERT [dbo].[Tbl_Rol] ([id_Rol], [tipo_Rol], [estado]) VALUES (9, N'NUEVO ROLL', 1)
SET IDENTITY_INSERT [dbo].[Tbl_Rol] OFF
SET IDENTITY_INSERT [dbo].[Tbl_TipoGestion] ON 

INSERT [dbo].[Tbl_TipoGestion] ([id_TipoGestion], [tipo_Gestion], [estado]) VALUES (1, N'Vaciones', 3)
INSERT [dbo].[Tbl_TipoGestion] ([id_TipoGestion], [tipo_Gestion], [estado]) VALUES (2, N'Ausencia', 3)
SET IDENTITY_INSERT [dbo].[Tbl_TipoGestion] OFF
SET IDENTITY_INSERT [dbo].[Tbl_TipoUsuario] ON 

INSERT [dbo].[Tbl_TipoUsuario] ([id_TipoUsu], [tipo_Usuario], [estado]) VALUES (1, N'PRIMER NIVEL', 3)
INSERT [dbo].[Tbl_TipoUsuario] ([id_TipoUsu], [tipo_Usuario], [estado]) VALUES (2, N'SEGUNDO NIVEL', 3)
INSERT [dbo].[Tbl_TipoUsuario] ([id_TipoUsu], [tipo_Usuario], [estado]) VALUES (3, N'TERCER NIVEL', 3)
SET IDENTITY_INSERT [dbo].[Tbl_TipoUsuario] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Usuario] ON 

INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1034, 1090, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1035, 1091, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1036, 1092, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 4, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1037, 1093, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1038, 1094, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 4, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1039, 1095, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 4, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1040, 1096, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 4, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1041, 1097, N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 4, 3, 1, NULL)
INSERT [dbo].[Tbl_Usuario] ([id_Usuario], [id_Persona], [contrasenia], [id_Rol], [id_TipoUsu], [estado], [token_recovery]) VALUES (1042, 1098, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 4, 3, 1, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_Usuario] OFF
/****** Object:  Index [UQ__Tbl_Pers__415B7BE52F0DD1AB]    Script Date: 10/12/2019 13:39:33 ******/
ALTER TABLE [dbo].[Tbl_Persona] ADD UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_Pais] ADD  DEFAULT ('') FOR [country_code]
GO
ALTER TABLE [dbo].[Tbl_Pais] ADD  DEFAULT ('') FOR [country_name]
GO
ALTER TABLE [dbo].[Tbl_Acta_Usuario]  WITH CHECK ADD  CONSTRAINT [t_acta0_fk] FOREIGN KEY([id_Acta])
REFERENCES [dbo].[Tbl_Acta] ([id_Acta])
GO
ALTER TABLE [dbo].[Tbl_Acta_Usuario] CHECK CONSTRAINT [t_acta0_fk]
GO
ALTER TABLE [dbo].[Tbl_Acta_Usuario]  WITH CHECK ADD  CONSTRAINT [t_usuario2_fk] FOREIGN KEY([id_Usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_Usuario])
GO
ALTER TABLE [dbo].[Tbl_Acta_Usuario] CHECK CONSTRAINT [t_usuario2_fk]
GO
ALTER TABLE [dbo].[Tbl_Agremiado]  WITH CHECK ADD  CONSTRAINT [t_ltrabajo0_fk] FOREIGN KEY([id_LugarTrabajo])
REFERENCES [dbo].[Tbl_Departamento] ([id_Departamento])
GO
ALTER TABLE [dbo].[Tbl_Agremiado] CHECK CONSTRAINT [t_ltrabajo0_fk]
GO
ALTER TABLE [dbo].[Tbl_Agremiado]  WITH CHECK ADD  CONSTRAINT [t_usuario0_fk] FOREIGN KEY([id_Usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_Usuario])
GO
ALTER TABLE [dbo].[Tbl_Agremiado] CHECK CONSTRAINT [t_usuario0_fk]
GO
ALTER TABLE [dbo].[Tbl_Deduccion]  WITH CHECK ADD  CONSTRAINT [t_agremiado0_fk] FOREIGN KEY([id_Agremiado])
REFERENCES [dbo].[Tbl_Agremiado] ([id_Agremiado])
GO
ALTER TABLE [dbo].[Tbl_Deduccion] CHECK CONSTRAINT [t_agremiado0_fk]
GO
ALTER TABLE [dbo].[Tbl_Departamento]  WITH CHECK ADD  CONSTRAINT [t_compania_fk] FOREIGN KEY([id_Compania])
REFERENCES [dbo].[Tbl_Compania] ([id_Compania])
GO
ALTER TABLE [dbo].[Tbl_Departamento] CHECK CONSTRAINT [t_compania_fk]
GO
ALTER TABLE [dbo].[Tbl_Empleado]  WITH CHECK ADD  CONSTRAINT [t_ltrabajo1_fk] FOREIGN KEY([id_LugarTrabajo])
REFERENCES [dbo].[Tbl_Departamento] ([id_Departamento])
GO
ALTER TABLE [dbo].[Tbl_Empleado] CHECK CONSTRAINT [t_ltrabajo1_fk]
GO
ALTER TABLE [dbo].[Tbl_Empleado]  WITH CHECK ADD  CONSTRAINT [t_usuario1_fk] FOREIGN KEY([id_Usuario])
REFERENCES [dbo].[Tbl_Usuario] ([id_Usuario])
GO
ALTER TABLE [dbo].[Tbl_Empleado] CHECK CONSTRAINT [t_usuario1_fk]
GO
ALTER TABLE [dbo].[Tbl_Gestion]  WITH CHECK ADD  CONSTRAINT [t_empleado_fk] FOREIGN KEY([id_Empleado])
REFERENCES [dbo].[Tbl_Empleado] ([id_Empleado])
GO
ALTER TABLE [dbo].[Tbl_Gestion] CHECK CONSTRAINT [t_empleado_fk]
GO
ALTER TABLE [dbo].[Tbl_Gestion]  WITH CHECK ADD  CONSTRAINT [t_tgestion_fk] FOREIGN KEY([id_TipoGestion])
REFERENCES [dbo].[Tbl_TipoGestion] ([id_TipoGestion])
GO
ALTER TABLE [dbo].[Tbl_Gestion] CHECK CONSTRAINT [t_tgestion_fk]
GO
ALTER TABLE [dbo].[Tbl_Persona]  WITH CHECK ADD  CONSTRAINT [t_ecivil_fk] FOREIGN KEY([id_ECivil])
REFERENCES [dbo].[Tbl_EstadoCivil] ([id_ECivil])
GO
ALTER TABLE [dbo].[Tbl_Persona] CHECK CONSTRAINT [t_ecivil_fk]
GO
ALTER TABLE [dbo].[Tbl_Usuario]  WITH CHECK ADD  CONSTRAINT [t_persona_fk] FOREIGN KEY([id_Persona])
REFERENCES [dbo].[Tbl_Persona] ([id_Persona])
GO
ALTER TABLE [dbo].[Tbl_Usuario] CHECK CONSTRAINT [t_persona_fk]
GO
ALTER TABLE [dbo].[Tbl_Usuario]  WITH CHECK ADD  CONSTRAINT [t_rol_fk] FOREIGN KEY([id_Rol])
REFERENCES [dbo].[Tbl_Rol] ([id_Rol])
GO
ALTER TABLE [dbo].[Tbl_Usuario] CHECK CONSTRAINT [t_rol_fk]
GO
ALTER TABLE [dbo].[Tbl_Usuario]  WITH CHECK ADD  CONSTRAINT [t_tipousu_fk] FOREIGN KEY([id_TipoUsu])
REFERENCES [dbo].[Tbl_TipoUsuario] ([id_TipoUsu])
GO
ALTER TABLE [dbo].[Tbl_Usuario] CHECK CONSTRAINT [t_tipousu_fk]
GO
