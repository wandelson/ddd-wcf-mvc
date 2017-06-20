using System;
using System.Collections.Generic;
using DomainValidation.Validation;
using Domain.Validations.Clientes;

namespace Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
            Telefones = new List<Telefone>();
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}