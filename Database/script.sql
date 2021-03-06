USE [Crud]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/06/2017 17:51:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enderecos]    Script Date: 20/06/2017 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[EnderecoId] [uniqueidentifier] NOT NULL,
	[Logradouro] [varchar](150) NOT NULL,
	[Numero] [varchar](100) NOT NULL,
	[Complemento] [varchar](100) NULL,
	[Bairro] [varchar](50) NOT NULL,
	[CEP] [varchar](8) NOT NULL,
	[Cidade] [varchar](100) NULL,
	[Estado] [varchar](100) NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Enderecos] PRIMARY KEY CLUSTERED 
(
	[EnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefones]    Script Date: 20/06/2017 17:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefones](
	[TelefoneId] [uniqueidentifier] NOT NULL,
	[DDD] [smallint] NOT NULL,
	[NumeroTelefone] [int] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Telefones] PRIMARY KEY CLUSTERED 
(
	[TelefoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enderecos_dbo.Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_dbo.Enderecos_dbo.Clientes_ClienteId]
GO
ALTER TABLE [dbo].[Telefones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Telefones_dbo.Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Telefones] CHECK CONSTRAINT [FK_dbo.Telefones_dbo.Clientes_ClienteId]
GO
