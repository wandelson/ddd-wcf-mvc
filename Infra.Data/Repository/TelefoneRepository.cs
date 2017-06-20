using Domain.Entities;
using Domain.Interfaces.Repository;
using Infra.Data.Context;
using Infra.Data.Repository;

namespace Infra.Data.Repository
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(DataContext context)
            : base(context)
        {
            
        }
    }
}