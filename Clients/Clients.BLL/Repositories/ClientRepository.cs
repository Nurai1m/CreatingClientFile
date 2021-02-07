using Clients.DAL.DBContext;
using Clients.DAL.Entities;
using Clients.DAL.IRepositories;
using System.Linq;

namespace Clients.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IQueryable<ClientEntity> Query;
        private readonly ApplicationDBContext _context;
        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
            Query = _context.Set<ClientEntity>();
        }
        public ClientEntity GetDataBySocialNumber(string socialNum) 
        {
            return Query.FirstOrDefault(x => x.SocialNumber == socialNum);
        }
    }
}
