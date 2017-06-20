using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Validations.Clientes;

namespace Domain .Tests.Validation
{
    [TestClass]
    public class ClienteAptoParaCadastroTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void ClienteApto_Validation_True()
        {
            Cliente = new Cliente()
            {
                CPF = "30390600822",
                Email = "edu@edu.com.br"
            };

            Cliente.Enderecos.Add(new Endereco());

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(null);
            stubRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(null);

            var cliValidation = new ClienteAptoParaCadastroValidation(stubRepo);
            Assert.IsTrue(cliValidation.Validate(Cliente).IsValid);
        }

        [TestMethod]
        public void ClienteApto_Validation_False()
        {
            Cliente = new Cliente()
            {
                CPF = "30390600822",
                Email = "edu@edu.com.br"
            };
            
            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(Cliente);
            stubRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(Cliente);

            var cliValidation = new ClienteAptoParaCadastroValidation(stubRepo);
            var result = cliValidation.Validate(Cliente);

            Assert.IsFalse(cliValidation.Validate(Cliente).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "CPF já cadastrado! Esqueceu sua senha?"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}
