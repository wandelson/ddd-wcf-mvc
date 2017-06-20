using System;
using System.Collections.Generic;
using Domain;
using Domain.Entities;

namespace Domain.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(Guid id);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterTodos();
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);

        Endereco AdicionarEndereco(Endereco endereco);
        Endereco AtualizarEndereco(Endereco endereco);
        Endereco ObterEnderecoPorId(Guid id);
        void RemoverEndereco(Guid id);



        Telefone AdicionarTelefone(Telefone endereco);
        Telefone AtualizarTelefone(Telefone endereco);
        Telefone ObterTelefonePorId(Guid id);
        void RemoverTelefone(Guid id);

    }
}