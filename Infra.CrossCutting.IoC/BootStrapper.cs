using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Services;
using Infra.Data.Context;
using Infra.Data.Interfaces;
using Infra.Data.Repository;
using Infra.Data.UoW;
using SimpleInjector;
using AppService.Interfaces;
using AppService;

namespace Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<IClienteApplication, ClienteApplication>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<ITelefoneRepository, TelefoneRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<DataContext>(Lifestyle.Scoped);
        }
    }
}