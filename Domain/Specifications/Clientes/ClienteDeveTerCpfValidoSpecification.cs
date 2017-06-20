using DomainValidation.Interfaces.Specification;
using Domain;
using Domain.Validations.Documentos;
using Domain.Entities;

namespace Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPFValidation.Validar(cliente.CPF);
        }
    }
}