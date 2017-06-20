using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Infra.Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(DataContext context)
            : base(context)
        {
            
        }

        public Cliente ObterPorCpf(string cpf)
        {
            //return Db.Clientes.FirstOrDefault(c => c.CPF == cpf);
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes";

            return cn.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Enderecos e " +
                       "ON c.ClienteId = e.ClienteId " +
                       "LEFT JOIN Telefones t " +
                       "ON t.ClienteId = e.ClienteId " +
                       "WHERE c.ClienteId = @sid";

            var cliente = new List<Cliente>();
            cn.Query<Cliente, Endereco, Telefone, Cliente>(sql,
                (c, e, t) =>
                {
                    cliente.Add(c);
                    if(e != null)
                        cliente[0].Enderecos.Add(e);

                    if (t != null)
                        cliente[0].Telefones.Add(t);

                    return cliente.FirstOrDefault();

                }, new { sid = id }, splitOn: "ClienteId, EnderecoId, TelefoneId");

            return cliente.FirstOrDefault();
        }
    }
}