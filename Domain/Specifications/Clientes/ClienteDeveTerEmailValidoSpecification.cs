using DomainValidation.Interfaces.Specification;
using Domain;
using Domain.Validations.Documentos;
using Domain.Entities;

namespace Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validate(cliente.Email);
        }
    }
}