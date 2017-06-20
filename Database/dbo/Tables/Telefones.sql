CREATE TABLE [dbo].[Telefones] (
    [TelefoneId]     UNIQUEIDENTIFIER NOT NULL,
    [DDD]            SMALLINT         NOT NULL,
    [NumeroTelefone] INT              NOT NULL,
    [ClienteId]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Telefones] PRIMARY KEY CLUSTERED ([TelefoneId] ASC),
    CONSTRAINT [FK_dbo.Telefones_dbo.Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([ClienteId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ClienteId]
    ON [dbo].[Telefones]([ClienteId] ASC);

