CREATE TABLE [dbo].[Clientes] (
    [ClienteId]      UNIQUEIDENTIFIER NOT NULL,
    [Nome]           VARCHAR (150)    NOT NULL,
    [Email]          VARCHAR (100)    NOT NULL,
    [CPF]            VARCHAR (11)     NOT NULL,
    [DataNascimento] DATETIME         NOT NULL,
    [DataCadastro]   DATETIME         NOT NULL,
    CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY CLUSTERED ([ClienteId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CPF]
    ON [dbo].[Clientes]([CPF] ASC);

