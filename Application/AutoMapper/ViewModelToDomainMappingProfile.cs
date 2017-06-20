using AppService.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace AppService.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteTelefoneEnderecoViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ClienteTelefoneEnderecoViewModel, Endereco>();
            CreateMap<TelefoneViewModel, Telefone>();
            CreateMap<ClienteTelefoneEnderecoViewModel, Telefone>();
        }
    }
}