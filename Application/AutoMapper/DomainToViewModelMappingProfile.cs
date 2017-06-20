using AppService.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace AppService.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile ()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteTelefoneEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Endereco, ClienteTelefoneEnderecoViewModel>();
            CreateMap<Telefone, TelefoneViewModel>();
            CreateMap<Telefone, ClienteTelefoneEnderecoViewModel>();
        }
    }
}