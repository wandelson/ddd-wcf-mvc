using Domain.Entities;
using Domain.Interfaces.Repository;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext context)
            : base(context)
        {
            
        }
    }
}