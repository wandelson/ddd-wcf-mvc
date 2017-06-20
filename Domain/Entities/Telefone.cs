using DomainValidation.Validation;
using System;

namespace Domain.Entities
{
    public class Telefone
    {
        public Telefone()
        {
            TelefoneId = Guid.NewGuid();
        }

        public Guid TelefoneId { get; set; }
        public short DDD { get; set; }
        public int NumeroTelefone { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public ValidationResult ValidationResult { get; set; }


    }
}