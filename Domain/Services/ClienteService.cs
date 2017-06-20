using System;
using System.Collections.Generic;
using Domain;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Validations.Clientes;
using Domain.Entities;

namespace Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ITelefoneRepository _telefoneRepository;

        public ClienteService(IClienteRepository clienteRepository, 
            IEnderecoRepository enderecoRepository,
            ITelefoneRepository telefoneReposository
            )
        {
            _telefoneRepository = telefoneReposository;
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if(!cliente.IsValid())
            {
                return cliente;
            }

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
            {
                return cliente;
            }

            cliente.ValidationResult.Message = "Cliente cadastrado com sucesso :)";
            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public Endereco AdicionarEndereco(Endereco endereco)
        {
            return _enderecoRepository.Adicionar(endereco);
        }

        public Endereco AtualizarEndereco(Endereco endereco)
        {
            return _enderecoRepository.Atualizar(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            return _enderecoRepository.ObterPorId(id);
        }

        public void RemoverEndereco(Guid id)
        {
            _enderecoRepository.Remover(id);
        }



        public Telefone AdicionarTelefone(Telefone telefone)
        {
            return _telefoneRepository.Adicionar(telefone);
        }

        public Telefone AtualizarTelefone(Telefone telefone)
        {
            return _telefoneRepository.Atualizar(telefone);
        }

        public Telefone ObterTelefonePorId(Guid id)
        {
            return _telefoneRepository.ObterPorId(id);
        }

        public void RemoverTelefone(Guid id)
        {
            _telefoneRepository.Remover(id);
        }


        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}