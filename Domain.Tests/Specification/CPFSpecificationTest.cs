using Domain.Entities;
using Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests.Specification
{
    [TestClass]
    public class CPFSpecificationTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void CPF_Valido_True()
        {
            Cliente = new Cliente()
            {
                CPF = "30390600822"
            };

            var cpf = new ClienteDeveTerCpfValidoSpecification();
            Assert.IsTrue(cpf.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void CPF_Valido_False()
        {
            Cliente = new Cliente()
            {
                CPF = "30390600821"
            };

            var cpf = new ClienteDeveTerCpfValidoSpecification();
            Assert.IsFalse(cpf.IsSatisfiedBy(Cliente));
        }
    }
}
