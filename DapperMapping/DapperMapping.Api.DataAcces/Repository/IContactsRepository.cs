using DapperMapping.Api.Models;

namespace DapperMapping.Api.DataAcces.Repository
{
    public interface IContactsRepository
    {
        IEnumerable<Contacts> All();
    }
}
