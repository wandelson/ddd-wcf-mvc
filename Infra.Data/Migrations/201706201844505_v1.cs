namespace Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .Index(t => t.CPF, unique: true);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        EnderecoId = c.Guid(nullable: false),
                        Logradouro = c.String(nullable: false, maxLength: 150, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 8, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Estado = c.String(maxLength: 100, unicode: false),
                        ClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        TelefoneId = c.Guid(nullable: false),
                        DDD = c.Short(nullable: false),
                        NumeroTelefone = c.Int(nullable: false),
                        ClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TelefoneId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefones", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Enderecos", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Telefones", new[] { "ClienteId" });
            DropIndex("dbo.Enderecos", new[] { "ClienteId" });
            DropIndex("dbo.Clientes", new[] { "CPF" });
            DropTable("dbo.Telefones");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Clientes");
        }
    }
}
