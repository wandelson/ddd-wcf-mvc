using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Service;
using Infra.Data.Interfaces;
using AppService.Interfaces;
using AppService.ViewModels;
using System.Linq;

namespace AppService
{
    public class ClienteApplication : ApplicationService, IClienteApplication
    {
        private readonly IClienteService _clienteService;

        public ClienteApplication(IClienteService clienteService, IUnitOfWork uow)
            : base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteTelefoneEnderecoViewModel Adicionar(ClienteTelefoneEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteTelefoneEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteTelefoneEnderecoViewModel, Endereco>(clienteEnderecoViewModel);
            var telefone = Mapper.Map<ClienteTelefoneEnderecoViewModel, Telefone>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);
            cliente.Telefones.Add(telefone);

            BeginTransaction();

            var clienteReturn = _clienteService.Adicionar(cliente);
            clienteEnderecoViewModel = Mapper.Map<Cliente, ClienteTelefoneEnderecoViewModel>(clienteReturn);
            if (!clienteReturn.ValidationResult.IsValid)
            {

                clienteEnderecoViewModel.Erros = clienteReturn.ValidationResult.Erros.Select(x=> x.Message).ToList();
                // Não faz o commit
                return clienteEnderecoViewModel;
            }


            Commit();

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            BeginTransaction();
            _clienteService.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));
            Commit();
            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            BeginTransaction();
            _clienteService.Remover(id);
            Commit();
        }

        public EnderecoViewModel AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            
            BeginTransaction();
            _clienteService.AdicionarEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _clienteService.AtualizarEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_clienteService.ObterEnderecoPorId(id));
        }

        public void RemoverEndereco(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoverEndereco(id);
            Commit();
        }


        public TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Mapper.Map<TelefoneViewModel, Telefone>(telefoneViewModel);

            BeginTransaction();
            _clienteService.AdicionarTelefone(telefone);
            Commit();

            return telefoneViewModel;
        }

        public TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = Mapper.Map<TelefoneViewModel, Telefone>(telefoneViewModel);

            BeginTransaction();
            _clienteService.AtualizarTelefone(telefone);
            Commit();

            return telefoneViewModel;
        }

        public TelefoneViewModel ObterTelefonePorId(Guid id)
        {
            return Mapper.Map<Telefone, TelefoneViewModel>(_clienteService.ObterTelefonePorId(id));
        }

        public void RemoverTelefone(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoverTelefone(id);
            Commit();
        }



        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }

     
    }
}