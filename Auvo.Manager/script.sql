USE [ClimaTempoSimples]
GO
/****** Object:  Table [dbo].[Cidade]    Script Date: 14/04/2022 09:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cidade](
	[Id] [int] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[EstadoId] [int] NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 14/04/2022 09:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[UF] [char](2) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrevisaoClima]    Script Date: 14/04/2022 09:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrevisaoClima](
	[Id] [int] NOT NULL,
	[Clima] [varchar](15) NOT NULL,
	[TemperaturaMinima] [decimal](18, 0) NOT NULL,
	[TemperaturaMaxima] [decimal](18, 0) NOT NULL,
	[DataPrevisao] [datetime] NOT NULL,
	[CidadeId] [int] NOT NULL,
 CONSTRAINT [PK_PrevisaoClima] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_Estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_Cidade_Estado]
GO
ALTER TABLE [dbo].[PrevisaoClima]  WITH CHECK ADD  CONSTRAINT [FK_PrevisaoClima_Cidade] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Cidade] ([Id])
GO
ALTER TABLE [dbo].[PrevisaoClima] CHECK CONSTRAINT [FK_PrevisaoClima_Cidade]
GO
