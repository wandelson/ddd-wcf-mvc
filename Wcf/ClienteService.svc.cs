using System;
using System.Collections.Generic;
using AppService.Interfaces;
using AppService.ViewModels;

namespace Wcf
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteApplication _clienteApplication;

        public ClienteService(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
        }

        public ClienteTelefoneEnderecoViewModel Criar(ClienteTelefoneEnderecoViewModel clienteTelefoneEnderecoViewModel)
        {
            return _clienteApplication.Adicionar(clienteTelefoneEnderecoViewModel);
        }

        public IEnumerable<ClienteViewModel> ListarTodos()
        {
            return _clienteApplication.ObterTodos();
        }
    }
}