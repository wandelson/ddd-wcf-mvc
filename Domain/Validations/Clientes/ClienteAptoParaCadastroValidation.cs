using DomainValidation.Validation;
using Domain;
using Domain.Interfaces.Repository;
using Domain.Specifications.Clientes;
using Domain.Entities;

namespace Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);
            var clienteEndereco = new ClienteDeveTerUmEnderecoSpecification();

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
            base.Add("clienteEndereco", new Rule<Cliente>(clienteEndereco, "Cliente não informou endereço"));
        }
    }
}