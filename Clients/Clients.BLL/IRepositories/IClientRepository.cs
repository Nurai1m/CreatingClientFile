using Clients.DAL.Entities;

namespace Clients.DAL.IRepositories
{
    public interface IClientRepository
    {
        ClientEntity GetDataBySocialNumber(string socialNum);
    }
}
