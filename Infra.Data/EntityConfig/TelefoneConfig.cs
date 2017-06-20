using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.EntityConfig
{
    // Fluent API
    public class TelefoneConfig : EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfig()
        {
            HasKey(c => c.TelefoneId);

            Property(c => c.DDD)
                .IsRequired();

            Property(c => c.NumeroTelefone)
                .IsRequired();                
            
            Ignore(c => c.ValidationResult);

            //HasOptional()
            HasRequired(e => e.Cliente)
                .WithMany(c => c.Telefones)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Telefones");
        }
    }
}