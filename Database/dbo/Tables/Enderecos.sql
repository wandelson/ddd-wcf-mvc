CREATE TABLE [dbo].[Enderecos] (
    [EnderecoId]  UNIQUEIDENTIFIER NOT NULL,
    [Logradouro]  VARCHAR (150)    NOT NULL,
    [Numero]      VARCHAR (100)    NOT NULL,
    [Complemento] VARCHAR (100)    NULL,
    [Bairro]      VARCHAR (50)     NOT NULL,
    [CEP]         VARCHAR (8)      NOT NULL,
    [Cidade]      VARCHAR (100)    NULL,
    [Estado]      VARCHAR (100)    NULL,
    [ClienteId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Enderecos] PRIMARY KEY CLUSTERED ([EnderecoId] ASC),
    CONSTRAINT [FK_dbo.Enderecos_dbo.Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([ClienteId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ClienteId]
    ON [dbo].[Enderecos]([ClienteId] ASC);

