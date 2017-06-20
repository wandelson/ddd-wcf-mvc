using System;
using System.Collections.Generic;
using AppService.ViewModels;

namespace AppService.Interfaces
{
    public interface IClienteApplication : IDisposable
    {
        ClienteTelefoneEnderecoViewModel Adicionar(ClienteTelefoneEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel ObterPorId(Guid id);
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void Remover(Guid id);

        EnderecoViewModel AdicionarEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel AtualizarEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel ObterEnderecoPorId(Guid id);
        void RemoverEndereco(Guid id);

        TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel);
        TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel);
        TelefoneViewModel ObterTelefonePorId(Guid id);
        void RemoverTelefone(Guid id);

    }
}